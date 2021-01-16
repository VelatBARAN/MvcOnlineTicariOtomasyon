using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        private Context c = new Context();
        public ActionResult Index()
        {
            return View(c.Uruns.Where(x => x.Durum == true).ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> listKategori = (from k in c.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = k.KategoriAd,
                                                     Value = k.KategoriId.ToString()
                                                 }).ToList();

            ViewBag.Kategoriler = listKategori;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult YeniUrun(Urun urun)
        {
            if (ModelState.IsValid)
            {
                urun.Durum = true;
                c.Uruns.Add(urun);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urun);
        }

        public ActionResult UrunSil(int? id)
        {
            var u = c.Uruns.Find(id.Value);
            u.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UrunGuncelle(int? id)
        {
            List<SelectListItem> listKategori = (from k in c.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = k.KategoriAd,
                                                     Value = k.KategoriId.ToString()
                                                 }).ToList();

            ViewBag.Kategoriler = listKategori;
            var u = c.Uruns.Find(id.Value);
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult UrunGuncelle(Urun urun)
        {
            if (ModelState.IsValid)
            {
                var u = c.Uruns.Find(urun.UrunId);
                u.UrunAd = urun.UrunAd;
                u.Marka = urun.Marka;
                u.Stok = urun.Stok;
                u.AlisFiyat = urun.AlisFiyat;
                u.SatisFiyat = urun.SatisFiyat;
                u.KategoriId = urun.KategoriId;
                u.UrunGorsel = urun.UrunGorsel;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urun);
        }
    }
}