using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Carilers.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult cariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cariEkle(Cariler cr)
        {
            if (!ModelState.IsValid)
            {
                return View("cariEkle");
            }
            c.Carilers.Add(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult cariGetir(int id)
        {
            var getir = c.Carilers.Find(id);
            return View("cariGetir", getir);
        }

        public ActionResult cariGuncelle(Cariler cr)
        {
            var guncelle = c.Carilers.Find(cr.CariID);
            guncelle.Cari_ad = cr.Cari_ad;
            guncelle.Cari_soyad = cr.Cari_soyad;
            guncelle.Cari_mail = cr.Cari_mail;
            guncelle.Cari_sehir = cr.Cari_sehir;

            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult cariSatis(int id)
        {
            var satislar = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            ViewBag.must = c.Carilers.Where(x => x.CariID == id).Select(y => y.Cari_ad + " " + y.Cari_soyad).FirstOrDefault();
            return View(satislar);
        }
    }
}