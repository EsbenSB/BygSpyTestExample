using MongoDB.Driver;

namespace BygSpyWebAPI.Models
{
    public class BygSpyDBContext
    {
        private readonly IMongoDatabase _database;

        public BygSpyDBContext()
        {
            var client = new MongoClient("mongodb+srv://esb57676:bygspy1234@bygspy.x3xrrjm.mongodb.net/");
            _database = client.GetDatabase("byg_spy");
        }

        public IMongoCollection<User> UserRecord => _database.GetCollection<User>("users");
    }
}
