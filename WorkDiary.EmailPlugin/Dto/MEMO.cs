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
    
    public partial class MEMO
    {
        public int MEMO_ID { get; set; }
        public Nullable<int> TIME_SHEET_ID { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public string MEMO_TEXT { get; set; }
        public string MEMO_COLLECTIVE_TEXT { get; set; }
        public Nullable<int> PROVIDER_ID { get; set; }
        public Nullable<int> JOB_ID { get; set; }
    }
}
