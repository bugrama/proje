using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje.Models.Siniflar;

namespace proje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                var degerler = c.Turlars.Where(x => x.Baslik == p).ToList(); ;
                return View(degerler);

            }
            else
            {
                var degerler = c.Turlars.ToList();
                return View(degerler);
            }
        }
        [HttpGet]
        public ActionResult YeniTur()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniTur(Turlar t)
        {
            c.Turlars.Add(t);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult TurSil(int id)
        {
            var t = c.Turlars.Find(id);
            c.Turlars.Remove(t);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TurGetir(int id)
        {
            var tl = c.Turlars.Find(id);
            return View("TurGetir", tl);
        }
        public ActionResult TurGuncelle(Turlar t)
        {
            var tr = c.Turlars.Find(t.Id);
            tr.Aciklama = t.Aciklama;
            tr.Baslik = t.Baslik;
            tr.Resim = t.Resim;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);

        }
        public ActionResult YorumSil(int id)
        {
            var t = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(t);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.Id);
            yrm.yorum = y.yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}