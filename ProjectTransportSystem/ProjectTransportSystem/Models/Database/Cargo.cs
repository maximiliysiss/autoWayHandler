using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Название
    /// </summary>
    public class Cargo
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Единицы измерения
        /// </summary>
        public string Units { get; set; }
    }
}