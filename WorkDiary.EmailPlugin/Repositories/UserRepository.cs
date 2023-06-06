using exampleOfHangfire.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailPlugin.Repositories
{
    public class UserRepository : RepositoryBase
    {
        public List<GetTodayWorkSummary_Result> GetTodayTimeLog(DateTime date)
        {
            return _db.GetTodayWorkSummary(date).ToList();
        }

        public GetTodayWorkSummaryByProvider_Result GetTodayWorkSummaryByProvider(DateTime toDateTime, int? providerId, int? jobId)
        {
            return _db.GetTodayWorkSummaryByProvider(toDateTime, providerId, jobId).FirstOrDefault();
        }

        public List<GetTodayWorkSummaryImagesByProvider_Result> GetTodayWorkSummaryImagesByProvider(DateTime dateTime, int? providerId, int? jobId)
        {
            return _db.GetTodayWorkSummaryImagesByProvider(dateTime, providerId, jobId).ToList();
        }

        public List<DailyScreenLogs_sp_Result> GetScreenLogs(int providerId, int jobId, DateTime createdOn)
        {
            return _db.DailyScreenLogs_sp(providerId, jobId, createdOn).ToList();
        }
    }
}