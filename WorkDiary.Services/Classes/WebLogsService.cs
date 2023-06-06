using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Classes;
using WorkDiaryServices.models;

namespace WorkDiaryServices.Classes
{
    public class WebLogsService
    {
        public WebLogs WebLogs(DateTime? start_date, DateTime? end_date, int? provider_id, int? job_id)
        {
            var weblogs = new WebLogsRepository().GetWebLogs(start_date, end_date, provider_id, job_id);

            if(weblogs.Count() > 0)
            {
                // Group the logs by hour
                var logsByHour = weblogs.GroupBy(r => (((DateTime)r.CREATED_ON).Date).AddHours(((DateTime)r.CREATED_ON).Hour));

                // Map the result to the WebLogs model
                var logs = logsByHour.Select(group => new Logs
                {
                    Hour = group.Key,
                    Sessions = group.Select(r => new Session
                    {
                        IMAGE_ID = r.IMAGE_ID,
                        WORKING_ON = r.WORKING_ON,
                        ACTIVE_WINDOW_TITLE = r.ACTIVE_WINDOW_TITLE,
                        KEY_STROKE_LELVE = r.KEY_STROKE_LEVEL,
                        MOUSE_CLICK = r.MOUSE_CLICK,
                        WINDOWS_SWITCHED = r.WINDOWS_SWITCHED,
                        ACTIVITY_LEVEL = (int)r.ACTIVITY_LEVEL,
                        IMAGE_NAME = r.IMAGE_NAME,
                        START_TIME = r.START_TIME,
                        END_TIME = r.END_TIME,
                        TOTAL_MINUTES = (int)r.TOTAL_MINUTES,
                        CREATED_ON = (DateTime)r.CREATED_ON
                    }).ToList()
                }).ToList();

                var webLogs = new WebLogs
                {
                    StartDate = logsByHour.Min(group => group.Key),
                    EndDate = logsByHour.Max(group => group.Key),
                    Logs = logs
                };
                return webLogs;
            }
            return null;
        }
    }
}
