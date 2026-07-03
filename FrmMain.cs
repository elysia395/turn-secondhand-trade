using System.Data;
using System.Drawing.Drawing2D;
using Microsoft.Data.SqlClient;

namespace 转一转校园二手物品交易系统
{
    public partial class FrmMain : FrmBase
    {
        private Form? currentForm = null;

        public FrmMain()
        {
            InitializeComponent();
            string bgDir = Path.Combine(Application.StartupPath, "Sys_images", Program.BackgroundDir);
            pnl_Menu.BackgroundImage = Image.FromFile(Path.Combine(bgDir, "background_menu.png"));
            pnl_Content.BackgroundImage = Image.FromFile(Path.Combine(bgDir, "background_main.jpg"));
        }

        private void FrmMainLoad(object sender, EventArgs e)
        {
            Text = "二手交易系统 - " + Program.CurrentUserName;
            btn_admin.Visible = Program.CurrentUserRole == "超级管理员"
                || Program.CurrentUserRole == "商品管理员";

            LoadAnnouncement();
        }

        private void LoadAnnouncement()
        {
            panel1.Controls.Clear();

            string sql = @"SELECT TOP 1 content FROM announcements ORDER BY created_time DESC";
            DataTable dt = SQLHelper.Query(sql);

            string text = dt.Rows.Count > 0 && dt.Rows[0]["content"] != DBNull.Value
                ? "📢 " + dt.Rows[0]["content"].ToString().Replace("\\n", Environment.NewLine)
                : "暂无公告";

            Label lbl = new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("微软雅黑", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(70, 130, 180),
                BackColor = Color.Transparent,
                AutoSize = false,
            };

            panel1.Controls.Add(lbl);
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentForm != null)
            {
                pnl_Content.Controls.Remove(currentForm);
                currentForm.Dispose();
            }

            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnl_Content.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void BtnGoodsListClick(object sender, EventArgs e)
        {
            OpenChildForm(new FrmGoodslist());
        }

        private void BtnPublishClick(object sender, EventArgs e)
        {
            OpenChildForm(new FrmPublishGoods());
        }

        private void BtnMyOrderClick(object sender, EventArgs e)
        {
            OpenChildForm(new FrmMyOrder());
        }

        private void BtnLogoutClick(object sender, EventArgs e)
        {
            Program.CurrentUserId = 0;
            Program.CurrentUserName = "";
            Program.CurrentUserRole = "";
            this.Close();
        }

        private void pnl_Content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            if (Program.CurrentUserRole != "超级管理员" &&
                Program.CurrentUserRole != "商品管理员")
            {
                ShowError("无权限访问");
                return;
            }
            OpenChildForm(new Frmadmin());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = panel1.ClientRectangle;
            int r = 12;

            using (var path = GetRoundedRect(rect, r))
            {
                using (var brush = new LinearGradientBrush(
                    rect,
                    Color.FromArgb(240, 248, 255),
                    Color.FromArgb(176, 224, 230),
                    LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, path);
                }

                using (var pen = new Pen(Color.FromArgb(70, 130, 180), 2))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private static GraphicsPath GetRoundedRect(Rectangle rect, int r)
        {
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r - 1, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r - 1, rect.Bottom - r - 1, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r - 1, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
