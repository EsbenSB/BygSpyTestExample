using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Services.Interfaces
{
    public interface ISpyingObjectService
    {
        List<SpyingObject> CreateSpyObject();
        Task<SpyingObjectTempEntity> GetAddressId(string address);
        Task<string> GetJordstykkeFromAddressId(string addressId);
        Task<int> GetBfeFromJordstykke(string addressId);
        Task<int> GetGrundFromBfe(int bfe);
        Task<SpyingObject> MapToSpyingObject(SpyingObjectTempEntity spyingObjectTempEntity, SpyingObject spyObject);
        Task PostSpyingObject(SpyingObject spyObject);
        Task DeleteSpyingObject(string id);
        Task<List<SpyingObject>> GetAllSpyingObjectAsync();
        Task<SpyingObject> GetSpyingObjectByIdAsync(string id);
        Task UpdateSpyingObjectAsync(string id, SpyingObject updatedSpyingObject);
    }
}
