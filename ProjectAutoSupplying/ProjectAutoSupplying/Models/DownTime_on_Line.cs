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
    
    public partial class DownTime_on_Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime Start_time { get; set; }
        public System.DateTime End_time { get; set; }
        public string Code { get; set; }
        public int WayList_ID { get; set; }
    
        public virtual WayList WayList { get; set; }
    }
}