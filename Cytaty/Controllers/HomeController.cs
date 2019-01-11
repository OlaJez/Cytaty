using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cytaty.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //nie jest zlinkowany, do zrobienia pozniej ewentualnie
        public ActionResult About()
        {
            ViewBag.Message = "O nas. Tutaj moge opisać cos tam o nas.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}