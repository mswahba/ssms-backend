using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSMS.EntityModels;

namespace SSMS.Users
{
  // Inherit from BaseCOntroller to get all the actions inside it in the derived controller
  // [Authorize]
  public class UsersController : BaseController<User, String>
  {
    // Store the usersService object that comes
    // from DependencyInjection DI which injects it in the constructor
    private BaseService<User, String> _UserSrv { get; }
    // Give the BaseConstructor the dependency it needs which is DB contect
    // To get Db Context, we receive it from DI then pass it to Base constructor
    public UsersController(BaseService<User, String> usersService, Ado ado)
                        : base(usersService, "users", "userId", ado)
    {
      _UserSrv = usersService;    //DI inject usersService object here from startup Class
    }
    [AllowAnonymous]
    [HttpPost("Signup")]
    public IActionResult SignUp([FromBody]SignUp signup)
    {
      // (1)check if MS is valid
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        // (2) Mapping from SignUp [View Model] to User [Entity Model]
        User user = Helpers.Map(signup);
        // (3) Hashing UserPassword before Saving to DB
        string salt = "appsettings.json".GetJsonValue<AppSettings>("HashSalt");
        string hash = Helpers.Hashing(user.UserPassword,salt);
        Console.WriteLine(user.UserPassword);
        Console.WriteLine(hash);
        Console.WriteLine(Helpers.ValidateHash(user.UserPassword,salt,hash));
        user.UserPassword = hash;
        // (4) insert the User into DB
        _UserSrv.Add(user);
        // (5) if everything is ok, return the full User and the JWT
        return Ok(new { User = user, Token = Helpers.GetToken(user) });
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex);
      }
    }
    [AllowAnonymous]
    [HttpPost("SignIn")]
    public IActionResult SignIn([FromBody]SignIn signin)
    {
      // (1) check if ModelState is Invalid return Validation Error
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        // (2) Get User by his Credentials [userId - userPassword]
        var user = _UserSrv.GetOne(u => u.UserId == signin.UserId && u.UserPassword == signin.UserPassword);
        // (3) if User doesn't exist
        if (user == null)
          return BadRequest(new Error() { Message = "Invalid User." });
        // (4) if User is not Active
        if (user.IsActive == false)
          return BadRequest( new Error() { Message = "This account hasn't been activated Yet." });
        // (5) if everything is ok, return the full User and the JWT
        return Ok(new { User = user, Token = Helpers.GetToken(user) });
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex);
      }
    }
    [AllowAnonymous]
    [HttpPost("ChangePassword")]
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
