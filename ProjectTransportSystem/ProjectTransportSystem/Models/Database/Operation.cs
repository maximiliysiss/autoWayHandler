using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Операция
    /// </summary>
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}