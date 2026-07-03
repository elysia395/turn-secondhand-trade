using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 转一转校园二手物品交易系统
{
    public partial class FrmMyOrder : Form
    {
        public FrmMyOrder()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Sys_images", Program.BackgroundDir, "background_form.png"));
            this.DoubleBuffered = true;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (dgv_Order.CurrentRow == null)
            {
                MessageBox.Show("请选中一个订单");
                return;
            }

            string status = dgv_Order.CurrentRow.Cells["ColStatus"].Value.ToString();
            int orderId = Convert.ToInt32(dgv_Order.CurrentRow.Cells["ColId"].Value);

            if (rdo_Seller.Checked)
            {
                // 卖家确认付款：待付款 → 待收货
                if (status != "待付款")
                {
                    MessageBox.Show("只有「待付款」状态的订单才能确认收款");
                    return;
                }
                SQLHelper.Exec("UPDATE orders SET order_status='待收货' WHERE order_id=@id",
                    new[] { new SqlParameter("@id", orderId) });
                MessageBox.Show("已确认收款，等待买家确认收货");
            }
            else
            {
                // 买家确认收货：待收货 → 已完成
                if (status != "待收货")
                {
                    MessageBox.Show("只有「待收货」状态的订单才能确认收货");
                    return;
                }
                SQLHelper.Exec("UPDATE orders SET order_status='已完成', complete_time=GETDATE() WHERE order_id=@id",
                    new[] { new SqlParameter("@id", orderId) });
                MessageBox.Show("确认收货成功！订单已完成。");
            }
            LoadOrders();
        }

        private void btn_ModifyPrice_Click(object sender, EventArgs e)
        {
            if (dgv_Order.CurrentRow == null)
            {
                MessageBox.Show("请选中一个订单");
                return;
            }

            string status = dgv_Order.CurrentRow.Cells["ColStatus"].Value.ToString();
            if (status != "待付款")
            {
                MessageBox.Show("只有「待付款」状态的订单才能修改价格");
                return;
            }

            int orderId = Convert.ToInt32(dgv_Order.CurrentRow.Cells["ColId"].Value);
            decimal currentDealPrice = Convert.ToDecimal(dgv_Order.CurrentRow.Cells["ColDealPrice"].Value);

            // 弹出输入框让卖家输入新价格
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "请输入新的成交价：", "修改价格", currentDealPrice.ToString("F2"), -1, -1);

            if (string.IsNullOrWhiteSpace(input))
                return;

            if (!decimal.TryParse(input, out decimal newPrice) || newPrice <= 0)
            {
                MessageBox.Show("请输入有效的正数价格");
                return;
            }

            SQLHelper.Exec("UPDATE orders SET deal_price=@price WHERE order_id=@id",
                new SqlParameter[]
                {
                    new SqlParameter("@price", newPrice),
                    new SqlParameter("@id", orderId)
                });
            MessageBox.Show($"价格已修改为 {newPrice:F2} 元");
            LoadOrders();
        }

        private void rdo_Buyer_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonVisibility();
            LoadOrders();
        }

        private void rdo_Seller_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonVisibility();
            LoadOrders();
        }

        private void UpdateButtonVisibility()
        {
            if (rdo_Seller.Checked)
            {
                // 卖家视图：显示两个按钮
                btn_Confirm.Text = "确认收款";
                btn_Confirm.Visible = true;
                btn_ModifyPrice.Visible = true;
            }
            else
            {
                // 买家视图：只显示确认收货
                btn_Confirm.Text = "确认收货";
                btn_Confirm.Visible = true;
                btn_ModifyPrice.Visible = false;
            }
        }

        private void btn_ModifyAddress_Click(object sender, EventArgs e)
        {
            if (dgv_Order.CurrentRow == null)
            {
                MessageBox.Show("请选中一个订单");
                return;
            }

            string status = dgv_Order.CurrentRow.Cells["ColStatus"].Value.ToString();
            if (status == "已完成" || status == "已退款")
            {
                MessageBox.Show("该订单已完成，无法修改地址");
                return;
            }

            int orderId = Convert.ToInt32(dgv_Order.CurrentRow.Cells["ColId"].Value);
            string currentAddress = dgv_Order.CurrentRow.Cells["ColAddress"]?.Value?.ToString() ?? "";

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "请输入新的收货地址：", "修改地址", currentAddress, -1, -1);

            if (string.IsNullOrWhiteSpace(input))
                return;

            SQLHelper.Exec("UPDATE orders SET shipping_address=@addr WHERE order_id=@id",
                new SqlParameter[]
                {
                    new SqlParameter("@addr", input.Trim()),
                    new SqlParameter("@id", orderId)
                });
            MessageBox.Show("收货地址已更新");
            LoadOrders();
        }

        private void FrmMyOrder_Load(object sender, EventArgs e)
        {
            rdo_Buyer.Checked = true;
            UpdateButtonVisibility();
            BeginInvoke(() => LoadOrders());
        }

        private void LoadOrders()
        {
            string field = rdo_Buyer.Checked ? "o.buyer_id" : "o.seller_id";
            lbl_Tip.Text = rdo_Buyer.Checked ? "当前显示：我买的订单" : "当前显示：我卖的订单";
            ColBuyer.HeaderText = rdo_Buyer.Checked ? "卖家" : "买家";
            ColBuyer.DataPropertyName = rdo_Buyer.Checked ? "seller_name" : "buyer_name";

            string sql = @"
    SELECT o.order_id, o.order_status, o.order_time,
           g.title AS goods_title, g.price AS goods_price,
           o.deal_price,
           b.username AS buyer_name, s.username AS seller_name
    FROM orders o
    JOIN goods g ON o.goods_id = g.goods_id
    JOIN users b ON o.buyer_id = b.user_id
    JOIN users s ON o.seller_id = s.user_id
    WHERE " + field + @" = @uid
    ORDER BY o.order_time DESC";
            SqlParameter[] ps = { new SqlParameter("@uid", Program.CurrentUserId) };
            dgv_Order.AutoGenerateColumns = false;
            dgv_Order.DataSource = SQLHelper.Query(sql, ps);
        }

        private void lbl_Tip_Click(object sender, EventArgs e)
        {

        }
    }
}
