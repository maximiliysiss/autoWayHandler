using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Путевой лист
    /// </summary>
    public class WayList : IEquatable<WayList>
    {
        public WayList() { }
        public WayList(WayBill wayBill)
        {
            this.Customer = wayBill.Consignee;
        }
        [Key]
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime ArriveTime { get; set; }
        public Contract Contract { get; set; }
        public Trip Trip { get; set; } = new Trip();
        public List<TrailerCar> TrailerCars { get; set; } = new List<TrailerCar>();
        public List<DriverAccompanying> DriverAccompanyings { get; set; } = new List<DriverAccompanying>();
        public MovingFuel MovingFuel { get; set; } = new MovingFuel();

        public bool Equals(WayList other)
        {
            return this.Id == other.Id;
        }
    }
}
