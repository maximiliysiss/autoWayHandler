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
    
    public partial class Additional_Operation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Additional_Operation()
        {
            this.Additional_operation__load_unload_ = new HashSet<Additional_operation__load_unload_>();
        }
    
        public int Id { get; set; }
        public System.TimeSpan Time { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Additional_operation__load_unload_> Additional_operation__load_unload_ { get; set; }
    }
}
