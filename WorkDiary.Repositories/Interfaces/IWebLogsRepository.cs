using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;

namespace WorkDiaryRepository.Interfaces
{
    public interface IWebLogsRepository
    {
        List<Web_GetWorkSummaryImagesByProviderAndJob_Result> GetWebLogs(DateTime start_date, DateTime end_date, int provider_id, int job_id);
    }
}
