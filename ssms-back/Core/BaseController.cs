using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;
using System.Linq.Dynamic.Core;

namespace SSMS
{
    [Route("[controller]")]
    public class BaseController<TEntity, TKey> : Controller where TEntity : class
    {
        private string _tableName { get; }
        private string _keyName { get; }
        private BaseService<TEntity, TKey> _service { get; }
        private Ado _ado { get; set; }
        private string _selectMaxId { get; set;}

        private IActionResult DoDelete(string deleteType, TEntity entity) {
            if (deleteType == null)
                return BadRequest(new Error() { Message = "Can't identify The type of the Delete operation"});
            if(entity == null)
                return BadRequest(new Error() { Message = "Item doesn't exist" });
            // switch on the [deleteType] and perform the appropriate action
            int res;
            try {
                switch (deleteType)
                {
                    case "logical":
                        res = _service.DeleteLogical(entity);
                        if(res == -1)
                            return BadRequest(new Error() { Message = "Can't delete this Item Logically" });
                        else if(res == -2)
                            return BadRequest(new Error() { Message = "Item has already been Logically deleted before" });
                        return Ok($"{res} Item(s) Deleted successfully...");
                    case "physical":
                        res = _service.Delete(entity);
                        return Ok($"{res} Item(s) Deleted successfully...");
                    default:
                        return BadRequest(new Error() { Message = "Unknow Delete Type" });
                }
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }
        // receive the service (to deal with db) 
        // and the table name of the entity (from entity Controller) and the PK field name
        // and the ado from DI
        public BaseController(BaseService<TEntity, TKey> service, string tableName, string keyName, Ado ado)
        {
            _tableName = tableName;
            _keyName = keyName;
            _service = service;
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
                return BadRequest(new Error() { Message = "Unknow List Type.[all] OR [deleted] OR [existing] only acceptable"});
            //If page size & number aren't provided from the query string
            //then return regular result based on list type.
            IQueryable<TEntity> result;
            try
            {
                switch (listType.ToLower())
                {
                    case "existing":
                        result = _service.GetQuery(item =>
                           item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                                      ? true
                                      : false
                       );
                        break;
                    case "deleted":
                        result = _service.GetQuery(item =>
                          item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                                     ? false
                                     : true
                       );
                        break;
                    case "all":
                        result = _service.GetQuery();
                        break;
                    default:
                        result = _service.GetQuery();
                        break;
                }
                // if page size and number are provided, return page result  (from GetPage())
                if (pageSize != null && pageNumber != null)
                {
                    var pageResult = _service.GetPageResult(result, (int)pageSize, (int)pageNumber);
                    return Ok(pageResult);
                }
                return Ok(result);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
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
                return BadRequest(new Error() { Message = "Must supply at least one of the following : [Filters] and/or [Fileds] and/or [Order By]"});
            IQueryable<TEntity> query = _service.GetQuery().AsQueryable();
            IQueryable result;
            try
            {
                //if filters provided, apply filters and get the query after applying (where) on it
                if (filters != null)
                    query = _service.ApplySqlWhere(filters, _tableName);
                //if orderBy provided, Give it the previous query (either filtered or not )
                //then apply sort and get the query after applying (orderBy) on it
                if (orderBy != null)
                    query = _service.ApplySort(orderBy, query);
                //put query value (whether filtered and ordered, filtered only, ordered only, nothing applied) in result
                result = query;
                //if select fields provided, apply dynamic select on the previous query
                if (fields != null)
                    result = _service.ApplySelect(fields, query);
                if (pageSize != null && pageNumber != null)
                {
                    var PageResult = _service.GetPageResult(result, (int)pageSize, (int)pageNumber);
                    return Ok(PageResult);
                }
                //Ok() takes the result (Linq query) , executes it , gets the data, convert it to JSON
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Find(TKey id)
        {
            return Ok(_service.GetOne(id));
        }
        [HttpPost("add")]
        public IActionResult Add([FromQuery] string autoId, [FromBody] TEntity entity)
        {
            // get newId sql select statement
            _selectMaxId =  $"Declare @v_id int;" +
                            "set @v_id = (select max("+ _keyName +") from "+ _tableName +");" +
                            "if @v_id is null set @v_id = 0;" +
                            "set @v_id = @v_id + 1;select @v_id;";
            try {
                // if autoId has value then generate newId and set keyName of this entity
                if(!String.IsNullOrEmpty(autoId))
                    entity.SetValue(_keyName,_ado.ExecuteScalar(_selectMaxId));
                // model state errors
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                // add entity and saveChanges
                _service.Add(entity);
                // if everything is ok, return the full user obj with all inserted values
                return Ok(entity);
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
        }
        //Update all parent Data -- used either by Parent or Admin
        [HttpPut("update")]
        public IActionResult Update([FromBody]TEntity entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _service.Update(entity);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(entity);  //if everything is ok, return the full  obj with all inserted values
        }
        //update Only ParentId --Used by Admins Only
        [HttpPut("update-Key")]
        public IActionResult UpdateKey([FromQuery] string tableName, string keyName, TKey newKey, TKey oldKey)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(keyName) || newKey == null || tableName == null)
                return BadRequest(new Error() { Message = "Incomplete Data..."});
            try
            {
                _service.UpdateKey(tableName, keyName, newKey, oldKey);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
            //Use Reflection : When we have a string OF a property and want to access a property value in runtime
            //Get type,
            //Get Property (binding Flags: ignore case sensitive, instance (not static), public) ,
            //Get Value
            var result = _service.GetOne(item => item.GetValue(keyName).Equals(newKey));
            //if everything is ok, return the full user obj with all inserted values
            return Ok(result);
        }
        //An action to receive type of Delete operation (logical or physical) and the entity to be deleted
        // Then call the appropriate function from the BaseService class to execute operation
        // the param (deleteType) will come from queryString
        [HttpPost("delete")]
        public IActionResult Delete([FromQuery] string deleteType, [FromBody] TEntity entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return DoDelete(deleteType, entity);
        }
        //An action to receive type of Delete operation (logical or physical) and the entity to be deleted
        // Then call the appropriate function from the BaseService class to execute operation
        // the param (deleteType) will come from queryString
        [HttpDelete("delete-by-id")]
        public IActionResult Delete([FromQuery] string deleteType, [FromQuery] TKey key)
        {
            // if the supplied key doesn't match the TKey DataType
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // First get the entity using its key to send it to delete method
            TEntity entity = _service.GetOne(key);
            return DoDelete(deleteType, entity);
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
            try
            {
                var res = _service.ApplyFilter(filters);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // [controller]/sql-where?filters=
        // Apply Filter (sql Where Caluse)
        [HttpGet("sql-where")]
        public IActionResult SqlWhere([FromQuery] string filters)
        {
            try
            {
                var res = _service.ApplySqlWhere(filters, _tableName);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //'fields' is a comma separated string of entity fields we want to select
        //return entity that contains only these fields
        // [controller]/Select?fileds=empId, empName
        [HttpGet("select")]
        public IActionResult Select([FromQuery] string fields)
        {
            if (fields == null)
                return BadRequest(new Error() { Message = "Must supply fields"});
            // string[] fieldsArr = fields.Split(',', StringSplitOptions.RemoveEmptyEntries);
            // fieldsArr = fieldsArr.Where(field => !string.IsNullOrWhiteSpace(field)).ToArray();
            //dict to hold anonymous obj .....
            var fieldsArr = fields.SplitAndRemoveEmpty(',');
            Dictionary<string, object> obj;
            //Get collection of all fileds(columns) and items(rows)
            var items = _service.GetQuery().ToList();
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
        //Dynamic Select using System.Linq.Dynamic.core
        // Select() takes a comma separated list of fields,
        //and generates the select statement which will be exectued in SQL and return the result
        [HttpGet("select-Dynamic")]
        public IActionResult SelectDynamic([FromQuery] string fields)
        {
            if (fields == null)
                return BadRequest(new Error() { Message = "Must supply fields"});
            try
            {
                var res = _service.ApplySelect(fields, null);  //use linq.dynamic.core to generate the
                return Ok(res);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("select-Ado")]
        public IActionResult SelectAdo([FromQuery] string sqlQuery)
        {
            try
            {
                var result = _ado.ExecuteQuery(sqlQuery);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //Users/sort?orderby= userId desc, userPassword
        [HttpGet("sort")]
        public IActionResult Sort([FromQuery] string orderBy)
        {
            if (orderBy == null)
                return BadRequest(new Error() { Message = "Must supply 'Order By' statement"});
            try
            {
                var res = _service.ApplySort(orderBy, null);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        #endregion
    }
}
