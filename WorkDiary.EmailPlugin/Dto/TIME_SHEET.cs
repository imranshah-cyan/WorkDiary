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
    
    public partial class TIME_SHEET
    {
        public int TIME_SHEET_ID { get; set; }
        public Nullable<int> JOB_AWARDED_ID { get; set; }
        public Nullable<int> BUYER_ID { get; set; }
        public Nullable<int> PROVIDER_ID { get; set; }
        public Nullable<int> JOB_ID { get; set; }
        public Nullable<int> JOB_OFFER_ID { get; set; }
        public Nullable<int> JOB_TYPE { get; set; }
        public Nullable<System.DateTime> START_DATE_TIME { get; set; }
        public Nullable<System.DateTime> END_DATE_TIME { get; set; }
        public Nullable<bool> IS_COMPLETED_BY_PROVIDER { get; set; }
        public Nullable<int> TOTAL_DAYS { get; set; }
        public Nullable<int> TOTAL_HOURS { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
        public Nullable<int> MODIFIED_BY { get; set; }
        public Nullable<bool> IS_ARCHIVED { get; set; }
        public Nullable<bool> IS_VERIFIED_BY_BUYER { get; set; }
        public Nullable<bool> IS_PAYED { get; set; }
        public Nullable<bool> IS_CANCELLED_BY_BUYER { get; set; }
        public Nullable<bool> IS_COMPLETED_VERIFIED_BY_BUYER { get; set; }
        public Nullable<int> TASK_ID { get; set; }
        public string WORKING_ON { get; set; }
    }
}