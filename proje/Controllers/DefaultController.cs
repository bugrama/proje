using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje.Models.Siniflar;

namespace proje.Controllers
{
    public class DefaultController : Controller
    {
        
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Turlars
           .OrderBy(x => Guid.NewGuid())
           .Take(4)
           .ToList();

            return View(degerler);

        }
        public ActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            var degerler = c.Turlars.OrderByDescending(x => x.Id).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial2()
        {
            var deger = c.Turlars.Where(x => x.Id == 1).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial3()
        {
            var enCokYorumluTurlar = c.Turlars
            .Select(t => new
            {
                Tur = t,
                YorumSayisi = t.Yorumlars.Count()
            })
            .OrderByDescending(x => x.YorumSayisi)
            .Take(5)
            .Select(x => x.Tur)
            .ToList();

            return PartialView(enCokYorumluTurlar);
        }
        public PartialViewResult Partial4()
        {
            var deger = c.Turlars.Take(3).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial5()
        {
            var deger = c.Turlars.Take(3).OrderByDescending(x => x.Id).ToList();
            return PartialView(deger);
        }
    }
}