using System;
using System.Collections.Generic;

namespace ProjectTransportSystem.Models.Database
{
    public class LoadUnloadOperation
    {
        public int ID { get; set; }
        public string Method { get; set; }
        public DateTime ArriveDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime DownTime { get; set; }
        public string Executor { get; set; }
        public Waybill Waybill { get; set; }
        public OperationLoadUnloadEtc OperationLoadUnloadEtc { get; set; }
        public List<AdditionalOperation> AdditionalOperations { get; set; }
    }
}