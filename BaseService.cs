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
            // Use db.Set<TEntity> to access db set collection (tables) 
            // instead of using db.Parents or db.users  to be generic    
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
        //update the primary key of any given table 
        public int UpdateKey(string tableName, string keyName, TKey newKey, TKey oldKey)
        {
            string sql = $"update {tableName} set {keyName} = {newKey.ToString()} where {keyName} = {oldKey.ToString()}";
            return db.Database.ExecuteSqlCommand(sql);
        }
        /// <summary>
        /// takes entity to be deleted, get the 'isDeleted' property value , if exists get  its value 
        /// if isDeleted is 'true'  return , if not change its value to true 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int DeleteLogical(TEntity entity)
        {
            string propName = "IsDeleted";
            if (entity.GetProperty(propName) == null)
                return 0;
            bool value = false;
            if (entity.GetValue(propName) != null)
                value = (bool)entity.GetValue(propName);
            if (value == true)
                return 0;
            entity.SetValue("IsDeleted", true);
            return db.SaveChanges();
        }
        //takes entity to be deleted physically from DB, get the 'isDeleted' property , if exists delete the whole row from table
        public int Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            return db.SaveChanges();
        }
        //to attach the entity to the DBCOntext so that the change tracker is aware of it
        //Behind the scenes, many other function can call attach like (add, remove..)
        //Also any entity returned from a query (find, firstOrDefault ....) will call Attach be Default
        //We use it only in cases where Attach won't be called by default (by Add() or Remove() or Change entity state)
        public void Attach(TEntity entity)
        {
            db.Set<TEntity>().Attach(entity); 
        } 
        public int Save()
        {
            return db.SaveChanges();
        }

    }
}