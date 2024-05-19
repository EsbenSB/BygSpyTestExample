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

        public SpyController(ISpyService spyService)
        {
            _spyService = spyService;
        }

        [HttpGet]
        public async Task<List<Spy>> Get()
        {
            return await _spyService.GetAllSpiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Spy>> Get(string id)
        {
            var result = await _spyService.GetSpyAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            return result;
        } 

        [HttpPost]
        public async Task Post([FromBody] Spy Spy)
        {
             await _spyService.CreateSpyAsync(Spy);
        }

        [HttpPut("{id}")]
        public async Task Update(string id, [FromBody] Spy spyObject)
        {
            
            await _spyService.UpdateSpyAsync(id, spyObject);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            
           await _spyService.DeleteSpyAsync(id);
        }
    }
}
