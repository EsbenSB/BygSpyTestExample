using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Services.Interfaces
{
    public interface ISpyNotificationService
    {
        Task<List<Spy>> GetSpyNotification(List<Spy> spy);
        Task<Spy> UpdateSpyNotification(Spy spy);
    }
}
