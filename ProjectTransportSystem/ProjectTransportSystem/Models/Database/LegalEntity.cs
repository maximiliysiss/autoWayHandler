using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Юр лицо
    /// </summary>
    public class LegalEntity: IEquatable<LegalEntity>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LegalAdress { get; set; }
        public string Account { get; set; }
        public string BankName { get; set; }
        public string OKONX { get; set; }
        public string OKPO { get; set; }
        public string INN { get; set; }

        public bool Equals(LegalEntity other)
        {
            return this.Id == other.Id;
        }
    }
}