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


        private readonly IMongoCollection<User> _userCollection;
        //private readonly MongoService _mongoService;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteUserAsync(string id)
        {
            try
            {
                id = "htrehtrehtrhrte";
                await _userRepository.DeleteUserAsync(id);
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

        public async Task<List<User>> GetAllUsers()
        {
            var result = await _userRepository.GetAllUserAsync();
            return result;
        }
        public async Task<User> GetUserByIdAsync(string id)
        {
            var result = await _userRepository.GetUserByIdAsync(id);
            return result;
        }

        public async Task PostUser(User user)
        {
            try
            {
                user.Id = ObjectId.GenerateNewId().ToString();
                await _userRepository.CreateUserAcync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
