namespace 转一转校园二手物品交易系统
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lbl_Title = new Label();
            lbl_Pwd = new Label();
            lbl_UserName = new Label();
            txt_UserName = new TextBox();
            txt_Pwd = new TextBox();
            btn_Login = new Button();
            btn_Register = new Button();
            link_ForgotPwd = new LinkLabel();
            LoginPanel = new Panel();
            LoginPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.Anchor = AnchorStyles.None;
            lbl_Title.AutoSize = true;
            lbl_Title.BackColor = SystemColors.ControlLightLight;
            lbl_Title.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lbl_Title.Location = new Point(100, 18);
            lbl_Title.Margin = new Padding(5, 0, 5, 0);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(360, 40);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "二手物品交易系统·登录页";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Pwd
            // 
            lbl_Pwd.Anchor = AnchorStyles.None;
            lbl_Pwd.AutoSize = true;
            lbl_Pwd.BackColor = SystemColors.ButtonHighlight;
            lbl_Pwd.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lbl_Pwd.Location = new Point(93, 141);
            lbl_Pwd.Margin = new Padding(5, 0, 5, 0);
            lbl_Pwd.Name = "lbl_Pwd";
            lbl_Pwd.Size = new Size(75, 28);
            lbl_Pwd.TabIndex = 1;
            lbl_Pwd.Text = "密码：";
            lbl_Pwd.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_UserName
            // 
            lbl_UserName.Anchor = AnchorStyles.None;
            lbl_UserName.AutoSize = true;
            lbl_UserName.BackColor = SystemColors.ControlLightLight;
            lbl_UserName.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lbl_UserName.Location = new Point(72, 91);
            lbl_UserName.Margin = new Padding(5, 0, 5, 0);
            lbl_UserName.Name = "lbl_UserName";
            lbl_UserName.Size = new Size(96, 28);
            lbl_UserName.TabIndex = 2;
            lbl_UserName.Text = "用户名：";
            lbl_UserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_UserName
            // 
            txt_UserName.Anchor = AnchorStyles.None;
            txt_UserName.Location = new Point(178, 89);
            txt_UserName.Margin = new Padding(5, 4, 5, 4);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Size = new Size(312, 30);
            txt_UserName.TabIndex = 3;
            // 
            // txt_Pwd
            // 
            txt_Pwd.Anchor = AnchorStyles.None;
            txt_Pwd.Location = new Point(178, 141);
            txt_Pwd.Margin = new Padding(5, 4, 5, 4);
            txt_Pwd.Name = "txt_Pwd";
            txt_Pwd.PasswordChar = '*';
            txt_Pwd.Size = new Size(312, 30);
            txt_Pwd.TabIndex = 4;
            txt_Pwd.KeyDown += txt_Pwd_KeyDown;
            // 
            // btn_Login
            // 
            btn_Login.Anchor = AnchorStyles.None;
            btn_Login.BackColor = SystemColors.Highlight;
            btn_Login.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btn_Login.Location = new Point(125, 242);
            btn_Login.Margin = new Padding(5, 4, 5, 4);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(126, 42);
            btn_Login.TabIndex = 5;
            btn_Login.Text = "登录";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += BtnLoginClick;
            // 
            // btn_Register
            // 
            btn_Register.Anchor = AnchorStyles.None;
            btn_Register.BackColor = SystemColors.Highlight;
            btn_Register.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btn_Register.Location = new Point(310, 242);
            btn_Register.Margin = new Padding(5, 4, 5, 4);
            btn_Register.Name = "btn_Register";
            btn_Register.Size = new Size(126, 42);
            btn_Register.TabIndex = 6;
            btn_Register.Text = "注册账号";
            btn_Register.UseVisualStyleBackColor = false;
            btn_Register.Click += BtnRegisterClick;
            // 
            // link_ForgotPwd
            // 
            link_ForgotPwd.ActiveLinkColor = Color.Red;
            link_ForgotPwd.AutoSize = true;
            link_ForgotPwd.BackColor = SystemColors.ButtonHighlight;
            link_ForgotPwd.DisabledLinkColor = Color.Gray;
            link_ForgotPwd.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            link_ForgotPwd.LinkColor = Color.IndianRed;
            link_ForgotPwd.Location = new Point(229, 196);
            link_ForgotPwd.Name = "link_ForgotPwd";
            link_ForgotPwd.Size = new Size(102, 25);
            link_ForgotPwd.TabIndex = 7;
            link_ForgotPwd.TabStop = true;
            link_ForgotPwd.Text = "忘记密码？";
            link_ForgotPwd.VisitedLinkColor = Color.Gray;
            link_ForgotPwd.LinkClicked += link_ForgotPwd_LinkClicked;
            // 
            // LoginPanel
            // 
            LoginPanel.BackColor = SystemColors.ButtonFace;
            LoginPanel.Controls.Add(lbl_UserName);
            LoginPanel.Controls.Add(lbl_Title);
            LoginPanel.Controls.Add(link_ForgotPwd);
            LoginPanel.Controls.Add(btn_Register);
            LoginPanel.Controls.Add(lbl_Pwd);
            LoginPanel.Controls.Add(btn_Login);
            LoginPanel.Controls.Add(txt_UserName);
            LoginPanel.Controls.Add(txt_Pwd);
            LoginPanel.Location = new Point(309, 263);
            LoginPanel.Name = "LoginPanel";
            LoginPanel.Size = new Size(560, 299);
            LoginPanel.TabIndex = 8;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1178, 744);
            Controls.Add(LoginPanel);
            DoubleBuffered = true;
            Margin = new Padding(5, 4, 5, 4);
            Name = "FrmLogin";
            Text = "登录界面";
            LoginPanel.ResumeLayout(false);
            LoginPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_Title;
        private Label lbl_Pwd;
        private Label lbl_UserName;
        private TextBox txt_UserName;
        private TextBox txt_Pwd;
        private Button btn_Login;
        private Button btn_Register;
        private LinkLabel link_ForgotPwd;
        private Panel LoginPanel;
    }
}
