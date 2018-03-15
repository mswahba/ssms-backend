using System;
using System.Linq;
using SSMS.EntityModels;

namespace SSMS.Users.Parents
{
    public class ParentsService
    {
        private SSMSContext db { get; }
        public ParentsService(SSMSContext _db)
        {
            db = _db;   
        }
        public void AddParent(Parent parent)
        {
            db.Parents.Add(parent);  
            db.SaveChanges();      
        }
        public Parent GetParent(Func<Parent,bool> expression)
        {
            return db.Parents.Where(expression).SingleOrDefault(); 
        }
        public int Save()
        {
           return db.SaveChanges(); 
        }
    }
}