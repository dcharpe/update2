using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CYJ.Models;

namespace CYJ.Services
{
    public class TeamServices
    {
        private readonly cyjEntities _dbContext;

        public TeamServices()
        {
            _dbContext = new cyjEntities(); 
        }
        public List<TEAM> GetAllTeams()
        {
            return _dbContext.TEAMs.ToList();
        }

        public TEAM GetTeamById(int id)
        {
            return _dbContext.TEAMs.SingleOrDefault(t => t.TeamID == id);
        }

        public void InsertTeam(TEAM _teamName)
        {
            _dbContext.TEAMs.Add(_teamName);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Update(string entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this._dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public void Dispose()
        {
            //Cleanup Resources
            _dbContext.Dispose();
        }


    }
}