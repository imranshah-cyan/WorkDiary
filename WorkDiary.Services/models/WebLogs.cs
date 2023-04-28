using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDiaryServices.models
{
    public class WebLogs
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Logs> Logs { get; set; }
    }

    public class Logs
    {
        public DateTime Hour { get; set; }
        public List<Session> Sessions { get; set; } = new List<Session>();
    }

    public class Session
    {
        public int IMAGE_ID { get; set; }
        public string WORKING_ON { get; set; }
        public string ACTIVE_WINDOW_TITLE { get; set; }
        public int KEY_STROKE_LELVE { get; set; }
        public int MOUSE_CLICK { get; set; }
        public int WINDOWS_SWITCHED { get; set; }
        public int ACTIVITY_LEVEL { get; set; }
        public string IMAGE_NAME { get; set; }
        public string START_TIME { get; set; }
        public string END_TIME { get; set; }
        public int TOTAL_MINUTES { get; set; }
        public DateTime CREATED_ON { get; set; }
    }
}
