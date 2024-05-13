using BygSpyWebAPI.Models;
using BygSpyWebAPI.MongoDb;
using MongoDB.Driver;
using static BygSpyWebAPI.Repositories.UserRepository;

namespace BygSpyWebAPI.Repositories
{
    public class UserRepository
    {

        //private readonly IMongoCollection<User> _userCollection;
        private readonly BygSpyDbContext _dbContext;


        public UserRepository(BygSpyDbContext dbContext)
        {
            //_userCollection = database.GetCollection<User>("Users");
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                return await _dbContext.Users.Find(user => true).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.Find<User>(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.Find<User>(user => user.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _dbContext.Users.InsertOneAsync(user);
            return user;
        }

        public async Task UpdateUserAsync(Guid id, User updatedUser)
        {
            await _dbContext.Users.ReplaceOneAsync(user => user.Id == id, updatedUser);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _dbContext.Users.DeleteOneAsync(user => user.Id == id);
        }

    }
}