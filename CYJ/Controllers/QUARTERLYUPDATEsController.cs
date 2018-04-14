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
    public class QUARTERLYUPDATEsController : Controller
    {
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // GET: QUARTERLYUPDATEs
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.QUARTERLYUPDATEs.ToList());
        }

        [Authorize(Roles = "Admin, Observer")]
        public ActionResult Home()
        {
            return View(db.ABOUTs.ToList());
        }

        // GET: QUARTERLYUPDATEs/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: QUARTERLYUPDATEs/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "updateID,updateHeader,updateBody,updateDate")] QUARTERLYUPDATE qUARTERLYUPDATE)
        {
            if (ModelState.IsValid)
            {
                db.QUARTERLYUPDATEs.Add(qUARTERLYUPDATE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUARTERLYUPDATE);
        }

        // GET: QUARTERLYUPDATEs/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUARTERLYUPDATE qUARTERLYUPDATE = db.QUARTERLYUPDATEs.Find(id);
            if (qUARTERLYUPDATE == null)
            {
                return HttpNotFound();
            }
            return View(qUARTERLYUPDATE);
        }

        // POST: QUARTERLYUPDATEs/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "updateID,updateHeader,updateBody,updateDate")] QUARTERLYUPDATE qUARTERLYUPDATE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUARTERLYUPDATE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUARTERLYUPDATE);
        }

        // GET: QUARTERLYUPDATEs/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUARTERLYUPDATE qUARTERLYUPDATE = db.QUARTERLYUPDATEs.Find(id);
            if (qUARTERLYUPDATE == null)
            {
                return HttpNotFound();
            }
            return View(qUARTERLYUPDATE);
        }

        // POST: QUARTERLYUPDATEs/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            QUARTERLYUPDATE qUARTERLYUPDATE = db.QUARTERLYUPDATEs.Find(id);
            db.QUARTERLYUPDATEs.Remove(qUARTERLYUPDATE);
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
