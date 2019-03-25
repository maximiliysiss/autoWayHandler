using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Операция
    /// </summary>
    public class Operation : IEquatable<Operation>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(Operation other)
        {
            return this.Id == other.Id;
        }
    }
}