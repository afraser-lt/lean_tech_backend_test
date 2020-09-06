using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_CRUD.MyModels
{
    public class Shipment
    {
        public int Id { get; set; }
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
        public decimal Rate { get; set; }
        //[NotMapped]
        //public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
    }
}
