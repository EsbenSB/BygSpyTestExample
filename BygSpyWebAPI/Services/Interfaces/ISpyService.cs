using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Services.Interfaces
{
    public interface ISpyService
    {
        Task<List<Spy>> GetAllSpies();
        Task<Spy?> GetSpyAsync(string id);
        Task CreateSpyAsync(Spy newSpy);
        Task UpdateSpyAsync(string id, Spy updatedSpy);
        Task DeleteSpyAsync(string id);
    }
}
