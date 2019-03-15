using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Оплата (цена)?
    /// </summary>
    public class Costing
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Тип оплаты
        /// </summary>
        public string CostingKind { get; set; }
        /// <summary>
        /// За тонну
        /// </summary>
        public double ForTonnes { get; set; }
        /// <summary>
        /// Перегруз
        /// </summary>
        public double Underweight { get; set; }
        /// <summary>
        /// ?
        /// </summary>
        public double ForSpecPrnsp { get; set; }
        /// <summary>
        /// За обслуживание
        /// </summary>
        public double ForTransportService { get; set; }
        /// <summary>
        /// За загрузку/погрузку
        /// </summary>
        public double LoadUnloadWork { get; set; }
        /// <summary>
        /// За доп загрузку
        /// </summary>
        public double OverStandardSimpleLoading { get; set; }
        /// <summary>
        /// За доп выгрузку
        /// </summary>
        public double OverStandardSimpleUnloading { get; set; }
        /// <summary>
        /// Другие выплаты
        /// </summary>
        public double OtherCosting { get; set; }
        /// <summary>
        /// ?
        /// </summary>
        public double DiscountsForReducingDowntime { get; set; }
    }
}