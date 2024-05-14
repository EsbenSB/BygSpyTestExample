using BygSpyWebAPI.Models;
using BygSpyWebAPI.MongoDb;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyWebAPI.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BygSpyWebAPI.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public async Task<List<User>> GetAllUsersAsync() =>
        //    await _userCollection.Find(_ => true).ToListAsync();

        //public async Task<User?> GetUserAsync(string id) =>
        //    await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //public async Task CreateUserAsync(User newUser) =>
        //    await _userCollection.InsertOneAsync(newUser);

        //public async Task UpdateUserAsync(string id, User updatedUser) =>
        //    await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        //public async Task RemoveUserAsync(string id) =>
        //    await _userCollection.DeleteOneAsync(x => x.Id == id);



        public async Task<List<User>> GetAllUsersAsync()
        {
            var result = await _userRepository.GetAllUsersAsync();
            return result;
        }

        public async Task<User?> GetUserAsync(string id)
        {
            var result = await _userRepository.GetUserAsync(id);
            return result;
        }

        public async Task CreateUserAsync(User newUser)
        {
            try
            {
                newUser.Id = ObjectId.GenerateNewId().ToString();
                await _userRepository.CreateUserAsync(newUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task UpdateUserAsync(string id, User updatedUser)
        {
            try
            {
                await _userRepository.UpdateUserAsync(id, updatedUser);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task DeleteUserAsync(string id)
        {
            try
            {
                await _userRepository.RemoveUserAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
