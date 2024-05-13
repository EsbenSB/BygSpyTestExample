using BygSpyWebAPI.Models;
using BygSpyWebAPI.Repositories;

namespace BygSpyWebAPI.Repositories.Interfaces
{
    public interface ISpyRepository
    {
        Task CreateSpyAsync(Spy spyingObject);
        Task DeleteSpyAsync(string id);
        Task<List<Spy>> GetAllSpyAsync();
        Task<Spy> GetSpyByIdAsync(string id);
        Task UpdateSpyAsync(string id, Spy updatedSpyingObject);
    }
}
