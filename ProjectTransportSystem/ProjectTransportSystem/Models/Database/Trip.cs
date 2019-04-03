using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Маршрут
    /// </summary>
    public class Trip : IEquatable<Trip>
    {
        [Key]
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Distance { get; set; }

        public bool Equals(Trip other)
        {
            return this.Id == other.Id;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(From))
                return string.Empty;
            return $"{From} - {To}";
        }
    }
}