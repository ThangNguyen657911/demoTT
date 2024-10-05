using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenDucThang_QuanLyThuVien
{
    public partial class frmNhanvien : Form
    {
        Nhanvien nv = new Nhanvien();
        private object sqlConn;
        private string strSQL;
        private string connectionString;

        public frmNhanvien()
        {
            InitializeComponent();

            connectionString = "Data Source = LAPTOP-701I9284\\SQLEXPRESS; Database = QLTHUVIEN; Integrated Security = True ";

            liv_DanhSachNhanVien.Columns.Add("Mã NV", 80, HorizontalAlignment.Left);
            liv_DanhSachNhanVien.Columns.Add("Họ Tên", 200, HorizontalAlignment.Left);
            liv_DanhSachNhanVien.Columns.Add("Ngày Sinh", 300, HorizontalAlignment.Left);
            liv_DanhSachNhanVien.Columns.Add("Địa Chỉ", 600, HorizontalAlignment.Left);
            liv_DanhSachNhanVien.Columns.Add("Điện thoại", 80, HorizontalAlignment.Left);
            liv_DanhSachNhanVien.Columns.Add("Bằng cấp", 100, HorizontalAlignment.Left);
            groupBox2_Enter();
        }

        private void groupBox2_Enter()
        {
            DataTable dt = nv.LayDSNhanvien();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi =
                liv_DanhSachNhanVien.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text) ||
       
                string.IsNullOrEmpty(txtNgaySinh.Text) || 
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtDienThoai.Text) ||
                string.IsNullOrEmpty(cbxBangCap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();

                    string strSQL = "Select Manhanvien, HoTenNhanVien," +
                        "Ngaysinh,Diachi,Dienthoai, TenBangcap From Nhanvien N, " +
                        "BANGCAP B Where N.MaBangCap = B.MaBangCap";

                    using (SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn))
                    {
                        sqlcmd.Parameters.AddWithValue("@HoTenNhanVien", txtHoTen.Text);
                        
                        sqlcmd.Parameters.AddWithValue("@NgaySinh", txtNgaySinh.Text); 
                        sqlcmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                        sqlcmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text);
                        sqlcmd.Parameters.AddWithValue("@TenBangcap", cbxBangCap.Text);

                        sqlcmd.ExecuteNonQuery(); 
                        MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }

        }
    }
}
