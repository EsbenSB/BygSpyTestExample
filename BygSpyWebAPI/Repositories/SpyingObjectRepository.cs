using BygSpyWebAPI.Models;
using BygSpyWebAPI.MongoDb;
using BygSpyWebAPI.Repositories.Interfaces;
using MongoDB.Driver;

namespace BygSpyWebAPI.Repositories
{
    public class SpyingObjectRepository : ISpyingObjectRepository
    {
        private readonly IMongoCollection<SpyingObject> _spyingObjectCollection;

        public SpyingObjectRepository(BygSpyDBContext dbContext)
        {
            _spyingObjectCollection = dbContext.SpyObjects;
        }

        public async Task<List<SpyingObject>> GetAllSpyingObjectsAsync() =>
            await _spyingObjectCollection.Find(_ => true).ToListAsync();

        public async Task<SpyingObject?> GetSpyingObjectAsync(string id) =>
            await _spyingObjectCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<SpyingObject>> GetAllSpyingObjectsBySpyId(string spyId) =>
            await _spyingObjectCollection.Find(x => x.SpyId == spyId).ToListAsync();
        
        public async Task CreateSpyingObjectAsync(SpyingObject spyingObject)
        {
            await _spyingObjectCollection.InsertOneAsync(spyingObject);
        }

        public async Task UpdateSpyingObjectAsync(string id, SpyingObject updatedSpyingObject) =>
            await _spyingObjectCollection.ReplaceOneAsync(x => x.Id == id, updatedSpyingObject);

        public async Task DeleteSpyingObjectAsync(string id) =>
            await _spyingObjectCollection.DeleteOneAsync(x => x.Id == id);
    }
}
