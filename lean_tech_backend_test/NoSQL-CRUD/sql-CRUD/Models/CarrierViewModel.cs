namespace sql_CRUD.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Diagnostics.CodeAnalysis;

    public class CarrierViewModel
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("ID")]
        [BsonRepresentation(BsonType.Int32, AllowTruncation = true)]
        public int? Id { get; set; }

        [BsonElement("SCAC")]
        [AllowNull]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string SCAC { get; set; }

        [BsonElement("NAME")]
        [AllowNull]
        [BsonRepresentation(BsonType.String, AllowTruncation = true)]
        public string Name { get; set; }

        [BsonElement("MC")]
        [AllowNull]
        [BsonRepresentation(BsonType.Int32, AllowTruncation = true)]
        public int? MC { get; set; }

        [BsonElement("DOT")]
        [AllowNull]
        [BsonRepresentation(BsonType.Int32, AllowTruncation = true)]
        public int? DOT { get; set; }

        [BsonElement("FEIN")]
        [AllowNull]
        [BsonRepresentation(BsonType.Int32, AllowTruncation = true)]
        public int? FEIN { get; set; }
    }
}
