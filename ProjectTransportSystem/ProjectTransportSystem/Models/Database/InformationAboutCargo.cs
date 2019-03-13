using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    public partial class InformationAboutCargo
    {
        public int Id { get; set; }
        public string NomenclatureCode { get; set; }
        public string PreiscPosition { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double Summary { get; set; }
        public int DocumentsCount { get; set; }
        public string PackKind { get; set; }
        public int PlaceCount { get; set; }
        public string MassDeterminationMethod { get; set; }
        public double Mass { get; set; }
        public Cargo Cargo { get; set; }
        public Waybill WayBill { get; set; }
    }
}
