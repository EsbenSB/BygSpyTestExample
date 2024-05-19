using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Services.Interfaces
{
    public interface ISpyingObjectService
    {
        Task<List<SpyingObject>> GetAllSpyingObjectAsync();
        Task<SpyingObject> GetSpyingObjectByIdAsync(string id);
        Task<List<SpyingObject>> GetAllSpyingObjectsBySpyId(string spyId);
        Task<SpyingObjectTempEntity> GetAddressIdAsync(string address);
        Task<string> GetJordstykkeFromAddressIdAsync(string addressId);
        Task<int> GetBfeFromJordstykkeAsync(string addressId);
        Task<int> GetGrundFromBfeAsync(int bfe);
        Task<SpyingObject?> MapToSpyingObjectAsync(SpyingObjectTempEntity spyingObjectTempEntity, SpyingObject spyObject);
        Task CreateSpyObjectAsync(SpyingObject spyObject);
        Task UpdateSpyingObjectAsync(string id, SpyingObject updatedSpyingObject);
        Task DeleteSpyingObjectAsync(string id);
    }
}
