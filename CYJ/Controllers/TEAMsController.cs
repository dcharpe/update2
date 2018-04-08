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
    public class TEAMsController : Controller
    {
        private cyjEntities db = new cyjEntities();

        // GET: TEAMs
        public ActionResult Index()
        {
            return View(db.TEAMs.ToList());
        }

        // GET: TEAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEAM tEAM = db.TEAMs.Find(id);
            if (tEAM == null)
            {
                return HttpNotFound();
            }
            return View(tEAM);
        }

        // GET: TEAMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TEAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "TeamID,TeamName")] TEAM tEAM)
        {
            if (ModelState.IsValid)
            {
                db.TEAMs.Add(tEAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tEAM);
        }

        // GET: TEAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEAM tEAM = db.TEAMs.Find(id);
            if (tEAM == null)
            {
                return HttpNotFound();
            }
            return View(tEAM);
        }

        // POST: TEAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "TeamID,TeamName")] TEAM tEAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tEAM);
        }

        // GET: TEAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEAM tEAM = db.TEAMs.Find(id);
            if (tEAM == null)
            {
                return HttpNotFound();
            }
            return View(tEAM);
        }

        // POST: TEAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TEAM tEAM = db.TEAMs.Find(id);
            db.TEAMs.Remove(tEAM);
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
