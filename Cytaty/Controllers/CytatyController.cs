using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cytaty.Models;

namespace Cytaty.Controllers
{
    public class CytatyController : Controller
    {
        private CytatyConnection db = new CytatyConnection();

        // GET: Cytaty
        public ActionResult Index()
        {
            var cytaty = db.Cytaty.Include(c => c.Mysliciele);
            return View(cytaty.ToList());
        }

        //do strony ostatnio dodane cytaty
        public ActionResult OstatnioDodane()
        {
            var cytaty = db.Cytaty.Include(c => c.Mysliciele);
            return View(cytaty.OrderByDescending(c=> c.DataDodania).Take(3));

        }



        // GET: Cytaty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cytaty.Models.Cytaty cytaty = db.Cytaty.Find(id);
            if (cytaty == null)
            {
                return HttpNotFound();
            }
            return View(cytaty);
        }

        // GET: Cytaty/Create
        public ActionResult Create()
        {
            ViewBag.ID_Mysliciel = new SelectList(db.Mysliciele, "ID_Mysliciel", "Mysliciel");
            ViewBag.ID_SlowoKlucz = new SelectList(db.SłowaKluczowe, "ID_SlowoKlucz", "Tag");
            return View();
           
        }


        // POST: Cytaty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cytat,Cytat,ID_Mysliciel,ID_SlowoKlucz,DataDodania,DataEdycji")] Cytaty.Models.Cytaty cytaty)
        {
            if (ModelState.IsValid)
            {
                cytaty.DataDodania = DateTime.Now;
                cytaty.DataEdycji = DateTime.Now;
                db.Cytaty.Add(cytaty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Mysliciel = new SelectList(db.Mysliciele, "ID_Mysliciel", "Mysliciel", cytaty.ID_Mysliciel);
            return View(cytaty);
        }

        // GET: Cytaty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cytaty.Models.Cytaty cytaty = db.Cytaty.Find(id);
            if (cytaty == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Mysliciel = new SelectList(db.Mysliciele, "ID_Mysliciel", "Mysliciel", cytaty.ID_Mysliciel);
            ViewBag.ID_SlowoKlucz = new SelectList(db.SłowaKluczowe, "ID_SlowoKlucz", "Tag");
            return View(cytaty);
        }

        // POST: Cytaty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cytat,Cytat,ID_Mysliciel,ID_SlowoKlucz,DataDodania,DataEdycji")] Cytaty.Models.Cytaty cytaty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cytaty).State = EntityState.Modified;
                cytaty.DataEdycji = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Mysliciel = new SelectList(db.Mysliciele, "ID_Mysliciel", "Mysliciel", cytaty.ID_Mysliciel);
            return View(cytaty);
        }

        // GET: Cytaty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cytaty.Models.Cytaty cytaty = db.Cytaty.Find(id);
            if (cytaty == null)
            {
                return HttpNotFound();
            }
            return View(cytaty);
        }

        // POST: Cytaty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cytaty.Models.Cytaty cytaty = db.Cytaty.Find(id);
            db.Cytaty.Remove(cytaty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
