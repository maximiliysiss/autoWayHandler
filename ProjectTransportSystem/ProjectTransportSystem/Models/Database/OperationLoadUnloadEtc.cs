using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Дополнительная операция?
    /// </summary>
    public class OperationLoadUnloadEtc
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}