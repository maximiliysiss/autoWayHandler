using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Работа водителя
    /// </summary>
    public class DriverWork: IEquatable<DriverWork>
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Операция
        /// </summary>
        public Operation Operation { get; set; }
        public DateTime TimeOnShedule { get; set; }
        public double ZeroMileage { get; set; }
        public double SpeedometerDisplay { get; set; }
        public DateTime FactTime { get; set; }
        /// <summary>
        /// Движение топлива
        /// </summary>
        public MovingFuel MovingFuel { get; set; }
        public WayList WayList { get; set; }

        public bool Equals(DriverWork other)
        {
            return this.Id == other.Id;
        }
    }
}
