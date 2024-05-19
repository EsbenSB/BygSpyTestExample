using BygSpyWebAPI.Models;
using BygSpyWebAPI.MongoDb;
using BygSpyWebAPI.Repositories.Interfaces;
using MongoDB.Driver;

namespace BygSpyWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(BygSpyDBContext dbContext)
        {
            _userCollection = dbContext.Users;
        }

        public async Task<List<User>> GetAllUsersAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetUserAsync(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<User?> GetUserByEmailAsync(string existingEmail) =>
           await _userCollection.Find(x => x.Email == existingEmail).FirstOrDefaultAsync();
       
        public async Task CreateUserAsync(User newUser) =>
            await _userCollection.InsertOneAsync(newUser);

        public async Task UpdateUserAsync(string id, User updatedUser) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task RemoveUserAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}
