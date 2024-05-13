using BygSpyServer.Models;
using BygSpyServer.MongoDb;
using MongoDB.Driver;

namespace BygSpyServer.Services
{

    public class UserService
    {

        private readonly IMongoCollection<User> _userCollection;
        //private readonly MongoService _mongoService;

        public UserService(DatabaseSettings databaseSettings, MongoService mongoService)
        {
            //#1
            //var client = new MongoClient(databaseSettings.ConnectionString);
            //var database = client.GetDatabase(databaseSettings.DatabaseName);
            //_userCollection = database.GetCollection<User>("users");
            
            //#2
            _userCollection = mongoService.Users;
        }

      
        //#1 check if this or #2 works
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userCollection.Find(user => true).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userCollection.Find<User>(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
            return user;
        }

        public async Task UpdateUserAsync(Guid id, User updatedUser)
        {
            await _userCollection.ReplaceOneAsync(user => user.Id == id, updatedUser);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userCollection.DeleteOneAsync(user => user.Id == id);
        }


        //#2
        public List<User> GetAllUsers()
        {
            return _userCollection.Find(user => true).ToList();
        }

        public User GetUserById(Guid id)
        {
            return _userCollection.Find<User>(user => user.Id == id).FirstOrDefault();
        }
        public User CreateUser(User user)
        {
            _userCollection.InsertOne(user);
            return user;
        }

        public void UpdateUser(Guid id, User updatedUser)
        {
            _userCollection.ReplaceOne(user => user.Id == id, updatedUser);
        }

        public void DeleteUser(Guid id)
        {
            _userCollection.DeleteOne(user => user.Id == id);
        }
    }


}
