using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sql_CRUD.Models
{
    public class ShipmentOrdersViewModel
    {
        public int? Id { get; set; }
        public ShipmentViewModel Shipment { get; set; }
        public OrderViewModel Order { get; set; }
    }
}
