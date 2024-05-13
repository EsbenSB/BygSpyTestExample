//using BygSpyWebAPI.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace BygSpyWebAPI.Controllers
//{
//    [Route("api/spyingobject")] // Corrected route template
//    [ApiController]
//    public class SpyingObjectController : ControllerBase
//    {
//        private readonly SpyingObjectService _spyingObjectService;

//        public SpyingObjectController(DatabaseSettings databaseSettings)
//        {
//            _spyingObjectService = new SpyingObjectService(databaseSettings);
//        }

//        [HttpGet]
//        public IActionResult GetAllUsers()
//        {
//            var users = _spyingObjectService.GetAllSpyingObjects();
//            return Ok(users);
//        }

//        [HttpGet("{id}")]
//        public IActionResult Get(int id)
//        {
//            // Implement your logic here
//            return null;
//        }

//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//            // Implement your logic here
//        }

//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//            // Implement your logic here
//        }

//        [HttpDelete("{id}")]
//        public void DeleteSpyingObject(int id)
//        {
//            // Implement your logic here
//        }
//    }
//}
