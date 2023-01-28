using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var listele = c.Urunlers.ToList();
            return View(listele);
        }


        [HttpGet]
        public ActionResult urunEkle()
        {
            List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Kategori_ad,
                                              Value = x.KategoriID.ToString()
                                              
                                          }).ToList();
            ViewBag.dgr = deger.ToList();

            List<SelectListItem> deger1 = (from x in c.Urunlers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Urun_durum.ToString()

                                          }).ToList();
            ViewBag.dgr1 = deger1.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult urunEkle(Urunler u)
        {
            c.Urunlers.Add(u);
                
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult urunGetir(int id)
        {
            List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Kategori_ad,
                                              Value = x.KategoriID.ToString()

                                          }).ToList();
            ViewBag.dgr = deger.ToList();

            List<SelectListItem> deger1 = (from x in c.Urunlers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Urun_durum.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1.ToList();
            var urun = c.Urunlers.Find(id);
            return View("urunGetir",urun);
        }

        public ActionResult urunGuncelle(Urunler u)
        {
            var urun = c.Urunlers.Find(u.UrunID);
            urun.Kategoriid= u.Kategoriid;
            urun.Urun_ad = u.Urun_ad;
            urun.Urun_Marka = u.Urun_Marka;
            urun.Urun_gorsel = u.Urun_gorsel;
            urun.Urun_alis_fiyat = u.Urun_alis_fiyat;
            urun.Urun_satis_fiyat = u.Urun_satis_fiyat;
            urun.Urun_durum = u.Urun_durum;
            urun.Urun_stok = u.Urun_stok;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult urunSil(int id)
        {
            var sil = c.Urunlers.Find(id);
            c.Urunlers.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}