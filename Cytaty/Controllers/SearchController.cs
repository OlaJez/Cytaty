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
                
                //wyszukiwanie, potem zrzucam do listy zeby dzialalo count //include zeby nie bylo tylko id mysliciela
                var cytaty = db.Cytaty.Where(c => c.Cytat.Contains(zapytanieUzytkownika.zapytanie)||c.Mysliciele.Mysliciel.Contains(zapytanieUzytkownika.zapytanie) ).Include(c => c.Mysliciele).ToList();

                //jest w liscie, mozna zrobic count
                if (cytaty.Count > 0)
                {
                    ViewBag.query = zapytanieUzytkownika.zapytanie;
                    return View("Result", cytaty); //przekazanie cytatow
                }
                else
                    return View("NiemaCytatu");
            }


        }

    }
}
