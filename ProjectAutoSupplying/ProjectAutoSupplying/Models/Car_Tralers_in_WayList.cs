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
    
    public partial class Car_Tralers_in_WayList
    {
        public int Id { get; set; }
        public int Car_Trailer_ID { get; set; }
        public int WayList_ID { get; set; }
    
        public virtual Car_Trailer Car_Trailer { get; set; }
        public virtual WayList WayList { get; set; }
    }
}
