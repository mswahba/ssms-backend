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
        [HttpGet("list")]
        public IActionResult list()
        {
            return Ok(_service.GetAll());
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
            //Use Reflection : When we have a string OF property and want to access a property value during runtime
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
        public IActionResult Delete( [FromQuery] string deleteType, [FromBody] TEntity entity)
        {
            if (deleteType == null)
                return BadRequest ("Can't identify The type of the Delete operation"); 
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
        public IActionResult Delete( [FromQuery] string deleteType, [FromQuery] TKey key)
        {
            if (deleteType == null)
                return BadRequest ("Can't identify The type of the Delete operation"); 
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
