using Cytaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;


namespace Cytaty.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(Cytaty.Models.ZapytanieWyszukiwarka zapytanieUzytkownika)
        {
            //jesli nie jest null
            if (ModelState.IsValid)
            {
                CytatyConnection db = new CytatyConnection();
                
                //wyszukiwanie
                var cytaty = db.Cytaty.Where(c => c.Cytat.Contains(zapytanieUzytkownika.zapytanie)||c.Mysliciele.Mysliciel.Contains(zapytanieUzytkownika.zapytanie) ).Include(c => c.Mysliciele);
                return View("Result", cytaty);
            }

            return View(zapytanieUzytkownika);
        }

    }
}
