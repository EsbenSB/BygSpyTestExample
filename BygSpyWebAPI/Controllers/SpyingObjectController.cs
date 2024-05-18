using BygSpyWebAPI.Services;
using BygSpyWebAPI.Models;
using BygSpyWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BygSpyWebAPI.Controllers
{
    [Route("api/spyingobject")] // Corrected route template
    [ApiController]
    public class SpyingObjectController : ControllerBase
    {
        private readonly ISpyingObjectService _spyingObjectService;
        private readonly DatabaseSettings _databaseSettings;
        public SpyingObjectController(DatabaseSettings databaseSettings, ISpyingObjectService spyingObjectService)
        {
            _spyingObjectService = spyingObjectService;
        }
        [HttpGet]
        public async Task<List<SpyingObject>> GetAllUsers()
        {
            var users = await _spyingObjectService.GetAllSpyingObjectAsync();
            return users;
        }

        [HttpGet("{id}")]
        public Task<SpyingObject> Get(string id)
        {
           var result = _spyingObjectService.GetSpyingObjectByIdAsync(id);
            return result;
        }

        [HttpPost]
        public void Post([FromBody] SpyingObjectTransferModel spyObjectTransfer)
        {
            SpyingObject spyObject = new SpyingObject();
            spyObject.spyId = spyObjectTransfer.spyId;
            spyObject.newobjectName = spyObjectTransfer.newobjectName;
            //først send en adresse
            //derefter få adresse id
            //få jordstykke jordstykke
            //få bfe
            // og få  grund
            //1
            SpyingObjectTempEntity spyingObjectTempEntity = new SpyingObjectTempEntity();

           

            spyingObjectTempEntity = _spyingObjectService.GetAddressId(spyObjectTransfer.adress).Result;
            //2
            var jordstykke = _spyingObjectService.GetJordstykkeFromAddressId(spyingObjectTempEntity.addressId);
            //3
            spyObject.BFE = _spyingObjectService.GetBfeFromJordstykke(jordstykke.Result).Result;

            //hvis du får bbr sag til at virke burde det se sådan ud
            //var grund = _spyingObjectService.GetGrundFromBfe(bfe.Result);
            spyObject.Status = _spyingObjectService.GetGrundFromBfe(spyObject.BFE).Result;
            // det er den nedenstående der skal gemmes i mongodb 
            spyObject = _spyingObjectService.MapToSpyingObject(spyingObjectTempEntity, spyObject).Result;

            _spyingObjectService.PostSpyingObject(spyObject);
            //ivirkeligheden burde der være et ekstra kald til bbr sag men kan ikke finde en ejendom med en sag på??

        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] SpyingObject updatedSpyingObject)
        {
           await _spyingObjectService.UpdateSpyingObjectAsync(id, updatedSpyingObject);
        }

        [HttpDelete("{id}")]
        public void DeleteSpyingObject(string id)
        {
            //todo jeg burde enlig ikke bruge bfe men id da der godt kan være flere brugere med samme bfe men aldrig id doh 
            _spyingObjectService.DeleteSpyingObject(id);
        }
    }
}
