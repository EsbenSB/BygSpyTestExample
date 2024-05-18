using BygSpyWebAPI.Models;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyWebAPI.Services.Interfaces;
using MongoDB.Bson;

namespace BygSpyWebAPI.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task CreateUserAsync(User newUser)
        {
            var user = await GetUserByEmailAsync(newUser.Email);

            if (user is not null)
            {
                throw new InvalidOperationException($"User with email '{user.Email}' already exists.");
            }

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
