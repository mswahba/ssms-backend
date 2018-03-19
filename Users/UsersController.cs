using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Users
{
    //Inherit from BaseCOntroller to get all the actions inside it in the derived controller
    public class UsersController : BaseController<User, String>
    {
        //Store the usersService object that comes 
        //from DependencyInjection DI which injects it in the constructor
        private BaseService<User,String> _UserSrv { get; }
        //Give the BaseConstructor the dependency it needs which is DB contect
        //To get Db Context, we receive it from DI then pass it to Base constructor
        public UsersController(BaseService<User,String> usersService):base(usersService)
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
          [HttpGet ("SignIn")]
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
        
    }
}
