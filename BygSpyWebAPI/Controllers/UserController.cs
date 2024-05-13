using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BygSpyServer.Services;
using BygSpyServer.Models;
using BygSpyServer.MongoDb;

namespace BygSpyServer.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly MongoService _mongoService;

        public UserController(DatabaseSettings databaseSettings, MongoService mongoService)
        {
            _mongoService = new MongoService();
            _userService = new UserService(databaseSettings, mongoService);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _userService.CreateUser(user);
            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateUser(Guid id, User updatedUser)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.UpdateUser(id, updatedUser);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);

            return NoContent();
        }
    }
}
