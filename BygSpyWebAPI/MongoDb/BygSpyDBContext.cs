using BygSpyWebAPI.Models;
using MongoDB.Driver;

namespace BygSpyWebAPI.MongoDb
{
    public class BygSpyDBContext
    {

        private readonly IMongoDatabase _database;

        public BygSpyDBContext(IConfiguration configuration)
        {

            //var client = new MongoClient(configuration.GetConnectionString("MongoDB"));

            var client = new MongoClient("mongodb+srv://esb57676:bygspy1234@bygspy.x3xrrjm.mongodb.net/");
            _database = client.GetDatabase("bygspy");
        }

        // Define MongoDB collections for users, roles, etc. if necessary
        // Example:
         public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
         public IMongoCollection<SpyingObject> spyobject => _database.GetCollection<SpyingObject>("SpyingObject");
        public IMongoCollection<Spy> spy => _database.GetCollection<Spy>("Spy");
    }
}
