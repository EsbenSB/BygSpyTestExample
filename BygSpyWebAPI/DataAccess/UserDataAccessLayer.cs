using BygSpyWebAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BygSpyWebAPI.DataAccess
{
    public class UserDataAccessLayer
    {
        UserDBContext db = new UserDBContext();

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await db.UserRecord.Find(users => true).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await db.UserRecord.Find(user => user.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await db.UserRecord.Find(user => user.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await db.UserRecord.InsertOneAsync(user);
            return user;
        }

        public async Task UpdateUserAsync(Guid id, User updatedUser)
        {
            await db.UserRecord.ReplaceOneAsync(user => user.Id == id, updatedUser);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await db.UserRecord.DeleteOneAsync(user => user.Id == id);
        }
    }
}
