using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult YeniTur(Turlar t, HttpPostedFileBase ResimDosyasi)
        {
            if (ResimDosyasi != null && ResimDosyasi.ContentLength > 0)
            {
                
                string dosyaAdi = Path.GetFileName(ResimDosyasi.FileName);

               
                string kaydetmeYolu = Path.Combine(Server.MapPath("~/Content/Resimler"), dosyaAdi);

               
                ResimDosyasi.SaveAs(kaydetmeYolu);

                
                t.Resim = "/Content/Resimler/" + dosyaAdi;
            }

            
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
            tr.Kontenjan = t.Kontenjan;
            tr.Tags = t.Tags;
            tr.Resim = t.Resim;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);

        }
        public ActionResult Siparislistesi()
        {
            var siparisler = c.Siparislers.ToList();
            return View(siparisler);
        }
        public ActionResult SiparisSil(int id)
        {
            var y = c.Siparislers.Find(id);
            c.Siparislers.Remove(y);  
            c.SaveChanges();
            return RedirectToAction("Siparislistesi");
        }

        [HttpPost]
        public ActionResult SiparisOnayla(int id)
        {
            var siparis = c.Siparislers.Find(id);
            if (siparis != null)
            {
                var tur = c.Turlars.Find(siparis.TurId);
                if (tur != null)
                {
                    if (tur.Kontenjan >= siparis.Kisi)
                    {
                        tur.Kontenjan -= siparis.Kisi;
                        c.Siparislers.Remove(siparis);
                        c.SaveChanges();
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Kontenjan yetersiz." });
                    }
                }
            }
            return Json(new { success = false, message = "Sipariş veya tur bulunamadı." });
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
        [HttpPost]
        public ActionResult TurTarihGuncelle(int Id, DateTime BaslangicTarihi, DateTime BitisTarihi)
        {
            var tur = c.Turlars.Find(Id);
            if (tur != null)
            {
                tur.BaslangicTarihi = BaslangicTarihi;
                tur.BitisTarihi = BitisTarihi;
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}