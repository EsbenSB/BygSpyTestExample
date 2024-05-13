using BygSpyWebAPI.Models;
using MongoDB.Driver;

namespace BygSpyWebAPI.MongoDb
{
    public class BygSpyDbContext
    {

        private readonly IMongoDatabase _database;

        public BygSpyDbContext()
        {
            //var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            //_database = client.GetDatabase("YourDatabaseName");

            var client = new MongoClient("mongodb+srv://esb57676:bygspy1234@bygspy.x3xrrjm.mongodb.net/");
            _database = client.GetDatabase("byg_spy");
        }

        // Define MongoDB collections for users, roles, etc. if necessary
        // Example:
         public IMongoCollection<User> Users => _database.GetCollection<User>("users");

    }
}
