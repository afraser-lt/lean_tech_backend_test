using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace nosql_CRUD.Models
{
    public partial class CustomerOrders
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Customers Customer { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
