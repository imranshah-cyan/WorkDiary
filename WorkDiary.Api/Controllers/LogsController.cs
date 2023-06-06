using System;
using System.Collections.Generic;
using System.Web.Http;
using ServiceDotNet.Api.Models;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryServices.Classes;
using WorkDiaryServices.models;

namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/workDiaryApp")]
    public class LogsController : ApiController
    {
        [HttpPost]
        [Route("Logs")]
        public SP_WorkDiaryAppLogs_Result GetLogs([FromBody] Log log)
        {
            var result = (SP_WorkDiaryAppLogs_Result)null;
            try
            {
                result = new LogService().GetLogs(log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    
        [HttpPost]
        [Route("webLogs")]
        public WebLogs GetWebLogs([FromBody] ProviderLog pLog)
        {
            if (pLog.Period == 1)
            {
                pLog.Start_Time = DateTime.Now.Date;
                pLog.End_Time = DateTime.Now.Date.AddDays(1);
            }
            else if (pLog.Period == -1)
            {
                pLog.Start_Time = DateTime.Now.Date.AddDays(-1);
                pLog.End_Time = DateTime.Now.Date;
            }
            else if (pLog.Period == -7)
            {
                pLog.Start_Time = DateTime.Now.Date.AddDays(-7);
                pLog.End_Time = DateTime.Now.Date;
            }
            else if (pLog.Period == -30)
            {
                pLog.Start_Time = DateTime.Now.Date.AddMonths(-1);
                pLog.End_Time = DateTime.Now.Date;
            }
            else
            {
                pLog.Start_Time = pLog.Start_Time;
                pLog.End_Time = pLog.End_Time;
            }

            var result = new WebLogsService().WebLogs(pLog.Start_Time, pLog.End_Time, pLog.PROVIDER_ID, pLog.JOB_ID);
            return result;
        }

        [HttpPost]
        [Route("TotalTimeinSec")]
        public int? TotalTimeinSec(Log log)
        {
            var result = new LogService().GetTotalTime(log);
            return result;
        }

        [HttpPost]
        [Route("TotalLogs")]
        public Web_TotalLogsByProviderAndJob_Result TotalLogs(Log log)
        {
            var result = new LogService().GetTotalLogs(log);
            return result;
        }

        [HttpPost]
        [Route("TotalScreenLogs")]
        public List<Web_ScreenLogs_Result> TotalScreenLogs(Log log)
        {
            var result = new LogService().GetTotalScreenLogs(log);
            return result;
        }
    }

}