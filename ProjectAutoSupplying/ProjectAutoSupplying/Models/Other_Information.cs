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
    
    public partial class Other_Information
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Other_Information()
        {
            this.WayBills = new HashSet<WayBill>();
        }
    
        public int Id { get; set; }
        public int Distance_on_road_group_ID { get; set; }
        public int Code_exp_ { get; set; }
        public double For_transport_service_of_client { get; set; }
        public double For_transport_service_of_driver { get; set; }
        public double Driver_adjustment_factor { get; set; }
        public double Main_tariff_adjustment_factor { get; set; }
        public double Fine { get; set; }
    
        public virtual Distance_of_transportation_by_road_group Distance_of_transportation_by_road_group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WayBill> WayBills { get; set; }
    }
}
