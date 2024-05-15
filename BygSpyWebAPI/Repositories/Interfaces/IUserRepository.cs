using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        //Task<List<User>> GetAllUsersAsync();
        //Task CreateUserAcync(User user);
        //Task DeleteUserAsync(string id);
        //Task<List<User>> GetAllUserAsync();
        //Task<User> GetUserByIdAsync(string id);
        //Task UpdateUserAsync(string id, User updatedUserObject);

        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserAsync(string id);
        Task<User?> GetUserByEmailAsync(string existingEmail);
        Task CreateUserAsync(User newUser);
        Task UpdateUserAsync(string id, User updatedUser);
        Task RemoveUserAsync(string id);
        
    }
}
