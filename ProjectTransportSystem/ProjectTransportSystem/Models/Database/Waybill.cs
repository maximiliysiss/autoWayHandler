using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Путевая bill
    /// </summary>
    public class WayBill : IEquatable<WayBill>
    {
        [Key]
        public int ID { get; set; }
        public List<DriverAccompanying> Driver { get; set; }
        public List<TrailerCar> Car { get; set; }
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
        public List<Contract> Contracts { get; set; }

        public bool Equals(WayBill other)
        {
            return this.ID == other.ID;
        }
    }
}