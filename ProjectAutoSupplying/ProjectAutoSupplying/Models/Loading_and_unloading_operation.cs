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
    
    public partial class Loading_and_unloading_operation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loading_and_unloading_operation()
        {
            this.Additional_operation__load_unload_ = new HashSet<Additional_operation__load_unload_>();
        }
    
        public int Id { get; set; }
        public string Operation { get; set; }
        public string Executor { get; set; }
        public string Method { get; set; }
        public System.TimeSpan Arrive_time { get; set; }
        public System.TimeSpan Departure_time { get; set; }
        public System.TimeSpan Downtime { get; set; }
        public int Waybill_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Additional_operation__load_unload_> Additional_operation__load_unload_ { get; set; }
        public virtual WayBill WayBill { get; set; }
    }
}
