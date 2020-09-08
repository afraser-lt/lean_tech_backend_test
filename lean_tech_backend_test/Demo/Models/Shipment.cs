using System;

namespace Demo.MyModels
{
    public class Shipment
    {
        public int Id { get; set; }
        public string CarrierId { get; set; }
        public string Date { get; set; }
        public string OriginCountry { get; set; }
        public string OriginState { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCountry { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCity { get; set; }
        public string PickupDate { get; set; }
        public string DeliveryDate { get; set; }
        public string Status { get; set; }
        public string Rate { get; set; }
        //public Carrier Carrier { get; set; }
    }
}
