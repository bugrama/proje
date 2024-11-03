using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje.Models.Siniflar;

namespace proje.Controllers
{
    public class TurlarController : Controller
    {
        // GET: Blog
        Context c = new Context();
        TurYorum ty = new TurYorum();
        public ActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                ty.Deger1 = c.Turlars.Where(x => x.Baslik == p).ToList();
                ty.Deger3 = c.Turlars.OrderByDescending(x => x.Id).Take(3).ToList();
                return View(ty);
            }
            else
            {
                ty.Deger1 = c.Turlars.ToList();
                ty.Deger3 = c.Turlars.OrderByDescending(x => x.Id).Take(3).ToList();
                return View(ty);
            }
        }
        public ActionResult TurDetay(int id)
        {
            
            ty.Deger1 = c.Turlars.Where(x => x.Id == id).ToList();
            ty.Deger2 = c.Yorumlars.Where(x => x.Turid == id).ToList();
            return View(ty);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}