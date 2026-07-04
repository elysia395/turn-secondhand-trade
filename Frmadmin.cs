using Microsoft.Data.SqlClient;
using System.Data;

namespace 转一转校园二手物品交易系统
{
    public partial class Frmadmin : FrmBase
    {
        public Frmadmin()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();

            string bg = Path.Combine(Application.StartupPath, "Sys_images", Program.BackgroundDir);
            tpGoodsAudit.BackgroundImage = Image.FromFile(Path.Combine(bg, "background_admin_goods.png"));
            tpUserManage.BackgroundImage = Image.FromFile(Path.Combine(bg, "background_admin_users.png"));
            tpOrderManage.BackgroundImage = Image.FromFile(Path.Combine(bg, "background_admin_orders.png"));
            tpStats.BackgroundImage = Image.FromFile(Path.Combine(bg, "background_admin_stats.png"));
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void Frmadmin_Load(object sender, EventArgs e)
        {
            if (Program.CurrentUserRole != "超级管理员" &&
                Program.CurrentUserRole != "商品管理员")
            {
                ShowError("无权限访问");
                this.Close();
                return;
            }

            dgv_Users.AutoGenerateColumns = false;
            dgv_AllOrders.AutoGenerateColumns = false;

            cbo_FilterStatus.Items.AddRange(new object[]
            {
                "全部", "待审核", "在售", "已拒绝", "已售"
            });
            cbo_FilterStatus.SelectedIndex = 1;

            cbo_FilterOrder.Items.Clear();
            cbo_FilterOrder.Items.AddRange(new object[]
            {
                "全部", "待收货", "已完成"
            });
            cbo_FilterOrder.SelectedIndex = 0;

            LoadGoods();
            LoadUsers();
            LoadOrders();
            LoadStats();

            if (Program.CurrentUserRole == "商品管理员")
            {
                tabAdmin.TabPages.Remove(tpUserManage);
                tabAdmin.TabPages.Remove(tpOrderManage);
                tabAdmin.TabPages.Remove(tpStats);
            }
            if (Program.CurrentUserRole != "超级管理员")
            {
                txt_Announcement.ReadOnly = true;
                btn_SaveAnnouncement.Enabled = false;
            }
        }

        private void LoadGoods()
        {
            string status = cbo_FilterStatus.Text;

            string sql = @"
SELECT 
    g.goods_id,
    g.title,
    g.price,
    u.username AS seller_name,
    g.status,
    g.created_time
FROM goods g
JOIN users u ON g.seller_id = u.user_id
WHERE (@s=N'全部' OR g.status=@s)
ORDER BY g.created_time DESC";

            dgv_GoodsAudit.DataSource = SQLHelper.Query(sql, new[]
            {
                new SqlParameter("@s", status)
            });
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadGoods();
        }

