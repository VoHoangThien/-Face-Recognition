using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatHienMatNguoiVaNhanDien
{
    
    class Student
    {
        private string HoTen, MSSV, NgaySinh, Khoa, Nganh, GT, KhoaHoc;

        public string MSSV1
        {
            get { return MSSV; }
            set { MSSV = value; }
        }

    
        
        public Student()
        {
           
        }
        public Student(string mssv, string ht, string ns, string k, string ng, string kh, string gioitinh)
        {
            
            MSSV = mssv;
            HoTen = ht;
            NgaySinh = ns;
            Khoa = k;// khoa
            Nganh = ng;// nganh
            KhoaHoc = kh;// khóa
            GT = gioitinh;
        }

        //public string NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        //public string HoTen1 { get => HoTen; set => HoTen = value; }
        //public string MSSV1 { get => MSSV; set => MSSV = value; }
        //public string Khoa1 { get => Khoa; set => Khoa = value; }
        //public string Nganh1 { get => Nganh; set => Nganh = value; }
        //public string GT1 { get => GT; set => GT = value; }
        //public string KhoaHoc1 { get => KhoaHoc; set => KhoaHoc = value; }
        
    }
}
