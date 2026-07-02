using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace 转一转校园二手物品交易系统
{
    public class SQLHelper
    {
        private static readonly string connStr =
            ConfigurationManager.ConnectionStrings["SecondHandDB"].ConnectionString;

        public static DataTable Query(string sql, SqlParameter[]? ps = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ps != null)
                        cmd.Parameters.AddRange(ps);
                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }

        public static int Exec(string sql, SqlParameter[]? ps = null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ps != null)
                        cmd.Parameters.AddRange(ps);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object Scalar(string sql, SqlParameter[]? ps = null)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ps != null)
                        cmd.Parameters.AddRange(ps);
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static (bool success, string msg) TryPlaceOrder(int goodsId, int buyerId, int sellerId)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand(
                            @"SELECT COUNT(1) FROM orders WHERE goods_id=@goodsId",
                            conn, tran);
                        cmd.Parameters.AddWithValue("@goodsId", goodsId);
                        if ((int)cmd.ExecuteScalar() > 0)
                            return (false, "该商品已有订单，无法重复下单");

                        cmd = new SqlCommand(
                            @"SELECT status FROM goods WITH (UPDLOCK) WHERE goods_id=@goodsId",
                            conn, tran);
                        cmd.Parameters.AddWithValue("@goodsId", goodsId);
                        string? status = cmd.ExecuteScalar()?.ToString();
                        if (status != "在售")
                            return (false, "商品已被其他人先下单了");

                        cmd.CommandText = "SELECT price FROM goods WHERE goods_id=@goodsId";
                        decimal price = (decimal)cmd.ExecuteScalar();

                        cmd.CommandText = "INSERT INTO orders (goods_id, buyer_id, seller_id, order_status, shipping_address, deal_price) VALUES (@goodsId, @buyerId, @sellerId, '待付款',  '', @dealPrice)";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@goodsId", goodsId);
                        cmd.Parameters.AddWithValue("@buyerId", buyerId);
                        cmd.Parameters.AddWithValue("@sellerId", sellerId);
                        cmd.Parameters.AddWithValue("@dealPrice", price);
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "UPDATE goods SET status='已售' WHERE goods_id=@goodsId";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@goodsId", goodsId);
                        cmd.ExecuteNonQuery();

                        tran.Commit();
                        return (true, "下单成功！请在「我的订单」中查看");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        return (false, "下单失败：" + ex.Message);
                    }
                }
            }
        }
    }
}
