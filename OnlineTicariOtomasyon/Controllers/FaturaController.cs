using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Siniflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Faturalars.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult faturaEkle()
        {
            return View();
        }

        public ActionResult faturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult faturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult faturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.FaturaTarih = f.FaturaTarih;
            fatura.FaturaTeslimAlan = f.FaturaTeslimAlan;
            fatura.FaturaTeslimEden = f.FaturaTeslimEden;
            fatura.FaturaSaat = f.FaturaSaat;
            fatura.FaturaVergiDairesi = f.FaturaVergiDairesi;
            fatura.FaturaToplam = f.FaturaToplam;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}