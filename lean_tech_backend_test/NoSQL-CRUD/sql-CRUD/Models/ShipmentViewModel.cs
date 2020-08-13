using MongoDB.Bson;
namespace sql_CRUD.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class ShipmentViewModel
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("ID")]
        [BsonRepresentation(BsonType.Int32, AllowTruncation = true)]
        public int? Id { get; set; }

        [BsonElement("CARRIER_ID")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Carrier_Id { get; set; }

        [BsonElement("DATE")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Date { get; set; }

        [BsonElement("ORIIGN_COUNTRY")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Oriign_Country { get; set; }

        [BsonElement("ORIGIN_STATE")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Origin_State { get; set; }
        
        [BsonElement("ORIGIN_CITY")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Origin_City { get; set; }

        [BsonElement("DESTINATION_COUNTRY")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Destination_Country { get; set; }

        [BsonElement("DESTINATION_STATE")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Destination_State { get; set; }

        [BsonElement("DESTINATION_CITY")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Destination_City { get; set; }

        [BsonElement("PICKUP_DATE")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Pickup_Date { get; set; }

        [BsonElement("DELIVERY_DATE")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Delivery_Date { get; set; }

        [BsonElement("STATUS")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Status { get; set; }

        [BsonElement("CARRIER_RATE")]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Carrier_Rate { get; set; }
    }
}
