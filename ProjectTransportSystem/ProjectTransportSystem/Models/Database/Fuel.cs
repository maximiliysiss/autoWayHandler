using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Топливо
    /// </summary>
    public class Fuel : IEquatable<Fuel>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public double Price { get; set; }

        public bool Equals(Fuel other)
        {
            return this.Id == other.Id;
        }
    }
}