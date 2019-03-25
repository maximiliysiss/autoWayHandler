using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Движение топлива
    /// </summary>
    public class MovingFuel : IEquatable<MovingFuel>
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Топлива
        /// </summary>
        public Fuel Fuel { get; set; }
        /// <summary>
        /// Выдано
        /// </summary>
        public double Given { get; set; }
        /// <summary>
        /// Баланс на выезде
        /// </summary>
        public double BalanceAtCheckout { get; set; }
        /// <summary>
        /// Баланс на въезде
        /// </summary>
        public double BalanceAtCheckin { get; set; }
        public double Commissioned { get; set; }
        public double CoefficientOfChangeInTheNorm { get; set; }
        public int WorkTimeSpecObor { get; set; }
        public int WorkTimeDvigFe { get; set; }

        public bool Equals(MovingFuel other)
        {
            return this.Id == other.Id;
        }
    }
}