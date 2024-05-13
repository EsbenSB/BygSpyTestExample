//using BygSpyWebAPI.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace BygSpyWebAPI.Controllers
//{
//    [Route("api/spy")]
//    [ApiController]
//    public class SpyController : ControllerBase
//    {
//        private readonly SpyService _spyService;

//        public SpyController(DatabaseSettings databaseSettings)
//        {
//            _spyService = new SpyService(databaseSettings);
//        }

//        [HttpGet]
//        public IEnumerable<string> GetAllSpies()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        [HttpGet("{id}")]
//        public string GetSpyById(int id)
//        {
//            return "value";
//        }

//        [HttpPost]
//        public void CreateSpy([FromBody] string value)
//        {
//            // Implement your logic here
//        }

//        [HttpPut("{id}")]
//        public void UpdateSpy(Guid id, [FromBody] string value)
//        {
//            // Implement your logic here
//        }

//        [HttpDelete("{id}")]
//        public void DeleteSpyById(Guid id)
//        {
//            // Implement your logic here
//        }
//    }
//}
