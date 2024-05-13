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

        public async Task CreateUserAsync(User newUser) =>
            await _userCollection.InsertOneAsync(newUser);

        public async Task UpdateUserAsync(string id, User updatedUser) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task RemoveUserAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);

        //public async Task CreateUserAcync(User user)
        //{

        //    await _userCollection.InsertOneAsync(user);
        //}
        //public async Task<List<User>> GetAllUserAsync()
        //{
        //    try
        //    {
        //        var filter = Builders<User>.Filter.Empty;
        //        var result = await _userCollection.Find(filter).ToListAsync();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //    }
        //    return null;

        //}

        //public async Task<User> GetUserByIdAsync(string id)
        //{
        //    //todo spørg esben hvad jeg gør forkert når jeg prøver og hente basserede på id 
        //    var filter = Builders<User>.Filter.Eq("Name", id);
        //    var result = await _userCollection.Find(filter).FirstOrDefaultAsync();
        //    return result;
        //}
        //public async Task DeleteUserAsync(string id)
        //{
        //    var filter = Builders<User>.Filter.Eq("Name", id);
        //    var result = await _userCollection.DeleteOneAsync(filter);

        //    if (result.DeletedCount == 0)
        //    {
        //        throw new InvalidOperationException($"User with ID {id} not found.");
        //    }
        //}
        //public async Task UpdateUserAsync(string id, User updatedUser)
        //{
        //    //Guid guidId = Guid.Parse(id);

        //    var filter = Builders<User>.Filter.Eq(s => s.Name, id);

        //    var result = await _userCollection.ReplaceOneAsync(filter, updatedUser);

        //    if (result.MatchedCount == 0)
        //    {
        //        throw new InvalidOperationException($"User with id {id} not found.");
        //    }
        //}
    }
}
