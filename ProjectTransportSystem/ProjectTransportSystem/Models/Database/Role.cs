using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Роль
    /// </summary>
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}