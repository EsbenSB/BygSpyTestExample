using BygSpyWebAPI.Models;
using BygSpyWebAPI.Services;
using BygSpyWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BygSpyWebAPI.Controllers
{
    [Route("api/spy")]
    [ApiController]
    public class SpyController : ControllerBase
    {
        private readonly ISpyService _spyService;

        public SpyController(DatabaseSettings databaseSettings, ISpyService spyService)
        {
            _spyService = spyService;
        }

        [HttpGet]
        public async Task<List<Spy>> GetAllSpies()
        {
            return await _spyService.GetAllSpies();
        }

        [HttpGet("{id}")]
        public Task<Spy> GetSpyByIdAsync(string id)
        {
            //todo delete me when guid is fixed
            id = "htrehtre";
            var result = _spyService.GetSpyAsync(id);
            return result;
        } 

        [HttpPost]
        public void PostSpy([FromBody] Spy Spy)
        {
            _spyService.CreateSpyAsync(Spy);
        }

        [HttpPut("{id}")]
        public async void UpdateSpy(Guid id, [FromBody] Spy spyObject)
        {
            //todo delete me when guid is fixed
           var test = "htrehtre";
            //Convert.ToString(id)
            await _spyService.UpdateSpyAsync(test, spyObject);
        }

        [HttpDelete("{id}")]
        public async void DeleteSpyById(Guid id)
        {
            
           await _spyService.DeleteSpyAsync(Convert.ToString(id));
        }
    }
}
