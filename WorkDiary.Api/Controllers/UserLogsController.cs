using System;
using System.Collections.Generic;
using System.Web.Http;
using ServiceDotNet.Api.Models;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;

namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/userlogs")]
    public class UserLogsController : ApiController
    {
        [HttpPost]
        [Route("search")]
        public List<UserLogsGetByHours_Result> SearchUserLog([FromBody]UserLogModel uLog)
        {
            if (uLog.IS_LAST_HOUR)
            {
                uLog.START_TIME = DateTime.Now.AddHours(-1);
                uLog.END_TIME = DateTime.Now;
            }
            return new JobRepository().GetUserLogByTime(Convert.ToInt32(uLog.USER_ID),Convert.ToInt32(uLog.JOB_ID),Convert.ToDateTime(uLog.START_TIME), Convert.ToDateTime(uLog.END_TIME));
        }
    }
}