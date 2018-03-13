using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSMS.Models;

namespace SSMS.Users
{
    public class UsersController : Controller
    {
        //Store the dbContext object that comes 
        //from DependencyInjection DI which injects it in the constructor
        private test1Context db { get; }
        public UsersController(test1Context _db)
        {
            db = _db;    //DI inject DBContext object here from startup Class
        }
        public IActionResult SignUp([FromBody]SignUp signup)
        {
            //(1)check if MS is valid 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //2) Mapping between view Model to entity Model  (user is Entity -- signup is the View)
            // here we fill in all data not entered by the user 
            User user = Models.User.Map(signup);
            try
            {
                db.Users.Add(user);    // attach user object to the DB Set collection of Users and change its state to (Added)
                db.SaveChanges();      //Generate the appropriate sql statement based on the object state  
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(user);  //if everything is ok, return the full user obj with all inserted values  
        }
        public IActionResult SignIn([FromBody]SignIn signin)
        {
            //(1)check if MS is valid 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = db.Users
                        .Where(u => u.UserId == signin.UserId && u.UserPassword == signin.UserPassword)
                        .SingleOrDefault();  //this function executes the where
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
    }
}
