using BygSpyWebAPI.Models;
using BygSpyWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BygSpyWebAPI.Controllers
{
    [Route("api/spyingobject")]
    [ApiController]
    public class SpyingObjectController : ControllerBase
    {
        private readonly ISpyingObjectService _spyingObjectService;
        public SpyingObjectController(ISpyingObjectService spyingObjectService)
        {
            _spyingObjectService = spyingObjectService;
        }
        [HttpGet]
        public async Task<List<SpyingObject>> Get()
        {
            var users = await _spyingObjectService.GetAllSpyingObjectAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<SpyingObject> Get(string id)
        {
            var result = await _spyingObjectService.GetSpyingObjectByIdAsync(id);
            return result;
        }

        [HttpPost]
        public async Task Post([FromBody] SpyingObjectTransferModel spyObjectTransfer)
        {
            SpyingObject spyObject = new SpyingObject();
            spyObject.SpyId = spyObjectTransfer.SpyId;
            spyObject.SpyingObjectName = spyObjectTransfer.NewObjectName;

            SpyingObjectTempEntity spyingObjectTempEntity = new SpyingObjectTempEntity();
            spyingObjectTempEntity = _spyingObjectService.GetAddressIdAsync(spyObjectTransfer.Adress).Result;

            var jordstykke = _spyingObjectService.GetJordstykkeFromAddressIdAsync(spyingObjectTempEntity.AddressId);
            spyObject.BFE = _spyingObjectService.GetBfeFromJordstykkeAsync(jordstykke.Result).Result;
            spyObject.Status = _spyingObjectService.GetGrundFromBfeAsync(spyObject.BFE).Result;
            spyObject = _spyingObjectService.MapToSpyingObjectAsync(spyingObjectTempEntity, spyObject).Result;

            await _spyingObjectService.CreateSpyObjectAsync(spyObject);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] SpyingObject updatedSpyingObject)
        {
            await _spyingObjectService.UpdateSpyingObjectAsync(id, updatedSpyingObject);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _spyingObjectService.DeleteSpyingObjectAsync(id);
        }
    }
}
