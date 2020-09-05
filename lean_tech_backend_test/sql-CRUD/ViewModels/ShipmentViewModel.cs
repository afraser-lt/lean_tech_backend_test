using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sql_CRUD.Models
{
    public class ShipmentViewModel
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public string OriginCountry { get; set; }
        public string OriginState { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCountry { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCity { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Status { get; set; }
        public CarrierViewModel Carrier { get; set; }
    }
}
