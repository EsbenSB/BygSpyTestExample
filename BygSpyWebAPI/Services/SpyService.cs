using BygSpyWebAPI.Models;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyWebAPI.Services.Interfaces;
using MongoDB.Bson;

namespace BygSpyWebAPI.Services
{
    public class SpyService : ISpyService
    {
        private readonly ISpyRepository _spyRepository;

        public SpyService(ISpyRepository spyRepository)
        {
            _spyRepository = spyRepository;
        }

        public async Task<List<Spy>> GetAllSpies()
        {
            var result = await _spyRepository.GetAllSpyAsync();
            return result;
        }
        public async Task<Spy?> GetSpyAsync(string id)
        {
            var result = await _spyRepository.GetSpyByIdAsync(id);
            return result;
        }

        public async Task CreateSpyAsync(Spy spy)
        {
            try
            {
                spy.Id = ObjectId.GenerateNewId().ToString();
                await _spyRepository.CreateSpyAsync(spy);
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
                await _spyRepository.UpdateSpyAsync(id, updatedSpy);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task DeleteSpyAsync(string id)
        {
            try
            {
                await _spyRepository.DeleteSpyAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

