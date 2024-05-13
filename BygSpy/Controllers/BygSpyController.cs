using BygSpy.DataAccess;
using BygSpy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BygSpy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BygSpyController : ControllerBase
    {
        BygSpyDataAccessLayer objbygspy = new BygSpyDataAccessLayer();

        [HttpGet]
        [Route("api/User/Index")]
        public IEnumerable<User> Index()
        {
            return objbygspy.GetAllUsers();
        }

        [HttpPost]
        [Route("api/User/Create")]
        public void Create([FromBody] User user)
        {
            objbygspy.AddUser(user);
        }

        [HttpGet]
        [Route("api/User/Details/{id}")]
        public User Details(string id)
        {
            return objbygspy.GetUserData(id);
        }

        [HttpPut]
        [Route("api/User/Edit")]
        public void Edit([FromBody] User user)
        {
            objbygspy.UpdateUser(user);
        }

        [HttpDelete]
        [Route("api/User/Delete/{id}")]
        public void Delete(string id)
        {
            objbygspy.DeleteUser(id);
        }
    }
}
