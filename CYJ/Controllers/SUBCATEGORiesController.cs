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
    [Authorize]
    public class SUBCATEGORiesController : Controller
    {
        private cyjEntities db = new cyjEntities();

        // GET: SUBCATEGORies
        public ActionResult Index()
        {
            var sUBCATEGORies = db.SUBCATEGORies.Include(s => s.CATEGORY);
            return View(sUBCATEGORies.ToList());
        }

        // GET: SUBCATEGORies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORY sUBCATEGORY = db.SUBCATEGORies.Find(id);
            if (sUBCATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(sUBCATEGORY);
        }

        // GET: SUBCATEGORies/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName");
            return View();
        }

        // POST: SUBCATEGORies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "subcategoryID,subcategoryName,categoryID")] SUBCATEGORY sUBCATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.SUBCATEGORies.Add(sUBCATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName", sUBCATEGORY.categoryID);
            return View(sUBCATEGORY);
        }

        // GET: SUBCATEGORies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORY sUBCATEGORY = db.SUBCATEGORies.Find(id);
            if (sUBCATEGORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName", sUBCATEGORY.categoryID);
            return View(sUBCATEGORY);
        }

        // POST: SUBCATEGORies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "subcategoryID,subcategoryName,categoryID")] SUBCATEGORY sUBCATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUBCATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName", sUBCATEGORY.categoryID);
            return View(sUBCATEGORY);
        }

        // GET: SUBCATEGORies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORY sUBCATEGORY = db.SUBCATEGORies.Find(id);
            if (sUBCATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(sUBCATEGORY);
        }

        // POST: SUBCATEGORies/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SUBCATEGORY sUBCATEGORY = db.SUBCATEGORies.Find(id);
            db.SUBCATEGORies.Remove(sUBCATEGORY);
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
