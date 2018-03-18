using System;
using System.Linq;
using SSMS.EntityModels;
/// <summary>
/// ALl services that deal with DB functions (save- query - add - update - delete)
/// </summary>
namespace SSMS.Users
{
    public class UsersService
    {
        //Store the dbContext object that comes 
        //from DependencyInjection DI which injects it in the constructor
        private SSMSContext db { get; }
        public UsersService(SSMSContext _db)
        {
            db = _db;    //DI inject DBContext object here from startup Class
        }
        public void AddUser(User user)
        {
            db.Users.Add(user);    // attach user object to the DB Set collection of Users and change its state to (Added)
            db.SaveChanges();      //Generate the appropriate sql statement based on the object state  
        }
        public User GetUser(Func<User,bool> expression)
        {
            return db.Users.Where(expression).SingleOrDefault();  //this function executes the where
        }
        public int Save()
        {
           return db.SaveChanges(); 
        }
    }
}