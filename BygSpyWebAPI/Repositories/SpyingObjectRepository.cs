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

        public async Task<List<SpyingObject>> GetAllSpyingObjectsAsync()
        {
            try
            {
                var filter = Builders<SpyingObject>.Filter.Empty;
                var result = await _spyingObjectCollection.Find(filter).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;

        }

        public async Task<SpyingObject> GetSpyingObjectByIdAsync(string id)
        {
            var filter = Builders<SpyingObject>.Filter.Eq("_id", id);
            var result = await _spyingObjectCollection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<SpyingObject>> GetAllSpyingObjectsBySpyId(string spyId)
        {
            try
            {
                var filter = Builders<SpyingObject>.Filter.Eq("spyId", spyId);
                var result = await _spyingObjectCollection.Find(filter).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;
        }
        public async Task CreateSpyingObjectAsync(SpyingObject spyingObject)
        {
            await _spyingObjectCollection.InsertOneAsync(spyingObject);
        }

        public async Task UpdateSpyingObjectAsync(string id, SpyingObject updatedSpyingObject)
        {
            Guid guidId = Guid.Parse(id);

            var filter = Builders<SpyingObject>.Filter.Eq(s => s.Id, guidId);

            var result = await _spyingObjectCollection.ReplaceOneAsync(filter, updatedSpyingObject);

            if (result.MatchedCount == 0)
            {
                throw new InvalidOperationException($"SpyingObject with id {id} not found.");
            }
        }

        public async Task DeleteSpyingObjectAsync(string id)
        {
            var filter = Builders<SpyingObject>.Filter.Eq("_id", id);
            var result = await _spyingObjectCollection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new InvalidOperationException($"SpyingObject with ID {id} not found.");
            }
        }

    }
}
