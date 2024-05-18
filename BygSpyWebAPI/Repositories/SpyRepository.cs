using BygSpyWebAPI.Models;
using BygSpyWebAPI.MongoDb;
using BygSpyWebAPI.Repositories.Interfaces;
using MongoDB.Driver;

namespace BygSpyWebAPI.Repositories
{
    public class SpyRepository : ISpyRepository
    {
        private readonly IMongoCollection<Spy> _spyCollection;

        public SpyRepository(BygSpyDBContext dbContext)
        {
            _spyCollection = dbContext.Spies;
        }

        public async Task<List<Spy>> GetAllSpyAsync() =>
            await _spyCollection.Find(_ => true).ToListAsync();

        public async Task<Spy?> GetSpyByIdAsync(string id) =>
            await _spyCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateSpyAsync(Spy newSpy) =>
            await _spyCollection.InsertOneAsync(newSpy);

        public async Task UpdateSpyAsync(string id, Spy updatedSpy) =>
            await _spyCollection.ReplaceOneAsync(x => x.Id == id, updatedSpy);

        public async Task DeleteSpyAsync(string id) =>
            await _spyCollection.DeleteOneAsync(x => x.Id == id);
    }
}
