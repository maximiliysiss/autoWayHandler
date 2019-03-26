using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Другая информация
    /// </summary>
    public class OtherInformation : IEquatable<OtherInformation>
    {
        [Key]
        public int Id { get; set; }
        public DistanceOnRoadGroup DistanceOnRoadGroup { get; set; }
        public int CodeExp { get; set; }
        public double ForTransportServiceOfClient { get; set; }
        public double ForTransportServiceOfDriver { get; set; }
        public double DriverAdjustmentFactor { get; set; }
        public double MainTariffAdjustmentFactor { get; set; }
        public double Fine { get; set; }

        public bool Equals(OtherInformation other)
        {
            return this.Id == other.Id;
        }

        public override string ToString()
        {
            return "Other Information";
        }
    }
}