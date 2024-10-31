using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buoi9.Models;
namespace Buoi9.Controllers
{
    public class SachController : Controller
    {
        //
        // GET: /Sach/
        dbQuanLyBanSachDataDataContext dbSach = new dbQuanLyBanSachDataDataContext();
        public ActionResult Index()
        {
            List<Sach> lstSach = dbSach.Saches.Select(t => t).ToList<Sach>();
            return View(lstSach);
        }
        public ActionResult SachPartial()
        {
            List<Sach> lstSach = dbSach.Saches.Select(t=>t).ToList<Sach>();
            return View(lstSach);
        }

        public ActionResult XemChiTiet( int id)
        {
            Sach detailSach = dbSach.Saches.Where(t => t.MaSach == id).FirstOrDefault();
            return View(detailSach);
        }
    }
}
