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
        private BaseService<User, String> _UserSrv { get; }
        //Give the BaseConstructor the dependency it needs which is DB contect
        //To get Db Context, we receive it from DI then pass it to Base constructor
        public UsersTestController(BaseService<User, String> usersService)
                            : base(usersService, "users")
        {
            _UserSrv = usersService;    //DI inject usersService object here from startup Class
        }
        public IActionResult SignUp([FromBody]SignUp signup)
        {
            //(1)check if MS is valid 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //2) Mapping between view Model to entity Model  (user is Entity -- signup is the View)
            // here we fill in all data not entered by the user 
            User user = Extensions.Map(signup);
            try
            {
                _UserSrv.Add(user);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(user);  //if everything is ok, return the full user obj with all inserted values  
        }
        [HttpGet("SignIn")]
        public IActionResult SignIn([FromBody]SignIn signin)
        {
            //(1)check if MS is valid 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = _UserSrv.GetOne(u => u.UserId == signin.UserId && u.UserPassword == signin.UserPassword);
            try
            {
                if (user == null)
                    return BadRequest("Invalid User.");
                if (user.IsActive == false)
                    return BadRequest("This account hasn't been activated Yet.");
                return Ok(user);  //if everything is ok, return the full user obj with all inserted values  
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
        public IActionResult ChangePassword([FromBody]ChangedPassword changedpassword)
        {
            //(1)check if MS is valid 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //(2) Get user Data from DB 
            var user = _UserSrv.GetOne(u => u.UserId == changedpassword.UserId && u.UserPassword == changedpassword.OldPassword);
            try
            {
                if (user == null)
                    return BadRequest("Invalid User.");
                //(3) Update statement and saving new pwd 
                user.UserPassword = changedpassword.NewPassword;
                _UserSrv.Save();
                return Ok(user);  //if everything is ok, return the full user obj with all inserted values  
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
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
           var res =  _UserSrv.GetList(item => (bool) item.GetValue("IsActive") == true);
           // var res= _UserSrv.GetQuery(item => item.IsActive == true); 
            return Ok(res); 
        }
    }
}
