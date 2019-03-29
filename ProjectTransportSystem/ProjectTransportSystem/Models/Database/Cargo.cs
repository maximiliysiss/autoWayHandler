using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Название
    /// </summary>
    public class Cargo : IEquatable<Cargo>
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Единицы измерения
        /// </summary>
        public string Units { get; set; }
        public double Netto { get; set; }
        public double Brutto { get; set; }

        public bool Equals(Cargo other)
        {
            return this.ID == other.ID;
        }
    }
}