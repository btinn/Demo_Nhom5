using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buoi9.Models;
namespace Buoi9.Controllers
{
    public class ChuDeController : Controller
    {
        dbQuanLyBanSachDataDataContext dbSach = new dbQuanLyBanSachDataDataContext();

        //
        // GET: /ChuDe/

        public ActionResult ChuDePartial()
        {
            List<ChuDe> lstChuDe = dbSach.ChuDes.Select(cd => cd).Skip(0).Take(7).OrderBy(t => t.TenChuDe).ToList<ChuDe>();
            
            return View(lstChuDe);
        }
        public ActionResult SachTheoCD(int id)
        {
            List<Sach> lstSachtheoCD = dbSach.Saches.Select(cd => cd).Where(t => t.MaChuDe == id).ToList<Sach>();

            return View(lstSachtheoCD);
        }
    }
}
