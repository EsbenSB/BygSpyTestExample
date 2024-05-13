using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BygSpyWebAPI.Services;
using BygSpyWebAPI.Models;
using BygSpyWebAPI.MongoDb;
using BygSpyWebAPI.Services.Interfaces;

namespace BygSpyWebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public Task<User> GetUserByIdAsync(string id)
        {
            //todo delete me when guid is fixed
            id = "htrehtre";
            var result = _userService.GetUserByIdAsync(id);
            return result;
        }

        [HttpPost]
        public void PostUser([FromBody] User user)
        {
            _userService.PostUser(user);
        }

        [HttpPut("{id}")]
        public async void UpdateUser(Guid id, [FromBody] User userObject)
        {
            //todo delete me when guid is fixed
            var test = "htrehtre";
            //Convert.ToString(id)
            await _userService.UpdateUserAsync(test, userObject);
        }

        [HttpDelete("{id}")]
        public async void DeleteUserById(Guid id)
        {

            await _userService.DeleteUserAsync(Convert.ToString(id));
        }
    }
}
