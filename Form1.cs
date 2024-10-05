using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenDucThang_QuanLyThuVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        //hàm ẩn các form chưa dùng tới 
        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            hideForm();
            foreach(Form f in this.MdiChildren)
            {
                if(f.Name =="frmNhanvien")
                {
                    f.Activate();
                    f.BringToFront();
                    f.WindowState = FormWindowState.Maximized; 
                    return;

                }    
            }   
            frmNhanvien nv = new frmNhanvien();
            nv.MdiParent = this;
            nv.WindowState = FormWindowState.Maximized;
            nv.Show();
        }

        private void hideForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Hide();
            }    

        }
        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void tspDocGia_Click(object sender, EventArgs e)
        {
            hideForm();
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmDocGia")
                {
                    f.Activate();
                    f.BringToFront();
                    f.WindowState = FormWindowState.Maximized;
                    return;

                }
            }
            frmDocGia dg = new frmDocGia();
            dg.MdiParent = this;
            dg.WindowState = FormWindowState.Maximized;
            dg.Show();
        }

        private void tspBangCap_Click(object sender, EventArgs e)
        {
            hideForm();
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "frmBangCap")
                {
                    f.Activate();
                    f.BringToFront();
                    f.WindowState = FormWindowState.Maximized;
                    return;

                }
            }
            frmBangCap bangcap = new frmBangCap();
            bangcap.MdiParent = this;
            bangcap.WindowState = FormWindowState.Maximized;
            bangcap.Show();
        }
    }
}
