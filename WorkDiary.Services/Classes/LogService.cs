using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository;
using WorkDiaryRepository.Classes;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryServices.Interfaces;

namespace WorkDiaryServices.Classes
{
    public class LogService : ILogService
    {
        public SP_WorkDiaryAppLogs_Result GetLogs(Log log)
        {
            return GetProviderLogs(log);
        }

        public SP_WorkDiaryAppLogs_Result GetProviderLogs(Log pLog)
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

            return new LogRepository().GetLogs(pLog);
        }
    }
}