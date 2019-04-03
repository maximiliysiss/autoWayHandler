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
        public List<Cargo> Cargos { get; set; } = new List<Cargo>();
        public DistanceOnRoadGroup DistanceOnRoadGroup { get; set; } = new DistanceOnRoadGroup();
        public string AutoEnterprise { get; set; }
        public string Shipper { get; set; }
        public string Consignee { get; set; }
        public LoadUnloadOperation Loading { get; set; } = new LoadUnloadOperation();
        public LoadUnloadOperation Uploading { get; set; } = new LoadUnloadOperation();
        public List<Costing> Costing { get; set; } = new List<Costing>
        {
            new Costing{ Name="Выполнено" },
            new Costing{ Name="Расценка" },
            new Costing{ Name="К оплате" }
        };
        public OtherInformation OtherInformation { get; set; } = new OtherInformation();

        public bool Equals(WayBill other)
        {
            return this.ID == other.ID;
        }
    }
}