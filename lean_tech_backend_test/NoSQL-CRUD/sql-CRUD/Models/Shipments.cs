using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace nosql_CRUD.Models
{
    public partial class Shipments
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Date")]
        public string Date { get; set; }
        [BsonElement("OriginCountry")]
        public string OriginCountry { get; set; }
        [BsonElement("OriginState")]
        public string OriginState { get; set; }
        [BsonElement("OriginCity")]
        public string OriginCity { get; set; }
        [BsonElement("DestinationCountry")]
        public string DestinationCountry { get; set; }
        [BsonElement("DestinationState")]
        public string DestinationState { get; set; }
        [BsonElement("DestinationCity")]
        public string DestinationCity { get; set; }
        [BsonElement("PickupDate")]
        public string PickupDate { get; set; }
        [BsonElement("DeliveryDate")]
        public string DeliveryDate { get; set; }
        [BsonElement("Status")]
        public string Status { get; set; }

        public Carriers Carrier { get; set; }
    }
}
