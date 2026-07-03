namespace 转一转校园二手物品交易系统
{
    partial class Frmadmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmadmin));
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            tabAdmin = new TabControl();
            tpGoodsAudit = new TabPage();
            btn_Reject = new Button();
            btn_Approve = new Button();
            btn_Refresh = new Button();
            cbo_FilterStatus = new ComboBox();
            lbl_Filter = new Label();
            dgv_GoodsAudit = new DataGridView();
            tpUserManage = new TabPage();
            txt_SearchUser = new TextBox();
            dgv_Users = new DataGridView();
            col_user_id = new DataGridViewTextBoxColumn();
            col_username = new DataGridViewTextBoxColumn();
            col_phone = new DataGridViewTextBoxColumn();
            col_role_name = new DataGridViewTextBoxColumn();
            col_user_status = new DataGridViewTextBoxColumn();
            col_created_time = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btn_DisableUser = new Button();
            btn_SearchUser = new Button();
            tpOrderManage = new TabPage();
            label2 = new Label();
            dgv_AllOrders = new DataGridView();
            col_order_id = new DataGridViewTextBoxColumn();
            col_goods_title = new DataGridViewTextBoxColumn();
            col_buyer_name = new DataGridViewTextBoxColumn();
            col_seller_name = new DataGridViewTextBoxColumn();
            col_goods_price = new DataGridViewTextBoxColumn();
            col_order_status = new DataGridViewTextBoxColumn();
            col_order_time = new DataGridViewTextBoxColumn();
            col_complete_time = new DataGridViewTextBoxColumn();
            cbo_FilterOrder = new ComboBox();
            btn_MarkComplete = new Button();
            btn_RefreshOrder = new Button();
            tpStats = new TabPage();
            txt_Announcement = new TextBox();
            btn_SaveAnnouncement = new Button();
            grp_Stats = new GroupBox();
            lbl_CompletedCount = new Label();
            lbl_ShippingCount = new Label();
            lbl_OrderCount = new Label();
            lbl_PendingCount = new Label();
            lbl_OnSaleCount = new Label();
            lbl_GoodsCount = new Label();
            lbl_AdminCount = new Label();
            lbl_UserCount = new Label();
            btn_RefreshStats = new Button();
            tabAdmin.SuspendLayout();
            tpGoodsAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_GoodsAudit).BeginInit();
            tpUserManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Users).BeginInit();
            tpOrderManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_AllOrders).BeginInit();
            tpStats.SuspendLayout();
            grp_Stats.SuspendLayout();
            SuspendLayout();
            // 
            // tabAdmin
            // 
            tabAdmin.Controls.Add(tpGoodsAudit);
            tabAdmin.Controls.Add(tpUserManage);
            tabAdmin.Controls.Add(tpOrderManage);
            tabAdmin.Controls.Add(tpStats);
            tabAdmin.Dock = DockStyle.Fill;
            tabAdmin.Location = new Point(0, 0);
            tabAdmin.Margin = new Padding(2, 1, 2, 1);
            tabAdmin.Name = "tabAdmin";
            tabAdmin.SelectedIndex = 0;
            tabAdmin.Size = new Size(842, 744);
            tabAdmin.TabIndex = 6;
            // 
            // tpGoodsAudit
            // 
            tpGoodsAudit.BackgroundImage = (Image)resources.GetObject("tpGoodsAudit.BackgroundImage");
            tpGoodsAudit.BackgroundImageLayout = ImageLayout.Stretch;
            tpGoodsAudit.Controls.Add(btn_Reject);
            tpGoodsAudit.Controls.Add(btn_Approve);
            tpGoodsAudit.Controls.Add(btn_Refresh);
            tpGoodsAudit.Controls.Add(cbo_FilterStatus);
            tpGoodsAudit.Controls.Add(lbl_Filter);
            tpGoodsAudit.Controls.Add(dgv_GoodsAudit);
            tpGoodsAudit.Location = new Point(4, 33);
            tpGoodsAudit.Margin = new Padding(2, 1, 2, 1);
            tpGoodsAudit.Name = "tpGoodsAudit";
            tpGoodsAudit.Padding = new Padding(2, 1, 2, 1);
            tpGoodsAudit.Size = new Size(834, 707);
            tpGoodsAudit.TabIndex = 0;
            tpGoodsAudit.Text = "商品审核";
            tpGoodsAudit.UseVisualStyleBackColor = true;
            // 
            // btn_Reject
            // 
            btn_Reject.ForeColor = Color.Red;
            btn_Reject.Location = new Point(523, 433);
            btn_Reject.Margin = new Padding(2, 1, 2, 1);
            btn_Reject.Name = "btn_Reject";
            btn_Reject.Size = new Size(102, 34);
            btn_Reject.TabIndex = 8;
            btn_Reject.Text = "拒绝";
            btn_Reject.UseVisualStyleBackColor = true;
            btn_Reject.Click += btn_Reject_Click;
            // 
            // btn_Approve
            // 
            btn_Approve.BackColor = Color.LightGreen;
            btn_Approve.Location = new Point(207, 433);
            btn_Approve.Margin = new Padding(2, 1, 2, 1);
            btn_Approve.Name = "btn_Approve";
            btn_Approve.Size = new Size(102, 34);
            btn_Approve.TabIndex = 7;
            btn_Approve.Text = "审核通过";
            btn_Approve.UseVisualStyleBackColor = false;
            btn_Approve.Click += btn_Approve_Click;
            // 
            // btn_Refresh
            // 
            btn_Refresh.Location = new Point(501, 61);
            btn_Refresh.Margin = new Padding(2, 1, 2, 1);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(63, 32);
            btn_Refresh.TabIndex = 6;
            btn_Refresh.Text = "刷新";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // cbo_FilterStatus
            // 
            cbo_FilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_FilterStatus.FormattingEnabled = true;
            cbo_FilterStatus.Location = new Point(330, 58);
            cbo_FilterStatus.Margin = new Padding(2, 1, 2, 1);
            cbo_FilterStatus.Name = "cbo_FilterStatus";
            cbo_FilterStatus.Size = new Size(164, 32);
            cbo_FilterStatus.TabIndex = 5;
            cbo_FilterStatus.SelectedIndexChanged += cbo_FilterStatus_SelectedIndexChanged;
            // 
            // lbl_Filter
            // 
            lbl_Filter.AutoSize = true;
            lbl_Filter.BackColor = Color.Transparent;
            lbl_Filter.Location = new Point(270, 65);
            lbl_Filter.Name = "lbl_Filter";
            lbl_Filter.Size = new Size(64, 24);
            lbl_Filter.TabIndex = 4;
            lbl_Filter.Text = "状态：";
            // 
            // dgv_GoodsAudit
            // 
            dgv_GoodsAudit.AllowUserToAddRows = false;
            dgv_GoodsAudit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_GoodsAudit.BackgroundColor = Color.LightBlue;
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = SystemColors.Control;
            dataGridViewCellStyle19.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle19.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgv_GoodsAudit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgv_GoodsAudit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = SystemColors.Window;
            dataGridViewCellStyle20.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle20.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = DataGridViewTriState.False;
            dgv_GoodsAudit.DefaultCellStyle = dataGridViewCellStyle20;
            dgv_GoodsAudit.Location = new Point(0, 99);
            dgv_GoodsAudit.Margin = new Padding(2, 1, 2, 1);
            dgv_GoodsAudit.MultiSelect = false;
            dgv_GoodsAudit.Name = "dgv_GoodsAudit";
            dgv_GoodsAudit.ReadOnly = true;
            dgv_GoodsAudit.RowHeadersWidth = 72;
            dgv_GoodsAudit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_GoodsAudit.Size = new Size(853, 319);
            dgv_GoodsAudit.TabIndex = 1;
            // 
            // tpUserManage
            // 
            tpUserManage.BackgroundImage = (Image)resources.GetObject("tpUserManage.BackgroundImage");
            tpUserManage.BackgroundImageLayout = ImageLayout.Stretch;
            tpUserManage.Controls.Add(txt_SearchUser);
            tpUserManage.Controls.Add(dgv_Users);
            tpUserManage.Controls.Add(label1);
            tpUserManage.Controls.Add(btn_DisableUser);
            tpUserManage.Controls.Add(btn_SearchUser);
            tpUserManage.Location = new Point(4, 33);
            tpUserManage.Margin = new Padding(2, 1, 2, 1);
            tpUserManage.Name = "tpUserManage";
            tpUserManage.Padding = new Padding(2, 1, 2, 1);
            tpUserManage.Size = new Size(834, 707);
            tpUserManage.TabIndex = 1;
            tpUserManage.Text = "用户管理";
            tpUserManage.UseVisualStyleBackColor = true;
            // 
            // txt_SearchUser
            // 
            txt_SearchUser.Location = new Point(361, 73);
            txt_SearchUser.Margin = new Padding(2, 1, 2, 1);
            txt_SearchUser.Name = "txt_SearchUser";
            txt_SearchUser.Size = new Size(196, 30);
            txt_SearchUser.TabIndex = 4;
            // 
            // dgv_Users
            // 
            dgv_Users.AllowUserToAddRows = false;
            dgv_Users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Users.BackgroundColor = Color.LightBlue;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = SystemColors.Control;
            dataGridViewCellStyle21.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle21.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            dgv_Users.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            dgv_Users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Users.Columns.AddRange(new DataGridViewColumn[] { col_user_id, col_username, col_phone, col_role_name, col_user_status, col_created_time });
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = SystemColors.Window;
            dataGridViewCellStyle22.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle22.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = DataGridViewTriState.False;
            dgv_Users.DefaultCellStyle = dataGridViewCellStyle22;
            dgv_Users.Location = new Point(0, 112);
            dgv_Users.Margin = new Padding(2, 1, 2, 1);
            dgv_Users.Name = "dgv_Users";
            dgv_Users.ReadOnly = true;
            dgv_Users.RowHeadersWidth = 72;
            dgv_Users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Users.Size = new Size(858, 308);
            dgv_Users.TabIndex = 3;
            dgv_Users.CellContentClick += dgv_Users_CellContentClick;
            // 
            // col_user_id
            // 
            col_user_id.DataPropertyName = "user_id";
            col_user_id.HeaderText = "ID";
            col_user_id.MinimumWidth = 9;
            col_user_id.Name = "col_user_id";
            col_user_id.ReadOnly = true;
            // 
            // col_username
            // 
            col_username.DataPropertyName = "username";
            col_username.HeaderText = "用户名";
            col_username.MinimumWidth = 9;
            col_username.Name = "col_username";
            col_username.ReadOnly = true;
            // 
            // col_phone
            // 
            col_phone.DataPropertyName = "phone";
            col_phone.HeaderText = "手机号";
            col_phone.MinimumWidth = 9;
            col_phone.Name = "col_phone";
            col_phone.ReadOnly = true;
            // 
            // col_role_name
            // 
            col_role_name.DataPropertyName = "role_name";
            col_role_name.HeaderText = "角色";
            col_role_name.MinimumWidth = 9;
            col_role_name.Name = "col_role_name";
            col_role_name.ReadOnly = true;
            // 
            // col_user_status
            // 
            col_user_status.DataPropertyName = "status";
            col_user_status.HeaderText = "状态";
            col_user_status.MinimumWidth = 9;
            col_user_status.Name = "col_user_status";
            col_user_status.ReadOnly = true;
            // 
            // col_created_time
            // 
            col_created_time.DataPropertyName = "created_time";
            col_created_time.HeaderText = "注册时间";
            col_created_time.MinimumWidth = 9;
            col_created_time.Name = "col_created_time";
            col_created_time.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(305, 78);
            label1.Name = "label1";
            label1.Size = new Size(64, 24);
            label1.TabIndex = 2;
            label1.Text = "搜索：";
            // 
            // btn_DisableUser
            // 
            btn_DisableUser.Location = new Point(342, 422);
            btn_DisableUser.Margin = new Padding(2, 1, 2, 1);
            btn_DisableUser.Name = "btn_DisableUser";
            btn_DisableUser.Size = new Size(151, 48);
            btn_DisableUser.TabIndex = 1;
            btn_DisableUser.Text = "禁用/解禁";
            btn_DisableUser.UseVisualStyleBackColor = true;
            btn_DisableUser.Click += btn_DisableUser_Click;
            // 
            // btn_SearchUser
            // 
            btn_SearchUser.Location = new Point(581, 72);
            btn_SearchUser.Margin = new Padding(2, 1, 2, 1);
            btn_SearchUser.Name = "btn_SearchUser";
            btn_SearchUser.Size = new Size(68, 34);
            btn_SearchUser.TabIndex = 0;
            btn_SearchUser.Text = "搜索";
            btn_SearchUser.UseVisualStyleBackColor = true;
            btn_SearchUser.Click += btn_SearchUser_Click;
            // 
            // tpOrderManage
            // 
            tpOrderManage.BackgroundImage = (Image)resources.GetObject("tpOrderManage.BackgroundImage");
            tpOrderManage.BackgroundImageLayout = ImageLayout.Stretch;
            tpOrderManage.Controls.Add(label2);
            tpOrderManage.Controls.Add(dgv_AllOrders);
            tpOrderManage.Controls.Add(cbo_FilterOrder);
            tpOrderManage.Controls.Add(btn_MarkComplete);
            tpOrderManage.Controls.Add(btn_RefreshOrder);
            tpOrderManage.Location = new Point(4, 33);
            tpOrderManage.Margin = new Padding(2, 1, 2, 1);
            tpOrderManage.Name = "tpOrderManage";
            tpOrderManage.Padding = new Padding(2, 1, 2, 1);
            tpOrderManage.Size = new Size(834, 707);
            tpOrderManage.TabIndex = 2;
            tpOrderManage.Text = "订单纠纷处理";
            tpOrderManage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(253, 76);
            label2.Name = "label2";
            label2.Size = new Size(64, 24);
            label2.TabIndex = 4;
            label2.Text = "状态：";
            // 
            // dgv_AllOrders
            // 
            dgv_AllOrders.AllowUserToAddRows = false;
            dgv_AllOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_AllOrders.BackgroundColor = Color.LightBlue;
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = SystemColors.Control;
            dataGridViewCellStyle23.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle23.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.True;
            dgv_AllOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            dgv_AllOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_AllOrders.Columns.AddRange(new DataGridViewColumn[] { col_order_id, col_goods_title, col_buyer_name, col_seller_name, col_goods_price, col_order_status, col_order_time, col_complete_time });
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = SystemColors.Window;
            dataGridViewCellStyle24.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle24.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = DataGridViewTriState.False;
            dgv_AllOrders.DefaultCellStyle = dataGridViewCellStyle24;
            dgv_AllOrders.Location = new Point(3, 124);
            dgv_AllOrders.Margin = new Padding(2, 1, 2, 1);
            dgv_AllOrders.Name = "dgv_AllOrders";
            dgv_AllOrders.ReadOnly = true;
            dgv_AllOrders.RowHeadersWidth = 72;
            dgv_AllOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_AllOrders.Size = new Size(856, 337);
            dgv_AllOrders.TabIndex = 3;
            // 
            // col_order_id
            // 
            col_order_id.DataPropertyName = "order_id";
            col_order_id.HeaderText = "ID";
            col_order_id.MinimumWidth = 9;
            col_order_id.Name = "col_order_id";
            col_order_id.ReadOnly = true;
            // 
            // col_goods_title
            // 
            col_goods_title.DataPropertyName = "goods_title";
            col_goods_title.HeaderText = "商品";
            col_goods_title.MinimumWidth = 9;
            col_goods_title.Name = "col_goods_title";
            col_goods_title.ReadOnly = true;
            // 
            // col_buyer_name
            // 
            col_buyer_name.DataPropertyName = "buyer_name";
            col_buyer_name.HeaderText = "买家";
            col_buyer_name.MinimumWidth = 9;
            col_buyer_name.Name = "col_buyer_name";
            col_buyer_name.ReadOnly = true;
            // 
            // col_seller_name
            // 
            col_seller_name.DataPropertyName = "seller_name";
            col_seller_name.HeaderText = "卖家";
            col_seller_name.MinimumWidth = 9;
            col_seller_name.Name = "col_seller_name";
            col_seller_name.ReadOnly = true;
            // 
            // col_goods_price
            // 
            col_goods_price.DataPropertyName = "goods_price";
            col_goods_price.HeaderText = "金额";
            col_goods_price.MinimumWidth = 9;
            col_goods_price.Name = "col_goods_price";
            col_goods_price.ReadOnly = true;
            // 
            // col_order_status
            // 
            col_order_status.DataPropertyName = "order_status";
            col_order_status.HeaderText = "状态";
            col_order_status.MinimumWidth = 9;
            col_order_status.Name = "col_order_status";
            col_order_status.ReadOnly = true;
            // 
            // col_order_time
            // 
            col_order_time.DataPropertyName = "order_time";
            col_order_time.HeaderText = "下单时间";
            col_order_time.MinimumWidth = 9;
            col_order_time.Name = "col_order_time";
            col_order_time.ReadOnly = true;
            // 
            // col_complete_time
            // 
            col_complete_time.DataPropertyName = "complete_time";
            col_complete_time.HeaderText = "完成时间";
            col_complete_time.MinimumWidth = 9;
            col_complete_time.Name = "col_complete_time";
            col_complete_time.ReadOnly = true;
            // 
            // cbo_FilterOrder
            // 
            cbo_FilterOrder.FormattingEnabled = true;
            cbo_FilterOrder.Location = new Point(328, 71);
            cbo_FilterOrder.Margin = new Padding(2, 1, 2, 1);
            cbo_FilterOrder.Name = "cbo_FilterOrder";
            cbo_FilterOrder.Size = new Size(197, 32);
            cbo_FilterOrder.TabIndex = 2;
            cbo_FilterOrder.SelectedIndexChanged += cbo_FilterOrder_SelectedIndexChanged;
            // 
            // btn_MarkComplete
            // 
            btn_MarkComplete.Location = new Point(347, 477);
            btn_MarkComplete.Margin = new Padding(2, 1, 2, 1);
            btn_MarkComplete.Name = "btn_MarkComplete";
            btn_MarkComplete.Size = new Size(140, 34);
            btn_MarkComplete.TabIndex = 1;
            btn_MarkComplete.Text = "标记为已完成";
            btn_MarkComplete.UseVisualStyleBackColor = true;
            btn_MarkComplete.Click += btn_MarkComplete_Click;
            // 
            // btn_RefreshOrder
            // 
            btn_RefreshOrder.Location = new Point(534, 71);
            btn_RefreshOrder.Margin = new Padding(2, 1, 2, 1);
            btn_RefreshOrder.Name = "btn_RefreshOrder";
            btn_RefreshOrder.Size = new Size(145, 34);
            btn_RefreshOrder.TabIndex = 0;
            btn_RefreshOrder.Text = "刷新";
            btn_RefreshOrder.UseVisualStyleBackColor = true;
            btn_RefreshOrder.Click += btn_RefreshOrder_Click;
            // 
            // tpStats
            // 
            tpStats.BackgroundImage = (Image)resources.GetObject("tpStats.BackgroundImage");
            tpStats.BackgroundImageLayout = ImageLayout.Stretch;
            tpStats.Controls.Add(txt_Announcement);
            tpStats.Controls.Add(btn_SaveAnnouncement);
            tpStats.Controls.Add(grp_Stats);
            tpStats.Controls.Add(btn_RefreshStats);
            tpStats.Location = new Point(4, 33);
            tpStats.Margin = new Padding(2, 1, 2, 1);
            tpStats.Name = "tpStats";
            tpStats.Padding = new Padding(2, 1, 2, 1);
            tpStats.Size = new Size(834, 707);
            tpStats.TabIndex = 3;
            tpStats.Text = "数据统计";
            tpStats.UseVisualStyleBackColor = true;
            // 
            // txt_Announcement
            // 
            txt_Announcement.BackColor = Color.Beige;
            txt_Announcement.Location = new Point(66, 376);
            txt_Announcement.Margin = new Padding(2, 1, 2, 1);
            txt_Announcement.Multiline = true;
            txt_Announcement.Name = "txt_Announcement";
            txt_Announcement.Size = new Size(703, 208);
            txt_Announcement.TabIndex = 3;
            txt_Announcement.TextChanged += txt_Announcement_TextChanged;
            // 
            // btn_SaveAnnouncement
            // 
            btn_SaveAnnouncement.Location = new Point(363, 609);
            btn_SaveAnnouncement.Margin = new Padding(2, 1, 2, 1);
            btn_SaveAnnouncement.Name = "btn_SaveAnnouncement";
            btn_SaveAnnouncement.Size = new Size(112, 38);
            btn_SaveAnnouncement.TabIndex = 2;
            btn_SaveAnnouncement.Text = "发布公告";
            btn_SaveAnnouncement.UseVisualStyleBackColor = true;
            btn_SaveAnnouncement.Click += btn_SaveAnnouncement_Click;
            // 
            // grp_Stats
            // 
            grp_Stats.BackColor = Color.Beige;
            grp_Stats.Controls.Add(lbl_CompletedCount);
            grp_Stats.Controls.Add(lbl_ShippingCount);
            grp_Stats.Controls.Add(lbl_OrderCount);
            grp_Stats.Controls.Add(lbl_PendingCount);
            grp_Stats.Controls.Add(lbl_OnSaleCount);
            grp_Stats.Controls.Add(lbl_GoodsCount);
            grp_Stats.Controls.Add(lbl_AdminCount);
            grp_Stats.Controls.Add(lbl_UserCount);
            grp_Stats.Location = new Point(66, 60);
            grp_Stats.Margin = new Padding(2, 1, 2, 1);
            grp_Stats.Name = "grp_Stats";
            grp_Stats.Padding = new Padding(2, 1, 2, 1);
            grp_Stats.Size = new Size(703, 238);
            grp_Stats.TabIndex = 1;
            grp_Stats.TabStop = false;
            grp_Stats.Text = "数据统计";
            // 
            // lbl_CompletedCount
            // 
            lbl_CompletedCount.AutoSize = true;
            lbl_CompletedCount.Location = new Point(322, 176);
            lbl_CompletedCount.Name = "lbl_CompletedCount";
            lbl_CompletedCount.Size = new Size(134, 24);
            lbl_CompletedCount.TabIndex = 7;
            lbl_CompletedCount.Text = "已完成订单：--";
            // 
            // lbl_ShippingCount
            // 
            lbl_ShippingCount.AutoSize = true;
            lbl_ShippingCount.Location = new Point(322, 133);
            lbl_ShippingCount.Name = "lbl_ShippingCount";
            lbl_ShippingCount.Size = new Size(134, 24);
            lbl_ShippingCount.TabIndex = 6;
            lbl_ShippingCount.Text = "待收货订单：--";
            // 
            // lbl_OrderCount
            // 
            lbl_OrderCount.AutoSize = true;
            lbl_OrderCount.Location = new Point(322, 85);
            lbl_OrderCount.Name = "lbl_OrderCount";
            lbl_OrderCount.Size = new Size(116, 24);
            lbl_OrderCount.TabIndex = 5;
            lbl_OrderCount.Text = "订单总数：--";
            // 
            // lbl_PendingCount
            // 
            lbl_PendingCount.AutoSize = true;
            lbl_PendingCount.Location = new Point(321, 40);
            lbl_PendingCount.Name = "lbl_PendingCount";
            lbl_PendingCount.Size = new Size(134, 24);
            lbl_PendingCount.TabIndex = 4;
            lbl_PendingCount.Text = "待审核商品：--";
            // 
            // lbl_OnSaleCount
            // 
            lbl_OnSaleCount.AutoSize = true;
            lbl_OnSaleCount.Location = new Point(24, 176);
            lbl_OnSaleCount.Name = "lbl_OnSaleCount";
            lbl_OnSaleCount.Size = new Size(116, 24);
            lbl_OnSaleCount.TabIndex = 3;
            lbl_OnSaleCount.Text = "在售商品：--";
            // 
            // lbl_GoodsCount
            // 
            lbl_GoodsCount.AutoSize = true;
            lbl_GoodsCount.Location = new Point(24, 133);
            lbl_GoodsCount.Name = "lbl_GoodsCount";
            lbl_GoodsCount.Size = new Size(116, 24);
            lbl_GoodsCount.TabIndex = 2;
            lbl_GoodsCount.Text = "商品总数：--";
            // 
            // lbl_AdminCount
            // 
            lbl_AdminCount.AutoSize = true;
            lbl_AdminCount.Location = new Point(24, 85);
            lbl_AdminCount.Name = "lbl_AdminCount";
            lbl_AdminCount.Size = new Size(116, 24);
            lbl_AdminCount.TabIndex = 1;
            lbl_AdminCount.Text = "管理员数：--";
            // 
            // lbl_UserCount
            // 
            lbl_UserCount.AutoSize = true;
            lbl_UserCount.Location = new Point(24, 42);
            lbl_UserCount.Name = "lbl_UserCount";
            lbl_UserCount.Size = new Size(134, 24);
            lbl_UserCount.TabIndex = 0;
            lbl_UserCount.Text = "注册用户数：--";
            // 
            // btn_RefreshStats
            // 
            btn_RefreshStats.Location = new Point(359, 318);
            btn_RefreshStats.Margin = new Padding(2, 1, 2, 1);
            btn_RefreshStats.Name = "btn_RefreshStats";
            btn_RefreshStats.Size = new Size(112, 34);
            btn_RefreshStats.TabIndex = 0;
            btn_RefreshStats.Text = "刷新统计";
            btn_RefreshStats.UseVisualStyleBackColor = true;
            btn_RefreshStats.Click += btn_RefreshStats_Click;
            // 
            // Frmadmin
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(842, 744);
            Controls.Add(tabAdmin);
            DoubleBuffered = true;
            Margin = new Padding(2, 1, 2, 1);
            Name = "Frmadmin";
            Text = "管理员面板";
            Load += Frmadmin_Load;
            tabAdmin.ResumeLayout(false);
            tpGoodsAudit.ResumeLayout(false);
            tpGoodsAudit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_GoodsAudit).EndInit();
            tpUserManage.ResumeLayout(false);
            tpUserManage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Users).EndInit();
            tpOrderManage.ResumeLayout(false);
            tpOrderManage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_AllOrders).EndInit();
            tpStats.ResumeLayout(false);
            tpStats.PerformLayout();
            grp_Stats.ResumeLayout(false);
            grp_Stats.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabAdmin;
        private TabPage tpGoodsAudit;
        private Button btn_Reject;
        private Button btn_Approve;
        private Button btn_Refresh;
        private ComboBox cbo_FilterStatus;
        private Label lbl_Filter;
        private DataGridView dgv_GoodsAudit;
        private DataGridViewTextBoxColumn col_audit_id;
        private DataGridViewTextBoxColumn col_audit_title;
        private DataGridViewTextBoxColumn col_audit_price;
        private DataGridViewTextBoxColumn col_audit_seller;
        private DataGridViewTextBoxColumn col_audit_status;
        private DataGridViewTextBoxColumn col_audit_time;
        private TabPage tpUserManage;
        private TabPage tpOrderManage;
        private TabPage tpStats;
        private DataGridView dgv_Users;
        private Label label1;
        private Button btn_DisableUser;
        private Button btn_SearchUser;
        private TextBox txt_SearchUser;
        private Label label2;
        private DataGridView dgv_AllOrders;
        private ComboBox cbo_FilterOrder;
        private Button btn_MarkComplete;
        private Button btn_RefreshOrder;
        private GroupBox grp_Stats;
        private Button btn_RefreshStats;
        private Label lbl_CompletedCount;
        private Label lbl_ShippingCount;
        private Label lbl_OrderCount;
        private Label lbl_PendingCount;
        private Label lbl_OnSaleCount;
        private Label lbl_GoodsCount;
        private Label lbl_AdminCount;
        private Label lbl_UserCount;
        private DataGridViewTextBoxColumn col_user_id;
        private DataGridViewTextBoxColumn col_username;
        private DataGridViewTextBoxColumn col_phone;
        private DataGridViewTextBoxColumn col_role_name;
        private DataGridViewTextBoxColumn col_user_status;
        private DataGridViewTextBoxColumn col_created_time;
        private DataGridViewTextBoxColumn col_order_id;
        private DataGridViewTextBoxColumn col_goods_title;
        private DataGridViewTextBoxColumn col_buyer_name;
        private DataGridViewTextBoxColumn col_seller_name;
        private DataGridViewTextBoxColumn col_goods_price;
        private DataGridViewTextBoxColumn col_order_status;
        private DataGridViewTextBoxColumn col_order_time;
        private DataGridViewTextBoxColumn col_complete_time;
        private Button btn_SaveAnnouncement;
        private TextBox txt_Announcement;
    }
}
