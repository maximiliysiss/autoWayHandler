using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models.Database
{
    /// <summary>
    /// Тип транспорта (Справочник)
    /// </summary>
    class TransportType
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
