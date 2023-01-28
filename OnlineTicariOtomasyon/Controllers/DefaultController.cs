using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var listele = c.Kategoris.ToList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult kategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult kategoriSil(int id)
        {
            var degerler = c.Kategoris.Find(id);
            c.Kategoris.Remove(degerler);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("kategoriGetir", kategori);
        }

        public ActionResult kategoriGuncelle(Kategori k)
        {
            var kategori = c.Kategoris.Find(k.KategoriID);
            kategori.Kategori_ad = k.Kategori_ad;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
       
    }
}