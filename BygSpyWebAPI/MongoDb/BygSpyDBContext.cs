﻿using BygSpyWebAPI.Models;
using MongoDB.Driver;

namespace BygSpyWebAPI.MongoDb
{
    public class BygSpyDBContext
    {

        private readonly IMongoDatabase _database;

        public BygSpyDBContext()
        {
            var client = new MongoClient("mongodb+srv://esb57676:bygspy1234@bygspy.x3xrrjm.mongodb.net/");
            _database = client.GetDatabase("bygspy");
        }
        
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Spy> Spies => _database.GetCollection<Spy>("Spy");
        public IMongoCollection<SpyingObject> SpyObjects => _database.GetCollection<SpyingObject>("SpyingObject");
    }
}
