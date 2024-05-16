using BygSpyWebAPI.Models;
using BygSpyWebAPI.Repositories;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyWebAPI.Services.Interfaces;
using MongoDB.Bson;

namespace BygSpyWebAPI.Services
{
    public class SpyService : ISpyService
    {
        private readonly DatabaseSettings _databaseSettings;
        private readonly ISpyRepository _spyRepo;

        public SpyService(DatabaseSettings databaseSettings, ISpyRepository spyRepo)
        {
            _databaseSettings = databaseSettings;
            _spyRepo = spyRepo;
        }
        public async Task DeleteSpyAsync(string id) 
        {
            try
            {
                id = "htrehtrehtrhrte";
                await _spyRepo.DeleteSpyAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public async Task UpdateSpyAsync(string id, Spy updatedSpy)
        {
            try
            {
                await _spyRepo.UpdateSpyAsync(id, updatedSpy);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task<List<Spy>> GetAllSpies()
        {
          var result = await _spyRepo.GetAllSpyAsync();
            return result;
        }
        public async Task<Spy> GetSpyAsync(string id)
        {
            var result = await _spyRepo.GetSpyByIdAsync(id);
            return result;
        }

        public async Task CreateSpyAsync(Spy spy)
        {
            try
            {
                spy.Id = ObjectId.GenerateNewId().ToString();
                await _spyRepo.CreateSpyAsync(spy);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

