using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Repositories.Interfaces
{
    public interface ISpyingObjectRepository
    {
        Task<List<SpyingObject>> GetAllSpyingObjectsAsync();
        Task<SpyingObject> GetSpyingObjectByIdAsync(string id);
        Task<List<SpyingObject>> GetAllSpyingObjectsBySpyId(string spyId);
        Task CreateSpyingObjectAsync(SpyingObject spyingObject);
        Task UpdateSpyingObjectAsync(string id, SpyingObject updatedSpyingObject);
        Task DeleteSpyingObjectAsync(string id);
    }
}
