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
    public class CATEGORiesController : Controller
    {
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // GET: CATEGORies
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var cATEGORies = db.CATEGORIES.Include(c => c.WORKSTREAM);
            return View(cATEGORies.ToList());
        }


        // GET: CATEGORies/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMS, "workstreamID", "workstreamName");
            return View();
        }

        // POST: CATEGORies/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "categoryID,categoryName,workstreamID")] CATEGORy cATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIES.Add(cATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.workstreamID = new SelectList(db.WORKSTREAMS, "workstreamID", "workstreamName", cATEGORY.workstreamID);
            return View(cATEGORY);
        }

        // GET: CATEGORies/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORy cATEGORY = db.CATEGORIES.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMS, "workstreamID", "workstreamName", cATEGORY.workstreamID);
            return View(cATEGORY);
        }

        // POST: CATEGORies/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "categoryID,categoryName,workstreamID")] CATEGORy cATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMS, "workstreamID", "workstreamName", cATEGORY.workstreamID);
            return View(cATEGORY);
        }

        // GET: CATEGORies/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORy cATEGORY = db.CATEGORIES.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: CATEGORies/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORy cATEGORY = db.CATEGORIES.Find(id);
            db.CATEGORIES.Remove(cATEGORY);
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
