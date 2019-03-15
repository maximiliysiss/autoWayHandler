using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Контракт
    /// </summary>
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Компания
        /// </summary>
        public string Company { get; set; }
        public DateTime ArriveTime { get; set; }
        public string WhereToGetCargo { get; set; }
        public string WhereToDeliverCargo { get; set; }
        /// <summary>
        /// Количество поездок
        /// </summary>
        public int CountTrips { get; set; }
        /// <summary>
        /// Расстояние
        /// </summary>
        public double Distance { get; set; }
        /// <summary>
        /// Тоннаж
        /// </summary>
        public double Tonnes { get; set; }
        /// <summary>
        /// Груз
        /// </summary>
        public Cargo Cargo { get; set; }
        /// <summary>
        /// Юридическое лицо
        /// </summary>
        public LegalEntity LegalEntity { get; set; }
        public List<WayBill> Waybills { get; set; }
    }
}
