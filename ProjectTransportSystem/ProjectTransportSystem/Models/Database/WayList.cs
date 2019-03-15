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
    public class WayList
    {
        [Key]
        public int Id { get; set; }
        public DateTime ArriveTime { get; set; }
        public Contract Contract { get; set; }
        public Trip Trip { get; set; }
        public List<TrailerCar> TrailerCars { get; set; }
        public List<DriverAccompanying> DriverAccompanyings { get; set; }
    }
}
