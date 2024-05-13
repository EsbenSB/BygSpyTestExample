using BygSpyServer.Models;

namespace BygSpyWebAPI.Services.Interfaces
{
    public interface ISpyService
    {
        Task PostSpy(Spy spy);
        Task<Spy> GetSpyByIdAsync(string id);
        Task<List<Spy>> GetAllSpies();
        Task DeleteSpyAsync(string id);
        Task UpdateSpyAsync(string id, Spy updatedSpy);
    }
}
