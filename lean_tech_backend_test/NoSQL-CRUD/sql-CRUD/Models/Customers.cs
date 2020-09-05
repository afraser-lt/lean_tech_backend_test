using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nosql_CRUD.Models
{
    public partial class Customers
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
