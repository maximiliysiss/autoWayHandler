using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Операции загрузки/выгрузки
    /// </summary>
    public class LoadUnloadOperation : IEquatable<LoadUnloadOperation>
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Метод
        /// </summary>
        public string Method { get; set; }
        public DateTime ArriveDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime DownTime { get; set; }
        /// <summary>
        /// Исполнитель
        /// </summary>
        public string Executor { get; set; }
        /// <summary>
        /// ?
        /// </summary>
        public List<AdditionalOperation> AdditionalOperations { get; set; } = new List<AdditionalOperation>();

        public bool Equals(LoadUnloadOperation other)
        {
            return this.ID == other.ID;
        }
    }
}