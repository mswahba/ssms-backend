using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        public int AddParent(Parent parent)
        {
            db.Parents.Add(parent);  
            return db.SaveChanges(); 
        }
        public int UpdateParent(Parent parent)
        {
            //Attach the coming object to the db COntext 
            //Change the coming object state to modified so that saveChanges generates an update statment 
            db.Entry(parent).State = EntityState.Modified;
            return db.SaveChanges(); 
        }
        public int UpdateParentId(string newId, string oldId)
        {
            string sql = $"update parents set parentId = {newId} where parentId = {oldId}"; 
            return db.Database.ExecuteSqlCommand(sql); 
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