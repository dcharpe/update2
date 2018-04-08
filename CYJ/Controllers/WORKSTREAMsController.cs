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
    public class WORKSTREAMsController : Controller
    {
        private cyjEntities db = new cyjEntities();

        // GET: WORKSTREAMs
        public ActionResult Index()
        {
            var wORKSTREAMs = db.WORKSTREAMs.Include(w => w.CATEGORY).Include(w => w.SUBCATEGORY).Include(w => w.TEAM);
            return View(wORKSTREAMs.ToList());
        }

        // GET: WORKSTREAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKSTREAM wORKSTREAM = db.WORKSTREAMs.Find(id);
            if (wORKSTREAM == null)
            {
                return HttpNotFound();
            }
            return View(wORKSTREAM);
        }

        // GET: WORKSTREAMs/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName");
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORies, "subcategoryID", "subcategoryName");
            ViewBag.teamID = new SelectList(db.TEAMs, "TeamID", "TeamName");
            return View();
        }

        // POST: WORKSTREAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "workstreamID,workstreamName,teamID,categoryID,subcategoryID")] WORKSTREAM wORKSTREAM)
        {
            if (ModelState.IsValid)
            {
                db.WORKSTREAMs.Add(wORKSTREAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName", wORKSTREAM.categoryID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORies, "subcategoryID", "subcategoryName", wORKSTREAM.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMs, "TeamID", "TeamName", wORKSTREAM.teamID);
            return View(wORKSTREAM);
        }

        // GET: WORKSTREAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKSTREAM wORKSTREAM = db.WORKSTREAMs.Find(id);
            if (wORKSTREAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName", wORKSTREAM.categoryID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORies, "subcategoryID", "subcategoryName", wORKSTREAM.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMs, "TeamID", "TeamName", wORKSTREAM.teamID);
            return View(wORKSTREAM);
        }

        // POST: WORKSTREAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "workstreamID,workstreamName,teamID,categoryID,subcategoryID")] WORKSTREAM wORKSTREAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wORKSTREAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName", wORKSTREAM.categoryID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORies, "subcategoryID", "subcategoryName", wORKSTREAM.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMs, "TeamID", "TeamName", wORKSTREAM.teamID);
            return View(wORKSTREAM);
        }

        // GET: WORKSTREAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WORKSTREAM wORKSTREAM = db.WORKSTREAMs.Find(id);
            if (wORKSTREAM == null)
            {
                return HttpNotFound();
            }
            return View(wORKSTREAM);
        }

        // POST: WORKSTREAMs/Delete/5
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            WORKSTREAM wORKSTREAM = db.WORKSTREAMs.Find(id);
            db.WORKSTREAMs.Remove(wORKSTREAM);
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
