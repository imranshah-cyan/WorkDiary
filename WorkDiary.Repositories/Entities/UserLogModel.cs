using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceDotNet.Api.Models
{
    public class UserLogModel
    {
        public int ID { get; set; }
        public int? USER_ID { get; set; }
        public DateTime? START_TIME { get; set; }
        public string WINDOW_TITLE { get; set; }
        public int? KEY_STROKES { get; set; }
        public int? MOUSE_CLICKS { get; set; }
        public int? SCROLLING { get; set; }
        public int? TIME_SPENT_IN_SEC { get; set; }
        public DateTime? END_TIME { get; set; }
        public int? JOB_ID { get; set; }
        public bool IS_LAST_HOUR { get; set; }
    }
}