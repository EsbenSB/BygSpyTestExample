using BygSpyServer.Models;

namespace BygSpyWebAPI.Repositories.Interfaces
{
    public interface ISpyingObjectRepository
    {
        Task CreateSpyingObjectAsync(SpyingObject spyingObject);
        Task DeleteSpyingObjectAsync(string bfe);
        Task<List<SpyingObject>> GetAllSpyingObjectAsync();
        Task<SpyingObject> GetSpyingObjectByIdAsync(string bfe);
        Task UpdateSpyingObjectAsync(string id, SpyingObject updatedSpyingObject);
    }
}
