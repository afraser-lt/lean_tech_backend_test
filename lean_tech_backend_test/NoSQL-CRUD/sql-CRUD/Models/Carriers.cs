using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace nosql_CRUD.Models
{
    public partial class Carriers
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("SCAC")]
        public string Scac { get; set; }
        [BsonElement("MC")]
        public long Mc { get; set; }
        [BsonElement("DOT")]
        public long Dot { get; set; }
        [BsonElement("FEIN")]
        public long Fein { get; set; }
        [BsonElement("Rate")]
        [Display(Name = "Rate")]
        //[DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal Rate { get; set; }
    }
}
