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
    
    public partial class Information_about_the_cargo
    {
        public int Id { get; set; }
        public string Nomenclature_code { get; set; }
        public string Preisc__position { get; set; }
        public int Cargo_ID { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double Summary { get; set; }
        public int Documents_count { get; set; }
        public string Pack_kind { get; set; }
        public int Place_Count { get; set; }
        public string Mass_determination_method { get; set; }
        public double Mass { get; set; }
        public int Waybill_ID { get; set; }
    
        public virtual Cargo Cargo { get; set; }
        public virtual WayBill WayBill { get; set; }
    }
}