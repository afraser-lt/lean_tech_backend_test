using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nosql_CRUD.Models
{
    public partial class PackaginTypes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Heigth")]
        public decimal Heigth { get; set; }
        [BsonElement("Width")]
        public decimal Width { get; set; }
        [BsonElement("Length")]
        public decimal Length { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
    }
}
