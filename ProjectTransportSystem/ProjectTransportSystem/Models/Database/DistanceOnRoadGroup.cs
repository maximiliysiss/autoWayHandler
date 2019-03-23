using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Дистации на дорогах разных групп
    /// </summary>
    public class DistanceOnRoadGroup: IEquatable<DistanceOnRoadGroup>
    {
        [Key]
        public int ID { get; set; }
        public double Total { get; set; }
        public double InCity { get; set; }
        public double FirstGroup { get; set; }
        public double SecondGroup { get; set; }
        public double ThirdGroup { get; set; }

        public bool Equals(DistanceOnRoadGroup other)
        {
            return this.ID == other.ID;
        }
    }
}