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
    public class FISCALYEARsController : Controller
    {
        private cyjEntities db = new cyjEntities();

        // GET: FISCALYEARs
        public ActionResult Index()
        {
            var fISCALYEARs = db.FISCALYEARs.Include(f => f.QUARTEROPTION);
            return View(fISCALYEARs.ToList());
        }

        // GET: FISCALYEARs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FISCALYEAR fISCALYEAR = db.FISCALYEARs.Find(id);
            if (fISCALYEAR == null)
            {
                return HttpNotFound();
            }
            return View(fISCALYEAR);
        }

        // GET: FISCALYEARs/Create
        public ActionResult Create()
        {
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONs, "quarteroptionID", "quarterOpt");
            return View();
        }

        // POST: FISCALYEARs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "fiscalYearID,fy,quarteroptionID,subcategoryID")] FISCALYEAR fISCALYEAR)
        {
            if (ModelState.IsValid)
            {
                db.FISCALYEARs.Add(fISCALYEAR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONs, "quarteroptionID", "quarterOpt", fISCALYEAR.quarteroptionID);
            return View(fISCALYEAR);
        }

        // GET: FISCALYEARs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FISCALYEAR fISCALYEAR = db.FISCALYEARs.Find(id);
            if (fISCALYEAR == null)
            {
                return HttpNotFound();
            }
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONs, "quarteroptionID", "quarterOpt", fISCALYEAR.quarteroptionID);
            return View(fISCALYEAR);
        }

        // POST: FISCALYEARs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "fiscalYearID,fy,quarteroptionID,subcategoryID")] FISCALYEAR fISCALYEAR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fISCALYEAR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.quarteroptionID = new SelectList(db.QUARTEROPTIONs, "quarteroptionID", "quarterOpt", fISCALYEAR.quarteroptionID);
            return View(fISCALYEAR);
        }

        // GET: FISCALYEARs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FISCALYEAR fISCALYEAR = db.FISCALYEARs.Find(id);
            if (fISCALYEAR == null)
            {
                return HttpNotFound();
            }
            return View(fISCALYEAR);
        }

        // POST: FISCALYEARs/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FISCALYEAR fISCALYEAR = db.FISCALYEARs.Find(id);
            db.FISCALYEARs.Remove(fISCALYEAR);
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
