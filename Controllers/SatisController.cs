using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        private Context c = new Context();
        public ActionResult Index()
        {
            return View(c.SatisHarekets.ToList());
        }

        [HttpGet]
        public ActionResult YeniSatisYap()
        {
            List<SelectListItem> listUrunler = (from u in c.Uruns.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = u.UrunAd,
                                                    Value = u.UrunId.ToString()
                                                }).ToList();

            List<SelectListItem> listCariler = (from u in c.Carilers.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = u.CariAd + " " + u.CariSoyad,
                                                    Value = u.CariId.ToString()
                                                }).ToList();

            List<SelectListItem> listPersoneller = (from u in c.Personels.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = u.PersonelAd + " " + u.PersonelSoyad,
                                                        Value = u.PersonelId.ToString()
                                                    }).ToList();

            ViewBag.Urunler = listUrunler;
            ViewBag.Cariler = listCariler;
            ViewBag.Personeller = listPersoneller;

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatisYap(SatisHareket satisHareket)
        {
            if (ModelState.IsValid)
            {
                satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToLongDateString());
                c.SatisHarekets.Add(satisHareket);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(satisHareket);
        }

        [HttpGet]
        public ActionResult SatisGuncelle(int? id)
        {
            List<SelectListItem> listUrunler = (from u in c.Uruns.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = u.UrunAd,
                                                    Value = u.UrunId.ToString()
                                                }).ToList();

            List<SelectListItem> listCariler = (from u in c.Carilers.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = u.CariAd + " " + u.CariSoyad,
                                                    Value = u.CariId.ToString()
                                                }).ToList();

            List<SelectListItem> listPersoneller = (from u in c.Personels.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = u.PersonelAd + " " + u.PersonelSoyad,
                                                        Value = u.PersonelId.ToString()
                                                    }).ToList();

            ViewBag.Urunler = listUrunler;
            ViewBag.Cariler = listCariler;
            ViewBag.Personeller = listPersoneller;

            return View(c.SatisHarekets.Find(id.Value));
        }

        public ActionResult SatisGuncelle(SatisHareket satisHareket)
        {
            if (ModelState.IsValid)
            {
                var s = c.SatisHarekets.Find(satisHareket.SatisId);
                s.UrunId = satisHareket.UrunId;
                s.CariId = satisHareket.CariId;
                s.PersonelId = satisHareket.PersonelId;
                s.Fiyat = satisHareket.Fiyat;
                s.Adet = satisHareket.Adet;
                s.ToplamTutar = satisHareket.ToplamTutar;
                s.Tarih = DateTime.Parse(DateTime.Now.ToLongDateString());
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(satisHareket);
        }

        [HttpGet]
        public ActionResult SatisDetay(int? id)
        {
            var s = c.SatisHarekets.Where(x => x.SatisId == id.Value).ToList();
            return View(s);
        }
    }
}