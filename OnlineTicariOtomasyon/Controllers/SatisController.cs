using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.SatisHarekets.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult satisYap()
        {
            List<SelectListItem> urun = (from x in c.Urunlers
                                         select new SelectListItem
                                         {
                                             Text = x.Urun_ad,
                                             Value = x.UrunID.ToString()
                                         }).ToList();

            ViewBag.urn = urun;

            List<SelectListItem> musteri = (from x in c.Carilers
                                         select new SelectListItem
                                         {
                                             Text = x.Cari_ad + " " + x.Cari_soyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();

            ViewBag.mst = musteri;

            List<SelectListItem> person = (from x in c.Personels
                                         select new SelectListItem
                                         {
                                             Text = x.Personel_ad + " " + x.Personel_soyad,
                                             Value = x.PersonelID.ToString()
                                         }).ToList();

            ViewBag.per = person;
            return View();
        }
        [HttpPost]
        public ActionResult satisYap(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortTimeString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult satisGetir(int id)
        {
            List<SelectListItem> uruns = (from x in c.Urunlers 
                                          select new SelectListItem
                                            {
                                                Text = x.Urun_ad,
                                                Value = x.UrunID.ToString()
                                            }).ToList();
                                            ViewBag.urn = uruns;

            List<SelectListItem> must = (from x in c.Carilers
                                          select new SelectListItem
                                          {
                                              Text = x.Cari_ad + " " + x.Cari_soyad,
                                              Value = x.CariID.ToString()
                                          }).ToList();
            ViewBag.mst = must;

            List<SelectListItem> person = (from x in c.Personels
                                          select new SelectListItem
                                          {
                                              Text = x.Personel_ad + " " + x.Personel_soyad,
                                              Value = x.PersonelID.ToString()
                                          }).ToList();
            ViewBag.per = person;

            var satis = c.SatisHarekets.Find(id);
            return View("satisGetir", satis);
        }

        public ActionResult satisGuncelle(SatisHareket s)
        {
            var satis = c.SatisHarekets.Find(s.SatisID);
            satis.Urunid = s.Urunid;
            satis.Cariid = s.Cariid;
            satis.Personelid = s.Personelid;
            satis.Fiyat = s.Fiyat;
            satis.Adet = s.Adet;
            satis.ToplamTutar = s.ToplamTutar;
            satis.Tarih = s.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");



        }

        public ActionResult urunListesi()
        {
            var urunList = c.Urunlers.ToList();
            return View(urunList);
        }

       
    }
}