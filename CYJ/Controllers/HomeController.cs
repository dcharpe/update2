using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CYJ.Models;
using CYJ.Models.ViewModels;

namespace CYJ.Controllers
{
    [Authorize(Roles = "Admin, Observer")]
    public class HomeController : Controller
    {
        private cyjdatabaseEntities db = new cyjdatabaseEntities();
        public HomeController()
        {
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Added()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Observer")]
        public ActionResult ServiceDelivery()
        {
            return View();
        }


        [Authorize(Roles = "Admin, Observer")]
        public ActionResult CorpMemberExperience()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Observer")]
        public ActionResult ExternalAffairs()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Observer")]
        public ActionResult Revenue()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Observer")]
        public ActionResult OpEx()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Observer")]
        public ActionResult RAD()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Observer")]
        public ActionResult Index()
        {
            return View(db.ABOUTs.ToList());
        }

        public JsonResult GetEvents()
        {
            using (cyjdatabaseEntities dc = new cyjdatabaseEntities())
            {
                var events = dc.CALENDARs.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(CALENDAR e)
        {
            var status = false;
            using (cyjdatabaseEntities dc = new cyjdatabaseEntities())
            {
                if (e.eventID > 0)
                {
                    //Update the event
                    var v = dc.CALENDARs.Where(a => a.eventID == e.eventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.eventHeader = e.eventHeader;
                        v.eventStart = e.eventStart;
                        v.eventEnd = e.eventEnd;
                        v.eventDescription = e.eventDescription;
                  
                    }
                }
                else
                {
                    dc.CALENDARs.Add(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (cyjdatabaseEntities dc = new cyjdatabaseEntities())
            {
                var v = dc.CALENDARs.Where(a => a.eventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.CALENDARs.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}