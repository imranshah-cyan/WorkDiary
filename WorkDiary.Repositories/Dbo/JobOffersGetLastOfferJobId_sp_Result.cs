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
    
    public partial class JobOffersGetLastOfferJobId_sp_Result
    {
        public Nullable<long> Row { get; set; }
        public int JOB_OFFER_ID { get; set; }
        public Nullable<int> JOB_ID { get; set; }
        public Nullable<int> PROVIDER_ID { get; set; }
        public string PROVIDER_CONTACT_NAME { get; set; }
        public string PROVIDER_USER_NAME { get; set; }
        public Nullable<int> BUYER_ID { get; set; }
        public string BUYER_CONTACT_NAME { get; set; }
        public string BUYER_USER_NAME { get; set; }
        public Nullable<int> CURRENCY_ID { get; set; }
        public string CURRENCY_NAME { get; set; }
        public string CURRENCY_SYMBOL { get; set; }
        public Nullable<decimal> OFFER_AMOUNT { get; set; }
        public Nullable<decimal> SERVICE_FEE { get; set; }
        public Nullable<decimal> CLIENT_CHARGED { get; set; }
        public Nullable<decimal> UPFRONT_PAYMENT { get; set; }
        public string TIME_REQUIRED { get; set; }
        public string DESCRIPTION { get; set; }
        public string TERMS { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<bool> IS_OFFER_BY_BUYER { get; set; }
        public string CREATED_ON_DISPLAY { get; set; }
    }
}
