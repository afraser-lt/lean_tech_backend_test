using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace nosql_CRUD.Models
{
    public partial class Bols
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PO")]
        //[Required]
        public string Po { get; set; }

        [BsonElement("SpecialIntructions")]
        public string SpecialInstruction { get; set; }

        [BsonElement("ItemsDesciptions")]
        public string ItemsDesciptions { get; set; }

        public PackaginTypes PackaginType { get; set; }
        public Receivers Receiver { get; set; }
        public Shipments Shipment { get; set; }
        //public List<ObjectId> CustomerOrders { get; set; }
        public List<CustomerOrders> CustomerOrders { get; set; }
    }
}
