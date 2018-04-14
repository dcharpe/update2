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
    public class QUARTEROPTIONs1Controller : Controller
    {
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // GET: QUARTEROPTIONs1
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var qUARTEROPTIONS = db.QUARTEROPTIONS.Include(q => q.FISCALYEAR);
            return View(qUARTEROPTIONS.ToList());
        }


        // GET: QUARTEROPTIONs1/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARS, "fiscalYearID", "fiscalYearID");
            return View();
        }

        // POST: QUARTEROPTIONs1/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "quarteroptionID,quarteroptionName,subcategoryID,fiscalYearID")] QUARTEROPTION qUARTEROPTION)
        {
            if (ModelState.IsValid)
            {
                db.QUARTEROPTIONS.Add(qUARTEROPTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARS, "fiscalYearID", "fiscalYearID", qUARTEROPTION.fiscalYearID);
            return View(qUARTEROPTION);
        }

        // GET: QUARTEROPTIONs1/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUARTEROPTION qUARTEROPTION = db.QUARTEROPTIONS.Find(id);
            if (qUARTEROPTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARS, "fiscalYearID", "fiscalYearID", qUARTEROPTION.fiscalYearID);
            return View(qUARTEROPTION);
        }

        // POST: QUARTEROPTIONs1/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "quarteroptionID,quarteroptionName,subcategoryID,fiscalYearID")] QUARTEROPTION qUARTEROPTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUARTEROPTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARS, "fiscalYearID", "fiscalYearID", qUARTEROPTION.fiscalYearID);
            return View(qUARTEROPTION);
        }

        // GET: QUARTEROPTIONs1/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUARTEROPTION qUARTEROPTION = db.QUARTEROPTIONS.Find(id);
            if (qUARTEROPTION == null)
            {
                return HttpNotFound();
            }
            return View(qUARTEROPTION);
        }

        // POST: QUARTEROPTIONs1/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            QUARTEROPTION qUARTEROPTION = db.QUARTEROPTIONS.Find(id);
            db.QUARTEROPTIONS.Remove(qUARTEROPTION);
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
