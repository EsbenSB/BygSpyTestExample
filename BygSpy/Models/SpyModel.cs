using MongoDB.Bson.Serialization.Attributes;

namespace BygSpy.Models
{
    public class SpyModel
    {
        //public string Name { get; set; }
        //public string Address { get; set; }
        //public int status { get; set; }
        //public DateTime VirkningFra { get; set; }
        [BsonElement("Id")]
        public string Id { get; set; }

        [BsonElement("newobjectName")]
        public string newobjectName { get; set; }

        [BsonElement("adress")]
        public string adress { get; set; }

        [BsonElement("spyId")]
        public string spyId { get; set; }
    }
}
