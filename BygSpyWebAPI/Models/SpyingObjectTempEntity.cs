using MongoDB.Bson.Serialization.Attributes;

namespace BygSpyWebAPI.Models
{
    public class SpyingObjectTempEntity
    {
        [BsonElement("addressId")]
        public string addressId { get; set; }
        [BsonElement("Street")]
        public string Street { get; set; }
        [BsonElement()]
        public string City { get; set; }
    }
}
