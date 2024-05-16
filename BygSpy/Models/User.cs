using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BygSpy.Models
{
    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("_id")] // Assuming the backend uses "_id" for ObjectId
        public string? Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [BsonElement("Email")]
        [JsonProperty("Email")]
        public string Email { get; set; } = null!;

        [BsonElement("Password")]
        [JsonProperty("Password")]
        public string Password { get; set; } = null!;

        [BsonElement("PhoneNumber")]
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;
    }
}
