using BygSpyWebAPI.Models;
using MongoDB.Driver;

namespace BygSpyWebAPI.DataAccess
{
    public class BygSpyDataAccessLayer
    {
        BygSpyDBContext db = new BygSpyDBContext();

        public List<User> GetAllUsers()
        {
            try
            {
                return db.UserRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddUser(User employee)
        {
            try
            {
                db.UserRecord.InsertOne(employee);
            }
            catch
            {
                throw;
            }
        }

        public User GetUserData(string id)
        {
            try
            {
                FilterDefinition<User> filterEmployeeData = Builders<User>.Filter.Eq("Id", id);

                return db.UserRecord.Find(filterEmployeeData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                db.UserRecord.ReplaceOne(filter: g => g.Id == user.Id, replacement: user);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteUser(string id)
        {
            try
            {
                FilterDefinition<User> employeeData = Builders<User>.Filter.Eq("Id", id);
                db.UserRecord.DeleteOne(employeeData);
            }
            catch
            {
                throw;
            }
        }
    }
}
