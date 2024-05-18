using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BygSpy.Models
{
    public class Spy
    {
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        [BsonElement("Creator_Email")]
        public string Creator_Email { get; set; } = null!;

    }
}
