using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BygSpyWebAPI.Models
{
    public class UserDBContext
    {
        private readonly IMongoDatabase _database;

        public UserDBContext()
        {
            var client = new MongoClient("mongodb+srv://esb57676:bygspy1234@bygspy.x3xrrjm.mongodb.net/");
            _database = client.GetDatabase("byg_spy");
        }

        public IMongoCollection<User> UserRecord => _database.GetCollection<User>("users");
    }
}