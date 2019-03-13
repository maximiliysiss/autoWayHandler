using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    public class WayList
    {
        public int Id { get; set; }
        public int Contract_ID { get; set; }
        public System.TimeSpan Arrive_time { get; set; }
        public int Trip_ID { get; set; }

        public virtual Contract Contract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DownTime_on_Line> DownTime_on_Line { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Driver_Work> Driver_Work { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Driver_Accompanying_in_WayList> Driver_Accompanying_in_WayList { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
