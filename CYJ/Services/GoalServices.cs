using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CYJ.Models;

namespace CYJ.Services
{
    public class GoalServices
    {
        private readonly cyjdatabaseEntities _dbContext;
        public GoalServices()
        {
            _dbContext = new cyjdatabaseEntities();
        }

        public List<GOALACTUAL> GetAllGoal()
        {

            return _dbContext.GOALACTUALS.ToList();
        }

        public GOALACTUAL GetAGoalsById(int id)
        {
            return _dbContext.GOALACTUALS.SingleOrDefault(t => t.goalActualID == id);
        }

        public void Dispose()
        {
            //Cleanup Resources
            _dbContext.Dispose();
        }

    }
}