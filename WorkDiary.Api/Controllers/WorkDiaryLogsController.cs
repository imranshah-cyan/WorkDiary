using System;
using System.Collections.Generic;
using System.Web.Http;
using ServiceDotNet.Api.Models;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;

namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/workdiary")]
    public class WorkDiaryLogsController : ApiController
    {
        [HttpPost]
        [Route("Logs")]
        public SP_GetProviderLogs_Result GetWordDiaryLogs([FromBody] ProviderLog pLog)
        {
            var result = (SP_GetProviderLogs_Result)null;
            if((pLog.BUYER_ID > 0) && (pLog.PROVIDER_ID > 0))
            {
                var provider = new ProviderLogRepository().CheckProviderByBuyerId(pLog);
                if(provider != null)
                {
                    result = GetProviderLogs(pLog);
                }
                else
                {
                    return null;
                }
            }
            else if((pLog.BUYER_ID <=0) && (pLog.PROVIDER_ID > 0))
            {
                result = GetProviderLogs(pLog);
            }
            return result;
        }

        [HttpPost]
        [Route("LogsByJob")]
        public SP_GetProviderLogsByJob_Result GetWordDiaryLogsByJob([FromBody] ProviderLog pLog)
        {
            var result = (SP_GetProviderLogsByJob_Result)null;
            if ((pLog.BUYER_ID > 0) && (pLog.PROVIDER_ID > 0) && (pLog.JOB_ID > 0))
            {
                var provider = new ProviderLogRepository().CheckProviderByBuyerId(pLog);
                if (provider != null)
                {
                    result = GetProviderLogsByJob(pLog);
                }
            }
            else if ((pLog.BUYER_ID <= 0) && (pLog.PROVIDER_ID > 0) && (pLog.JOB_ID > 0))
            {
                result = GetProviderLogsByJob(pLog);
            }
            return result;
        }

        public SP_GetProviderLogs_Result GetProviderLogs([FromBody] ProviderLog pLog)
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

            return new ProviderLogRepository().GetProviderLogs(pLog);
        }

        public SP_GetProviderLogsByJob_Result GetProviderLogsByJob([FromBody] ProviderLog pLog)
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

            return new ProviderLogRepository().GetProviderLogsByJob(pLog);
        }
    }
}