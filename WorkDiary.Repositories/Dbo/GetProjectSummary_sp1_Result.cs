//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkDiaryRepository.Dbo
{
    using System;
    
    public partial class GetProjectSummary_sp1_Result
    {
        public Nullable<int> JOB_ID { get; set; }
        public string JOB_TITLE { get; set; }
        public Nullable<int> TOTAL_HOURS { get; set; }
        public string TOTAL_DURATION { get; set; }
        public Nullable<int> KEY_STROKES { get; set; }
        public Nullable<int> MOUSE_CLICKS { get; set; }
        public Nullable<int> ACTIVITY_LEVEL { get; set; }
        public Nullable<System.DateTime> STARTED_ON { get; set; }
        public string STARTED_ON_DESCRIPTIVE_DAYS { get; set; }
        public Nullable<System.DateTime> LAST_WORKED_ON { get; set; }
        public string LAST_ON_DESCRIPTIVE_DAYS { get; set; }
    }
}
