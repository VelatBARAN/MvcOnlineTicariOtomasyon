using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        private Context c = new Context();
        public ActionResult Index()
        {
            return View(c.Carilers.Where(x=>x.Durum == true).ToList());
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult YeniCari(Cariler cariler)
        {
            if (ModelState.IsValid)
            {
                cariler.Durum = true;
                c.Carilers.Add(cariler);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cariler);
        }

        public ActionResult CariSil(int? id)
        {
            var ca = c.Carilers.Find(id.Value);
            ca.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariGuncelle(int? id)
        {
            var ca = c.Carilers.Find(id.Value);
            return View(ca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CariGuncelle(Cariler cariler)
        {
            if (ModelState.IsValid)
            {
                var ca = c.Carilers.Find(cariler.CariId);
                ca.CariAd = cariler.CariAd;
                ca.CariSoyad = cariler.CariSoyad;
                ca.CariSehir = cariler.CariSehir;
                ca.CariMail = cariler.CariMail;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cariler);
        }

        [HttpGet]
        public ActionResult CariSatisGecmisi(int? id)
        {
            ViewBag.Cari = c.Carilers.Where(x => x.CariId == id.Value).Select(x => x.CariAd + " " + x.CariSoyad).FirstOrDefault();
            return View(c.SatisHarekets.Where(x => x.CariId == id.Value).ToList());
        }
    }
}