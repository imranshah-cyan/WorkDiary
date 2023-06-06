using exampleOfHangfire.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailPlugin.Repositories
{
    public class JobRepository : RepositoryBase
    {
        public List<GetProjectTeamJobs_sp_Result> GetTeams()
        {
            return _db.GetProjectTeamJobs_sp().ToList();
        }

        public List<ScreenLogsGet_sp_Result> GetScreenLogs(int providerId, int jobId, DateTime createdOn)
        {
            return _db.ScreenLogsGet_sp(providerId, jobId, createdOn).ToList();
        }
    }
}

