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
    
    public partial class Car_Trailer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car_Trailer()
        {
            this.Car_Tralers_in_WayList = new HashSet<Car_Tralers_in_WayList>();
            this.WayBills = new HashSet<WayBill>();
        }
    
        public int Id { get; set; }
        public string State_number { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Type_ID { get; set; }
    
        public virtual Transport_Type Transport_Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car_Tralers_in_WayList> Car_Tralers_in_WayList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WayBill> WayBills { get; set; }
    }
}
