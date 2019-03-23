using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Дополнительные операции
    /// </summary>
    public class AdditionalOperation: IEquatable<AdditionalOperation>
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        public int Count { get; set; }

        public bool Equals(AdditionalOperation other)
        {
            return this.ID == other.ID;
        }
    }
}
