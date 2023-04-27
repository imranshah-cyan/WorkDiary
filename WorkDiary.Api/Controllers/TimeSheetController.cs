using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;

namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/timesheet")]
    public class TimeSheetController : ApiController
    {
        [Route("user/{userId}/{currentJobId}/{currentDateTime}")]
        [System.Web.Http.HttpGet]
        public GetUserTimeLog_Result GetUserLog(int userId, int currentJobId, DateTime currentDateTime)
        {
            return new JobRepository().GetUserLog(userId, currentJobId, currentDateTime);
        }

        [Route("user/log/{userId}/{currentJobId}/{currentDateTime}")]
        [System.Web.Http.HttpGet]
        public GetTodayWorkSummaryByProvider_Result GetUserWorkLog(int userId, int currentJobId, DateTime currentDateTime)
        {
            return new UserRepository().GetTodayWorkSummaryByProvider(userId, currentJobId, Convert.ToDateTime(currentDateTime));
        }

        [System.Web.Http.HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        [Route("insert")]
        [System.Web.Http.HttpPost]
        public int Post([FromBody]TIME_SHEET timeSheet)
        {
            var timeSheetInsertId = new JobRepository().InsertTimeSheet(timeSheet);
            if (timeSheetInsertId != null)
                return (int)timeSheetInsertId;

            return 0;
        }


        [Route("update")]
        [System.Web.Http.HttpPut]
        public int Put(int id, [FromBody]TIME_SHEET timeSheet)
        {
            var updatetTimeSheetEndTime = new JobRepository().UpdatetTimeSheetEndTime(timeSheet);
            if (updatetTimeSheetEndTime != null)
                return (int)updatetTimeSheetEndTime;

            return 0;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


    }
}