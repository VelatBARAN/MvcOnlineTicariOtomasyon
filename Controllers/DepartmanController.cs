using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        private Context c = new Context();
        public ActionResult Index()
        {
            return View(c.Departmans.Where(x => x.Durum == true).ToList());
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult DepartmanEkle(Departman departman)
        {
            if (ModelState.IsValid)
            {
                departman.Durum = true;
                c.Departmans.Add(departman);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departman);
        }

        public ActionResult DepartmanSil(int? id)
        {
            var d = c.Departmans.Find(id.Value);
            d.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanGuncelle(int? id)
        {
            var d = c.Departmans.Find(id.Value);
            return View(d);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult DepartmanGuncelle(Departman departman)
        {
            if (ModelState.IsValid)
            {
                var d = c.Departmans.Find(departman.DepartmanId);
                d.DepartmanAd = departman.DepartmanAd;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departman);
        }

        [HttpGet]
        public ActionResult DepartmanDetay(int? id)
        {
            ViewBag.DepartmanAdi = c.Departmans.Where(x => x.DepartmanId == id.Value).Select(x => x.DepartmanAd).FirstOrDefault();
            return View(c.Personels.Where(x => x.DepartmanId == id.Value).ToList());
        }

        [HttpGet]
        public ActionResult DepartmanPersonelSatis(int? id)
        {
            ViewBag.Personel = c.Personels.Where(x => x.PersonelId == id.Value).Select(x => x.PersonelAd + " " + x.PersonelSoyad).FirstOrDefault();
            return View(c.SatisHarekets.Where(x => x.PersonelId == id.Value).ToList());
        }
    }
}