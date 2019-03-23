using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Роль
    /// </summary>
    public class Role: IEquatable<Role>
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public bool Equals(Role other)
        {
            return this.ID == other.ID;
        }
    }
}