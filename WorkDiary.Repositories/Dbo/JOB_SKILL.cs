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
    using System.Collections.Generic;
    
    public partial class JOB_SKILL
    {
        public int JOB_SKILL_ID { get; set; }
        public Nullable<int> JOB_ID { get; set; }
        public Nullable<int> CAT_ID { get; set; }
        public Nullable<int> CLASS_ID { get; set; }
        public Nullable<int> SKILL_ID { get; set; }
        public string SKILL_NAME { get; set; }
        public Nullable<bool> IS_ARCHIVED { get; set; }
    
        public virtual JOB JOB { get; set; }
    }
}