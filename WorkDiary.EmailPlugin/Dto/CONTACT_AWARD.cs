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
    
    public partial class CONTACT_AWARD
    {
        public int AWARD_ID { get; set; }
        public Nullable<int> CONTACT_ID { get; set; }
        public Nullable<int> CONTACT_CAT_ID { get; set; }
        public string NAME { get; set; }
        public Nullable<System.DateTime> YEAR_RECEIVED { get; set; }
        public string ORGANIZATION_NAME { get; set; }
        public Nullable<bool> IS_ARCHIVED { get; set; }
    
        public virtual CONTACT CONTACT { get; set; }
        public virtual CONTACT_CATEGORY CONTACT_CATEGORY { get; set; }
    }
}
