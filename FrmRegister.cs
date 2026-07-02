using Microsoft.Data.SqlClient;

namespace 转一转校园二手物品交易系统
{
    public partial class FrmRegister : FrmBase
    {
        public FrmRegister()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Sys_images", "Backgrounds", "background_form.png"));
        }

        private void BtnSubmitClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_UserName.Text))
            {
                lbl_Tip.Text = "请输入用户名";
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_Pwd.Text))
            {
                lbl_Tip.Text = "请输入密码";
                return;
            }
            if (txt_Pwd.Text != txt_ConfirmPwd.Text)
            {
                lbl_Tip.Text = "两次密码输入不一致";
                return;
            }

            string checkSql = "SELECT COUNT(*) FROM users WHERE username=@u";
            SqlParameter[] checkPs = { new SqlParameter("@u", txt_UserName.Text.Trim()) };
            int exists = (int)SQLHelper.Scalar(checkSql, checkPs);
            if (exists > 0)
            {
                lbl_Tip.Text = "该用户名已被注册";
                return;
            }

            string email = txt_Email.Text.Trim();
            if (!string.IsNullOrEmpty(email) && !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lbl_Tip.Text = "邮箱格式不正确";
                return;
            }

            string sql = "INSERT INTO users (username, password, phone, email, role_id, created_time, status) VALUES (@u, @p, @ph, @em, 1, @ct, 'active')";
            SqlParameter[] ps = {
                new SqlParameter("@u", txt_UserName.Text.Trim()),
                new SqlParameter("@p", BCrypt.Net.BCrypt.HashPassword(txt_Pwd.Text)),
                new SqlParameter("@ph", string.IsNullOrEmpty(txt_Phone.Text) ? (object)DBNull.Value : txt_Phone.Text),
                new SqlParameter("@em", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email),
                new SqlParameter("@ct", DateTime.Now),
            };
            SQLHelper.Exec(sql, ps);

            ShowTip("注册成功，请登录！");
            this.Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
