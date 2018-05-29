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
    
    public partial class WayBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WayBill()
        {
            this.Information_about_the_cargo = new HashSet<Information_about_the_cargo>();
            this.Loading_and_unloading_operations = new HashSet<Loading_and_unloading_operation>();
            this.WayBills_In_Contract = new HashSet<WayBills_In_Contract>();
        }
    
        public int Id { get; set; }
        public int Driver_ID { get; set; }
        public int Car_ID { get; set; }
        public string AutoEnterprise { get; set; }
        public string Transport_kind { get; set; }
        public string Company_customer { get; set; }
        public string Shipper { get; set; }
        public string Consignee { get; set; }
        public string Loading_Point { get; set; }
        public string Unloading_Point { get; set; }
        public string WayNumber { get; set; }
        public string Redirect { get; set; }
        public int Costing_ID { get; set; }
        public int Other_Information_ID { get; set; }
    
        public virtual Car_Trailer Car_Trailer { get; set; }
        public virtual Costing Costing { get; set; }
        public virtual Driver_Accompanying Driver_Accompanying { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Information_about_the_cargo> Information_about_the_cargo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loading_and_unloading_operation> Loading_and_unloading_operations { get; set; }
        public virtual Other_Information Other_Information { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WayBills_In_Contract> WayBills_In_Contract { get; set; }
    }
}