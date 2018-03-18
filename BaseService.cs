using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SSMS.EntityModels;

namespace SSMS
{
    public class PageResult<TEntity> where TEntity : class
    {
        public List<TEntity> PageItems { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
    public class BaseService<TEntity, TKey> where TEntity : class
    {
        private SSMSContext db { get; }
        public BaseService(SSMSContext _db)
        {
            db = _db;
        }
        public int Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            return db.SaveChanges();
        }
        public TEntity GetOne(Func<TEntity, bool> expression)
        {
            return db.Set<TEntity>().Where(expression).SingleOrDefault();
        }
        public List<TEntity> GetList(Func<TEntity, bool> expression)
        {
            return db.Set<TEntity>().Where(expression).ToList();
        }
        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }
        public TEntity Find(TKey id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public PageResult<TEntity> GetPage(int pageSize, int pageNumber)
        {
            return new PageResult<TEntity>
            {
                PageItems = db.Set<TEntity>().Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList(),
                TotalItems = db.Set<TEntity>().Count(),
                TotalPages = (int)Math.Ceiling((decimal)db.Set<TEntity>().Count() / pageSize),
            };
        }
        public int Update(TEntity entity)
        {
            //Attach the coming object to the db COntext 
            //Change the coming object state to modified so that saveChanges generates an update statment 
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();
        }
        public int UpdateKey(string tableName, string keyName, string newKey, string oldKey)
        {
            string sql = $"update {tableName} set {keyName} = {newKey} where {keyName} = {oldKey}"; 
            return db.Database.ExecuteSqlCommand(sql); 
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}