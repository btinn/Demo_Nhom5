using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buoi9.Models;
namespace Buoi9.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        dbQuanLyBanSachDataDataContext db = new dbQuanLyBanSachDataDataContext ();

        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int masach,string strURL)
        {
            //Lay danh sach gia hang
            List<GioHang> lstGioHang = LayGioHang();
            //Ktra co hang nay trong gio hang chua
            GioHang SanPham = lstGioHang.Find(s => s.maSach == masach);
            if(SanPham == null)
            {
                SanPham = new GioHang(masach);
                lstGioHang.Add(SanPham);
                return Redirect(strURL);
            }
            else
            {
                SanPham.soLuong++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int sl = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang != null)
            {
                sl = lstGioHang.Sum(s => s.soLuong);
            }
            return sl;
        }
        private double TongThanhTien()
        {
            double tthanhtien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {   
                tthanhtien = lstGioHang.Sum(s => s.thanhTien);
            }
            return tthanhtien;
        }

        public ActionResult GioHang()
        {
            if(Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Sach");

            }
            List<GioHang> lstGioHang = LayGioHang();

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();

            return View(lstGioHang);
        }

        public ActionResult XoaGioHang(int maSach)
        {
            List<GioHang> lstGioHang = LayGioHang();
            //Ktra co hang nay trong gio hang chua
          
                lstGioHang.RemoveAll(s => s.maSach == maSach);
                return RedirectToAction("GioHang","GioHang");
            
            if(lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Sach");
            }
            return RedirectToAction("GioHang", "GioHang");
        }

        public ActionResult XoaGioHang_All()
        {
            List<GioHang> lstGioHang = LayGioHang();
            //Ktra co hang nay trong gio hang chua

            lstGioHang.Clear();
            return RedirectToAction("GioHang", "GioHang");          
        }

        public ActionResult CapNhatGioHang(int maSach, FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang SanPham = lstGioHang.Single(s => s.maSach == maSach);

            if(SanPham != null)
            {
                string txtsp = "txtSoLuong_" + maSach.ToString();
                SanPham.soLuong = int.Parse(f[txtsp].ToString());
            }
            return RedirectToAction("GioHang", "GioHang");
        }

       
    }
}
