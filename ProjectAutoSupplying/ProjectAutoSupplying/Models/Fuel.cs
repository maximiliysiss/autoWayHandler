//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectAutoSupplying.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fuel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fuel()
        {
            this.Moving_Fuel = new HashSet<Moving_Fuel>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public double Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Moving_Fuel> Moving_Fuel { get; set; }
    }
}
