using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sql_CRUD.Models
{
    public class BOLViewModel
    {
        public int? Id { get; set; }
        public string PO { get; set; }
        public string SpecialIntructions { get; set; }
        public PackaginTypeViewModel PackaginType { get; set; }
        public string ItemDescriptions { get; set; }
        public ReceiverViewModel Receiver { get; set; }
        public ShipmentViewModel Shipment { get; set; } 
    }
}
