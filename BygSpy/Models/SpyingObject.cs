using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BygSpy.Models
{
    public class SpyingObject
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string? Id { get; set; }

        [BsonElement("BFE")]
        public int BFE { get; set; }

        [BsonElement("Street")]
        public string Street { get; set; } = null!;
        [BsonElement("Status")]
        public int Status { get; set; }
        [BsonElement("City")]
        public string City { get; set; } = null!;

        [BsonElement("spyId")]
        public string spyId { get; set; } = null!;

        [BsonElement("newobjectName")]
        public string newobjectName { get; set; } = null!;
    }
}
