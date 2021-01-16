using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        private Context c = new Context();

        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                c.Kategoris.Add(kategori);
                c.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        public ActionResult KategoriSil(int? id)
        {
            var k = c.Kategoris.Find(id.Value);
            c.Kategoris.Remove(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KategoriGuncelle(int? id)
        {
            var k = c.Kategoris.Find(id);
            return View(k);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                var k = c.Kategoris.Find(kategori.KategoriId);
                k.KategoriAd = kategori.KategoriAd;
                c.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategori);
        }
    }
}