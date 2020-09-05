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

        public PackaginTypes PackaginType { get; set; }
        public Receivers Receiver { get; set; }
        public Shipments Shipment { get; set; }
        public ICollection<CustomerOrders> customerOrders { get; set; }
    }
}
