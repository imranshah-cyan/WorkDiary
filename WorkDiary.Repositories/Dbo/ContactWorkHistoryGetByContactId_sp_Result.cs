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
    
    public partial class ContactWorkHistoryGetByContactId_sp_Result
    {
        public int WORK_HISTORY_ID { get; set; }
        public string POSITION_HELD { get; set; }
        public Nullable<System.DateTime> FROM_DATE { get; set; }
        public string FROM_DATE_DISPLAY { get; set; }
        public Nullable<System.DateTime> TO_DATE { get; set; }
        public string TO_DATE_DISPLAY { get; set; }
        public string EMPLOYER_NAME { get; set; }
        public string ROLES_RESPONSIBILITIES { get; set; }
    }
}