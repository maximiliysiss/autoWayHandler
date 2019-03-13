namespace ProjectTransportSystem.Models.Database
{
    public class OtherInformation
    {
        public int Id { get; set; }
        public DistanceOnRoadGroup DistanceOnRoadGroup  { get; set; }
        public int CodeExp { get; set; }
        public double ForTransportServiceOfClient { get; set; }
        public double ForTransportServiceOfDriver { get; set; }
        public double DriverAdjustmentFactor { get; set; }
        public double MainTariffAdjustmentFactor { get; set; }
        public double Fine { get; set; }
    }
}