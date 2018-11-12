using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SSMS.EntityModels;
using SSMS.ViewModels;

namespace SSMS.Users
{
  // Inherit from BaseCOntroller to get all the actions inside it in the derived controller
  // [Authorize]
  public class UsersController : BaseController<User, String>
  {
    // Store the usersService object that comes
    // from DependencyInjection DI which injects it in the constructor
    private VUser vUser;
    private User user;
    private BaseService<User, String> _UserSrv;
    private BaseService<RefreshToken, int> _RefreshTokenSrv;
    // do Update The user Refresh Token [used in RefreshToken Action]
    private int UpdateRefreshToken(User user, string refreshToken, string deviceInfo)
    {
      var existingRefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.DeviceInfo == deviceInfo);
      if(existingRefreshToken != null)
      {
        existingRefreshToken.Token = refreshToken;
        _RefreshTokenSrv.SetState(existingRefreshToken,"Modified");
        return _RefreshTokenSrv.Save();
      }
      return -1;
    }
    // do Insert Or Update The user Refresh Token [used in SignIn Action]
    private void InsertOrUpdateRefreshToken(User user, string refreshToken, string deviceInfo)
    {
      int updatedRows = UpdateRefreshToken(user,refreshToken,deviceInfo);
      if(updatedRows == -1)
        _RefreshTokenSrv.Add(new RefreshToken() { Token =  refreshToken, DeviceInfo = deviceInfo, UserId = user.UserId });
    }
    // get list of all refreshTokens for that userId
    private List<RefreshToken> GetRefreshTokens(string userId)
    {
      return _RefreshTokenSrv.GetList(rt => rt.UserId == userId);
    }
    // Give the BaseConstructor the dependency it needs which is DB contect
    // To get Db Context, we receive it from DI then pass it to Base constructor
    public UsersController(BaseService<User, String> usersService, BaseService<RefreshToken, int> refreshTokenSrv, Ado ado)
                        : base(usersService, "users", "userId", ado)
    {
       //DI inject usersService object here from startup Class
      _UserSrv = usersService;
      _RefreshTokenSrv = refreshTokenSrv;
    }

    #region UserController Actions

    [AllowAnonymous]
    [HttpPost("Signup")]
    public IActionResult SignUp([FromBody]SignUp signup)
    {
      // (1) Generate RefreshToken
      string refreshToken = Helpers.GetSecuredRandStr();
      // (2) Generate password Hash and salt
      // (_) Add a new Item with refreshToken and deviceInfo in RefreshTokens List in the User entity
      // (_) Mapping from SignUp [View Model] to User [Entity Model]
      // (_) based on UserTypeId fill the appropriate child entity (Parent - Employee - Student)
      user = Mapper.Map(signup, Request.GetDeviceInfo(), refreshToken);
      // (3) insert the User with its Refresh Token
      // (_) and its Child Entity [Parent - Employee - Student] into DB
      // (_) [insert into 3 tables: users, refreshTokens, one of (Parent - Employee - Student) ]
      _UserSrv.Add(user);
      // (4) Map the Entity User to View User [VUser]
      vUser = Mapper.Map(user);
      // (5) if everything is ok, return the [vUser - accessToken - refreshToken]
      return Ok(new
        {
          User = vUser,
          Tokens = new JWTTokens() {
            AccessToken = Helpers.GetToken(vUser),
            RefreshToken = refreshToken
          }
        }
      );
    }
    [AllowAnonymous]
    [HttpPost("SignIn")]
    public IActionResult SignIn(SignIn signin)
    {
      // (1) Get User by his Credentials [userId - userPassword]
      // and validate the userPassword against Passwordhash
      // and if exists, include all user RefreshTokens
      user = _UserSrv.GetOne(new List<string>() { "RefreshTokens" }, u => u.UserId == signin.UserId && Helpers.ValidateHash(signin.UserPassword,u.PasswordSalt,u.PasswordHash) );
      // (2) if User doesn't exist return badRequest
      if (user == null)
        return BadRequest(new Error() { Message = "Invalid User." });
      // (3) if User is [not Enabled OR isDeleted] return badRequest
      if (user.AccountStatusId != 2 && user.IsDeleted == true)
        return BadRequest( new Error() { Message = "This account hasn't been activated Yet." });
      // (4) Generate RefreshToken
      string refreshToken = Helpers.GetSecuredRandStr();
      // (5) Insert OR Update in refreshTokens Table
      InsertOrUpdateRefreshToken(user, refreshToken, Request.GetDeviceInfo());
      // (6) Map the Entity User to View User [VUser]
      vUser = Mapper.Map(user);
      // (7) if everything is ok, return the [vUser - accessToken - refreshToken]
      return Ok(new
        {
          User = vUser,
          Tokens = new JWTTokens() {
            AccessToken = Helpers.GetToken(vUser),
            RefreshToken = refreshToken
          }
        }
      );
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
        user.PasswordSalt = Helpers.GetSecuredRandStr();
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
    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public IActionResult RefreshToken(JWTTokens tokens)
    {
      // validate and get Claims From the given expired access Token
      var principal = Helpers.ValidateExpiredToken(tokens.AccessToken);
      // get the userId from the Expired Access Token Claims
      string userId = principal.Claims.SingleOrDefault(c => c.Type == "UserId").Value;
      // retrieve the user and all of his refresh tokens from DB
      user = _UserSrv.GetOne(new List<string>() { "RefreshTokens" }, u => u.UserId == userId );
      // if the given refreshToken not found in RefreshTokens collection of that user
      // throw Exception [return BadRequest]
      if (user.RefreshTokens.All(rt => rt.Token != tokens.RefreshToken) )
        throw new SecurityTokenException("Invalid refresh token ...");
      // map user to vUser to get a new accessToken
      vUser = Mapper.Map(user);
      string accessToken = Helpers.GetToken(vUser);
      string refreshToken = Helpers.GetSecuredRandStr();
      // update the user RefreshTokens with the new one
      UpdateRefreshToken(user, refreshToken, Request.GetDeviceInfo());
      // (_) if everything is ok, return the [vUser - accessToken - refreshToken]
      return Ok(new
        {
          User = vUser,
          Tokens = new JWTTokens() {
            AccessToken = accessToken,
            RefreshToken = refreshToken
          }
        }
      );
    }

    #endregion

  }
}
