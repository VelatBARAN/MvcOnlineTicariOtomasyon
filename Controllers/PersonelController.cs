using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        private Context c = new Context();
        public ActionResult Index()
        {
            return View(c.Personels.Where(x=>x.Durum == true).ToList());
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> listDepartman = (from k in c.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = k.DepartmanAd,
                                                     Value = k.DepartmanId.ToString()
                                                 }).ToList();

            ViewBag.Departmanlar = listDepartman;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult PersonelEkle(Personel personel)
        {
            if (ModelState.IsValid)
            {
                personel.Durum = true;
                c.Personels.Add(personel);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personel);
        }

        [HttpGet]
        public ActionResult PersonelGuncelle(int? id)
        {
            List<SelectListItem> listDepartman = (from k in c.Departmans.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = k.DepartmanAd,
                                                      Value = k.DepartmanId.ToString()
                                                  }).ToList();

            ViewBag.Departmanlar = listDepartman;
            var p = c.Personels.Find(id.Value);
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult PersonelGuncelle(Personel personel)
        {
            if (ModelState.IsValid)
            {
                var p = c.Personels.Find(personel.PersonelId);
                p.PersonelAd = personel.PersonelAd;
                p.PersonelSoyad = personel.PersonelSoyad;
                p.PersonelGorsel = personel.PersonelGorsel;
                p.DepartmanId = personel.DepartmanId;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personel);
        }

        public ActionResult PersonelSil(int? id)
        {
            var p = c.Personels.Find(id.Value);
            p.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}