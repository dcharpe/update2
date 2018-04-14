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

namespace CYJ.Views.GRAPHs
{
    public class ReturningACMController : Controller
    {
        // Database 
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // Charts for Corps Member Experience View
        public ActionResult CorpMemberExperience()
        {

            Highcharts returningacmChart = new Highcharts("returningacmChart");



            returningacmChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

            returningacmChart.SetTitle(new Title()
            {
                Text = "2ND YEAR ACM"
            });


            // Create objects for X - Axis
            object[] Q1Goal = Q1GoalsReturningACM().Cast<object>().ToArray();
            object[] Q1Actual = Q1ActualsReturningACM().Cast<object>().ToArray();
            object[] Q2Goal = Q2GoalsReturningACM().Cast<object>().ToArray();
            object[] Q2Actual = Q2ActualsReturningACM().Cast<object>().ToArray();
            object[] Q3Goal = Q3GoalsReturningACM().Cast<object>().ToArray();
            object[] Q3Actual = Q3ActualsReturningACM().Cast<object>().ToArray();
            object[] Q4Goal = Q4GoalsReturningACM().Cast<object>().ToArray();
            object[] Q4Actual = Q4ActualsReturningACM().Cast<object>().ToArray();
            object[] AnnualGoal = AnnualGoalsReturningACM().Cast<object>().ToArray();
            object[] AnnualActual = AnnualActualsReturningACM().Cast<object>().ToArray();
            object[] BestofCYGoal = BestofCYGoalsReturningACM().Cast<object>().ToArray();
            object[] BestofCYActual = BestofCYActualsReturningACM().Cast<object>().ToArray();

            // Create objects for Y - Axis
            string[] Subcategories = subCat().ToArray();


            returningacmChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = Subcategories
            });

