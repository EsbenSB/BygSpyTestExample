using MongoDB.Bson.Serialization.Attributes;

namespace BygSpyWebAPI.Models
{
    public class SpyingObjectTransferModel
    {
        [BsonElement("Id")]
        public string? Id { get; set; }

        [BsonElement("NewObjectName")]
        public string NewObjectName { get; set; } = null!;

        [BsonElement("adress")]
        public string Adress { get; set; } = null!;

        [BsonElement("spyId")]
        public string SpyId { get; set; } = null!;
    }
}
