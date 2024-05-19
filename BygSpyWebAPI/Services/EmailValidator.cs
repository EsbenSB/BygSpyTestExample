using BygSpyWebAPI.Models;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyWebAPI.Services.Interfaces;
namespace BygSpyWebAPI.Services
{
    public class EmailValidator : IUserValidator
    {
        private readonly IUserRepository _userRepository;

        public EmailValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ValidateAsync(User user)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException($"User with email '{user.Email}' already exists.");
            }
        }

    }
}
