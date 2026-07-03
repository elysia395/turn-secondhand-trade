using Microsoft.Data.SqlClient;
using System.Data;
using System.IO;

namespace 转一转校园二手物品交易系统
{
    public partial class FrmPublishGoods : FrmBase
    {
        private string? _selectedImagePath;

        public FrmPublishGoods()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Sys_images", Program.BackgroundDir, "background_form.png"));
            this.DoubleBuffered = true;
        }

        private void FrmPublishGoods_Load(object sender, EventArgs e)
        {
            BeginInvoke(() =>
            {
                DataTable dt = SQLHelper.Query("SELECT category_id, category_name FROM categories");
                LoadComboBox(cbo_Category, dt, "category_name", "category_id");
            });
        }

        private void btn_SelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(dlg.FileName);
                    if (fi.Length > 3 * 1024 * 1024)
                    {
                        ShowError("图片大小不能超过 3MB");
                        return;
                    }

                    _selectedImagePath = dlg.FileName;
                    pic_Goods.Image = Image.FromFile(dlg.FileName);
                }
            }
        }

        private void btn_Publish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_GoodsTitle.Text) ||
                cbo_Category.SelectedValue == null ||
                nud_Price.Value <= 0)
            {
                ShowError("请填写完整信息");
                return;
            }

            string sql = @"INSERT INTO goods 
    (title, price, category_id, seller_id, description, status, created_time)
    VALUES (@t, @p, @c, @s, @d, N'待审核', @ct);
    SELECT SCOPE_IDENTITY();";

            SqlParameter[] ps = {
                new SqlParameter("@t", txt_GoodsTitle.Text),
                new SqlParameter("@p", nud_Price.Value),
                new SqlParameter("@c", cbo_Category.SelectedValue),
                new SqlParameter("@s", Program.CurrentUserId),
                new SqlParameter("@d", rtb_Desc.Text),
                new SqlParameter("@ct", DateTime.Now),
            };

            int newId = Convert.ToInt32(SQLHelper.Scalar(sql, ps));

            if (_selectedImagePath != null)
            {
                string outDir = Path.Combine(Application.StartupPath, "Upload_image");
                Directory.CreateDirectory(outDir);
                string fileName = $"goods_{newId}_{Guid.NewGuid():N}{Path.GetExtension(_selectedImagePath)}";

                string outPath = Path.Combine(outDir, fileName);
                File.Copy(_selectedImagePath, outPath, overwrite: true);

                string srcDir = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", "..", "..", "Upload_image"));
                if (Directory.Exists(srcDir))
                    File.Copy(_selectedImagePath, Path.Combine(srcDir, fileName), overwrite: true);

                SQLHelper.Exec(
                    "INSERT INTO goods_images (goods_id, image_url) VALUES (@g, @u)",
                    new[] { new SqlParameter("@g", newId), new SqlParameter("@u", Path.Combine("Upload_image", fileName)) });
            }

            ShowTip("商品已提交审核，请等待管理员审核通过");
            this.Close();
        }
    }
}
