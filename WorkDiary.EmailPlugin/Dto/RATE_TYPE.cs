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
    
    public partial class RATE_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RATE_TYPE()
        {
            this.CONTACT_RATES = new HashSet<CONTACT_RATES>();
            this.JOBs = new HashSet<JOB>();
        }
    
        public int RATE_TYPE_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public bool IS_ARCHIVED { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTACT_RATES> CONTACT_RATES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOB> JOBs { get; set; }
    }
}
