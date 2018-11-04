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
        // (3) and Hashing UserPassword before Saving to DB
        User user = Helpers.Map(signup);
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
        // and validate the userPassword against Passwordhash
        var user = _UserSrv.GetOne(u => u.UserId == signin.UserId && Helpers.ValidateHash(signin.UserPassword,u.PasswordSalt,u.PasswordHash) );
        // (3) if User doesn't exist
        if (user == null)
          return BadRequest(new Error() { Message = "Invalid User." });
        // (4) if User is [not Enabled OR isDeleted] return badRequest
        if (user.AccountStatusId != 2 && user.IsDeleted == true)
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
      // (1) check if MS is valid
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      try
      {
        // (2) Get user Data from DB
        var user = _UserSrv.GetOne(u => u.UserId == changedpassword.UserId && Helpers.ValidateHash(changedpassword.OldPassword,u.PasswordSalt,u.PasswordHash) );
        if (user == null)
          return BadRequest(new Error() { Message = "Invalid User." });
        // (3) hashing the new password and set the passwordSalt and passwordHash
        user.PasswordSalt = Helpers.GetRandSalt();
        user.PasswordHash = Helpers.Hashing(changedpassword.NewPassword,user.PasswordSalt);
        // (4) Saving the new passwordSalt and passwordHash
        _UserSrv.Save();
        // (5) if everything is ok, return the full user
        return Ok(user);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex);
      }
    }
  }
}
