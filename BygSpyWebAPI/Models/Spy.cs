using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BygSpyWebAPI.Models
{
    public class Spy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
