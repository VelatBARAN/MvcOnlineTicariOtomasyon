﻿using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class HomeController : Controller
    {
        private Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
    }
}