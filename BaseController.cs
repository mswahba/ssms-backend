using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;
using System.Collections.Generic;
using System.Linq;

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
    }
}
