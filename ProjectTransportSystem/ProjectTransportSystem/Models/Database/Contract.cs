using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    public class Contract
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime ArriveTime { get; set; }
        public string WhereToGetCargo { get; set; }
        public string WhereToDeliverCargo { get; set; }
        public int CountTrips { get; set; }
        public double Distance { get; set; }
        public double Tonnes { get; set; }

        public virtual Cargo Cargo { get; set; }
        public virtual LegalEntity LegalEntity { get; set; }
    }
}
