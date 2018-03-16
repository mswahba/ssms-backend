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
        //Update all parent Data -- used either by Parent or Admin 
        public IActionResult Update([FromBody]Parent parent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _ParentSrv.UpdateParent(parent); 
            }
            catch (System.Exception ex)
            {
               return BadRequest(ex); 
            }    
            return Ok(parent);  //if everything is ok, return the full user obj with all inserted values  
        }
        //update Only ParentId --Used by Admins Only 
        public IActionResult UpdateId([FromBody] ChangedParentId changedParentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _ParentSrv.UpdateParentId(changedParentId.ParentNewId, changedParentId.ParentOldId); 
            }
            catch (System.Exception ex)
            {
               return BadRequest(ex); 
            }    
            return Ok(_ParentSrv.GetParent(p=> p.ParentId == changedParentId.ParentNewId));  //if everything is ok, return the full user obj with all inserted values  
        }

    }
}
