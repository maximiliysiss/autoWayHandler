using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Информация о грузе
    /// </summary>
    public class InformationAboutCargo : IEquatable<InformationAboutCargo>
    {
        [Key]
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
        public WayBill WayBill { get; set; }

        public bool Equals(InformationAboutCargo other)
        {
            return this.Id == other.Id;
        }
    }
}
