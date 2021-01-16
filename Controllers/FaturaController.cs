using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        private Context c = new Context();
        public ActionResult Index()
        {
            return View(c.Faturalars.ToList());
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult FaturaEkle(Faturalar faturalar)
        {
            if (ModelState.IsValid)
            {
                faturalar.FaturaTarihi = DateTime.Parse(DateTime.Now.ToLongDateString());
                c.Faturalars.Add(faturalar);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faturalar);
        }

        [HttpGet]
        public ActionResult FaturaGuncelle(int? id)
        {
            return View(c.Faturalars.Find(id.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult FaturaGuncelle(Faturalar faturalar)
        {
            if (ModelState.IsValid)
            {
                var f = c.Faturalars.Find(faturalar.FaturaId);
                f.FaturaSeriNo = faturalar.FaturaSeriNo;
                f.FaturaSiraNo = faturalar.FaturaSiraNo;
                f.VergiDairesi = faturalar.VergiDairesi;
                f.FaturaTarihi = faturalar.FaturaTarihi;
                f.Saat = faturalar.Saat;
                f.TeslimAlan = faturalar.TeslimAlan;
                f.TeslimEden = faturalar.TeslimEden;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faturalar);
        }

        [HttpGet]
        public ActionResult FaturaDetay(int? id)
        {
            Session["faturaid"] = id.Value;
            return View(c.FaturaKalems.Where(x => x.FaturaId == id.Value).ToList());
        }

        [HttpGet]
        public ActionResult FaturaKalemEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult FaturaKalemEkle(FaturaKalem faturaKalem)
        {
            if (ModelState.IsValid)
            {
                c.FaturaKalems.Add(faturaKalem);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faturaKalem);
        }
    }
}