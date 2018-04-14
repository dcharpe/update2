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
    public class TEAMsController : Controller
    {
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // GET: TEAMs
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.TEAMS.ToList());
        }


        // GET: TEAMs/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TEAMs/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "TeamID,TeamName")] TEAM tEAM)
        {
            if (ModelState.IsValid)
            {
                db.TEAMS.Add(tEAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tEAM);
        }

        // GET: TEAMs/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEAM tEAM = db.TEAMS.Find(id);
            if (tEAM == null)
            {
                return HttpNotFound();
            }
            return View(tEAM);
        }

        // POST: TEAMs/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEAM tEAM = db.TEAMS.Find(id);
            if (tEAM == null)
            {
                return HttpNotFound();
            }
            return View(tEAM);
        }

        // POST: TEAMs/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TEAM tEAM = db.TEAMS.Find(id);
            db.TEAMS.Remove(tEAM);
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
