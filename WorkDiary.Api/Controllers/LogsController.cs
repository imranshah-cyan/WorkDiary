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
        public WebLogs GetWebLogs(DateTime start_date, DateTime end_date, int provider_id, int job_id)
        {
            var result = new WebLogsService().WebLogs(start_date, end_date, provider_id, job_id);
            return result;
        }
    }

}