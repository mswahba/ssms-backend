using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Users
{
    //Inherit from BaseCOntroller to get all the actions inside it in the derived controller
    public class UsersTestController : BaseController<User, String>
    {
        //Store the usersService object that comes
        //from DependencyInjection DI which injects it in the constructor
        private BaseService _service { get; }
        //Give the BaseConstructor the dependency it needs which is DB contect
        //To get Db Context, we receive it from DI then pass it to Base constructor
        public UsersTestController(BaseService service)
                            : base(service, "users", "userId", null)
        {
            _service = service;
        }
        [NonAction]
        public IQueryable<User> GetQuery(Expression<Func<User, bool>> expression)
        {
            var context = new EntityModels.SSMSContext();
            return context.Set<User>().Where(expression);
        }
        [HttpGet("TestData")]
        public IActionResult TestData()
        {
            try
            {
                var res = GetQuery(item =>
                          item.GetValue("IsDeleted") == null || (bool)item.GetValue("IsDeleted") == false
                                     ? true
                                     : false
                      );
            return Ok(res);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }

            // var context = new EntityModels.SSMSContext();
            //Sends Where filters to SQL- as it doesn't execute query
            //but saves it in an expression variable to be extendable and reused
            // IQueryable<User> users1 = context.Users;
            //doesn't send Where - Gets ALl data- as it saves query in a delegate
            // which is get called and executed immediately
            //IEnumerable<User> users = context.Users;
            // var filtered = users1.Where(u => u.UserType == 1);
        }
       [HttpGet("Test-List")]
        public IActionResult testList()
        {
           var res =  _service.GetList<User>(item => (bool) item.GetValue("IsActive") == true);
           // var res= _UserSrv.GetQuery(item => item.IsActive == true);
            return Ok(res);
        }

    }
}
