using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SSMS
{
    [Route("[controller]")]
    public class BaseController<TEntity, TKey> : Controller where TEntity : class
    {
        private BaseService<TEntity, TKey> _service { get; }
        public BaseController(BaseService<TEntity,TKey> service)
        {
            _service = service;
        }
        [HttpGet ("list")]
        public IActionResult list()
        {
            return Ok(_service.GetAll());
        }
        [HttpGet ("{id}")]
        public IActionResult Find(TKey id)
        {
            return Ok(_service.Find(id));
        }
               
        //Get Specific page in a GridView based on pageSize and Page Number 
        // returns anonymous object that contains :  
        //(pageItems : array of items, Number of TotalItems,Number of TotalPages)
        [HttpGet ("Page")]
        public IActionResult GetPage(int pageSize, int pageNumber)
        {
            var result = _service.GetPage(pageSize, pageNumber);
            return Ok(result);
        }
    }
}
