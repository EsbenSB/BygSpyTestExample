using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Repositories.Interfaces
{
    public interface ISpyingObjectRepository
    {
        Task<List<SpyingObject>> GetAllSpyingObjectsAsync();
        Task<SpyingObject?> GetSpyingObjectAsync(string id);
        Task<List<SpyingObject>> GetAllSpyingObjectsBySpyId(string spyId);
        Task CreateSpyingObjectAsync(SpyingObject spyingObject);
        Task UpdateSpyingObjectAsync(string id, SpyingObject updatedSpyingObject);
        Task DeleteSpyingObjectAsync(string id);
    }
}
