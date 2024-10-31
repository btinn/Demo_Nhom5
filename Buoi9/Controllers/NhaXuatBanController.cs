using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buoi9.Models;
namespace Buoi9.Controllers
{
    public class NhaXuatBanController : Controller
    {
        dbQuanLyBanSachDataDataContext dbSach = new dbQuanLyBanSachDataDataContext();
        //
        // GET: /NhaXuatBan/
        dbQuanLyBanSachDataDataContext dbNXB = new dbQuanLyBanSachDataDataContext();
        public ActionResult NhaXuatBanPartial()
        {
            List<NhaXuatBan> lstNXB = dbNXB.NhaXuatBans.Select(t=>t).Skip(0).Take(7).OrderBy(t=>t.TenNXB).ToList<NhaXuatBan>();
            return View(lstNXB);
        }
        public ActionResult SachTheoNXB(int id)
        {
            List<Sach> lstSachtheoNXB = dbSach.Saches.Select(cd => cd).Where(t => t.MaNXB == id).ToList<Sach>();

            return View(lstSachtheoNXB);
        }
    }
}
