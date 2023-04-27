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
    }
}
