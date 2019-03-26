using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Средство передвижения или первозки
    /// </summary>
    public class TrailerCar : IEquatable<TrailerCar>
    {
        [Key]
        public int ID { get; set; }
        public TransportType TransportType { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public string StateNumber { get; set; }
        public string Model { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        public bool Equals(TrailerCar other)
        {
            return this.ID == other.ID;
        }

        public override string ToString()
        {
            return $"{Name} {Model} {StateNumber}";
        }
    }
}
