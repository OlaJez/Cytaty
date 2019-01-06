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
    public class MyslicieleController : Controller
    {
        private CytatyConnection db = new CytatyConnection();

        // GET: Mysliciele
        public ActionResult Index()
        {
            return View(db.Mysliciele.ToList());
        }

        // GET: Mysliciele/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mysliciele mysliciele = db.Mysliciele.Find(id);
            if (mysliciele == null)
            {
                return HttpNotFound();
            }
            return View(mysliciele);
        }

        // GET: Mysliciele/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mysliciele/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Mysliciel,Mysliciel,Lata_życia,Biogram,DataDodania,DataEdycji")] Mysliciele mysliciele)
        {
            if (ModelState.IsValid)
            {
                db.Mysliciele.Add(mysliciele);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mysliciele);
        }

        // GET: Mysliciele/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mysliciele mysliciele = db.Mysliciele.Find(id);
            if (mysliciele == null)
            {
                return HttpNotFound();
            }
            return View(mysliciele);
        }

        // POST: Mysliciele/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Mysliciel,Mysliciel,Lata_życia,Biogram,DataDodania,DataEdycji")] Mysliciele mysliciele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mysliciele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mysliciele);
        }

        // GET: Mysliciele/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mysliciele mysliciele = db.Mysliciele.Find(id);
            if (mysliciele == null)
            {
                return HttpNotFound();
            }
            return View(mysliciele);
        }

        // POST: Mysliciele/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mysliciele mysliciele = db.Mysliciele.Find(id);
            db.Mysliciele.Remove(mysliciele);
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
