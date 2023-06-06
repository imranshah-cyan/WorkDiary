using exampleOfHangfire.Dto;
using System;
using System.Collections.Generic;

namespace EmailPlugin.Models
{
    public class vmDailyWork
    {
        public DateTime? CreatedOn { get; set; }
        public GetTodayWorkSummary_Result JobsTimeLog { get; set; }
        public GetTodayWorkSummaryByProvider_Result Log { get; set; }
        public List<ScreenLogsGet_sp_Result> WindowsUsage { get; set; }
        public List<GetTodayWorkSummaryImagesByProvider_Result> Images { get; set; }

        public List<DailyScreenLogs_sp_Result> ScreenLogs { get; set; }
    }

    public class vmViewData
    {
        public DateTime? today { get; set; }
        public int? jobId { get; set; }
        public int? providerId { get; set; }
        public string Email { get; set; }
    }
}