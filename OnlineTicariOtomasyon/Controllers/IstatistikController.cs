using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            var deger2 = c.Urunlers.Count().ToString();
            var deger3 = c.Personels.Count().ToString();
            var deger4 = c.Kategoris.Count().ToString();
            var deger5 = c.Urunlers.Sum(x => x.Urun_stok).ToString();
            var deger6 = (from x in c.Urunlers select x.Urun_Marka).Distinct().Count().ToString();
            var deger7 = c.Urunlers.Count(x => x.Urun_stok <= 20).ToString();
            var deger8 = (from x in c.Urunlers orderby x.Urun_satis_fiyat descending select x.Urun_ad).FirstOrDefault();
            var deger9 = (from x in c.Urunlers orderby x.Urun_satis_fiyat ascending select x.Urun_ad).FirstOrDefault();
            var deger10 = c.Urunlers.Count(x => x.Urun_ad == "MacBook").ToString();
            var deger11 = c.Urunlers.Count(x => x.Urun_ad == "Laptop").ToString();
            var deger12 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            DateTime bugun = DateTime.Today;
            var deger13 = c.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            var deger14 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar).ToString();
            var deger15 = c.Urunlers.GroupBy(x => x.Urun_Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var deger16 = c.SatisHarekets.GroupBy(x => x.Urunler.Urun_ad).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();


            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;
            ViewBag.d5 = deger5;
            ViewBag.d6 = deger6;
            ViewBag.d7 = deger7;
            ViewBag.d8 = deger8;
            ViewBag.d9 = deger9;
            ViewBag.d10 = deger10;
            ViewBag.d11 = deger11;
            ViewBag.d12 = deger12;
            ViewBag.d13 = deger13;
            ViewBag.d14 = deger14;
            ViewBag.d15 = deger15;
            ViewBag.d16 = deger16;
            
            return View();
        }
    }
}