using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Users.Parents  
{
    public class ParentsController : BaseController<Parent>
    {
        private ParentsService _ParentSrv { get; }
        public ParentsController(ParentsService ParentsService , SSMSContext DB):base(DB)
        {
            _ParentSrv = ParentsService;    
        }
        public IActionResult Add([FromBody]Parent parent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _ParentSrv.AddParent(parent);                 
            }
            catch (System.Exception ex)
            {
               return BadRequest(ex); 
            }    

            return Ok(parent);  //if everything is ok, return the full user obj with all inserted values  
        }
    }
}
