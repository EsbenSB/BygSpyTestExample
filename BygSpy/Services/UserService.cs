using BygSpy.Models;

namespace BygSpy.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> RegisterUserAsync(User newUser)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/users/register", newUser);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

