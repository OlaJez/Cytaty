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
    public class UtworyController : Controller
    {
        private CytatyConnection db = new CytatyConnection();

        // GET: Utwory
        public ActionResult Index()
        {
            var utwory = db.Utwory.Include(u => u.Mysliciele);
            return View(utwory.ToList());
        }

        // GET: Utwory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utwory utwory = db.Utwory.Find(id);
            if (utwory == null)
            {
                return HttpNotFound();
            }
            return View(utwory);
        }

        // GET: Utwory/Create
        public ActionResult Create()
        {
            ViewBag.ID_Mysliciel = new SelectList(db.Mysliciele, "ID_Mysliciel", "Mysliciel");
            return View();
        }

        // POST: Utwory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Utwor,Tytuł,RokWydania,ID_Mysliciel")] Utwory utwory)
        {
            if (ModelState.IsValid)
            {
                db.Utwory.Add(utwory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Mysliciel = new SelectList(db.Mysliciele, "ID_Mysliciel", "Mysliciel", utwory.ID_Mysliciel);
            return View(utwory);
        }

        // GET: Utwory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utwory utwory = db.Utwory.Find(id);
            if (utwory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Mysliciel = new SelectList(db.Mysliciele, "ID_Mysliciel", "Mysliciel", utwory.ID_Mysliciel);
            return View(utwory);
        }

        // POST: Utwory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Utwor,Tytuł,RokWydania,ID_Mysliciel")] Utwory utwory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utwory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Mysliciel = new SelectList(db.Mysliciele, "ID_Mysliciel", "Mysliciel", utwory.ID_Mysliciel);
            return View(utwory);
        }

        // GET: Utwory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utwory utwory = db.Utwory.Find(id);
            if (utwory == null)
            {
                return HttpNotFound();
            }
            return View(utwory);
        }

        // POST: Utwory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utwory utwory = db.Utwory.Find(id);
            db.Utwory.Remove(utwory);
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
