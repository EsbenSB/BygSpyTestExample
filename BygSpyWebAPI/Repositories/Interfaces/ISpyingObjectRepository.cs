using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Repositories.Interfaces
{
    public interface ISpyingObjectRepository
    {
        Task CreateSpyingObjectAsync(SpyingObject spyingObject);
        Task DeleteSpyingObjectAsync(string id);
        Task<List<SpyingObject>> GetAllSpyingObjectAsync();
        Task<SpyingObject> GetSpyingObjectByIdAsync(string id);
        Task UpdateSpyingObjectAsync(string id, SpyingObject updatedSpyingObject);
    }
}
