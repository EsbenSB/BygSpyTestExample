using BygSpyWebAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Xml.Linq;

namespace BygSpyWebAPI.MongoDb
{
    public class MongoService
    {
        private readonly IMongoDatabase _database;

        public MongoService()
        {
            var connectionString = "mongodb+srv://esb57676:bygspy1234@bygspy.x3xrrjm.mongodb.net/";
            var databaseName = "YourDatabaseName";

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<User> spy => _database.GetCollection<User>("spy");
    }
}

