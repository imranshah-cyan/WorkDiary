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
    
    public partial class Web_Classes_Result
    {
        public int CLASS_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public int CAT_ID { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
        public Nullable<int> MODIFIED_BY { get; set; }
        public bool IS_ARCHIVED { get; set; }
        public Nullable<System.DateTime> ARCHIVED_ON { get; set; }
        public Nullable<int> ARCHIVED_BY { get; set; }
    }
}