using BygSpyServer.Models;
using BygSpyServer.MongoDb;
using BygSpyWebAPI.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BygSpyServer.Repositories
{
    public class SpyingObjectRepository : ISpyingObjectRepository
    {
        private readonly IMongoCollection<SpyingObject> _spyingObjectCollection;

        public SpyingObjectRepository(BygSpyDbContext dbContext)
        {
            //todo ændre nedenstående senere
            _spyingObjectCollection = (IMongoCollection<SpyingObject>?)dbContext.spy;
        }

        public async Task CreateSpyingObjectAsync(SpyingObject spyingObject)
        {
            await _spyingObjectCollection.InsertOneAsync(spyingObject);
        }

        public async Task<List<SpyingObject>> GetAllSpyingObjectAsync()
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
        public async Task<SpyingObject> GetSpyingObjectByIdAsync(string bfe)
        {
            var filter = Builders<SpyingObject>.Filter.Eq("BFE", bfe);
            var result = await _spyingObjectCollection.Find(filter).FirstOrDefaultAsync();
            return result;
        }
        public async Task DeleteSpyingObjectAsync(string bfe)
        {
            var filter = Builders<SpyingObject>.Filter.Eq("BFE", bfe);
            var result = await _spyingObjectCollection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new InvalidOperationException($"SpyingObject with ID {bfe} not found.");
            }
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
    }
}
