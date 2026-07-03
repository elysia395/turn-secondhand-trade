namespace 转一转校园二手物品交易系统
{
    partial class FrmGoodsDetail
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
            lbl_Price = new Label();
            lbl_Seller = new Label();
            lbl_Category = new Label();
            lbl_Time = new Label();
            pic_Goods = new PictureBox();
            rtb_Desc = new RichTextBox();
            btn_Order = new Button();
            ((System.ComponentModel.ISupportInitialize)pic_Goods).BeginInit();
            SuspendLayout();
            // 
            // lbl_Title
            // 
            lbl_Title.AutoSize = true;
            lbl_Title.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            lbl_Title.Location = new Point(448, 42);
            lbl_Title.Margin = new Padding(5, 0, 5, 0);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(101, 37);
            lbl_Title.TabIndex = 0;
            lbl_Title.Text = "商品名";
            // 
            // lbl_Price
            // 
            lbl_Price.AutoSize = true;
            lbl_Price.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);
            lbl_Price.ForeColor = Color.Red;
            lbl_Price.Location = new Point(448, 113);
            lbl_Price.Margin = new Padding(5, 0, 5, 0);
            lbl_Price.Name = "lbl_Price";
            lbl_Price.Size = new Size(90, 31);
            lbl_Price.TabIndex = 1;
            lbl_Price.Text = "￥0.00";
            // 
            // lbl_Seller
            // 
            lbl_Seller.AutoSize = true;
            lbl_Seller.Location = new Point(448, 169);
            lbl_Seller.Margin = new Padding(5, 0, 5, 0);
            lbl_Seller.Name = "lbl_Seller";
            lbl_Seller.Size = new Size(64, 24);
            lbl_Seller.TabIndex = 2;
            lbl_Seller.Text = "卖家：";
            // 
            // lbl_Category
            // 
            lbl_Category.AutoSize = true;
            lbl_Category.Location = new Point(448, 226);
            lbl_Category.Margin = new Padding(5, 0, 5, 0);
            lbl_Category.Name = "lbl_Category";
            lbl_Category.Size = new Size(64, 24);
            lbl_Category.TabIndex = 3;
            lbl_Category.Text = "分类：";
            // 
            // lbl_Time
            // 
            lbl_Time.AutoSize = true;
            lbl_Time.Location = new Point(448, 282);
            lbl_Time.Margin = new Padding(5, 0, 5, 0);
            lbl_Time.Name = "lbl_Time";
            lbl_Time.Size = new Size(100, 24);
            lbl_Time.TabIndex = 4;
            lbl_Time.Text = "发布时间：";
            // 
            // pic_Goods
            // 
            pic_Goods.BorderStyle = BorderStyle.FixedSingle;
            pic_Goods.Location = new Point(47, 42);
            pic_Goods.Margin = new Padding(5, 4, 5, 4);
            pic_Goods.Name = "pic_Goods";
            pic_Goods.Size = new Size(360, 370);
            pic_Goods.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Goods.TabIndex = 5;
            pic_Goods.TabStop = false;
            // 
            // rtb_Desc
            // 
            rtb_Desc.Location = new Point(47, 432);
            rtb_Desc.Margin = new Padding(5, 4, 5, 4);
            rtb_Desc.Name = "rtb_Desc";
            rtb_Desc.ReadOnly = true;
            rtb_Desc.Size = new Size(744, 108);
            rtb_Desc.TabIndex = 6;
            rtb_Desc.Text = "";
            // 
            // btn_Order
            // 
            btn_Order.BackColor = SystemColors.ActiveCaption;
            btn_Order.Location = new Point(327, 596);
            btn_Order.Margin = new Padding(5, 4, 5, 4);
            btn_Order.Name = "btn_Order";
            btn_Order.Size = new Size(189, 49);
            btn_Order.TabIndex = 7;
            btn_Order.Text = "立即购买";
            btn_Order.UseVisualStyleBackColor = false;
            btn_Order.Click += btn_Order_Click;
            // 
            // FrmGoodsDetail
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(843, 744);
            Controls.Add(btn_Order);
            Controls.Add(rtb_Desc);
            Controls.Add(pic_Goods);
            Controls.Add(lbl_Time);
            Controls.Add(lbl_Category);
            Controls.Add(lbl_Seller);
            Controls.Add(lbl_Price);
            Controls.Add(lbl_Title);
            Margin = new Padding(5, 4, 5, 4);
            Name = "FrmGoodsDetail";
            Text = "商品详情";
            Load += FrmGoodsDetail_Load;
            ((System.ComponentModel.ISupportInitialize)pic_Goods).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Title;
        private Label lbl_Price;
        private Label lbl_Seller;
        private Label lbl_Category;
        private Label lbl_Time;
        private PictureBox pic_Goods;
        private RichTextBox rtb_Desc;
        private Button btn_Order;
    }
}
