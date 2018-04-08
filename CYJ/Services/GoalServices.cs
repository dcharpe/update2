using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CYJ.Models;

namespace CYJ.Services
{
    public class GoalServices
    {
        private readonly cyjEntities _dbContext;
        public GoalServices()
        {
            _dbContext = new cyjEntities();
        }

        public List<GOALACTUAL> GetAllGoal()
        {

            return _dbContext.GOALACTUALs.ToList();
        }

        public GOALACTUAL GetAGoalsById(int id)
        {
            return _dbContext.GOALACTUALs.SingleOrDefault(t => t.goalActualID == id);
        }

        public void Dispose()
        {
            //Cleanup Resources
            _dbContext.Dispose();
        }

    }
}