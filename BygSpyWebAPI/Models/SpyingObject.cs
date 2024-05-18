using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BygSpyWebAPI.Models
{
    public class SpyingObject
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("BFE")]
        public int BFE { get; set; }

        [BsonElement("Street")]
        public string Street { get; set; } = null!;

        [BsonElement("Status")]
        public int Status { get; set; }
        [BsonElement("City")]
        public string City { get; set; } = null!;

        [BsonElement("spyId")]
        public string SpyId { get; set; } = null!;

        [BsonElement("newobjectName")]
        public string SpyingObjectName { get; set; } = null!;
    }
}