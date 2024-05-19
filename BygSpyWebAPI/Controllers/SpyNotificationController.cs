using BygSpyWebAPI.Models;
using BygSpyWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BygSpyWebAPI.Controllers
{
    [Route("api/spyingnotification")]
    [ApiController]
    public class SpyNotificationController : ControllerBase
    {
        private readonly ISpyNotificationService _spyNotificationService;

        public SpyNotificationController(ISpyNotificationService spyNotificationService)
        {
            _spyNotificationService = spyNotificationService;
        }

        [HttpPost]
        public async Task<List<Spy>> GetSpies([FromBody] List<Spy> spies)
        {
            var result = await _spyNotificationService.GetSpyNotification(spies);
            return result;
        }

        [HttpPut]
        public async Task Put(Spy spy)
        {
            await _spyNotificationService.UpdateSpyNotification(spy);
        }
    }
}
