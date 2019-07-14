using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using SSMS.EntityModels;

namespace SSMS
{
  public class BaseService
  {
    public BaseService(SSMSContext db)
    {
      _db = db;
    }

    #region Privates Fields and Methods
    private SSMSContext _db { get; }
    // build the condition of every key value pair in set command one by one
    private string _BuildSetKeyVal<TEntity>(string[] keyValue)
    {
      string _field = keyValue[0].Trim();
      string _value = keyValue[1].Trim();
      var prop = typeof(TEntity).GetProperty(_field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
      // if field not found or null then return empty string
      if (prop == null)
        return "";
      TypeCode typeCode = System.Type.GetTypeCode(Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
      switch (typeCode)
      {
        case TypeCode.String:
        case TypeCode.DateTime:
          return $"{_field} = '{_value}'";
        case TypeCode.Boolean:
          _value = Convert.ToBoolean(_value) == true ? "1" : "0";
          return $"{_field} = {_value}";
        default:
          return $"{_field} = {_value}";
      }
    }
    // build and return sql set clause of update statement from the setters string
    // setters comma separated string of each :(key|value)
    private string _BuildSqlSet<TEntity>(string setters)
    {
      // split setters and add every key value pair in set command as an item in an array
      string[] settersArr = setters.SplitAndRemoveEmpty(',');
      // list to hold every key value pair in set command as an array with 2 items
      List<string[]> settersList = settersArr.Select(item => item.SplitAndRemoveEmpty('|'))
                                             .ToList();
      // and finally return the aggregate sqlSet statement
      return settersList.Aggregate("", (sqlSet, keyValue) =>
      {
        if(settersList.First() == keyValue)
          sqlSet += _BuildSetKeyVal<TEntity>(keyValue);
        else
          sqlSet += $", {_BuildSetKeyVal<TEntity>(keyValue)}";
        return sqlSet;
      });
    }
    // takes array of filters each :(field|operator|value)
    // formats it .... and generates the conditions of the sql where clause
    private string _BuildCondition<TEntity>(string[] filter, string prefix)
    {
      string _field = filter[0].Trim();
      string _operator = filter[1].Trim();
      string _value = filter[2].Trim();

      var prop = typeof(TEntity).GetProperty(_field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
      //if field not found or null , return empty string
      if (prop == null)
        return "";
      var propertyType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
      TypeCode typeCode = System.Type.GetTypeCode(propertyType);
      switch (typeCode)
      {
        case TypeCode.Boolean:
          switch (_operator)
          {
            case "=":
              return $"{prefix} {_field} = {_value} ";
            case "!=":
              return $"{prefix} {_field} != {_value} ";
            default:
              return "";
          }
        case TypeCode.String:
          switch (_operator)
          {
            case "=":
              return $"{prefix} {_field} = '{_value}' ";
            case "!=":
              return $"{prefix} {_field} != '{_value}' ";
            case "%":
              return $"{prefix} {_field} like '%{_value}%' ";
            case "@":
              return $"{prefix} CONTAINS({_field} , '{_value}') ";
            default:
              return "";
          }
        case TypeCode.Byte:
        case TypeCode.SByte:
        case TypeCode.UInt16:
        case TypeCode.UInt32:
        case TypeCode.UInt64:
        case TypeCode.Int16:
        case TypeCode.Int32:
        case TypeCode.Int64:
        case TypeCode.Single:
        case TypeCode.Double:
        case TypeCode.Decimal:
          switch (_operator)
          {
            case "=":
              return $"{prefix} {_field} = {_value} ";
            case "!=":
              return $"{prefix} {_field} != {_value} ";
            case ">":
              return $"{prefix} {_field} > {_value} ";
            case "<":
              return $"{prefix} {_field} < {_value} ";
            case ">=":
              return $"{prefix} {_field} >= {_value} ";
            case "<=":
              return $"{prefix} {_field} <= {_value} ";
            default:
              return "";
          }
        case TypeCode.DateTime:
          switch (_operator)
          {
            case "=":
              return $"{prefix} {_field} = '{_value}' ";
            case "!=":
              return $"{prefix} {_field} != '{_value}' ";
            case ">":
              return $"{prefix} {_field} > '{_value}' ";
            case "<":
              return $"{prefix} {_field} < '{_value}' ";
            case ">=":
              return $"{prefix} {_field} >= '{_value}' ";
            case "<=":
              return $"{prefix} {_field} <= '{_value}' ";
            default:
              return "";
          }
        default:
          return "";
      }
    }
    // build and return the sql where clause from the filters string [field|operator|value]
    public string _BuildSqlWhere<TEntity>(string filters)
    {
      // split filters and add every filter as an item in an array
      string[] filtersArr = filters.SplitAndRemoveEmpty(',');
      // list to hold every filter as an array with 3 item
      List<string[]> filtersList = filtersArr.Select(item => item.SplitAndRemoveEmpty('|'))
                                             .ToList();
      // build the condition of every filter one by one
      // and finally return the aggregate sqlWhere statement
      return filtersList.Aggregate("", (sqlWhere, filter) =>
      {
        sqlWhere += (filtersList.First() == filter)
                        ? _BuildCondition<TEntity>(filter, "where")
                        : _BuildCondition<TEntity>(filter, "and");
        return sqlWhere;
      });
    }
    // takes item(entity or record) and filter ([0] field [1] operator [2] value)
    // applies filter on item and returns result (true/false) to where() in ApplyFilter() function
    private bool _CheckFilter(object item, string[] filter)
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
    #endregion

    #region Query [Tables] Services
    public TEntity Find<TEntity, TKey>(TKey id) where TEntity : class
    {
      return _db.Set<TEntity>().Find(id);
    }
    public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
    {
      return _db.Set<TEntity>().AsNoTracking().SingleOrDefault(expression);
    }
    public TEntity GetOne<TEntity>(List<string> propsToInclude, Expression<Func<TEntity, bool>> expression) where TEntity : class
    {
      // if there is no PropsToInclude then return Filtered entity without navigation properties
      if (propsToInclude == null)
        return GetOne<TEntity>(expression);
      // if there is any PropsToInclude then
      // Filter out any Props from PropsToInclude which isn't a navigation property
      // Then include all Filtered PropsToInclude in the ef query
      // Finally return Filtered entity with all needed navigation properties
      else
      {
        var query = _db.Set<TEntity>().AsNoTracking();
        propsToInclude = _db.Model
            .FindEntityType(typeof(TEntity))
            .GetNavigations()
            .Where(navProperty => navProperty.Name == propsToInclude.Find(IncProperty => navProperty.Name == IncProperty))
            .Select(navProperty => navProperty.Name)
            .ToList();
        foreach (var property in propsToInclude)
          query = query.Include(property);
        return query.SingleOrDefault(expression);
      }
    }
    //takes a lambda expression and executes it (using .ToList()) and returns result as list
    public List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
    {
      return _db.Set<TEntity>().AsNoTracking().Where(expression).ToList();
    }
    //returns all entities without applying any filter expression
    public List<TEntity> GetList<TEntity>() where TEntity : class
    {
      return _db.Set<TEntity>().AsNoTracking().ToList();
    }
    // GetPageResult Does the following:
    // 1) get total items  based on ListType string (all/existing/deleted)
    // 2) calculate the count of items  based on ListType
    // 3) calculate the number of pages based on page size and count of items
    public PageResult<T> GetPageResult<T>(IQueryable<T> query, int pageSize, int pageNumber)
      where T : class
    {
      var count = query.Count();
      return new PageResult<T>
      {
        PageItems = query.Skip(pageSize * (pageNumber - 1))
                          .Take(pageSize)
                          .ToList(),
        TotalItems = count,
        // Ceiling is a math function that adjusts any decimal fraction to the next integer
        TotalPages = (int)Math.Ceiling((decimal)count / pageSize),
      };
    }
    public PageResult GetPageResult(IQueryable query, int pageSize, int pageNumber)
    {
      var count = query.Count();
      return new PageResult
      {
        PageItems = query.Skip(pageSize * (pageNumber - 1))
                          .Take(pageSize)
                          .ToDynamicList(),
        TotalItems = count,
        // Ceiling is a math function that adjusts any decimal fraction to the next integer
        TotalPages = (int)Math.Ceiling((decimal)count / pageSize),
      };
    }
    // takes a lambda expression (and doesn't execute it) and returns result as enumerable
    // so that I can reuse it and add more linq operators (count() or take())
    public IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class
    {
      return _db.Set<TEntity>().AsNoTracking().Where(expression);
    }
    // returns all rows of an entity, AsNoTracking to return IQueryable to enable chain to it later
    public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
    {
      return _db.Set<TEntity>().AsNoTracking();
    }
    // receives a comma separated string of filters
    // and converts it to array of filters,
    // each filter is string array [0] field [1] operator [2] value)
    // It uses checkFilter() , sends it (item {record} , filter {filed|operator|value})
    public IQueryable<TEntity> ApplyFilter<TEntity>(string filters) where TEntity : class
    {
      // split filters and add every filter as an item in an array
      string[] filtersArr = filters.Split(',', StringSplitOptions.RemoveEmptyEntries);
      // list to hold every filter as an array with 3 item
      List<string[]> filtersList = filtersArr.Select(item => item.Split('|', StringSplitOptions.RemoveEmptyEntries))
                                              .ToList();
      // use no tracking so that db context won't track changes on this dbSet
      // better performance that AsQueryable -- used in read only queries
      var query = _db.Set<TEntity>().AsNoTracking();
      foreach (var filter in filtersList)
        query = query.Where(item => _CheckFilter(item, filter));
      return query;
    }
    public IQueryable<TEntity> ApplySqlWhere<TEntity>(string filters, string tableName) where TEntity : class
    {
      // use no tracking so that db context won't track changes on this dbSet
      // better performance than AsQueryable -- used in read only queries
      var query = _db.Set<TEntity>().AsNoTracking();
      // build the sql select statement with sql where clause
      string sqlQuery = $"select * from {tableName} {_BuildSqlWhere<TEntity>(filters)}";
      // finally return the linq query
      return query.FromSql(sqlQuery);
    }
    public IQueryable<TEntity> ApplySort<TEntity>(string orderBy, IQueryable<TEntity> query) where TEntity : class
    {
      //if query is not provide, we start querying on the whole entity from the beginning
      // if we get the query, we continue working on it
      query = (query == null) ? _db.Set<TEntity>().AsNoTracking() : query;
      // convert comma separated list to array so that we can remove empty items
      orderBy = orderBy.RemoveEmptyElements(',');
      //use Linq.Dynamic.Core library to apply orderby using sql-like string not expression
      return query.OrderBy(orderBy);
    }
    public IQueryable ApplySelect<TEntity>(string fields, IQueryable query)
      where TEntity : class
    {
      //if query is not provide, we start querying on the whole entity from the beginning
      // if we get the query, we continue working on it
      query = (query == null) ? _db.Set<TEntity>().AsNoTracking() : query;
      fields = fields.RemoveEmptyElements(',');
      return query.Select($"new({fields})");
    }
    #endregion

    #region Query [Views and QueryType] Services
    public IQueryable<T> GetView<T>()
      where T : class
    {
      return _db.Query<T>();
    }
    public object GetView(Type type)
    {
      return  _db.GetType()
                .GetMethod("Query")
                .MakeGenericMethod(type)
                .Invoke(_db, new object[] { });
    }
    #endregion

    #region Data Manipulation (Add-Update-Delete)
    public int Add<TEntity>(TEntity entity) where TEntity : class
    {
      // Use db.Set<TEntity> to access db set collection (tables)
      // instead of using db.Parents or db.users  to be generic
      _db.Set<TEntity>().Add(entity);
      return _db.SaveChanges();
    }
    public TEntity Add<TEntity>(string sqlCommand) where TEntity : class
    {
      return _db.Set<TEntity>().FromSql(sqlCommand).FirstOrDefault();
    }
    public int Update<TEntity>(TEntity entity) where TEntity : class
    {
      //Attach the coming object to the db COntext
      //Change the coming object state to modified so that saveChanges generates an update statment
      _db.Entry(entity).State = EntityState.Modified;
      return _db.SaveChanges();
    }
    //update the primary key of any given table
    public int UpdateKey<TKey>(string tableName, string keyName, TKey newKey, TKey oldKey)
    {
      string sql = $"update {tableName} set ";
      if (Type.GetTypeCode(oldKey.GetType()) == TypeCode.String)
        sql += $"{keyName} = '{newKey}' where {keyName} = '{oldKey}'";
      else
        sql += $"{keyName} = {newKey} where {keyName} = {oldKey}";
      return _db.Database.ExecuteSqlCommand(sql);
    }
    // build sql update statement with set keyValue pair and with where clause
    // from the setters [comma separated key=value]
    // and the filters [comma separated key|operator|value]
    // finally execute the dynamically generated sql update statement
    public int SqlUpdate<TEntity>(string tableName, string setters, string filters)
    {
      string sql = $"update {tableName} set {_BuildSqlSet<TEntity>(setters)} {_BuildSqlWhere<TEntity>(filters)}";
      return _db.Database.ExecuteSqlCommand(sql);
    }
    /// <summary>
    /// takes entity to be deleted, get the 'isDeleted' property value , if exists get  its value
    /// if isDeleted is 'true' return , if not change its value to true
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public int DeleteLogical<TEntity>(TEntity entity)
    {
      string propName = "IsDeleted";
      if (entity.GetProperty(propName) == null)
        return -1;
      bool value = false;
      if (entity.GetValue(propName) != null)
        value = (bool)entity.GetValue(propName);
      if (value == true)
        return -2;
      entity.SetValue("IsDeleted", true);
      return _db.SaveChanges();
    }
    //takes entity to be deleted physically from DB, get the 'isDeleted' property , if exists delete the whole row from table
    public int Delete<TEntity>(TEntity entity) where TEntity : class
    {
      _db.Set<TEntity>().Remove(entity);
      return _db.SaveChanges();
    }
    //to attach the entity to the DBCOntext so that the change tracker is aware of it
    //Behind the scenes, many other function can call attach like (add, remove..)
    //Also any entity returned from a query (find, firstOrDefault ....) will call Attach be Default
    //We use it only in cases where Attach won't be called by default (by Add() or Remove() or Change entity state)
    public void Attach<TEntity>(TEntity entity) where TEntity : class
    {
      _db.Set<TEntity>().Attach(entity);
    }
    //sets entity state , 4 cases
    // added > executes insert statement
    // Modified > update
    // Deleted > delete
    // unchanged > do nothing
    // db.Entry function checks if entity is attached or not,
    // if not, it attaches it to dbSet , then changes its state
    public void SetState<TEntity>(TEntity entity, string state) where TEntity : class
    {
      switch (state)
      {
        case "Added":
          _db.Entry(entity).State = EntityState.Added;
          break;
        case "Modified":
          _db.Entry(entity).State = EntityState.Modified;
          break;
        case "Deleted":
          _db.Entry(entity).State = EntityState.Deleted;
          break;
        default:
          _db.Entry(entity).State = EntityState.Unchanged;
          break;
      }
    }
    public int Save()
    {
      return _db.SaveChanges();
    }

    #endregion
  }
}