        private void dgv_GoodsAudit_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_GoodsAudit.CurrentRow == null) return;
            string status = dgv_GoodsAudit.CurrentRow.Cells["status"].Value?.ToString() ?? "";
            btn_Reject.Text = status == "在售" ? "撤回审核" : "拒绝";
        }

        private void btn_Approve_Click(object sender, EventArgs e)
        {
            ChangeStatus("在售", "商品已上架");
        }

        private void btn_Reject_Click(object sender, EventArgs e)
        {
            if (dgv_GoodsAudit.CurrentRow == null)
            {
                ShowError("请先选中一个商品");
                return;
            }

            string status = dgv_GoodsAudit.CurrentRow.Cells["status"].Value?.ToString() ?? "";

            if (status == "在售")
                ChangeStatus("待审核", "已撤回审核，商品恢复为待审核状态");
            else if (status == "待审核")
                ChangeStatus("已拒绝", "商品已拒绝");
            else
                ShowError("该商品状态不支持此操作");
        }

        private void ChangeStatus(string newStatus, string msg)
        {
            if (dgv_GoodsAudit.CurrentRow == null)
            {
                ShowError("请先选中一个商品");
                return;
            }

            if (!ShowConfirm($"确认要将该商品状态改为「{newStatus}」吗？"))
                return;

            int id = Convert.ToInt32(dgv_GoodsAudit.CurrentRow.Cells["goods_id"].Value);

            string sql = @"UPDATE goods 
SET status=@s, audit_admin_id=@aid, audit_time=GETDATE()
WHERE goods_id=@id";

            SQLHelper.Exec(sql, new[]
            {
                new SqlParameter("@s", newStatus),
                new SqlParameter("@aid", Program.CurrentUserId),
                new SqlParameter("@id", id)
            });

            ShowTip(msg);
            LoadGoods();
            LoadStats();
        }

        private void LoadUsers()
        {
            string key = txt_SearchUser.Text.Trim();

            string sql = @"
SELECT 
    u.user_id,
    u.username,
    u.phone,
    r.role_name,
    u.status,
    u.created_time
FROM users u
JOIN roles r ON u.role_id = r.role_id
WHERE (@k='' OR u.username LIKE N'%'+@k+N'%' OR u.phone LIKE N'%'+@k+N'%')
ORDER BY u.created_time DESC";

            dgv_Users.DataSource = SQLHelper.Query(sql, new[]
            {
                new SqlParameter("@k", key)
            });
        }

        private void btn_SearchUser_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btn_DisableUser_Click(object sender, EventArgs e)
        {
            if (dgv_Users.CurrentRow == null)
            {
                ShowError("请先选择一个用户");
                return;
            }

            int userId = Convert.ToInt32(dgv_Users.CurrentRow.Cells["col_user_id"].Value);
            string roleName = dgv_Users.CurrentRow.Cells["col_role_name"].Value?.ToString() ?? "";
            string status = dgv_Users.CurrentRow.Cells["col_user_status"].Value?.ToString() ?? "";

            if (userId == Program.CurrentUserId)
            {
                ShowError("不能禁用自己");
                return;
            }

            if (roleName == "超级管理员")
            {
                ShowError("不能禁用超级管理员");
                return;
            }

            string newStatus = status == "active" ? "disabled" : "active";
            string action = newStatus == "disabled" ? "禁用" : "解禁";

            if (!ShowConfirm($"确认要{action}该用户吗？"))
                return;

            SQLHelper.Exec(
                "UPDATE users SET status=@status WHERE user_id=@id",
                new[]
                {
                    new SqlParameter("@status", newStatus),
                    new SqlParameter("@id", userId)
                });

            ShowTip("操作成功");
            LoadUsers();
        }

        private void LoadOrders()
        {
            string status = cbo_FilterOrder.Text;

            string sql = @"
SELECT 
    o.order_id,
    g.title AS goods_title,
    g.price AS goods_price,
    b.username AS buyer_name,
    s.username AS seller_name,
    o.order_status,
    o.order_time,
    o.complete_time
FROM orders o
JOIN goods g ON o.goods_id = g.goods_id
JOIN users b ON o.buyer_id = b.user_id
JOIN users s ON o.seller_id = s.user_id
WHERE (@s=N'全部' OR o.order_status=@s)
ORDER BY o.order_time DESC";

            dgv_AllOrders.DataSource = SQLHelper.Query(sql, new[]
            {
                new SqlParameter("@s", status)
            });
        }

        private void btn_RefreshOrder_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btn_MarkComplete_Click(object sender, EventArgs e)
        {
            if (dgv_AllOrders.CurrentRow == null)
            {
                ShowError("请先选择订单");
                return;
            }

            string orderStatus = dgv_AllOrders.CurrentRow.Cells["col_order_status"].Value?.ToString() ?? "";

            if (orderStatus != "待收货")
            {
                ShowError(orderStatus == "已完成" ? "该订单已经完成" : "仅待收货订单可标记完成");
                return;
            }

            if (!ShowConfirm("确认标记该订单为已完成吗？"))
                return;

            int orderId = Convert.ToInt32(dgv_AllOrders.CurrentRow.Cells["col_order_id"].Value);

            SQLHelper.Exec(
                @"UPDATE orders 
          SET order_status=N'已完成', complete_time=GETDATE()
          WHERE order_id=@id",
                new[]
                {
                    new SqlParameter("@id", orderId)
                });

            ShowTip("订单已处理完成");
            LoadOrders();
            LoadStats();
        }

        private void LoadStats()
        {
            string sql = @"
SELECT
  (SELECT COUNT(*) FROM users WHERE status='active') AS user_count,
  (SELECT COUNT(*) FROM users u JOIN roles r ON u.role_id=r.role_id 
   WHERE r.role_name IN (N'超级管理员', N'商品管理员')) AS admin_count,
  (SELECT COUNT(*) FROM goods) AS goods_count,
  (SELECT COUNT(*) FROM goods WHERE status=N'在售') AS onsale_count,
  (SELECT COUNT(*) FROM goods WHERE status=N'待审核') AS pending_count,
  (SELECT COUNT(*) FROM orders) AS order_count,
  (SELECT COUNT(*) FROM orders WHERE order_status=N'待收货') AS shipping_count,
  (SELECT COUNT(*) FROM orders WHERE order_status=N'已完成') AS completed_count";

            DataTable dt = SQLHelper.Query(sql);
            if (dt.Rows.Count == 0) return;

            DataRow r = dt.Rows[0];

            lbl_UserCount.Text = "注册用户数：" + r["user_count"];
            lbl_AdminCount.Text = "管理员数：" + r["admin_count"];
            lbl_GoodsCount.Text = "商品总数：" + r["goods_count"];
            lbl_OnSaleCount.Text = "在售商品：" + r["onsale_count"];
            lbl_PendingCount.Text = "待审核商品：" + r["pending_count"];
            lbl_OrderCount.Text = "订单总数：" + r["order_count"];
            lbl_ShippingCount.Text = "待收货订单：" + r["shipping_count"];
            lbl_CompletedCount.Text = "已完成订单：" + r["completed_count"];
        }

        private void btn_RefreshStats_Click(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void btn_SaveAnnouncement_Click(object sender, EventArgs e)
        {
            if (Program.CurrentUserRole != "超级管理员")
            {
                ShowError("只有超级管理员可以发布公告");
                return;
            }

            string content = txt_Announcement.Text.Trim();
            if (content == "")
            {
                ShowError("公告内容不能为空");
                return;
            }

            if (!ShowConfirm("确认发布此公告吗？"))
                return;

            string sql = @"
INSERT INTO announcements(content, creator_id, created_time)
VALUES(@content, @uid, GETDATE())";

            SQLHelper.Exec(sql, new[]
            {
                new SqlParameter("@content", content),
                new SqlParameter("@uid", Program.CurrentUserId)
            });

            ShowTip("公告发布成功");
            txt_Announcement.Clear();
        }

        private void cbo_FilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGoods();
        }

        private void cbo_FilterOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void tpGoodsAudit_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_Announcement_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
