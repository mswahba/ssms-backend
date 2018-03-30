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
        private BaseService<TEntity, TKey> _service { get; }
        public BaseController(BaseService<TEntity, TKey> service)
        {
            _service = service;
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
                return BadRequest("Unknow List Type.[all] OR [deleted] OR [existing] only acceptable");
            // if page size and number are provided, return page result  (from GetPage())
            if (pageSize != null && pageNumber != null)
            {
                var res = _service.GetPage(listType, (int)pageSize, (int)pageNumber);
                return Ok(res);
            }
            //If page size & number aren't provided from the query string
            //then return regular result based on list type.  
            List<TEntity> result = new List<TEntity>();
            switch (listType.ToLower())
            {
                case "existing":
                    result = _service.GetList(item =>
                       item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                                  ? true
                                  : false
                   );
                    break;
                case "deleted":
                    result = _service.GetList(item =>
                       item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                                  ? false
                                  : true
                   );
                    break;
                case "all":
                    result = _service.GetAll();
                    break;
            }
            return Ok(result);
        }
        //Make it as default action for the controller
        [HttpGet("")]
        //'filters' is a comma separated "string" and 
        //one filter is like this [field|operator|value] 
        // operators must be one of (= , != , > , < , >=, <=, % [contains], @ [contains whole word])
        // Route : Users?filters=userName|=|Mohammad , age| > |20, isActive|=|false 
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
        //'fields' is a comma separated string of entity fields we want to select 
        //return entity that contains only these fields
        // [controller]/Select?fileds=empId, empName
        [HttpGet("Select")]
        public IActionResult Select([FromQuery] string fields)
        {
            if (fields == null)
                return BadRequest("Must supply fields");
            // string[] fieldsArr = fields.Split(',', StringSplitOptions.RemoveEmptyEntries);
            // fieldsArr = fieldsArr.Where(field => !string.IsNullOrWhiteSpace(field)).ToArray();
            //dict to hold anonymous obj ..... 
           var fieldsArr = fields.RemoveEmptyElementsArr(); 
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
        [HttpGet("Select-Dynamic")]
        public IActionResult SelectDynamic([FromQuery] string fields)
        {
            if (fields == null)
                return BadRequest("Must supply fields");
            fields = fields.RemoveEmptyElements(); 
            try
            {
                var res = _service.GetQuery()
                                  .AsQueryable()  //this is just conversion from enumerable to iqueriable
                                  .Select($"new({fields})");  //use linq.dynamic.core to generate the 
                return Ok(res);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //A function 
        //Users/sort?orderby= userId desc
        [HttpGet("Sort")]
        public IActionResult Sort([FromQuery] string orderBy)
        {
            if (orderBy == null)
                return BadRequest("Must supply 'Order By' statement");
            // convert comma separated list to array so that we can remove empty items                 
            orderBy = orderBy.RemoveEmptyElements(); 
            try
            {
                var res = _service.GetQuery().AsQueryable().OrderBy(orderBy);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Find(TKey id)
        {
            return Ok(_service.Find(id));
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] TEntity entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _service.Add(entity);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(entity);  //if everything is ok, return the full user obj with all inserted values  
        }
        //Update all parent Data -- used either by Parent or Admin 
        [HttpPost("Update")]
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
        [HttpGet("Update-Key")]
        //update Only ParentId --Used by Admins Only 
        public IActionResult UpdateKey([FromQuery] string tableName, string keyName, TKey newKey, TKey oldKey)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(keyName) || newKey == null || tableName == null)
                return BadRequest("Incomplete Data...");
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
        [HttpPost("Delete")]
        //An action to receive type of Delete operation (logical or physical) and the entity to be deleted
        // Then call the appropriate function from the BaseService class to execute operation
        // the param (deleteType) will come from queryString
        public IActionResult Delete([FromQuery] string deleteType, [FromBody] TEntity entity)
        {
            if (deleteType == null)
                return BadRequest("Can't identify The type of the Delete operation");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int res;
            if (deleteType == "logical")
            {
                _service.Attach(entity);
                res = _service.DeleteLogical(entity);
                return Ok($"{res} Item(s) Deleted successfully...");
            }
            else if (deleteType == "physical")
            {
                res = _service.Delete(entity);
                return Ok($"{res} Item(s) Deleted successfully...");
            }
            return BadRequest("Unknow Delete Type");
        }
        [HttpGet("Delete-ById")]
        //An action to receive type of Delete operation (logical or physical) and the entity to be deleted
        // Then call the appropriate function from the BaseService class to execute operation
        // the param (deleteType) will come from queryString
        public IActionResult Delete([FromQuery] string deleteType, [FromQuery] TKey key)
        {
            if (deleteType == null)
                return BadRequest("Can't identify The type of the Delete operation");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int res;
            //First get the entity using its key to send it to delete 
            TEntity entity = _service.Find(key);
            if (deleteType == "logical")
            {
                res = _service.DeleteLogical(entity);
                return Ok($"{res} Item(s) Deleted successfully...");
            }
            else if (deleteType == "physical")
            {
                res = _service.Delete(entity);
                return Ok($"{res} Item(s) Deleted successfully...");
            }
            return BadRequest("Unknow Delete Type");
        }

    }
}
