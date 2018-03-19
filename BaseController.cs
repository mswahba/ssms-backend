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
            var result = _service.GetOne(item => item.GetType().GetProperty(keyName,BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetValue(item).Equals(newKey));  //if everything is ok, return the full user obj with all inserted values  
            return Ok(result);
        }

    }
}