            returningacmChart.SetYAxis(new YAxis()
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

            returningacmChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });


            // Set series for quarterly goals + actuals
            returningacmChart.SetSeries(new Series[]
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



            return View(returningacmChart);
        }



        // Get the data for Q1 Goals
        public List<string> Q1GoalsReturningACM()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1returningacmQuery = (from y in goals
                                    where y.subcategoryID == 10 && y.quarteroptionID == 1
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q1Goals = new List<string>();

            foreach (var t in q1returningacmQuery)
            {

                q1Goals.Add(t.goalValue);

            }

            return q1Goals;

        }
        //Get the data for Q2 Returning ACM goals
        public List<string> Q2GoalsReturningACM()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2returningacmQuery = (from y in goals
                                    where y.subcategoryID == 10 && y.quarteroptionID == 2
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q2Goals = new List<string>();

            foreach (var t in q2returningacmQuery)
            {

                q2Goals.Add(t.goalValue);

            }

            return q2Goals;

        }

        //Get the data for Q3 Returning ACM Goals
        public List<string> Q3GoalsReturningACM()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3returningacmQuery = (from y in goals
                                    where y.subcategoryID == 10 && y.quarteroptionID == 3
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q3Goals = new List<string>();

            foreach (var t in q3returningacmQuery)
            {

                q3Goals.Add(t.goalValue);

            }

            return q3Goals;

        }

        //Get the data for Q4 Returning ACM Goals
        public List<string> Q4GoalsReturningACM()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4returningacmQuery = (from y in goals
                                    where y.subcategoryID == 10 && y.quarteroptionID == 4
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q4Goals = new List<string>();

            foreach (var t in q4returningacmQuery)
            {

                q4Goals.Add(t.goalValue);

            }

            return q4Goals;

        }


        //Get the data for Annual Returning ACM Goals
        public List<string> AnnualGoalsReturningACM()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var annualreturningacmQuery = (from y in goals
                                        where y.subcategoryID == 10 && y.quarteroptionID == 5
                                        join x in cats
                                        on y.categoryID equals x.categoryID
                                        join z in subcats
                                        on y.subcategoryID equals z.subcategoryID
                                        select new
                                        {
                                            goalValue = y.goalValue
                                        }).ToList();

            List<string> annualGoals = new List<string>();

            foreach (var t in annualreturningacmQuery)
            {

                annualGoals.Add(t.goalValue);

            }

            return annualGoals;

        }

        //Get the data for Best of City Year Returning ACM Goals
        public List<string> BestofCYGoalsReturningACM()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var bestofcyreturningacmQuery = (from y in goals
                                          where y.subcategoryID == 10 && y.quarteroptionID == 6
                                          join x in cats
                                          on y.categoryID equals x.categoryID
                                          join z in subcats
                                          on y.subcategoryID equals z.subcategoryID
                                          select new
                                          {
                                              goalValue = y.goalValue
                                          }).ToList();

            List<string> bestofcyGoals = new List<string>();

            foreach (var t in bestofcyreturningacmQuery)
            {

                bestofcyGoals.Add(t.goalValue);

            }

            return bestofcyGoals;

        }

        // Returning ACM - Quarter 1 ACTUALS
        public List<string> Q1ActualsReturningACM()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1returningacmQuery = (from y in goals
                                    where y.subcategoryID == 10 && y.quarteroptionID == 1
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q1Actuals = new List<string>();

            foreach (var t in q1returningacmQuery)
            {

                q1Actuals.Add(t.actualGoal);

            }

            return q1Actuals;



        }

        //Get Q2 Returning ACM Actuals
        public List<string> Q2ActualsReturningACM()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2returningacmQuery = (from y in goals
                                    where y.subcategoryID == 10 && y.quarteroptionID == 2
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q2Actuals = new List<string>();

            foreach (var t in q2returningacmQuery)
            {

                q2Actuals.Add(t.actualGoal);

            }

            return q2Actuals;
        }

        //Get Q3 Returning ACM Actuals
        public List<string> Q3ActualsReturningACM()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3returningacmQuery = (from y in goals
                                    where y.subcategoryID == 10 && y.quarteroptionID == 3
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q3Actuals = new List<string>();

            foreach (var t in q3returningacmQuery)
            {

                q3Actuals.Add(t.actualGoal);

            }

            return q3Actuals;
        }

        //Get Q4 Returning ACM Actuals
        public List<string> Q4ActualsReturningACM()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4returningacmQuery = (from y in goals
                                    where y.subcategoryID == 10 && y.quarteroptionID == 4
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q4Actuals = new List<string>();

            foreach (var t in q4returningacmQuery)
            {

                q4Actuals.Add(t.actualGoal);

            }

            return q4Actuals;
        }

        //Get Annual Returning ACM Actuals
        public List<string> AnnualActualsReturningACM()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var annualreturningacmQuery = (from y in goals
                                        where y.subcategoryID == 10 && y.quarteroptionID == 5
                                        join x in cats
                                        on y.categoryID equals x.categoryID
                                        join z in subcats
                                        on y.subcategoryID equals z.subcategoryID
                                        select new
                                        {
                                            actualGoal = y.actualGoal
                                        }).ToList();


            List<string> annualActuals = new List<string>();

            foreach (var t in annualreturningacmQuery)
            {

                annualActuals.Add(t.actualGoal);

            }

            return annualActuals;
        }

        //Get Best of CY Returning ACM Actuals
        public List<string> BestofCYActualsReturningACM()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var bestofcyreturningacmQuery = (from y in goals
                                          where y.subcategoryID == 10 && y.quarteroptionID == 6
                                          join x in cats
                                          on y.categoryID equals x.categoryID
                                          join z in subcats
                                          on y.subcategoryID equals z.subcategoryID
                                          select new
                                          {
                                              actualGoal = y.actualGoal
                                          }).ToList();


            List<string> bestofcyActuals = new List<string>();

            foreach (var t in bestofcyreturningacmQuery)
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

            var returningacmQuery = (from y in goals
                                  where y.subcategoryID == 10
                                  join x in cats
                                  on y.categoryID equals x.categoryID
                                  join z in subcats
                                  on y.subcategoryID equals z.subcategoryID
                                  select new
                                  {
                                      subcatTypes = x.categoryName
                                  }).ToList();

            List<string> subCats = new List<string>();

            foreach (var t in returningacmQuery)
            {

                subCats.Add(t.subcatTypes);

            }

            return subCats;
        }
    }
}