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
            using (cyjEntities1 dc = new cyjEntities1())
            {
                var events = dc.Calendars.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        public JsonResult SaveEvent(Calendar e)
        {
            var status = false;
            using (cyjEntities1 dc = new cyjEntities1())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Calendars.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.isFullDay = e.isFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Calendars.Add(e);
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
            using (cyjEntities1 dc = new cyjEntities1())
            {
                var v = dc.Calendars.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Calendars.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}