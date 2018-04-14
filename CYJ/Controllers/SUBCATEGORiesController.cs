using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CYJ.Models;

namespace CYJ.Controllers
{
    [Authorize(Roles = "Admin, Observer")]
    public class SUBCATEGORiesController : Controller
    {
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // GET: SUBCATEGORies
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var sUBCATEGORies = db.SUBCATEGORIES.Include(s => s.CATEGORy);
            return View(sUBCATEGORies.ToList());
        }


        // GET: SUBCATEGORies/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName");
            return View();
        }

        // POST: SUBCATEGORies/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "subcategoryID,subcategoryName,categoryID")] SUBCATEGORy sUBCATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.SUBCATEGORIES.Add(sUBCATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName", sUBCATEGORY.categoryID);
            return View(sUBCATEGORY);
        }

        // GET: SUBCATEGORies/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORy sUBCATEGORY = db.SUBCATEGORIES.Find(id);
            if (sUBCATEGORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName", sUBCATEGORY.categoryID);
            return View(sUBCATEGORY);
        }

        // POST: SUBCATEGORies/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "subcategoryID,subcategoryName,categoryID")] SUBCATEGORy sUBCATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUBCATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName", sUBCATEGORY.categoryID);
            return View(sUBCATEGORY);
        }

        // GET: SUBCATEGORies/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORy sUBCATEGORY = db.SUBCATEGORIES.Find(id);
            if (sUBCATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(sUBCATEGORY);
        }

        // POST: SUBCATEGORies/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SUBCATEGORy sUBCATEGORY = db.SUBCATEGORIES.Find(id);
            db.SUBCATEGORIES.Remove(sUBCATEGORY);
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
