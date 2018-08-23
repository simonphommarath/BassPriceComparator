using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BassPriceComparator.DAL;
using BassPriceComparator.Models;

namespace BassPriceComparator.Controllers
{
    public class BassController : Controller
    {
        private BassDBContext db = new BassDBContext();

        // GET: Bass
        public ActionResult Index()
        {
            return View(db.Basses.ToList());
        }

        // GET: Bass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bass bass = db.Basses.Find(id);
            if (bass == null)
            {
                return HttpNotFound();
            }
            return View(bass);
        }

        // GET: Bass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,model,name,brand,description")] Bass bass)
        {
            if (ModelState.IsValid)
            {
                db.Basses.Add(bass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bass);
        }

        // GET: Bass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bass bass = db.Basses.Find(id);
            if (bass == null)
            {
                return HttpNotFound();
            }
            return View(bass);
        }

        // POST: Bass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,model,name,brand,description")] Bass bass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bass);
        }

        // GET: Bass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bass bass = db.Basses.Find(id);
            if (bass == null)
            {
                return HttpNotFound();
            }
            return View(bass);
        }

        // POST: Bass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bass bass = db.Basses.Find(id);
            db.Basses.Remove(bass);
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
