using MongoDB.Bson.Serialization.Attributes;

namespace BygSpy.Models
{
    public class SpyModel
    {
        [BsonElement("Id")]
        public string? Id { get; set; }

        [BsonElement("NewObjectName")]
        public string NewObjectName { get; set; } = null!;

        [BsonElement("Adress")]
        public string Adress { get; set; } = null!;

        [BsonElement("SpyId")]
        public string SpyId { get; set; } = null!;
    }
}
