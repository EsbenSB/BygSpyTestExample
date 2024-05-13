using BygSpyWebAPI.Models;
using BygSpyWebAPI.MongoDb;
using BygSpyWebAPI.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BygSpyWebAPI.Repositories
{
    public class SpyRepository : ISpyRepository
    {
        private readonly IMongoCollection<Spy> _spyingObjectCollection;

        public SpyRepository(MongoDb.BygSpyDBContext dbContext)
        {
            _spyingObjectCollection = dbContext.spy;
        }

        public async Task CreateSpyAsync(Spy spy)
        {
            
            await _spyingObjectCollection.InsertOneAsync(spy);
        }
        public async Task<List<Spy>> GetAllSpyAsync()
        {
            try
            {
                var filter = Builders<Spy>.Filter.Empty;
                var result = await _spyingObjectCollection.Find(filter).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;

        }
        public async Task<List<Spy>> GetAllSpyingObjectAsync()
        {
            try
            {
                var filter = Builders<Spy>.Filter.Empty;
                var result = await _spyingObjectCollection.Find(filter).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;

        }
        public async Task<Spy> GetSpyByIdAsync(string id)
        {
            //todo spørg esben hvad jeg gør forkert når jeg prøver og hente basserede på id 
            var filter = Builders<Spy>.Filter.Eq("Name", id);
            var result = await _spyingObjectCollection.Find(filter).FirstOrDefaultAsync();
            return result;
        }
        public async Task DeleteSpyAsync(string id)
        {
            var filter = Builders<Spy>.Filter.Eq("Name", id);
            var result = await _spyingObjectCollection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new InvalidOperationException($"SpyingObject with ID {id} not found.");
            }
        }
        public async Task UpdateSpyAsync(string id, Spy updatedSpyingObject)
        {
            //Guid guidId = Guid.Parse(id);

            var filter = Builders<Spy>.Filter.Eq(s => s.Name, id);

            var result = await _spyingObjectCollection.ReplaceOneAsync(filter, updatedSpyingObject);

            if (result.MatchedCount == 0)
            {
                throw new InvalidOperationException($"SpyingObject with id {id} not found.");
            }
        }
    }
}
