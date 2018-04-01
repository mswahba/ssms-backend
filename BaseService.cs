using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SSMS.EntityModels;

namespace SSMS
{
    public class PageResult<TEntity> where TEntity : class
    {
        public List<dynamic> PageItems { get; set; }
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
        //takes a labmda expression and executes it (using .ToList()) and returns result as list  
        public List<TEntity> GetList(Func<TEntity, bool> expression)
        {
            return db.Set<TEntity>().Where(expression).ToList();
        }
        //returns all entities without applying any filter expression 
        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }
        //takes a labmda expression (and doesn't execute it) and returns result as enumerable  
        //so that I can reuse it and add more linq operators (count() or take())  
        public IEnumerable<TEntity> GetQuery(Func<TEntity, bool> expression)
        {
            return db.Set<TEntity>().Where(expression);
        }
        //returns all rows of an entity, AsQuerable to chain it later   
        public IEnumerable<TEntity> GetQuery()
        {
            return db.Set<TEntity>().AsQueryable();
        }
        //takes item(entity or record) and filter ([0] field [1] operator [2] value)
        //applies filter on item and returns result (true/false) to where() in ApplyFilter() function
        public bool CheckFilter(object item, string[] filter)
        {
            string _field = filter[0].Trim();
            string _operator = filter[1].Trim();
            string _value = filter[2].Trim();
            var prop = item.GetProperty(_field);
            if (prop == null)
                return false;  //if field not found or null , return false to Where()
            var propertyType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
            TypeCode typeCode = System.Type.GetTypeCode(propertyType);
            //First get value of filed in current row ex. age = 20 
            // compare it with the value we received from query ex. 25  
            //with every row we check : where (20 == 25) then return res (t or f) then go to next row
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToBoolean(item.GetValue(_field)) == Convert.ToBoolean(_value);
                        case "!=":
                            return Convert.ToBoolean(item.GetValue(_field)) != Convert.ToBoolean(_value);
                        default:
                            return false;
                    }
                case TypeCode.String:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToString(item.GetValue(_field)).ToLower() == _value.ToLower();
                        case "!=":
                            return Convert.ToString(item.GetValue(_field)).ToLower() != _value.ToLower();
                        case "%":
                            return Convert.ToString(item.GetValue(_field)).ToLower().Contains(_value.ToLower());
                        case "@":
                            return Regex.IsMatch(item.GetValue(_field).ToString().ToLower(), string.Format(@"\b{0}\b", Regex.Escape(_value.ToLower())));
                        default:
                            return false;
                    }
                case TypeCode.Byte:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToByte(item.GetValue(_field)) == Convert.ToByte(_value);
                        case "!=":
                            return Convert.ToByte(item.GetValue(_field)) != Convert.ToByte(_value);
                        case ">":
                            return Convert.ToByte(item.GetValue(_field)) > Convert.ToByte(_value);
                        case "<":
                            return Convert.ToByte(item.GetValue(_field)) < Convert.ToByte(_value);
                        case ">=":
                            return Convert.ToByte(item.GetValue(_field)) >= Convert.ToByte(_value);
                        case "<=":
                            return Convert.ToByte(item.GetValue(_field)) <= Convert.ToByte(_value);
                        default:
                            return false;
                    }
                case TypeCode.SByte:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToSByte(item.GetValue(_field)) == Convert.ToSByte(_value);
                        case "!=":
                            return Convert.ToSByte(item.GetValue(_field)) != Convert.ToSByte(_value);
                        case ">":
                            return Convert.ToSByte(item.GetValue(_field)) > Convert.ToSByte(_value);
                        case "<":
                            return Convert.ToSByte(item.GetValue(_field)) < Convert.ToSByte(_value);
                        case ">=":
                            return Convert.ToSByte(item.GetValue(_field)) >= Convert.ToSByte(_value);
                        case "<=":
                            return Convert.ToSByte(item.GetValue(_field)) <= Convert.ToSByte(_value);
                        default:
                            return false;
                    }
                case TypeCode.UInt16:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToUInt16(item.GetValue(_field)) == Convert.ToUInt16(_value);
                        case "!=":
                            return Convert.ToUInt16(item.GetValue(_field)) != Convert.ToUInt16(_value);
                        case ">":
                            return Convert.ToUInt16(item.GetValue(_field)) > Convert.ToUInt16(_value);
                        case "<":
                            return Convert.ToUInt16(item.GetValue(_field)) < Convert.ToUInt16(_value);
                        case ">=":
                            return Convert.ToUInt16(item.GetValue(_field)) >= Convert.ToUInt16(_value);
                        case "<=":
                            return Convert.ToUInt16(item.GetValue(_field)) <= Convert.ToUInt16(_value);
                        default:
                            return false;
                    }
                case TypeCode.UInt32:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToUInt32(item.GetValue(_field)) == Convert.ToUInt32(_value);
                        case "!=":
                            return Convert.ToUInt32(item.GetValue(_field)) != Convert.ToUInt32(_value);
                        case ">":
                            return Convert.ToUInt32(item.GetValue(_field)) > Convert.ToUInt32(_value);
                        case "<":
                            return Convert.ToUInt32(item.GetValue(_field)) < Convert.ToUInt32(_value);
                        case ">=":
                            return Convert.ToUInt32(item.GetValue(_field)) >= Convert.ToUInt32(_value);
                        case "<=":
                            return Convert.ToUInt32(item.GetValue(_field)) <= Convert.ToUInt32(_value);
                        default:
                            return false;
                    }
                case TypeCode.UInt64:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToUInt64(item.GetValue(_field)) == Convert.ToUInt64(_value);
                        case "!=":
                            return Convert.ToUInt64(item.GetValue(_field)) != Convert.ToUInt64(_value);
                        case ">":
                            return Convert.ToUInt16(item.GetValue(_field)) > Convert.ToUInt64(_value);
                        case "<":
                            return Convert.ToUInt64(item.GetValue(_field)) < Convert.ToUInt64(_value);
                        case ">=":
                            return Convert.ToUInt64(item.GetValue(_field)) >= Convert.ToUInt64(_value);
                        case "<=":
                            return Convert.ToUInt64(item.GetValue(_field)) <= Convert.ToUInt64(_value);
                        default:
                            return false;
                    }
                case TypeCode.Int16:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToInt16(item.GetValue(_field)) == Convert.ToInt16(_value);
                        case "!=":
                            return Convert.ToInt16(item.GetValue(_field)) != Convert.ToInt16(_value);
                        case ">":
                            return Convert.ToInt16(item.GetValue(_field)) > Convert.ToInt16(_value);
                        case "<":
                            return Convert.ToInt16(item.GetValue(_field)) < Convert.ToInt16(_value);
                        case ">=":
                            return Convert.ToInt16(item.GetValue(_field)) >= Convert.ToInt16(_value);
                        case "<=":
                            return Convert.ToInt16(item.GetValue(_field)) <= Convert.ToInt16(_value);
                        default:
                            return false;
                    }
                case TypeCode.Int32:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToInt32(item.GetValue(_field)) == Convert.ToInt32(_value);
                        case "!=":
                            return Convert.ToInt32(item.GetValue(_field)) != Convert.ToInt32(_value);
                        case ">":
                            return Convert.ToInt32(item.GetValue(_field)) > Convert.ToInt32(_value);
                        case "<":
                            return Convert.ToInt32(item.GetValue(_field)) < Convert.ToInt32(_value);
                        case ">=":
                            return Convert.ToInt32(item.GetValue(_field)) >= Convert.ToInt32(_value);
                        case "<=":
                            return Convert.ToInt32(item.GetValue(_field)) <= Convert.ToInt32(_value);
                        default:
                            return false;
                    }
                case TypeCode.Int64:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToInt64(item.GetValue(_field)) == Convert.ToInt64(_value);
                        case "!=":
                            return Convert.ToInt64(item.GetValue(_field)) != Convert.ToInt64(_value);
                        case ">":
                            return Convert.ToInt64(item.GetValue(_field)) > Convert.ToInt64(_value);
                        case "<":
                            return Convert.ToInt64(item.GetValue(_field)) < Convert.ToInt64(_value);
                        case ">=":
                            return Convert.ToInt64(item.GetValue(_field)) >= Convert.ToInt64(_value);
                        case "<=":
                            return Convert.ToInt64(item.GetValue(_field)) <= Convert.ToInt64(_value);
                        default:
                            return false;
                    }
                case TypeCode.Single:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToSingle(item.GetValue(_field)) == Convert.ToSingle(_value);
                        case "!=":
                            return Convert.ToSingle(item.GetValue(_field)) != Convert.ToSingle(_value);
                        case ">":
                            return Convert.ToSingle(item.GetValue(_field)) > Convert.ToSingle(_value);
                        case "<":
                            return Convert.ToSingle(item.GetValue(_field)) < Convert.ToSingle(_value);
                        case ">=":
                            return Convert.ToSingle(item.GetValue(_field)) >= Convert.ToSingle(_value);
                        case "<=":
                            return Convert.ToSingle(item.GetValue(_field)) <= Convert.ToSingle(_value);
                        default:
                            return false;
                    }
                case TypeCode.Double:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToDouble(item.GetValue(_field)) == Convert.ToDouble(_value);
                        case "!=":
                            return Convert.ToDouble(item.GetValue(_field)) != Convert.ToDouble(_value);
                        case ">":
                            return Convert.ToDouble(item.GetValue(_field)) > Convert.ToDouble(_value);
                        case "<":
                            return Convert.ToDouble(item.GetValue(_field)) < Convert.ToDouble(_value);
                        case ">=":
                            return Convert.ToDouble(item.GetValue(_field)) >= Convert.ToDouble(_value);
                        case "<=":
                            return Convert.ToDouble(item.GetValue(_field)) <= Convert.ToDouble(_value);
                        default:
                            return false;
                    }
                case TypeCode.Decimal:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToDecimal(item.GetValue(_field)) == Convert.ToUInt16(_value);
                        case "!=":
                            return Convert.ToDecimal(item.GetValue(_field)) != Convert.ToDecimal(_value);
                        case ">":
                            return Convert.ToDecimal(item.GetValue(_field)) > Convert.ToDecimal(_value);
                        case "<":
                            return Convert.ToDecimal(item.GetValue(_field)) < Convert.ToDecimal(_value);
                        case ">=":
                            return Convert.ToDecimal(item.GetValue(_field)) >= Convert.ToDecimal(_value);
                        case "<=":
                            return Convert.ToDecimal(item.GetValue(_field)) <= Convert.ToDecimal(_value);
                        default:
                            return false;
                    }
                case TypeCode.DateTime:
                    switch (_operator)
                    {
                        case "=":
                            return Convert.ToDateTime(item.GetValue(_field)) == Convert.ToDateTime(_value);
                        case "!=":
                            return Convert.ToDateTime(item.GetValue(_field)) != Convert.ToDateTime(_value);
                        case ">":
                            return Convert.ToDateTime(item.GetValue(_field)) > Convert.ToDateTime(_value);
                        case "<":
                            return Convert.ToDateTime(item.GetValue(_field)) < Convert.ToDateTime(_value);
                        case ">=":
                            return Convert.ToDateTime(item.GetValue(_field)) >= Convert.ToDateTime(_value);
                        case "<=":
                            return Convert.ToDateTime(item.GetValue(_field)) <= Convert.ToDateTime(_value);
                        default:
                            return false;
                    }
                default:
                    return false;
            }
        }
        // receives a comma separated string of filters 
        // and converts it to array of filters, 
        // each filter is string array [0] field [1] operator [2] value) 
        //It uses checkFilter() , sends it (item {record} , filter {filed|operator|value})
        public IQueryable<TEntity> ApplyFilter(string filters)
        {
            //split filters and add every filter as an item in an array 
            string[] filtersArr = filters.Split(',', StringSplitOptions.RemoveEmptyEntries);
            //list to hold every filter as an arry with 3 item 
            List<string[]> filtersList = filtersArr.Select(item => item.Split('|', StringSplitOptions.RemoveEmptyEntries))
                                                    .ToList();
            //use no tracking so that db context won't track changes on this dbset 
            //better performance that AsQueriable -- used in read only queries 
            var query = db.Set<TEntity>().AsNoTracking();
            foreach (var filter in filtersList)
                query = query.Where(item => CheckFilter(item, filter));
            return query;
        }
        public IQueryable<TEntity> ApplySort(string orderBy, IQueryable<TEntity> query)
        {
            //if query is not provide, we start querying on the whole entity from the beginning
            // if we get the query, we continue working on it  
            query = (query == null) ? db.Set<TEntity>().AsNoTracking() : query;
            // convert comma separated list to array so that we can remove empty items                             
            orderBy = orderBy.RemoveEmptyElements();
            //use Linq.Dynamic.Core library to apply orderby using sql-like string not expression 
            return query.OrderBy(orderBy);
        }
        public IQueryable ApplySelect(string fields, IQueryable<TEntity> query)
        {
            //if query is not provide, we start querying on the whole entity from the beginning
            // if we get the query, we continue working on it  
            query = (query == null) ? db.Set<TEntity>().AsNoTracking() : query;
            fields = fields.RemoveEmptyElements();
            return query.Select($"new({fields})");
        }
        public TEntity Find(TKey id)
        {
            return db.Set<TEntity>().Find(id);
        }
        //Does the following: 
        // 1) get total items  based on ListType string (all/existing/deleted) 
        // 2) calculate the count of items  based on ListType
        // 3) calculate the number of pages based on page size and count of items
        public PageResult<TEntity> GetPage(string listType, int pageSize, int pageNumber)
        {
            // create a generic delegate of type <TEntity> and returns a bool 
            // so that it will be used with linq Where() function 
            Func<TEntity, bool> expression;

            switch (listType.ToLower())
            {
                case "all":
                    return new PageResult<TEntity>
                    {
                        PageItems = db.Set<TEntity>().Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToDynamicList(), 
                        TotalItems = db.Set<TEntity>().Count(),
                        //Ceiling is a math function that adjusts any decimal fraction to the next integer 
                        TotalPages = (int)Math.Ceiling((decimal)db.Set<TEntity>().Count() / pageSize),
                    };
                case "deleted":
                    expression = item =>
                                        item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                                        ? false
                                        : true;
                    return new PageResult<TEntity>
                    {
                        PageItems = GetQuery(expression)
                                    .Skip(pageSize * (pageNumber - 1))
                                    .Take(pageSize).ToDynamicList(),
                        TotalItems = GetQuery(expression)
                                    .Count(),
                        TotalPages = (int)Math.Ceiling((decimal)GetQuery(expression).Count() / pageSize),
                    };
                case "existing":
                    expression = item =>
                                item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                                ? true
                                : false;
                    return new PageResult<TEntity>
                    {
                        PageItems = GetQuery(expression)
                                    .Skip(pageSize * (pageNumber - 1))
                                    .Take(pageSize).ToDynamicList(),
                        TotalItems = GetQuery(expression)
                                    .Count(),
                        TotalPages = (int)Math.Ceiling((decimal)GetQuery(expression).Count() / pageSize),
                    };
                default:
                    return null;    //if no List Type provided
            }

        }
        public PageResult<TEntity> GetPageResult(IQueryable query, int pageSize, int pageNumber)
        {
            return new PageResult<TEntity>
            {
                PageItems =query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToDynamicList(),
                TotalItems =query.Count(),
                //Ceiling is a math function that adjusts any decimal fraction to the next integer 
                TotalPages = (int)Math.Ceiling((decimal)query.Count() / pageSize),
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
        //sets entity state , 4 cases 
        // added > executes insert statement   
        // Modified > update 
        // Deleted > delete    
        // unchanged > do nothing  
        //db.Entry function checkis if entity is attached or not, 
        //if not, it attaches it to dbSet , then changes its state 
        public void SetState(TEntity entity, string state)
        {
            switch (state)
            {
                case "Added":
                    db.Entry(entity).State = EntityState.Added;
                    break;
                case "Modified":
                    db.Entry(entity).State = EntityState.Modified;
                    break;
                case "Deleted":
                    db.Entry(entity).State = EntityState.Deleted;
                    break;
                default:
                    db.Entry(entity).State = EntityState.Unchanged;
                    break;
            }
        }
        public int Save()
        {
            return db.SaveChanges();
        }
    }
}