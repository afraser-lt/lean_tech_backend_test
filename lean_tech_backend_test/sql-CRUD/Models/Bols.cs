using System;
using System.Collections.Generic;

namespace sql_CRUD.MyModels
{
    public class Bols
    {
        public int Id { get; set; }
        public string Po { get; set; }
        public string SpecialInstruction { get; set; }
        public string ItemsDesciptions { get; set; }

        public PackaginType PackaginType { get; set; }
        public Receiver Receiver { get; set; }
        public Shipment Shipment { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
