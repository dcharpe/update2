using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CYJ.Models;
using System.Web.Script.Services;
using System.Web.Services;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CYJ.Controllers
{
    [Authorize]
    public class GOALACTUALsController : Controller
    {
        
        private cyjEntities db = new cyjEntities();


        // GET: GOALACTUALs
        public ActionResult Index()
        {
            var gOALACTUALs = db.GOALACTUALs.Include(g => g.CATEGORY).Include(g => g.FISCALYEAR).Include(g => g.QUARTEROPTION).Include(g => g.SUBCATEGORY).Include(g => g.TEAM).Include(g => g.WORKSTREAM).Include(g => g.WORKSTREAM1);
            return View(gOALACTUALs.ToList());
        }

        public ViewResult FilterPeriod(string searchString)
        {
            var goals = from g in db.GOALACTUALs
                        select g;
            if (!String.IsNullOrEmpty(searchString))
            {
                goals = goals.Where(g => g.QUARTEROPTION.quarterOpt.Contains(searchString));
            }
            return View(goals.ToList());
        }

        public ViewResult FilterWorkstream(string searchString)
        {
            var goals = from g in db.GOALACTUALs
                        select g;
            if (!String.IsNullOrEmpty(searchString))
            {
                goals = goals.Where(g => g.WORKSTREAM.workstreamName.Contains(searchString));
            }
            return View(goals.ToList());
        }

        public ViewResult FilterFY(int searchString)
        {
            var goals = from g in db.GOALACTUALs
                        select g;
            goals = goals.Where(g => g.FISCALYEAR.fy.Equals(searchString));
            return View(goals.ToList());
        }

        // GET: GOALACTUALs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOALACTUAL gOALACTUAL = db.GOALACTUALs.Find(id);
            if (gOALACTUAL == null)
            {
                return HttpNotFound();
            }
            return View(gOALACTUAL);
        }

        // GET: GOALACTUALs/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName");
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARs, "fiscalYearID", "fiscalYearID");
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONs, "quarteroptionID", "quarterOpt");
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORies, "subcategoryID", "subcategoryName");
            ViewBag.teamID = new SelectList(db.TEAMs, "TeamID", "TeamName");
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMs, "workstreamID", "workstreamName");
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMs, "workstreamID", "workstreamName");
            return View();
        }

        // POST: GOALACTUALs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "goalActualID,goalValue,actualGoal,teamID,workstreamID,categoryID,subcategoryID,fiscalYearID,quarteroptionID")] GOALACTUAL gOALACTUAL)
        {
            if (ModelState.IsValid)
            {
                db.GOALACTUALs.Add(gOALACTUAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName", gOALACTUAL.categoryID);
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARs, "fiscalYearID", "fiscalYearID", gOALACTUAL.fiscalYearID);
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONs, "quarteroptionID", "quarterOpt", gOALACTUAL.quarteroptionID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORies, "subcategoryID", "subcategoryName", gOALACTUAL.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMs, "TeamID", "TeamName", gOALACTUAL.teamID);
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMs, "workstreamID", "workstreamName", gOALACTUAL.workstreamID);
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMs, "workstreamID", "workstreamName", gOALACTUAL.workstreamID);
            return View(gOALACTUAL);
        }

        // GET: GOALACTUALs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOALACTUAL gOALACTUAL = db.GOALACTUALs.Find(id);
            if (gOALACTUAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName", gOALACTUAL.categoryID);
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARs, "fiscalYearID", "fiscalYearID", gOALACTUAL.fiscalYearID);
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONs, "quarteroptionID", "quarterOpt", gOALACTUAL.quarteroptionID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORies, "subcategoryID", "subcategoryName", gOALACTUAL.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMs, "TeamID", "TeamName", gOALACTUAL.teamID);
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMs, "workstreamID", "workstreamName", gOALACTUAL.workstreamID);
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMs, "workstreamID", "workstreamName", gOALACTUAL.workstreamID);
            return View(gOALACTUAL);
        }

        // POST: GOALACTUALs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "goalActualID,goalValue,actualGoal,teamID,workstreamID,categoryID,subcategoryID,fiscalYearID,quarteroptionID")] GOALACTUAL gOALACTUAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gOALACTUAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.CATEGORies, "categoryID", "categoryName", gOALACTUAL.categoryID);
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARs, "fiscalYearID", "fiscalYearID", gOALACTUAL.fiscalYearID);
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONs, "quarteroptionID", "quarterOpt", gOALACTUAL.quarteroptionID);
            ViewBag.subcategoryID = new SelectList(db.SUBCATEGORies, "subcategoryID", "subcategoryName", gOALACTUAL.subcategoryID);
            ViewBag.teamID = new SelectList(db.TEAMs, "TeamID", "TeamName", gOALACTUAL.teamID);
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMs, "workstreamID", "workstreamName", gOALACTUAL.workstreamID);
            ViewBag.workstreamID = new SelectList(db.WORKSTREAMs, "workstreamID", "workstreamName", gOALACTUAL.workstreamID);
            return View(gOALACTUAL);
        }

        // GET: GOALACTUALs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GOALACTUAL gOALACTUAL = db.GOALACTUALs.Find(id);
            if (gOALACTUAL == null)
            {
                return HttpNotFound();
            }
            return View(gOALACTUAL);
        }

        // POST: GOALACTUALs/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GOALACTUAL gOALACTUAL = db.GOALACTUALs.Find(id);
            db.GOALACTUALs.Remove(gOALACTUAL);
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
