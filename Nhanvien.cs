using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenDucThang_QuanLyThuVien
{
    internal class Nhanvien
    {
        database db;
        public Nhanvien()
        {
            db = new database();
        }
        public DataTable LayDSNhanvien()
        {
            string strSQL = "Select Manhanvien, HoTenNhanVien," +
                "Ngaysinh,Diachi,Dienthoai, TenBangcap From Nhanvien N, " +
                "BANGCAP B Where N.MaBangCap = B.MaBangCap";
            DataTable dt = db.Execute(strSQL);
            //Goi phuong thuc truy xuat du lieu
            return dt;
        }


    


    }
}
