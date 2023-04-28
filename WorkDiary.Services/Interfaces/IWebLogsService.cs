using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryServices.models;

namespace WorkDiaryServices.Interfaces
{
    public interface IWebLogsService
    {
        WebLogs WebLogs(DateTime start_date, DateTime end_date, int provider_id, int job_id);
    }
}
