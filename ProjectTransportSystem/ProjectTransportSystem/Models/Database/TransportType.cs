using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Тип транспорта (Справочник)
    /// </summary>
    public class TransportType : IEquatable<TransportType>
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(TransportType other)
        {
            return this.ID == other.ID;
        }
    }
}
