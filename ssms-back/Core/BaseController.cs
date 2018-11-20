using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;
using SSMS.MvcFilters;
using AutoMapper;

namespace SSMS
{
  // [Authorize]
  [ApiExceptionFilter]
  [ApiController]
  [Route("[controller]")]
  public class BaseController<TEntity, TKey, TVEntity> : ControllerBase
    where TEntity : class
    where TVEntity : class
  {
    private readonly BaseService _service;
    private readonly IMapper _mapper;
    private readonly Ado _ado;
    private readonly string _tableName;
    private readonly string _keyName;

    private string _sqlAddCommand;
    private string _columnNames;
    private string _columnValues;
    private Dictionary<string, object> _deleteResult;
    private List<string> _BlockedFromAdd = new List<string>() { "User" };

    private void _SetDeleteResult(TEntity entity, int res, string deleteType)
    {
      _deleteResult = new Dictionary<string, object>();
      _deleteResult.Add(_keyName, entity.GetValue(_keyName));
      _deleteResult.Add("DeleteType", deleteType);
      _deleteResult.Add("Message", $"{res} Item(s) Deleted successfully...");
    }
    private IActionResult _DoDelete(string deleteType, TEntity entity)
    {
      if (deleteType == null)
        return BadRequest(new Error() { Message = "Can't identify The type of the Delete operation" });
      if (entity == null)
        return BadRequest(new Error() { Message = "Item doesn't exist" });
      // switch on the [deleteType] and perform the appropriate action
      int res;
      switch (deleteType)
      {
        case "logical":
          res = _service.DeleteLogical(entity);
          if (res == -1)
            return BadRequest(new Error() { Message = "Can't delete this Item Logically" });
          else if (res == -2)
            return BadRequest(new Error() { Message = "Item has already been Logically deleted before" });
          _SetDeleteResult(entity, res, "logical");
          return Ok(_deleteResult);
        case "physical":
          res = _service.Delete(entity);
          _SetDeleteResult(entity, res, "physical");
          return Ok(_deleteResult);
        default:
          return BadRequest(new Error() { Message = "Unknow Delete Type" });
      }
    }
    // map the page result
    private PageResult<TVEntity> _mapPageResult(PageResult<TEntity> pageResult)
    {
      return new PageResult<TVEntity>()
      {
        PageItems = _mapper.Map<List<TVEntity>>(pageResult.PageItems),
        TotalItems = pageResult.TotalItems,
        TotalPages = pageResult.TotalPages
      };
    }
    // get the query result:
    // check if there is paging then getPageResult else return query
    // check if there is mapping then mapPageResult [TEntity to TVEntity] else return pageResult
    private IActionResult _GetQueryResult(int? pageSize, int? pageNumber, IQueryable<TEntity> query)
    {
      // if page size and number are provided, return page result  (from GetPage())
      if (pageSize != null && pageNumber != null)
      {
        var pageResult = _service.GetPageResult<TEntity>(query, (int)pageSize, (int)pageNumber);
        if (typeof(TEntity).Name != typeof(TVEntity).Name)
          return Ok(_mapPageResult(pageResult));
        return Ok(pageResult);
      }
      if (typeof(TEntity).Name != typeof(TVEntity).Name)
        return Ok(_mapper.Map<List<TVEntity>>(query.ToList()));
      return Ok(query);
    }
    // get the entity result:
    // check if there is mapping then map Entity to VEntity else return Entity
    private IActionResult _GetEntityResult(TEntity entity)
    {
      // if everything is ok, return the full user Or the mapped user
      if (typeof(TEntity).Name != typeof(TVEntity).Name)
        return Ok(_mapper.Map<TVEntity>(entity));
      return Ok(entity);
    }
    // receive the service (to deal with db)
    // and the table name of the entity (from entity Controller) and the PK field name
    // and the ado from DI
    public BaseController(BaseService service, IMapper mapper, string tableName, string keyName, Ado ado)
    {
      _tableName = tableName;
      _keyName = keyName;
      _service = service;
      _mapper = mapper;
      _ado = ado;
    }
    //Get list of all items OR Non-Deleted (only) or Deleted (only) Items in a table besed on route param-
    //we send the list type as Route parameter ("all OR "deleted" OR "Existing")
    //we receive pagesize and page number (optional) if exists we return pageResult
    // which is a complex type that contains :
    //(pageItems : List of items, Number of TotalItems,Number of TotalPages)
    // if they aren't , return regular list of entity
    // [controller]/list/all?pagesize=25&pageNumber=4
    [HttpGet("List/{listType}")]
    public IActionResult list([FromRoute]string listType, [FromQuery] int? pageSize, [FromQuery]int? pageNumber)
    {
      //if list type doesn't match these three acceptable values (all/deleted/existing)
      //return bad request
      if (listType.ToLower() != "existing" &&
          listType.ToLower() != "deleted" &&
          listType.ToLower() != "all")
        return BadRequest(new Error() { Message = "Unknow List Type.[all] OR [deleted] OR [existing] only acceptable" });
      //If page size & number aren't provided from the query string
      //then return regular result based on list type.
      IQueryable<TEntity> query;
      switch (listType.ToLower())
      {
        case "existing":
          query = _service.GetQuery<TEntity>(item =>
              item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                        ? true
                        : false
          );
          break;
        case "deleted":
          query = _service.GetQuery<TEntity>(item =>
            item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                        ? false
                        : true
          );
          break;
        case "all":
          query = _service.GetQuery<TEntity>();
          break;
        default:
          query = _service.GetQuery<TEntity>();
          break;
      }
      return _GetQueryResult(pageSize, pageNumber, query);
    }

    /// <summary>
    ///Make it as default action for the controller
    ///    [controller]?filters=.....&fileds=.....&orderby=....
    ///    [controller]?fileds=.....&orderby=....
    ///    [controller]?orderby=....
    /// </summary>
    /// <param name="filters">one filter is like this [field|operator|value] </param>
    /// <param name="fields">a comma separated string of entity fields we want to select </param>
    /// <param name="orderBy">Users/sort?orderby= userId desc, userPassword</param>
    /// <param name="pageSize">Number of items per page</param>
    /// <param name="pageNumber">Number of page to get </param>
    /// <returns></returns>
    [HttpGet("")]
    public IActionResult Query([FromQuery] string filters,
                                [FromQuery] string fields,
                                [FromQuery] string orderBy,
                                [FromQuery] int? pageSize,
                                [FromQuery] int? pageNumber)
    {
      if (filters == null && fields == null && orderBy == null)
        return BadRequest(new Error() { Message = "Must supply at least one of the following : [filters] and/or [fields] and/or [orderBy]" });
      IQueryable<TEntity> query = _service.GetQuery<TEntity>().AsQueryable();
      IQueryable dynamicQuery;
      // if filters provided, apply filters and get the query after applying (where) on it
      if (filters != null)
        query = _service.ApplySqlWhere<TEntity>(filters, _tableName);
      // if orderBy provided, Give it the previous query (either filtered or not )
      // then apply sort and get the query after applying (orderBy) on it
      if (orderBy != null)
        query = _service.ApplySort(orderBy, query);
      // put query value (whether filtered and ordered, filtered only, ordered only, nothing applied) in result
      dynamicQuery = query;
      // if select fields provided, apply dynamic select on the previous query
      if (fields != null)
      {
        dynamicQuery = _service.ApplySelect<TEntity>(fields, query);
        if (pageSize != null && pageNumber != null)
        {
          var PageResult = _service.GetPageResult(dynamicQuery, (int)pageSize, (int)pageNumber);
          return Ok(PageResult);
        }
        return Ok(dynamicQuery);
      }
      return _GetQueryResult(pageSize, pageNumber, query);
    }

    [HttpGet("{id}")]
    public IActionResult Find(TKey id)
    {
      var entity = _service.Find<TEntity, TKey>(id);
      if (entity == null)
        return BadRequest(new Error() { Message = "Invalid Id ..." });
      return _GetEntityResult(entity);
    }
    [HttpPost("add")]
    public IActionResult Add([FromBody] TEntity entity)
    {
      if( _BlockedFromAdd.Any(eName => eName == typeof(TEntity).Name) )
        return BadRequest(new Error() { Message = "Oops! this action is not available for this entity !!" });
      // throw new Exception("something went wrong!!");
      // if autoId has value [ok] then generate newId and set keyName of this entity
      // otherwise the entity keyField [PK] has value [from User Input]
      if (entity.GetValue(_keyName).ToString() == "0")
      {
        // get the comma separated column names
        _columnNames = entity.GetPrimitivePropsNames();
        // get the comma separated column values
        // note: key column value replaced with the sql variable [@newId]
        // which will be fulfilled before executing the insert statement
        _columnValues = entity.GetPrimitivePropsValues();
        // build SQL Command that:
        // (1) get the max key value from entity table
        // (2) If it is = null then set it = 0
        // (3) increment it by one
        // (4) insert the entity with its values
        // (5) select the previously inserted entity
        _sqlAddCommand = $@"
          Declare @newId int;
          set @newId = (select max({_keyName}) from {_tableName});
          if @newId is null set @newId = 0;
          set @newId = @newId + 1;
          insert into {_tableName} ({_columnNames}) values ({_columnValues});
          select * from {_tableName} where {_keyName} = @newId;
        ";
        Console.WriteLine(_sqlAddCommand);
        // execute SQL Command and return its value
        entity = _service.Add<TEntity>(_sqlAddCommand);
      }
      else
      {
        // add entity and saveChanges
        _service.Add(entity);
      }
      return _GetEntityResult(entity);
    }
    //Update all parent Data -- used either by Parent or Admin
    [HttpPut("update")]
    public IActionResult Update([FromBody]TEntity entity)
    {
      _service.Update<TEntity>(entity);
      return _GetEntityResult(entity);
    }
    // update Only ParentId --Used by Admins Only
    [HttpPut("update-Key")]
    public IActionResult UpdateKey([FromQuery] TKey newKey, TKey oldKey)
    {
      if (newKey == null || oldKey == null)
        return BadRequest(new Error() { Message = "Must supply both newKey and oldKey ..." });
      _service.UpdateKey(_tableName, _keyName, newKey, oldKey);
      //Use Reflection : When we have a string OF a property and want to access a property value in runtime
      //Get type,
      //Get Property (binding Flags: ignore case sensitive, instance (not static), public) ,
      //Get Value
      TEntity entity = _service.GetOne<TEntity>(item => item.GetValue(_keyName).Equals(newKey));
      return _GetEntityResult(entity);
    }
    //An action to receive type of Delete operation (logical or physical) and the entity to be deleted
    // Then call the appropriate function from the BaseService class to execute operation
    // the param (deleteType) will come from queryString
    [HttpPost("delete")]
    public IActionResult Delete([FromQuery] string deleteType, [FromBody] TEntity entity)
    {
      return _DoDelete(deleteType, entity);
    }
    //An action to receive type of Delete operation (logical or physical) and the entity to be deleted
    // Then call the appropriate function from the BaseService class to execute operation
    // the param (deleteType) will come from queryString
    [HttpDelete("delete-by-id")]
    public IActionResult Delete([FromQuery] string deleteType, [FromQuery] TKey key)
    {
      // First get the entity using its key to send it to delete method
      TEntity entity = _service.Find<TEntity, TKey>(key);
      return _DoDelete(deleteType, entity);
    }
    /********************************************************** */
    #region assistant Actions
    //'filters' is a comma separated "string" and
    //one filter is like this [field|operator|value]
    // operators must be one of (= , != , > , < , >=, <=, % [contains], @ [contains whole word])
    // Route : Users?filters=userName|=|Mohammad , age| > |20, isActive|=|false
    [HttpGet("filter")]
    public IActionResult Filter([FromQuery] string filters)
    {
      var query = _service.ApplyFilter<TEntity>(filters);
      return Ok(query);
    }
    // [controller]/sql-update?setters=[value]&filters=[value]
    // Apply sql update Caluse
    [HttpGet("sql-update")]
    public IActionResult SqlUpdate([FromQuery] string setters, [FromQuery] string filters)
    {
      if(setters == null && filters == null)
        return BadRequest(new Error() { Message = "must supply both setters and filters query string" });
      int rows = _service.SqlUpdate<TEntity>(_tableName,setters,filters);
      return Ok($"{rows} row(s) affected ...");
    }
    // [controller]/sql-where?filters=
    // Apply sql Where Caluse
    [HttpGet("sql-where")]
    public IActionResult SqlWhere([FromQuery] string filters)
    {
      var query = _service.ApplySqlWhere<TEntity>(filters, _tableName);
      return Ok(query);
    }
    // 'fields' is a comma separated string of entity fields we want to select
    // return entity that contains only these fields
    // [controller]/Select?fileds=empId, empName
    [HttpGet("select")]
    public IActionResult Select([FromQuery] string fields)
    {
      if (fields == null)
        return BadRequest(new Error() { Message = "Must supply fields" });
      // string[] fieldsArr = fields.Split(',', StringSplitOptions.RemoveEmptyEntries);
      // fieldsArr = fieldsArr.Where(field => !string.IsNullOrWhiteSpace(field)).ToArray();
      //dict to hold anonymous obj .....
      var fieldsArr = fields.SplitAndRemoveEmpty(',');
      Dictionary<string, object> obj;
      //Get collection of all fileds(columns) and items(rows)
      var items = _service.GetQuery<TEntity>().ToList();
      //filter the collection of items to return only the required fields
      // Select creates an empty array of type the same as that returns from its inside block
      // then iterates all items and adds the returned value to the newly created array
      // after Select() iterates all items , it returns the array of items to result variable
      var result = items.Select(item =>
      {
        // Create empty dictionary that takes (string field name , object value )
        // each dictionary represents a record (row) as object
        obj = new Dictionary<string, object>();
        // fill the dictionary dynamically by setting the field name and its value)
        // we use for each because we have many fields
        foreach (var field in fieldsArr)
          obj.Add(field, item.GetValue(field));
        // return the new dynamically created row to the Select() function ,
        // so that the select() will loop to the next item
        return obj;
      });
      return Ok(result);
    }
    // Dynamic Select using System.Linq.Dynamic.core
    // Select() takes a comma separated list of fields,
    // and generates the select statement which will be exectued in SQL and return the result
    [HttpGet("select-Dynamic")]
    public IActionResult SelectDynamic([FromQuery] string fields)
    {
      if (fields == null)
        return BadRequest(new Error() { Message = "Must supply fields" });
      // using linq.dynamic.core to generate the needed select statement
      var query = _service.ApplySelect<TEntity>(fields, null);
      return Ok(query);
    }
    [HttpGet("select-Ado")]
    public IActionResult SelectAdo([FromQuery] string sqlQuery)
    {
      var result = _ado.ExecuteQuery(sqlQuery);
      return Ok(result);
    }
    // Users/sort?orderby= userId desc, userPassword
    [HttpGet("sort")]
    public IActionResult Sort([FromQuery] string orderBy)
    {
      if (orderBy == null)
        return BadRequest(new Error() { Message = "Must supply 'Order By' statement" });
      var query = _service.ApplySort<TEntity>(orderBy, null);
      return Ok(query);
    }
    #endregion
  }
}