//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace exampleOfHangfire.Dto
{
    using System;
    using System.Collections.Generic;
    
    public partial class JOB_FEEDBACK
    {
        public int FEEDBACK_ID { get; set; }
        public Nullable<int> JOB_AWARDED_ID { get; set; }
        public Nullable<int> BUYER_ID { get; set; }
        public Nullable<int> PROVIDER_ID { get; set; }
        public Nullable<int> FEEDBACK_FOR_USER_ID { get; set; }
        public Nullable<int> QUALITY_OF_WORK_RATING { get; set; }
        public Nullable<int> COMMUNICATION_RATING { get; set; }
        public Nullable<int> ON_BUDGET_RATING { get; set; }
        public Nullable<int> ON_TIME_RATING { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
        public Nullable<int> MODIFIED_BY { get; set; }
    }
}
