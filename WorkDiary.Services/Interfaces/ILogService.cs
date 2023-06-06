using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;

namespace WorkDiaryServices.Interfaces
{
    public interface ILogService
    {
        SP_WorkDiaryAppLogs_Result GetLogs(Log log);
        int? GetTotalTime(Log log);
        Web_TotalLogsByProviderAndJob_Result GetTotalLogs(Log log);
        List<Web_ScreenLogs_Result> GetTotalScreenLogs(Log entity);
    }
}
