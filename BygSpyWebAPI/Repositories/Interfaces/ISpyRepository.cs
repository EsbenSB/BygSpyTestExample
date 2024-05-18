using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Repositories.Interfaces
{
    public interface ISpyRepository
    {
        Task<List<Spy>> GetAllSpyAsync();
        Task<Spy?> GetSpyByIdAsync(string id);
        Task CreateSpyAsync(Spy newSpyingObject);
        Task UpdateSpyAsync(string id, Spy updatedSpyingObject);
        Task DeleteSpyAsync(string id);
    }
}
