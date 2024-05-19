using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Services.Interfaces
{
    public interface IUserValidator
    {
        Task ValidateAsync(User user);
    }
}
