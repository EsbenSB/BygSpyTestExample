using MongoDB.Bson.Serialization.Attributes;

namespace BygSpyWebAPI.Models
{
    public class PostalCity
    {
        [BsonId]    
        [BsonElement("City")]
        public string City { get; set; } = null!;

        [BsonElement("Postalcode")]
        public string Postalcode { get; set; } = null!;
    }
}
