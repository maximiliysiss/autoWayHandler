using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Дополнительная операция?
    /// </summary>
    public class OperationLoadUnloadEtc: IEquatable<OperationLoadUnloadEtc>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(OperationLoadUnloadEtc other)
        {
            return this.Id == other.Id;
        }
    }
}