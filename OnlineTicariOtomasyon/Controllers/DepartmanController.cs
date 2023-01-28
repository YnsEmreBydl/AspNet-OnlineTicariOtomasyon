using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Departmanlars.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult departmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult departmanEkle(Departmanlar d)
        {
            c.Departmanlars.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult departmanGetir(int id)
        {
            var dep = c.Departmanlars.Find(id);
            return View("departmanGetir", dep);
        }

        public ActionResult departmanGuncelle(Departmanlar d)
        {
            var dp = c.Departmanlars.Find(d.DepartmanID);
            dp.Departman_ad = d.Departman_ad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult departmanSil(int id)
        {
            var sil = c.Departmanlars.Find(id);
            c.Departmanlars.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult departmanDetay(int id)
        {

            var detay = c.Personels.Where(x => x.Departmanid == id).ToList();

            var dpt = c.Departmanlars.Where(x => x.DepartmanID == id).Select(y => y.Departman_ad).FirstOrDefault();
            ViewBag.dgr = dpt;
            return View(detay);
        }

        public ActionResult departmanSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();

            var dp = c.Personels.Where(x => x.PersonelID == id).Select(y => y.Personel_ad).FirstOrDefault();
            ViewBag.per = dp;
            return View(degerler);
        }
    }
}