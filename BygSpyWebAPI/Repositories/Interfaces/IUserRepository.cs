using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAcync(User user);
        Task DeleteUserAsync(string id);
        Task<List<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(string id);
        Task UpdateUserAsync(string id, User updatedUserObject);
    }
}
