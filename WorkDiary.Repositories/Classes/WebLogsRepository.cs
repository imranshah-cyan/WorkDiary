using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;

namespace WorkDiaryRepository.Classes
{
    public class WebLogsRepository : RepositoryBase
    {
        public List<Web_GetWorkSummaryImagesByProviderAndJob_Result> GetWebLogs(DateTime start_date, DateTime end_date, int provider_id, int job_id)
        {
            var result = _db.Web_GetWorkSummaryImagesByProviderAndJob(start_date, end_date, provider_id, job_id).ToList();
            return result;
        }

    }
}
