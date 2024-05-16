using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BygSpy.Models
{
    public class SpyModel
    {
        //public string Name { get; set; }
        //public string Address { get; set; }
        //public int status { get; set; }
        //public DateTime VirkningFra { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonElement("BFE")]
        public int BFE { get; set; }

        [BsonElement("Street")]
        public string Street { get; set; }
        [BsonElement("Status")]
        public int Status { get; set; }
        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("SpyName")]
        public string SpyName { get; set; }

        [BsonElement("newobjectName")]
        public string newobjectName { get; set; }


        //[BsonElement("Id")]
        //public string Id { get; set; }

        //[BsonElement("newobjectName")]
        //public string newobjectName { get; set; }

        [BsonElement("adress")]
        public string adress { get; set; }

        //[BsonElement("SpyName")]
        //public string SpyName { get; set; }



    }
}
