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
    [Authorize(Roles = "Admin, Observer")]
    public class CorpsMemberExperienceController : Controller
    {
        // Database 
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // Charts for Corps Member Experience View
        public ActionResult CorpMemberExperience()
        {

            Highcharts retentionChart = new Highcharts("retentionChart");



            retentionChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

            retentionChart.SetTitle(new Title()
            {
                Text = "AMERICORPS RETENTION"
            });


            // Create objects for X - Axis
            object[] Q1Goal = Q1GoalsRetention().Cast<object>().ToArray();
            object[] Q1Actual = Q1ActualsRetention().Cast<object>().ToArray();
            object[] Q2Goal = Q2GoalsRetention().Cast<object>().ToArray();
            object[] Q2Actual = Q2ActualsRetention().Cast<object>().ToArray();
            object[] Q3Goal = Q3GoalsRetention().Cast<object>().ToArray();
            object[] Q3Actual = Q3ActualsRetention().Cast<object>().ToArray();
            object[] Q4Goal = Q4GoalsRetention().Cast<object>().ToArray();
            object[] Q4Actual = Q4ActualsRetention().Cast<object>().ToArray();
            object[] AnnualGoal = AnnualGoalsRetention().Cast<object>().ToArray();
            object[] AnnualActual = AnnualActualsRetention().Cast<object>().ToArray();
            object[] BestofCYGoal = BestofCYGoalsRetention().Cast<object>().ToArray();
            object[] BestofCYActual = BestofCYActualsRetention().Cast<object>().ToArray();

            // Create objects for Y - Axis
            string[] Subcategories = subCat().ToArray();


            retentionChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = Subcategories
            });

            retentionChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "# Of AmeriCorps Members",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            retentionChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });


            // Set series for quarterly goals + actuals
            retentionChart.SetSeries(new Series[]
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
                },

                new Series{

                    Name = "Q2 GOAL",
                    Data = new Data(Q2Goal),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "Q2 ACTUAL",
                    Data = new Data(Q2Actual),
                   Color = ColorTranslator.FromHtml("#bedde0")
                },

                new Series{

                    Name = "Q3 GOAL",
                    Data = new Data(Q3Goal),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "Q3 ACTUAL",
                    Data = new Data(Q3Actual),
                   Color = ColorTranslator.FromHtml("#bedde0")
                },

                new Series{

                    Name = "Q4 GOAL",
                    Data = new Data(Q4Goal),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "Q4 ACTUAL",
                    Data = new Data(Q4Actual),
                   Color = ColorTranslator.FromHtml("#bedde0")
                },

                new Series{

                    Name = "ANNUAL GOAL",
                    Data = new Data(AnnualGoal),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "ANNUAL ACTUAL",
                    Data = new Data(AnnualActual),
                   Color = ColorTranslator.FromHtml("#bedde0")
                },
                new Series{

                    Name = "BEST OF CITY YEAR GOAL",
                    Data = new Data(BestofCYGoal),
                   Color = ColorTranslator.FromHtml("#3EC2CF")

                },

                new Series
                {
                    Name = "BEST OF CITY YEAR ACTUAL",
                    Data = new Data(BestofCYActual),
                   Color = ColorTranslator.FromHtml("#bedde0")
                }
            }
            );



            return View(retentionChart);
        }



        // Get the data for Q1 Goals
        public List<string> Q1GoalsRetention()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1retentionQuery = (from y in goals
                                     where y.subcategoryID == 7 && y.quarteroptionID == 1
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         goalValue = y.goalValue
                                     }).ToList();

            List<string> q1Goals = new List<string>();

            foreach (var t in q1retentionQuery)
            {

                q1Goals.Add(t.goalValue);

            }

            return q1Goals;

        }
        //Get the data for Q2 Retention goals
        public List<string> Q2GoalsRetention()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2retentionQuery = (from y in goals
                                    where y.subcategoryID == 7 && y.quarteroptionID == 2
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q2Goals = new List<string>();

            foreach (var t in q2retentionQuery)
            {

                q2Goals.Add(t.goalValue);

            }

            return q2Goals;

        }

        //Get the data for Q3 Retention Goals
        public List<string> Q3GoalsRetention()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3retentionQuery = (from y in goals
                                    where y.subcategoryID == 7 && y.quarteroptionID == 3
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q3Goals = new List<string>();

            foreach (var t in q3retentionQuery)
            {

                q3Goals.Add(t.goalValue);

            }

            return q3Goals;

        }

        //Get the data for Q4 Retention Goals
        public List<string> Q4GoalsRetention()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4retentionQuery = (from y in goals
                                    where y.subcategoryID == 7 && y.quarteroptionID == 4
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q4Goals = new List<string>();

            foreach (var t in q4retentionQuery)
            {

                q4Goals.Add(t.goalValue);

            }

            return q4Goals;

        }


        //Get the data for Annual Retention Goals
        public List<string> AnnualGoalsRetention()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var annualretentionQuery = (from y in goals
                                    where y.subcategoryID == 7 && y.quarteroptionID == 5
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> annualGoals = new List<string>();

            foreach (var t in annualretentionQuery)
            {

                annualGoals.Add(t.goalValue);

            }

            return annualGoals;

        }

        //Get the data for Best of City Year Retention Goals
        public List<string> BestofCYGoalsRetention()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var bestofcyretentionQuery = (from y in goals
                                    where y.subcategoryID == 7 && y.quarteroptionID == 6
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> bestofcyGoals = new List<string>();

            foreach (var t in bestofcyretentionQuery)
            {

                bestofcyGoals.Add(t.goalValue);

            }

            return bestofcyGoals;

        }

        // Retention - Quarter 1 ACTUALS
        public List<string> Q1ActualsRetention()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1retentionQuery = (from y in goals
                                     where y.subcategoryID == 7 && y.quarteroptionID == 1
                                     join x in cats
                                     on y.categoryID equals x.categoryID
                                     join z in subcats
                                     on y.subcategoryID equals z.subcategoryID
                                     select new
                                     {
                                         actualGoal = y.actualGoal
                                     }).ToList();


            List<string> q1Actuals = new List<string>();

            foreach (var t in q1retentionQuery)
            {

                q1Actuals.Add(t.actualGoal);

            }

            return q1Actuals;



        }

        //Get Q2 Retention Actuals
        public List<string> Q2ActualsRetention()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2retentionQuery = (from y in goals
                                    where y.subcategoryID == 7 && y.quarteroptionID == 2
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q2Actuals = new List<string>();

            foreach (var t in q2retentionQuery)
            {

                q2Actuals.Add(t.actualGoal);

            }

            return q2Actuals;
        }

        //Get Q3 Retention Actuals
        public List<string> Q3ActualsRetention()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3retentionQuery = (from y in goals
                                    where y.subcategoryID == 7 && y.quarteroptionID == 3
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q3Actuals = new List<string>();

            foreach (var t in q3retentionQuery)
            {

                q3Actuals.Add(t.actualGoal);

            }

            return q3Actuals;
        }

        //Get Q4 Retention Actuals
        public List<string> Q4ActualsRetention()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4retentionQuery = (from y in goals
                                    where y.subcategoryID == 7 && y.quarteroptionID == 4
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q4Actuals = new List<string>();

            foreach (var t in q4retentionQuery)
            {

                q4Actuals.Add(t.actualGoal);

            }

            return q4Actuals;
        }

        //Get Annual Retention Actuals
        public List<string> AnnualActualsRetention()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var annualretentionQuery = (from y in goals
                                    where y.subcategoryID == 7 && y.quarteroptionID == 5
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> annualActuals = new List<string>();

            foreach (var t in annualretentionQuery)
            {

                annualActuals.Add(t.actualGoal);

            }

            return annualActuals;
        }

        //Get Best of CY Retention Actuals
        public List<string> BestofCYActualsRetention()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var bestofcyretentionQuery = (from y in goals
                                    where y.subcategoryID == 7 && y.quarteroptionID == 6
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> bestofcyActuals = new List<string>();

            foreach (var t in bestofcyretentionQuery)
            {

                bestofcyActuals.Add(t.actualGoal);

            }

            return bestofcyActuals;
        }

        public List<string> subCat()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var retentionQuery = (from y in goals
                                   where y.subcategoryID == 7
                                   join x in cats
                                   on y.categoryID equals x.categoryID
                                   join z in subcats
                                   on y.subcategoryID equals z.subcategoryID
                                   select new
                                   {
                                       subcatTypes = x.categoryName
                                   }).ToList();

            List<string> subCats = new List<string>();

            foreach (var t in retentionQuery)
            {

                subCats.Add(t.subcatTypes);

            }

            return subCats;
        } 

    }
}
