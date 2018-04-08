using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Drawing;
using CYJ.Models;
using System.Collections.Generic;

namespace CYJ.Controllers
{
    public class GRAPHsController : Controller
    {



        // Database 
        private cyjEntities db = new cyjEntities();

        // Charts for Service Delivery View
        public ActionResult ServiceDelivery()
        {

            //ENROLLMENT CHART
            Highcharts enrollmentChart = new Highcharts("enrollmentChart");



            enrollmentChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

            enrollmentChart.SetTitle(new Title()
            {
                Text = "ENROLLMENT"
            });


            // Create objects for X - Axis
            object[] Q1Goal = Q1GoalsEnrollment().Cast<object>().ToArray();
            object[] Q1Actual = Q1ActualsEnrollment().Cast<object>().ToArray();

            // Create objects for Y - Axis
            string[] Subcategories = subCat().ToArray();


            enrollmentChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = Subcategories
            });

            enrollmentChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "# Of students",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            enrollmentChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });


            // Set series for quarterly goals + actuals
            enrollmentChart.SetSeries(new Series[]
            {
                new Series{

                    Name = "Q1 GOAL",
                    Data = new Data(Q1Goal),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "Q1 ACTUAL",
                    Data = new Data(Q1Actual),
                   Color = ColorTranslator.FromHtml("#bedde0")
                }

            }
            );



            return View(enrollmentChart);
        }



        // Get the data for Q1 Goals
        public List<string> Q1GoalsEnrollment()
        {
            var cats = db.CATEGORies;
            var subcats = db.SUBCATEGORies;
            var goals = db.GOALACTUALs;

            var q1enrollmentQuery = (from y in goals
                                     where y.subcategoryID == 4 && y.quarteroptionID == 1
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         goalValue = y.goalValue
                                     }).ToList();

            List<string> q1Goals = new List<string>();

            foreach (var t in q1enrollmentQuery)
            {

                q1Goals.Add(t.goalValue);

            }

            return q1Goals;

        }

        // Enrollment - Quarter 1 ACTUALS
        public List<string> Q1ActualsEnrollment()
        {

            var cats = db.CATEGORies;
            var subcats = db.SUBCATEGORies;
            var goals = db.GOALACTUALs;

            var q1enrollmentQuery = (from y in goals
                                     where y.subcategoryID == 4 && y.quarteroptionID == 1
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         actualGoal = y.actualGoal
                                     }).ToList();


            List<string> q1Actuals = new List<string>();

            foreach (var t in q1enrollmentQuery)
            {

                q1Actuals.Add(t.actualGoal);

            }

            return q1Actuals;



        }















        public List<string> subCat()
        {
            var cats = db.CATEGORies;
            var subcats = db.SUBCATEGORies;
            var goals = db.GOALACTUALs;

            var enrollmentQuery = (from y in goals
                                   where y.subcategoryID == 4
                                   join x in cats
                                   on y.categoryID equals x.categoryID
                                   join z in subcats
                                   on y.subcategoryID equals z.subcategoryID
                                   select new
                                   {
                                       subcatTypes = x.categoryName
                                   }).ToList();

            List<string> subCats = new List<string>();

            foreach (var t in enrollmentQuery)
            {

                subCats.Add(t.subcatTypes);

            }

            return subCats;
        }

        public ActionResult CorpMemberExperience()
        {
            return View();
        }

        public ActionResult ExternalAffairs()
        {
            return View();
        }

        public ActionResult OpEx()
        {
            return View();
        }

        public ActionResult RAD()
        {
            return View();
        }

        public ActionResult Revenue()
        {
            return View();
        }

    }



}