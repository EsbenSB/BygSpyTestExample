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

        [HttpGet]
        public async Task<List<Spy>> Get(List<Spy> spy)
        {
            var result = await _spyNotificationService.GetSpyNotification(spy);
            return result;
        }

        [HttpPut]
        public async Task Put(Spy spy)
        {
            await _spyNotificationService.UpdateSpyNotification(spy);
        }
    }
}
