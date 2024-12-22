using System;
using System.Linq;
using System.Web.Mvc;
using proje.Models;
using proje.Models.Siniflar;

namespace proje.Controllers
{
    public class TurlarController : Controller
    {
        Context c = new Context();
        TurYorum ty = new TurYorum();



        

        public ActionResult Index(string p, DateTime? startDate, string[] etiket, int page = 1)
        {
            int pageSize = 3;
            var turlar = c.Turlars.AsQueryable();

            if (!string.IsNullOrEmpty(p))
            {
                turlar = turlar.Where(x => x.Baslik.Contains(p));
            }

            if (startDate.HasValue)
            {
                turlar = turlar.Where(x => x.BaslangicTarihi >= startDate.Value);
            }

            if (etiket != null)
            {
                etiket = etiket.Where(e => e.ToLower() != "false").ToArray();
            }
                      
            if (etiket != null && etiket.Any())
            {
                turlar = turlar.Where(x => etiket.Any(e => x.Tags.Contains(e)));
            }


            ty.Deger1 = turlar.OrderBy(x => x.Id)
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .ToList();

            ty.Deger3 = c.Turlars.OrderByDescending(x => x.Id).Take(3).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = Math.Ceiling((double)turlar.Count() / pageSize);

            return View(ty);
        }

        [HttpPost]
        public ActionResult SiparisVer(string isim, string email, string telefon, int kisi, int turId)
        {
            try
            {
                var siparis = new Siparisler
                {
                    Isim = isim,
                    Email = email,
                    Telefon = telefon,
                    Kisi = kisi,
                    TurId = turId
                };

                c.Siparislers.Add(siparis);
                c.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
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
