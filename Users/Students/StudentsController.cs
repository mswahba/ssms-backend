using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Students 
{
    public class StudentsController : BaseController<Student,String>
    {
        private BaseService<Student,String> _StudentSrv { get; }
        public StudentsController(BaseService<Student,String> StudentsService):base(StudentsService)
        {
            _StudentSrv = StudentsService;
        }

        public IActionResult Add([FromBody]Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _StudentSrv.Add(student);
                return Ok(student);  //if everything is ok, return the full user obj with all inserted values  
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        public IActionResult Update([FromBody]Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                _StudentSrv.Update(student);
                return Ok(student);  //if everything is ok, return the full user obj with all inserted values  
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
