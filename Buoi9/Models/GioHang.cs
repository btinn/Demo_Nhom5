using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buoi9.Models
{
    public class GioHang
    {
        dbQuanLyBanSachDataDataContext db = new dbQuanLyBanSachDataDataContext();
        public int maSach { set; get; }
        public string tenSach { set; get; }
        public string anhBia { set; get; }
        public double donGia { set; get; }
        public int soLuong { set; get; }
        public double thanhTien 
        {
            get { return soLuong * donGia; }
        }
        

        public GioHang(int pMaSach)
        {
            maSach = pMaSach;
            Sach sa = db.Saches.Single(s => s.MaSach == maSach);
            tenSach = sa.TenSach;
            anhBia = sa.AnhBia;
            donGia = double.Parse(sa.GiaBan.ToString());
            soLuong = 1;
        }

    }
}