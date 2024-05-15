using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace BygSpy.Models
{
    public class User
    {
        //
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("_id")] // Assuming the backend uses "_id" for ObjectId
        public string? Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")] // Match the backend key "Name"
        public string Name { get; set; }

        [BsonElement("Email")]
        [JsonProperty("Email")] // Match the backend key "Email"
        public string Email { get; set; }

        [BsonElement("Password")]
        [JsonProperty("Password")] // Match the backend key "Password"
        public string Password { get; set; }

        [BsonElement("PhoneNumber")]
        [JsonProperty("PhoneNumber")] // Match the backend key "PhoneNumber"
        public string PhoneNumber { get; set; }
    }
}
