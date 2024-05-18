using MongoDB.Bson.Serialization.Attributes;

namespace BygSpyWebAPI.Models
{
    public class SpyingObjectTempEntity
    {
        [BsonElement("AddressId")]
        public string AddressId { get; set; } = null!;

        [BsonElement("Street")]
        public string Street { get; set; } = null!;

        [BsonElement("City")]
        public string City { get; set; } = null!;
    }
}
