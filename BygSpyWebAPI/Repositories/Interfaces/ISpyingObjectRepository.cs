using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Repositories.Interfaces
{
    public interface ISpyingObjectRepository
    {
        Task<List<SpyingObject>> GetAllSpyingObjectAsync();
        Task<SpyingObject> GetSpyingObjectByIdAsync(string id);
        Task CreateSpyingObjectAsync(SpyingObject spyingObject);
        Task UpdateSpyingObjectAsync(string id, SpyingObject updatedSpyingObject);
        Task DeleteSpyingObjectAsync(string id);
    }
}
