using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// ?
    /// </summary>
    public class WaysAndShipping : IEquatable<WaysAndShipping>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EndStation { get; set; }
        public double Distance { get; set; }
        public DateTime Time_Loop { get; set; }
        public ShippingKind ShippingKind { get; set; }

        public bool Equals(WaysAndShipping other)
        {
            return this.Id == other.Id;
        }
    }
}
