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
    public class FISCALYEARs1Controller : Controller
    {
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // GET: FISCALYEARs1
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var fISCALYEARS = db.FISCALYEARS.Include(f => f.QUARTEROPTION);
            return View(fISCALYEARS.ToList());
        }

        // GET: FISCALYEARs1/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONS, "quarteroptionID", "quarteroptionName");
            return View();
        }

        // POST: FISCALYEARs1/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "fiscalYearID,fiscalYear1,subcategoryID,quarteroptionID")] FISCALYEAR fISCALYEAR)
        {
            if (ModelState.IsValid)
            {
                db.FISCALYEARS.Add(fISCALYEAR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONS, "quarteroptionID", "quarteroptionName", fISCALYEAR.quarteroptionID);
            return View(fISCALYEAR);
        }

        // GET: FISCALYEARs1/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FISCALYEAR fISCALYEAR = db.FISCALYEARS.Find(id);
            if (fISCALYEAR == null)
            {
                return HttpNotFound();
            }
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONS, "quarteroptionID", "quarteroptionName", fISCALYEAR.quarteroptionID);
            return View(fISCALYEAR);
        }

        // POST: FISCALYEARs1/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "fiscalYearID,fiscalYear1,subcategoryID,quarteroptionID")] FISCALYEAR fISCALYEAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fISCALYEAR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONS, "quarteroptionID", "quarteroptionName", fISCALYEAR.quarteroptionID);
            return View(fISCALYEAR);
        }

        // GET: FISCALYEARs1/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FISCALYEAR fISCALYEAR = db.FISCALYEARS.Find(id);
            if (fISCALYEAR == null)
            {
                return HttpNotFound();
            }
            return View(fISCALYEAR);
        }

        // POST: FISCALYEARs1/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FISCALYEAR fISCALYEAR = db.FISCALYEARS.Find(id);
            db.FISCALYEARS.Remove(fISCALYEAR);
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
