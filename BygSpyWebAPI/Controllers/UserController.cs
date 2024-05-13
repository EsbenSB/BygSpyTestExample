using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BygSpyWebAPI.Services;
using BygSpyWebAPI.Models;
using BygSpyWebAPI.MongoDb;
using BygSpyWebAPI.Repositories;
using BygSpyWebAPI.DataAccess;

namespace BygSpyWebAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        //private readonly UserService _userService;
        //private readonly MongoService _mongoService;
        //private readonly UserRepository _userRepository;

        //public UserController()
        //{
        //    //_mongoService = new MongoService();
        //    //_userService = new UserService(databaseSettings, mongoService);
        //    BygSpyDbContext db = new BygSpyDbContext();
        //    _userRepository = new UserRepository(db);
        //}

        UserDataAccessLayer objuser = new UserDataAccessLayer();

        [HttpGet]
        public IActionResult Index()
        {
            var users = objuser.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public IActionResult GetUserById(Guid id)
        {
            var user = objuser.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            objuser.CreateUserAsync(user);
            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateUser(Guid id, User updatedUser)
        {
            var user = objuser.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            objuser.UpdateUserAsync(id, updatedUser);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = objuser.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            objuser.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
