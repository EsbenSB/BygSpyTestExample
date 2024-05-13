using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BygSpyWebAPI.Models
{
   
    public class PostalCity
    {
        [BsonId]    
        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("Postalcode")]
        public string Postalcode { get; set; }
    }
}
