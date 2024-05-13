using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BygSpyWebAPI.Models
{
    public class User
    {
      
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

    }
}

