using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BygSpyWebAPI.Models
{
    public class Spy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid UserId { get; set; }
    }
}
