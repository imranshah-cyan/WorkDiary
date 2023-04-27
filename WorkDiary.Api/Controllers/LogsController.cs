using System;
using System.Collections.Generic;
using System.Web.Http;
using ServiceDotNet.Api.Models;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryServices.Classes;

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
    }
}