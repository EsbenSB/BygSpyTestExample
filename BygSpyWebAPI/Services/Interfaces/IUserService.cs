using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(string id);
        Task<User?> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User newUser);
        Task UpdateUserAsync(string id, User updatedUser);
        Task DeleteUserAsync(string id);
    }
}
