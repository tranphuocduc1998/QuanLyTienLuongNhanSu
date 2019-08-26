using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLNSTL
{
    public partial class fmThemnhansu : DevExpress.XtraEditors.XtraForm
    {
        QLNSTLEntities db = new QLNSTLEntities();
        public fmThemnhansu()
        {
            InitializeComponent();
        }

        //Thêm Thông tin vào ComboBox
        public void cbo()
        {
            cboPhongban.Items.Clear();
            var pb = db.PHONGBANs.ToList();
            foreach (var itempb in pb)
            {
                cboPhongban.Items.Add(itempb.TENPB);
            }
            cboChucvu.Items.Clear();
            var cv = db.CHUCVUs.ToList();
            foreach (var itemcv in cv)
            {
                cboChucvu.Items.Add(itemcv.TENCV);
            }
            cboTrinhdo.Items.Clear();
            cboTrinhdo.Items.Add("Đại Học");
            cboTrinhdo.Items.Add("Cao Học");
            cboTrinhdo.Items.Add("Trung Học");
        }

        //Làm mới các ToolBox
        public void clear()
        {
            txtManv.Text = "";
            txtDantoc.Text = "";
            txtQuequan.Text = "";
            txtSDT.Text = "";
            txtTennv.Text = "";
            dtpNgaySinh.Text = "";
            dtpNgayvaolam.Text = "";
            rabtnNam.Checked = true;
            cboPhongban.SelectedIndex = 0;
            cboChucvu.SelectedIndex = 0;
            cboTrinhdo.SelectedIndex = 0;
        }

        private void fmThemnhansu_Load(object sender, EventArgs e)
        {
            cbo();
            clear();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTennv.Text == "" || txtDantoc.Text == "" || txtManv.Text == "" || txtQuequan.Text == "" || txtSDT.Text == "")
            {
                XtraMessageBox.Show("Bạn cần điền đây đủ thông tin trước khi lưu.","Thông báo!",MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            NHANVIEN TKNV = db.NHANVIENs.Find(Convert.ToString(txtManv.Text));
            if (TKNV != null)
            {
                XtraMessageBox.Show("Mã nhân viên đã được dùng.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
            NHANVIEN NV = new NHANVIEN();
            NV.MANV = txtManv.Text;
            NV.HOTEN = txtTennv.Text;
            NV.DANTOC = txtDantoc.Text;
            if (rabtnNam.Checked == true)
            {
                NV.GIOITINH = rabtnNam.Text;
            }
            else
            {
                NV.GIOITINH = rabtnNu.Text;
            }
            NV.SODIENTHOAI = txtSDT.Text;
            NV.QUEQUAN = txtQuequan.Text;
            NV.NGAYSINH = dtpNgaySinh.Value;
            NV.NGAYVAOLAM = dtpNgayvaolam.Value;
            var pb = db.PHONGBANs.Single(x => x.TENPB.Equals(cboPhongban.Text));
            NV.MAPB = pb.MAPB;
            var cv = db.CHUCVUs.Single(x => x.TENCV.Equals(cboChucvu.Text));
            NV.MACV = cv.MACV;
            NV.TRINHDO = cboTrinhdo.Text;
            db.NHANVIENs.Add(NV);
            db.SaveChanges();
            XtraMessageBox.Show("Lưu thành công.","Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
        }
    }
}