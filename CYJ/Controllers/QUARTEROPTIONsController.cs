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
    public class QUARTEROPTIONsController : Controller
    {
        private cyjEntities db = new cyjEntities();

        // GET: QUARTEROPTIONs
        public ActionResult Index()
        {
            var qUARTEROPTIONs = db.QUARTEROPTIONs.Include(q => q.FISCALYEAR);
            return View(qUARTEROPTIONs.ToList());
        }

        // GET: QUARTEROPTIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUARTEROPTION qUARTEROPTION = db.QUARTEROPTIONs.Find(id);
            if (qUARTEROPTION == null)
            {
                return HttpNotFound();
            }
            return View(qUARTEROPTION);
        }

        // GET: QUARTEROPTIONs/Create
        public ActionResult Create()
        {
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARs, "fiscalYearID", "fy");
            return View();
        }

        // POST: QUARTEROPTIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "quarteroptionID,subcategoryID,fiscalYearID,quarterOpt")] QUARTEROPTION qUARTEROPTION)
        {
            if (ModelState.IsValid)
            {
                db.QUARTEROPTIONs.Add(qUARTEROPTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARs, "fiscalYearID", "fiscalYearID", qUARTEROPTION.fiscalYearID);
            return View(qUARTEROPTION);
        }

        // GET: QUARTEROPTIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUARTEROPTION qUARTEROPTION = db.QUARTEROPTIONs.Find(id);
            if (qUARTEROPTION == null)
            {
                return HttpNotFound();
            }
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARs, "fiscalYearID", "fiscalYearID", qUARTEROPTION.fiscalYearID);
            return View(qUARTEROPTION);
        }

        // POST: QUARTEROPTIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "quarteroptionID,subcategoryID,fiscalYearID,quarterOpt")] QUARTEROPTION qUARTEROPTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUARTEROPTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fiscalYearID = new SelectList(db.FISCALYEARs, "fiscalYearID", "fiscalYearID", qUARTEROPTION.fiscalYearID);
            return View(qUARTEROPTION);
        }

        // GET: QUARTEROPTIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUARTEROPTION qUARTEROPTION = db.QUARTEROPTIONs.Find(id);
            if (qUARTEROPTION == null)
            {
                return HttpNotFound();
            }
            return View(qUARTEROPTION);
        }

        // POST: QUARTEROPTIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            QUARTEROPTION qUARTEROPTION = db.QUARTEROPTIONs.Find(id);
            db.QUARTEROPTIONs.Remove(qUARTEROPTION);
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
