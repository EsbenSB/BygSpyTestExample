using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task PostUser(User user);
        Task<User> GetUserByIdAsync(string id);
        Task<List<User>> GetAllUsers();
        Task DeleteUserAsync(string id);
        Task UpdateUserAsync(string id, User updatedUser);
    }
}
