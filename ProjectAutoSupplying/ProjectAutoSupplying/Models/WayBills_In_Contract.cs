//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectAutoSupplying.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class WayBills_In_Contract
    {
        public int Id { get; set; }
        public int Waybill_ID { get; set; }
        public int Contract_ID { get; set; }
        public System.TimeSpan Arrive_time { get; set; }
    
        public virtual Contract Contract { get; set; }
        public virtual WayBill WayBill { get; set; }
    }
}
