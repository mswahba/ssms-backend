using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SSMS
{
    public class BaseController<TEntity> : Controller where TEntity : class
    {
        private SSMSContext db { get; }
        public BaseController(SSMSContext _db)
        {
            db = _db;
        }
        public IActionResult list()
        {
            return Ok(db.Set<TEntity>().AsQueryable().ToList());
        }
        //Get Specific page in a GridView based on pageSize and Page Number 
        // returns anonymous object that contains :  
        //(pageItems : array of items, Number of TotalItems,Number of TotalPages)
        public IActionResult GetPage(int pageSize, int pageNumber)
        {
            var result = new {
                PageItems = db.Set<TEntity>().Skip(pageSize*(pageNumber-1)).Take(pageSize), 
                TotalItems = db.Set<TEntity>().Count(),
                TotalPages=(int) Math.Ceiling((decimal)db.Set<TEntity>().Count() / pageSize),
            };
          return Ok(result); 
        }
    }
}
