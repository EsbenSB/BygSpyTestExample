using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(string id);
        Task CreateUserAsync(User newUser);
        Task UpdateUserAsync(string id, User updatedUser);
        Task RemoveUserAsync(string id);
    }
}
