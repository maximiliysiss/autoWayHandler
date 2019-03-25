using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Тип погрузки?
    /// </summary>
    public class ShippingKind: IEquatable<ShippingKind>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(ShippingKind other)
        {
            return this.Id == other.Id;
        }
    }
}
