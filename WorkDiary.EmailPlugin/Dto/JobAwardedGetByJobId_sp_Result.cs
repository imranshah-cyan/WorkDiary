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
    
    public partial class JobAwardedGetByJobId_sp_Result
    {
        public Nullable<int> USER_ID { get; set; }
        public int JOB_ID { get; set; }
        public Nullable<int> JOB_TYPE_ID { get; set; }
        public string JOB_TYPE_NAME { get; set; }
        public Nullable<int> JOB_STATUS_ID { get; set; }
        public string JOB_STATUS_NAME { get; set; }
        public string JOB_TITLE { get; set; }
        public string DESCRIPTION { get; set; }
        public string APPROXIMATE_DURATION { get; set; }
        public Nullable<decimal> APPROXIMATE_BUDGET { get; set; }
        public string APPROXIMATE_BUDGET_DISPLAY { get; set; }
        public string DURATION { get; set; }
        public string RATE_TYPE_NAME { get; set; }
        public string SYMBOL { get; set; }
        public Nullable<decimal> RATE { get; set; }
        public string DISPLAY_RATE { get; set; }
        public Nullable<decimal> HOURLY_RATE { get; set; }
        public string HOURLY_RATE_DISPLAY { get; set; }
        public double HOURS_PER_WEEK { get; set; }
        public bool ON_SITE_WORK { get; set; }
        public string SITE_LOCATION_COUNTRY_NAME { get; set; }
        public int SITE_LOCATION_REGION_ID { get; set; }
        public int SITE_LOCATION_CITY_ID { get; set; }
        public string SITE_LOCATION_REGION_NAME { get; set; }
        public string SITE_LOCATION_CITY_NAME { get; set; }
        public string SITE_LOCATION_POSTCODE { get; set; }
        public int OFFER_SUBMIT_DAYS { get; set; }
        public string WORK_START { get; set; }
        public bool WORK_START_IMMIDIATELY { get; set; }
        public System.DateTime WORK_START_ON_DATE { get; set; }
        public bool JOB_VIEW_IS_PUBLIC { get; set; }
        public bool OFFER_AMOUNT_IS_PUBLIC { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public string CREATED_ON_DISPLAY { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<bool> IS_ARCHIVED { get; set; }
        public int JOB_SKILL_ID { get; set; }
        public int CAT_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public Nullable<int> CLASS_ID { get; set; }
        public string CLASS_NAME { get; set; }
        public Nullable<int> SKILL_ID { get; set; }
        public string SKILL_NAME { get; set; }
        public string JOB_SKILLS { get; set; }
        public int BUYER_USER_ID { get; set; }
        public string BUYER_CONTACT_NAME { get; set; }
        public string BUYER_USER_NAME { get; set; }
        public int JOB_OFFER_COUNT { get; set; }
        public int JOB_AWARDED_COUNT { get; set; }
        public int JOB_INVITED_COUNT { get; set; }
        public int JOB_AWARDED_ID { get; set; }
        public Nullable<decimal> JOB_AWARDED_AMOUNT { get; set; }
        public string JOB_AWARDED_AMOUNT_DISPLAY { get; set; }
        public Nullable<System.DateTime> DATE_AWARDED { get; set; }
        public string DATE_AWARDED_DISPLAY { get; set; }
        public Nullable<System.DateTime> DATE_COMPLETED { get; set; }
        public string DATE_COMPLETED_DISPLAY { get; set; }
    }
}