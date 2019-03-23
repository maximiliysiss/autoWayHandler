using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Путевая bill
    /// </summary>
    public class WayBill
    {
        [Key]
        public int ID { get; set; }
        public DriverAccompanying Driver { get; set; }
        public TrailerCar Car { get; set; }
        public string AutoEnterprise { get; set; }
        public string TransportKind { get; set; }
        public string CompanyCustomer { get; set; }
        public string Shipper { get; set; }
        public string Consignee { get; set; }
        public string LoadingPoint { get; set; }
        public string UnLoadingPoint { get; set; }
        public string WayNumber { get; set; }
        public string Redirect { get; set; }
        public Costing Costing { get; set; }
        public OtherInformation OtherInformation { get; set; }
    }
}