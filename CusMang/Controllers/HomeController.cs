﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CusMang.Models;

namespace CusMang.Controllers
{
    public class HomeController : Controller
    {
        private CusDBEntities db = new CusDBEntities();

        public ActionResult Index()
        {

            //var v = db.客戶資料.ToList();
            //int i = v.Count;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}