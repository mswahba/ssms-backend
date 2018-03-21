using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

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
        [HttpGet("List/{listType}")]
        public IActionResult list(string listType)
        {
            List<TEntity> result = new List<TEntity>();
            if (listType.ToLower() == "existing")
                result = _service.GetList(item =>
                   item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                              ? true
                              : false
               );
            else if (listType.ToLower() == "deleted")
                result = _service.GetList(item =>
                   item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                              ? false
                              : true
               );
            else if (listType.ToLower() == "all")
                result = _service.GetAll();
            else
                return BadRequest("Unknow List Type.[all] OR [deleted] OR [existing] only acceptable");
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Find(TKey id)
        {
            return Ok(_service.Find(id));
        }

        //Get Specific page in a GridView based on pageSize and Page Number 
        // returns anonymous object that contains :  
        //(pageItems : array of items, Number of TotalItems,Number of TotalPages)
        [HttpGet("Page")]
        public IActionResult GetPage(int pageSize, int pageNumber)
        {
            var result = _service.GetPage(pageSize, pageNumber);
            return Ok(result);
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
            //Use Reflection : When we have a string OF property and want to access a property value in runtime
            //Get type, 
            //Get Property (binding Flags: ignore case sensitive, instance (not static), public) , 
            //Get Value 
            var result = _service.GetOne(item => item.GetValue(keyName).Equals(newKey));  //if everything is ok, return the full user obj with all inserted values  
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
