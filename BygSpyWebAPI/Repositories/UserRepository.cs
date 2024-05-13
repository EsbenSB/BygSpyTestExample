using BygSpyServer.Models;
using BygSpyServer.MongoDb;
using MongoDB.Driver;

namespace BygSpyServer.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(MongoService mongoService)
        {
            _users = mongoService.Users;
        }

        public async Task CreateUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }
    }
}
