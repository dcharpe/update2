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
    public class WORKSTREAMs1Controller : Controller
    {
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // GET: WORKSTREAMs1
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var wORKSTREAMS = db.WORKSTREAMS.Include(w => w.CATEGORy).Include(w => w.SUBCATEGORy).Include(w => w.TEAM);
            return View(wORKSTREAMS.ToList());
        }


        // GET: WORKSTREAMs1/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName");
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORIES, "subcategoryID", "subcategoryName");
            ViewBag.teamID = new SelectList(db.TEAMS, "teamID", "teamName");
            return View();
        }

        // POST: WORKSTREAMs1/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "workstreamID,workstreamName,teamID,categoryID,subcategoryID")] WORKSTREAM wORKSTREAM)
        {
            if (ModelState.IsValid)
            {
                db.WORKSTREAMS.Add(wORKSTREAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName", wORKSTREAM.categoryID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORIES, "subcategoryID", "subcategoryName", wORKSTREAM.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMS, "teamID", "teamName", wORKSTREAM.teamID);
            return View(wORKSTREAM);
        }

        // GET: WORKSTREAMs1/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKSTREAM wORKSTREAM = db.WORKSTREAMS.Find(id);
            if (wORKSTREAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName", wORKSTREAM.categoryID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORIES, "subcategoryID", "subcategoryName", wORKSTREAM.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMS, "teamID", "teamName", wORKSTREAM.teamID);
            return View(wORKSTREAM);
        }

        // POST: WORKSTREAMs1/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "workstreamID,workstreamName,teamID,categoryID,subcategoryID")] WORKSTREAM wORKSTREAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wORKSTREAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName", wORKSTREAM.categoryID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORIES, "subcategoryID", "subcategoryName", wORKSTREAM.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMS, "teamID", "teamName", wORKSTREAM.teamID);
            return View(wORKSTREAM);
        }

        // GET: WORKSTREAMs1/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKSTREAM wORKSTREAM = db.WORKSTREAMS.Find(id);
            if (wORKSTREAM == null)
            {
                return HttpNotFound();
            }
            return View(wORKSTREAM);
        }

        // POST: WORKSTREAMs1/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WORKSTREAM wORKSTREAM = db.WORKSTREAMS.Find(id);
            db.WORKSTREAMS.Remove(wORKSTREAM);
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
