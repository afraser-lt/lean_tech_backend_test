using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nosql_CRUD.Models
{
    public partial class Orders
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Number")]
        public string Number { get; set; }
        [BsonElement("Packages")]
        public int Packages { get; set; }
        [BsonElement("Weight")]
        public decimal Weight { get; set; }
        [BsonElement("Pallet")]
        public bool Pallet { get; set; }
        [BsonElement("Slip")]
        public bool Slip { get; set; }
        [BsonElement("ShippperInfo")]
        public string ShippperInfo { get; set; }
    }
}
