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
    
    public partial class MailsGetByJobOfferId_sp_Result
    {
        public int MAIL_ID { get; set; }
        public Nullable<int> SENT_BY_USER_ID { get; set; }
        public Nullable<int> MAIL_STATUS_ID { get; set; }
        public string MAIL_STATUS_NAME { get; set; }
        public string RANDOM_BG_COLOR { get; set; }
        public string PROVIDER_CONTACT_NAME { get; set; }
        public string PROVIDER_USER_NAME { get; set; }
        public Nullable<int> TO_USER_ID { get; set; }
        public string BUYER_CONTACT_NAME { get; set; }
        public string BUYER_USER_NAME { get; set; }
        public string SENT_TO_NAME { get; set; }
        public string SENT_ON_DAYS { get; set; }
        public string SENT_ON_DISPLAY { get; set; }
        public string REPLY_ON_DISPLAY { get; set; }
        public string REPLY_ON_DAYS { get; set; }
        public string BODY_TEXT { get; set; }
        public string BODY_HTML { get; set; }
        public string ATTACHED_FILES { get; set; }
    }
}
