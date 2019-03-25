using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Задержка при выполнении?
    /// </summary>
    public class DownTimeOnLine : IEquatable<DownTimeOnLine>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public string Code { get; set; }
        public WayList WayList { get; set; }

        public bool Equals(DownTimeOnLine other)
        {
            return this.Id == other.Id;
        }
    }
}
