using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Services.Interfaces
{
    public interface ISpyService
    {
        Task<List<Spy>> GetAllSpiesAsync();
        Task<Spy?> GetSpyAsync(string id);
        Task<List<Spy>> GetAllSpyiesByCreatorEmailAsync(string creatorEmail);
        Task CreateSpyAsync(Spy newSpy);
        Task UpdateSpyAsync(string id, Spy updatedSpy);
        Task DeleteSpyAsync(string id);
    }
}
