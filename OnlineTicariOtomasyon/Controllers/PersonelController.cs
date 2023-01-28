using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {

            var list = c.Personels.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult personelEkle()
        {
            List<SelectListItem> deger = (from x in c.Departmanlars.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Departman_ad,
                                              Value = x.DepartmanID.ToString()
                                          }).ToList();

            ViewBag.dgr = deger.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult personelEkle(Personel p)
        {
           
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelGetir(int id)
        {
            List<SelectListItem> listele = (from x in c.Departmanlars
                                            select new SelectListItem
                                            {
                                                Text = x.Departman_ad,
                                                Value = x.DepartmanID.ToString()
                                            }).ToList();
            ViewBag.person = listele.ToList();

            var per = c.Personels.Find(id);
            return View("personelGetir", per);

        }

        public ActionResult personelGuncelle(Personel p)
        {
            var per = c.Personels.Find(p.PersonelID);
            per.Personel_ad = p.Personel_ad;
            per.Personel_soyad = p.Personel_soyad;
            per.Departmanid = p.Departmanid;
            per.Personel_resim = p.Personel_resim;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult personelSil(int id)
        {
            var per = c.Personels.Find(id);
            c.Personels.Remove(per);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}