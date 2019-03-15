using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Водитель или сопровождающий
    /// </summary>
    public class DriverAccompanying
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ThridName { get; set; }
        public string Certification { get; set; }
        public Role Role { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        /// <summary>
        /// Дата приема на работу (она есть всегда)
        /// </summary>
        public DateTime StartDateTime { get; set; }
        /// <summary>
        /// Дата увольнения (есть не всегда)
        /// </summary>
        public DateTime? EndDateTime { get; set; }
    }
}