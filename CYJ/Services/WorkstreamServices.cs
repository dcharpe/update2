using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CYJ.Models;

namespace CYJ.Services
{
    public class WorkstreamServices
    {
        private readonly cyjdatabaseEntities _dbContext;

        public WorkstreamServices()
        {
            _dbContext = new cyjdatabaseEntities();
        }

        public List<WORKSTREAM> GetAllWStreams()
        {
            return _dbContext.WORKSTREAMS.ToList();
        }

        /*public List<WORKSTREAM> GetWStreamsList(int teamID)
        {
            _dbContext.Configuration.ProxyCreationEnabled = false;

            return _dbContext.WORKSTREAMs.Where(x => x.TEAM_WORKSTREAM == teamID).ToList();
        }*/
        public WORKSTREAM GetWStreamsById(int id)
        {
            _dbContext.Configuration.ProxyCreationEnabled = false;
            return _dbContext.WORKSTREAMS.SingleOrDefault(t => t.workstreamID == id);
        }

        public void Dispose()
        {
            //Cleanup Resources
            _dbContext.Dispose();
        }
    }
}