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
    public class PromoterScoreController : Controller
    {
        // Database 
        private cyjdatabaseEntities db = new cyjdatabaseEntities();

        // Charts for Corps Member Experience View
        public ActionResult CorpMemberExperience()
        {

            Highcharts promoterChart = new Highcharts("promoterChart");



            promoterChart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Column,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.White),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.Gray,
                BorderRadius = 0,
                BorderWidth = 2

            });

            promoterChart.SetTitle(new Title()
            {
                Text = "ACM NET PROMOTER SCORE"
            });


            // Create objects for X - Axis
            object[] Q1Goal = Q1GoalsPromoter().Cast<object>().ToArray();
            object[] Q1Actual = Q1ActualsPromoter().Cast<object>().ToArray();
            object[] Q2Goal = Q2GoalsPromoter().Cast<object>().ToArray();
            object[] Q2Actual = Q2ActualsPromoter().Cast<object>().ToArray();
            object[] Q3Goal = Q3GoalsPromoter().Cast<object>().ToArray();
            object[] Q3Actual = Q3ActualsPromoter().Cast<object>().ToArray();
            object[] Q4Goal = Q4GoalsPromoter().Cast<object>().ToArray();
            object[] Q4Actual = Q4ActualsPromoter().Cast<object>().ToArray();
            object[] AnnualGoal = AnnualGoalsPromoter().Cast<object>().ToArray();
            object[] AnnualActual = AnnualActualsPromoter().Cast<object>().ToArray();
            object[] BestofCYGoal = BestofCYGoalsPromoter().Cast<object>().ToArray();
            object[] BestofCYActual = BestofCYActualsPromoter().Cast<object>().ToArray();

            // Create objects for Y - Axis
            string[] Subcategories = subCat().ToArray();


            promoterChart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Goal vs Actual", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = Subcategories
            });

            promoterChart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "Promoter Score",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });

            promoterChart.SetLegend(new Legend
            {
                Enabled = true,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });


            // Set series for quarterly goals + actuals
            promoterChart.SetSeries(new Series[]
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



            return View(promoterChart);
        }



        // Get the data for Q1 Promoter Goals
        public List<string> Q1GoalsPromoter()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1promoterscoreQuery = (from y in goals
                                    where y.subcategoryID == 8 && y.quarteroptionID == 1
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q1promoterscoreGoals = new List<string>();

            foreach (var t in q1promoterscoreQuery)
            {

                q1promoterscoreGoals.Add(t.goalValue);

            }

            return q1promoterscoreGoals;

        }
        //Get the data for Q2 Promoter goals
        public List<string> Q2GoalsPromoter()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2promoterscoreQuery = (from y in goals
                                    where y.subcategoryID == 8 && y.quarteroptionID == 2
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q2Goals = new List<string>();

            foreach (var t in q2promoterscoreQuery)
            {

                q2Goals.Add(t.goalValue);

            }

            return q2Goals;

        }

        //Get the data for Q3 Promoter Goals
        public List<string> Q3GoalsPromoter()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3promoterscoreQuery = (from y in goals
                                    where y.subcategoryID == 8 && y.quarteroptionID == 3
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q3Goals = new List<string>();

            foreach (var t in q3promoterscoreQuery)
            {

                q3Goals.Add(t.goalValue);

            }

            return q3Goals;

        }

        //Get the data for Q4 Promoter Goals
        public List<string> Q4GoalsPromoter()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4promoterscoreQuery = (from y in goals
                                    where y.subcategoryID == 8 && y.quarteroptionID == 4
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        goalValue = y.goalValue
                                    }).ToList();

            List<string> q4Goals = new List<string>();

            foreach (var t in q4promoterscoreQuery)
            {

                q4Goals.Add(t.goalValue);

            }

            return q4Goals;

        }


        //Get the data for Annual Promoter Goals
        public List<string> AnnualGoalsPromoter()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var annualpromoterscoreQuery = (from y in goals
                                        where y.subcategoryID == 8 && y.quarteroptionID == 5
                                        join x in cats
                                        on y.categoryID equals x.categoryID
                                        join z in subcats
                                        on y.subcategoryID equals z.subcategoryID
                                        select new
                                        {
                                            goalValue = y.goalValue
                                        }).ToList();

            List<string> annualGoals = new List<string>();

            foreach (var t in annualpromoterscoreQuery)
            {

                annualGoals.Add(t.goalValue);

            }

            return annualGoals;

        }

        //Get the data for Best of City Year Promoter Goals
        public List<string> BestofCYGoalsPromoter()
        {
            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var bestofcypromoterscoreQuery = (from y in goals
                                          where y.subcategoryID == 8 && y.quarteroptionID == 6
                                          join x in cats
                                          on y.categoryID equals x.categoryID
                                          join z in subcats
                                          on y.subcategoryID equals z.subcategoryID
                                          select new
                                          {
                                              goalValue = y.goalValue
                                          }).ToList();

            List<string> bestofcyGoals = new List<string>();

            foreach (var t in bestofcypromoterscoreQuery)
            {

                bestofcyGoals.Add(t.goalValue);

            }

            return bestofcyGoals;

        }

        // Promoter Score - Quarter 1 ACTUALS
        public List<string> Q1ActualsPromoter()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q1promoterscoreQuery = (from y in goals
                                    where y.subcategoryID == 8 && y.quarteroptionID == 1
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q1Actuals = new List<string>();

            foreach (var t in q1promoterscoreQuery)
            {

                q1Actuals.Add(t.actualGoal);

            }

            return q1Actuals;



        }

        //Get Q2 Promtoer Actuals
        public List<string> Q2ActualsPromoter()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q2promoterscoreQuery = (from y in goals
                                    where y.subcategoryID == 8 && y.quarteroptionID == 2
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q2Actuals = new List<string>();

            foreach (var t in q2promoterscoreQuery)
            {

                q2Actuals.Add(t.actualGoal);

            }

            return q2Actuals;
        }

        //Get Q3 Promoter Actuals
        public List<string> Q3ActualsPromoter()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q3promoterscoreQuery = (from y in goals
                                    where y.subcategoryID == 8 && y.quarteroptionID == 3
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q3Actuals = new List<string>();

            foreach (var t in q3promoterscoreQuery)
            {

                q3Actuals.Add(t.actualGoal);

            }

            return q3Actuals;
        }

        //Get Q4 Promoter Actuals
        public List<string> Q4ActualsPromoter()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var q4promoterscoreQuery = (from y in goals
                                    where y.subcategoryID == 8 && y.quarteroptionID == 4
                                    join x in cats
                                    on y.categoryID equals x.categoryID
                                    join z in subcats
                                    on y.subcategoryID equals z.subcategoryID
                                    select new
                                    {
                                        actualGoal = y.actualGoal
                                    }).ToList();


            List<string> q4Actuals = new List<string>();

            foreach (var t in q4promoterscoreQuery)
            {

                q4Actuals.Add(t.actualGoal);

            }

            return q4Actuals;
        }

        //Get Annual Promoter Actuals
        public List<string> AnnualActualsPromoter()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var annualpromoterscoreQuery = (from y in goals
                                        where y.subcategoryID == 8 && y.quarteroptionID == 5
                                        join x in cats
                                        on y.categoryID equals x.categoryID
                                        join z in subcats
                                        on y.subcategoryID equals z.subcategoryID
                                        select new
                                        {
                                            actualGoal = y.actualGoal
                                        }).ToList();


            List<string> annualActuals = new List<string>();

            foreach (var t in annualpromoterscoreQuery)
            {

                annualActuals.Add(t.actualGoal);

            }

            return annualActuals;
        }

        //Get Best of CY Promoter Actuals
        public List<string> BestofCYActualsPromoter()
        {

            var cats = db.CATEGORIES;
            var subcats = db.SUBCATEGORIES;
            var goals = db.GOALACTUALS;

            var bestofcypromoterscoreQuery = (from y in goals
                                          where y.subcategoryID == 8 && y.quarteroptionID == 6
                                          join x in cats
                                          on y.categoryID equals x.categoryID
                                          join z in subcats
                                          on y.subcategoryID equals z.subcategoryID
                                          select new
                                          {
                                              actualGoal = y.actualGoal
                                          }).ToList();


            List<string> bestofcyActuals = new List<string>();

            foreach (var t in bestofcypromoterscoreQuery)
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

            var promoterscoreQuery = (from y in goals
                                  where y.subcategoryID == 8
                                  join x in cats
                                  on y.categoryID equals x.categoryID
                                  join z in subcats
                                  on y.subcategoryID equals z.subcategoryID
                                  select new
                                  {
                                      subcatTypes = x.categoryName
                                  }).ToList();

            List<string> subCats = new List<string>();

            foreach (var t in promoterscoreQuery)
            {

                subCats.Add(t.subcatTypes);

            }

            return subCats;
        }
    }
}