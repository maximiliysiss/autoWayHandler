namespace ProjectTransportSystem.Models.Database
{
    public class Costing
    {
        public int Id { get; set; }
        public string CostingKind { get; set; }
        public double ForTonnes { get; set; }
        public double Underweight { get; set; }
        public double ForSpecPrnsp { get; set; }
        public double ForTransportService { get; set; }
        public double LoadUnloadWork { get; set; }
        public double OverStandardSimpleLoading { get; set; }
        public double OverStandardSimpleUnloading { get; set; }
        public double OtherCosting { get; set; }
        public double DiscountsForReducingDowntime { get; set; }
    }
}