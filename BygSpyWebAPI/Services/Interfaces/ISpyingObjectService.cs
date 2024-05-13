using BygSpyWebAPI.Models;

namespace BygSpyWebAPI.Services.Interfaces
{
    public interface ISpyingObjectService
    {
        List<SpyingObject> GetAllSpyingObjects();
        List<SpyingObject> CreateSpyObject();
        Task<string> GetAddressId(string address);


    }
}
