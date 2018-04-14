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
    public class TeamLeadersController : Controller
    {
        // Database 
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // Charts for Corps Member Experience View
        public ActionResult CorpMemberExperience()
        {

            Highcharts teamleadersChart = new Highcharts("teamleadersChart");



            teamleadersChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

            teamleadersChart.SetTitle(new Title()
            {
                Text = "RETURNING ACM- TEAM LEADERS"
            });


            // Create objects for X - Axis
            object[] Q1Goal = Q1GoalsTL().Cast<object>().ToArray();
            object[] Q1Actual = Q1ActualsTL().Cast<object>().ToArray();
            object[] Q2Goal = Q2GoalsTL().Cast<object>().ToArray();
            object[] Q2Actual = Q2ActualsTL().Cast<object>().ToArray();
            object[] Q3Goal = Q3GoalsTL().Cast<object>().ToArray();
            object[] Q3Actual = Q3ActualsTL().Cast<object>().ToArray();
            object[] Q4Goal = Q4GoalsTL().Cast<object>().ToArray();
            object[] Q4Actual = Q4ActualsTL().Cast<object>().ToArray();
            object[] AnnualGoal = AnnualGoalsTL().Cast<object>().ToArray();
            object[] AnnualActual = AnnualActualsTL().Cast<object>().ToArray();
            object[] BestofCYGoal = BestofCYGoalsTL().Cast<object>().ToArray();
            object[] BestofCYActual = BestofCYActualsTL().Cast<object>().ToArray();

            // Create objects for Y - Axis
            string[] Subcategories = subCat().ToArray();


            teamleadersChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = Subcategories
            });

            teamleadersChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "# Of Returning Applications",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            teamleadersChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });


            // Set series for quarterly goals + actuals
            teamleadersChart.SetSeries(new Series[]
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



            return View(teamleadersChart);
        }



        // Get the data for Q1 Goals
        public List<string> Q1GoalsTL()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1tlQuery = (from y in goals
                                    where y.subcategoryID == 9 && y.quarteroptionID == 1
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q1Goals = new List<string>();

            foreach (var t in q1tlQuery)
            {

                q1Goals.Add(t.goalValue);

            }

            return q1Goals;

        }
        //Get the data for Q2 Team Leaders goals
        public List<string> Q2GoalsTL()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2tlQuery = (from y in goals
                                    where y.subcategoryID == 9 && y.quarteroptionID == 2
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q2Goals = new List<string>();

            foreach (var t in q2tlQuery)
            {

                q2Goals.Add(t.goalValue);

            }

            return q2Goals;

        }

        //Get the data for Q3 Team Leaders Goals
        public List<string> Q3GoalsTL()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3tlQuery = (from y in goals
                                    where y.subcategoryID == 9 && y.quarteroptionID == 3
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q3Goals = new List<string>();

            foreach (var t in q3tlQuery)
            {

                q3Goals.Add(t.goalValue);

            }

            return q3Goals;

        }

        //Get the data for Q4 Team Leaders Goals
        public List<string> Q4GoalsTL()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4tlQuery = (from y in goals
                                    where y.subcategoryID == 9 && y.quarteroptionID == 4
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q4Goals = new List<string>();

            foreach (var t in q4tlQuery)
            {

                q4Goals.Add(t.goalValue);

            }

            return q4Goals;

        }


        //Get the data for Annual Team Leaders Goals
        public List<string> AnnualGoalsTL()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var annualtlQuery = (from y in goals
                                        where y.subcategoryID == 9 && y.quarteroptionID == 5
                                        join x in cats
                                        on y.categoryID equals x.categoryID
                                        join z in subcats
                                        on y.subcategoryID equals z.subcategoryID
                                        select new
                                        {
                                            goalValue = y.goalValue
                                        }).ToList();

            List<string> annualGoals = new List<string>();

            foreach (var t in annualtlQuery)
            {

                annualGoals.Add(t.goalValue);

            }

            return annualGoals;

        }

        //Get the data for Best of City Year Team Leaders Goals
        public List<string> BestofCYGoalsTL()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var bestofcytlQuery = (from y in goals
                                          where y.subcategoryID == 9 && y.quarteroptionID == 6
                                          join x in cats
                                          on y.categoryID equals x.categoryID
                                          join z in subcats
                                          on y.subcategoryID equals z.subcategoryID
                                          select new
                                          {
                                              goalValue = y.goalValue
                                          }).ToList();

            List<string> bestofcyGoals = new List<string>();

            foreach (var t in bestofcytlQuery)
            {

                bestofcyGoals.Add(t.goalValue);

            }

            return bestofcyGoals;

        }

        // Team Leaders - Quarter 1 ACTUALS
        public List<string> Q1ActualsTL()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1tlQuery = (from y in goals
                                    where y.subcategoryID == 9 && y.quarteroptionID == 1
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q1Actuals = new List<string>();

            foreach (var t in q1tlQuery)
            {

                q1Actuals.Add(t.actualGoal);

            }

            return q1Actuals;



        }

        //Get Q2 Team Leaders Actuals
        public List<string> Q2ActualsTL()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2tlQuery = (from y in goals
                                    where y.subcategoryID == 9 && y.quarteroptionID == 2
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q2Actuals = new List<string>();

            foreach (var t in q2tlQuery)
            {

                q2Actuals.Add(t.actualGoal);

            }

            return q2Actuals;
        }

        //Get Q3 Team Leaders Actuals
        public List<string> Q3ActualsTL()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3tlQuery = (from y in goals
                                    where y.subcategoryID == 9 && y.quarteroptionID == 3
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q3Actuals = new List<string>();

            foreach (var t in q3tlQuery)
            {

                q3Actuals.Add(t.actualGoal);

            }

            return q3Actuals;
        }

        //Get Q4 Team Leaders Actuals
        public List<string> Q4ActualsTL()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4tlQuery = (from y in goals
                                    where y.subcategoryID == 9 && y.quarteroptionID == 4
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q4Actuals = new List<string>();

            foreach (var t in q4tlQuery)
            {

                q4Actuals.Add(t.actualGoal);

            }

            return q4Actuals;
        }

        //Get Annual Team Leaders Actuals
        public List<string> AnnualActualsTL()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var annualtlQuery = (from y in goals
                                        where y.subcategoryID == 9 && y.quarteroptionID == 5
                                        join x in cats
                                        on y.categoryID equals x.categoryID
                                        join z in subcats
                                        on y.subcategoryID equals z.subcategoryID
                                        select new
                                        {
                                            actualGoal = y.actualGoal
                                        }).ToList();


            List<string> annualActuals = new List<string>();

            foreach (var t in annualtlQuery)
            {

                annualActuals.Add(t.actualGoal);

            }

            return annualActuals;
        }

        //Get Best of CY Team Leaders Actuals
        public List<string> BestofCYActualsTL()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var bestofcytlQuery = (from y in goals
                                          where y.subcategoryID == 9 && y.quarteroptionID == 6
                                          join x in cats
                                          on y.categoryID equals x.categoryID
                                          join z in subcats
                                          on y.subcategoryID equals z.subcategoryID
                                          select new
                                          {
                                              actualGoal = y.actualGoal
                                          }).ToList();


            List<string> bestofcyActuals = new List<string>();

            foreach (var t in bestofcytlQuery)
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

            var tlQuery = (from y in goals
                                  where y.subcategoryID == 9
                                  join x in cats
                                  on y.categoryID equals x.categoryID
                                  join z in subcats
                                  on y.subcategoryID equals z.subcategoryID
                                  select new
                                  {
                                      subcatTypes = x.categoryName
                                  }).ToList();

            List<string> subCats = new List<string>();

            foreach (var t in tlQuery)
            {

                subCats.Add(t.subcatTypes);

            }

            return subCats;
        }
    }
}