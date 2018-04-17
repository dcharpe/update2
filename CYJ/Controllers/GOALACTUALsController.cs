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
    public class GOALACTUALsController : Controller
    {
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // GET: GOALACTUALs
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var gOALACTUALS = db.GOALACTUALS.Include(g => g.CATEGORy).Include(g => g.FISCALYEAR).Include(g => g.QUARTEROPTION).Include(g => g.SUBCATEGORy).Include(g => g.TEAM).Include(g => g.WORKSTREAM);
            return View(gOALACTUALS.ToList());
        }

        [Authorize(Roles = "Admin, Observer")]
        public ViewResult FilterPeriod(string searchString)
        {
            var goals = from g in db.GOALACTUALS
                        select g;
            if (!String.IsNullOrEmpty(searchString))
            {
                goals = goals.Where(g => g.QUARTEROPTION.quarteroptionName.Contains(searchString));
            }
            return View(goals.ToList());
        }

        [Authorize(Roles = "Admin, Observer")]
        public ViewResult FilterWorkstream(string searchString)
        {
            var goals = from g in db.GOALACTUALS
                        select g;
            if (!String.IsNullOrEmpty(searchString))
            {
                goals = goals.Where(g => g.WORKSTREAM.workstreamName.Contains(searchString));
            }
            return View(goals.ToList());
        }

        [Authorize(Roles = "Admin, Observer")]
        public ViewResult FilterFY(int searchString)
        {
            var goals = from g in db.GOALACTUALS
                        select g;
            goals = goals.Where(g => g.FISCALYEAR.fiscalYear1.Equals(searchString));
            return View(goals.ToList());
        }


        // GET: GOALACTUALs/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName");
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARS, "fiscalYearID", "fiscalYear1");
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONS, "quarteroptionID", "quarteroptionName");
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORIES, "subcategoryID", "subcategoryName");
            ViewBag.teamID = new SelectList(db.TEAMS, "teamID", "teamName");
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMS, "workstreamID", "workstreamName");
            return View();
        }

        // POST: GOALACTUALs/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "goalActualID,goalValue,actualGoal,teamID,workstreamID,categoryID,subcategoryID,fiscalYearID,quarteroptionID")] GOALACTUAL gOALACTUAL)
        {
            if (ModelState.IsValid)
            {
                db.GOALACTUALS.Add(gOALACTUAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName", gOALACTUAL.categoryID);
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARS, "fiscalYearID", "fiscalYear1", gOALACTUAL.fiscalYearID);
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONS, "quarteroptionID", "quarteroptionName", gOALACTUAL.quarteroptionID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORIES, "subcategoryID", "subcategoryName", gOALACTUAL.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMS, "teamID", "teamName", gOALACTUAL.teamID);
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMS, "workstreamID", "workstreamName", gOALACTUAL.workstreamID);
            return View(gOALACTUAL);
        }

        // GET: GOALACTUALs/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOALACTUAL gOALACTUAL = db.GOALACTUALS.Find(id);
            if (gOALACTUAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName", gOALACTUAL.categoryID);
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARS, "fiscalYearID", "fiscalYear1", gOALACTUAL.fiscalYearID);
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONS, "quarteroptionID", "quarteroptionName", gOALACTUAL.quarteroptionID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORIES, "subcategoryID", "subcategoryName", gOALACTUAL.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMS, "teamID", "teamName", gOALACTUAL.teamID);
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMS, "workstreamID", "workstreamName", gOALACTUAL.workstreamID);
            return View(gOALACTUAL);
        }

        // POST: GOALACTUALs/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "goalActualID,goalValue,actualGoal,teamID,workstreamID,categoryID,subcategoryID,fiscalYearID,quarteroptionID")] GOALACTUAL gOALACTUAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gOALACTUAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.CATEGORIES, "categoryID", "categoryName", gOALACTUAL.categoryID);
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARS, "fiscalYearID", "fiscalYear1", gOALACTUAL.fiscalYearID);
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONS, "quarteroptionID", "quarteroptionName", gOALACTUAL.quarteroptionID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORIES, "subcategoryID", "subcategoryName", gOALACTUAL.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMS, "teamID", "teamName", gOALACTUAL.teamID);
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMS, "workstreamID", "workstreamName", gOALACTUAL.workstreamID);
            return View(gOALACTUAL);
        }

        // GET: GOALACTUALs/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOALACTUAL gOALACTUAL = db.GOALACTUALS.Find(id);
            if (gOALACTUAL == null)
            {
                return HttpNotFound();
            }
            return View(gOALACTUAL);
        }

        // POST: GOALACTUALs/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
  
        public ActionResult DeleteConfirmed(int id)
        {
            GOALACTUAL gOALACTUAL = db.GOALACTUALS.Find(id);
            db.GOALACTUALS.Remove(gOALACTUAL);
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
