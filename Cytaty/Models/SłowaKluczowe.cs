//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cytaty.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SłowaKluczowe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SłowaKluczowe()
        {
            this.SlowaKluczoweWCytatach = new HashSet<SlowaKluczoweWCytatach>();
        }
    
        public int ID_SlowoKlucz { get; set; }
        public string Tag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SlowaKluczoweWCytatach> SlowaKluczoweWCytatach { get; set; }
    }
}
