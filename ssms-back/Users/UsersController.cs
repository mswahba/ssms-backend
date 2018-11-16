using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
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
    private BaseService _service;
    private readonly SmtpClient _smtpClient;
    private static string _tableName = "users";
    private User user;
    private VUser vUser;
    // do Update The user Refresh Token [used in RefreshToken Action]
    private int _UpdateRefreshToken(User user, string refreshToken, string deviceInfo)
    {
      var existingRefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.DeviceInfo == deviceInfo);
      if(existingRefreshToken != null)
      {
        existingRefreshToken.Token = refreshToken;
        _service.SetState<RefreshToken>(existingRefreshToken,"Modified");
        return _service.Save();
      }
      return -1;
    }
    // do Insert Or Update The user Refresh Token [used in SignIn Action]
    private void _InsertOrUpdateRefreshToken(User user, string refreshToken, string deviceInfo)
    {
      int updatedRows = _UpdateRefreshToken(user,refreshToken,deviceInfo);
      if(updatedRows == -1)
        _service.Add<RefreshToken>(new RefreshToken() { Token =  refreshToken, DeviceInfo = deviceInfo, UserId = user.UserId });
    }
    // do Change the userPassword with the newPassword
    private IActionResult _DoChangePassword(User user, string newPassword)
    {
      // (3) hashing the new password and set the passwordSalt and passwordHash
      user.PasswordSalt = Helpers.GetSecuredRandStr();
      user.PasswordHash = Helpers.Hashing(newPassword, user.PasswordSalt);
      // (4) Saving the new passwordSalt and passwordHash
      _service.Save();
      // (5) Map the Entity User to View User [VUser]
      vUser = Map.ToVUser(user);
      // (6) if everything is ok, return the full vUser
      return Ok(vUser);
    }
    // Give the BaseConstructor the dependency it needs which is DB contect
    // To get Db Context, we receive it from DI then pass it to Base constructor
    public UsersController(BaseService service, Ado ado, SmtpClient smtpClient)
                        : base(service, _tableName, "userId", ado)
    {
       // DI inject usersService object here from startup Class
      _service = service;
      _smtpClient = smtpClient;
    }

    #region UserController Actions

    [AllowAnonymous]
    [HttpPost("signup")]
    public IActionResult SignUp([FromBody]SignUp signup)
    {
      // (1) Generate RefreshToken
      string refreshToken = Helpers.GetSecuredRandStr();
      // (2) Generate password Hash and salt
      // (_) Add a new Item with refreshToken and deviceInfo in RefreshTokens List in the User entity
      // (_) Mapping from SignUp [View Model] to User [Entity Model]
      // (_) based on UserTypeId fill the appropriate child entity (Parent - Employee - Student)
      user = Map.ToUser(signup, Request.GetDeviceInfo(), refreshToken);
      // (3) insert the User with its Refresh Token
      // (_) and its Child Entity [Parent - Employee - Student] into DB
      // (_) [insert into 3 tables: users, refreshTokens, one of (Parent - Employee - Student) ]
      _service.Add(user);
      // (4) Map the Entity User to View User [VUser]
      vUser = Map.ToVUser(user);
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
    [HttpPost("signin")]
    public IActionResult SignIn(SignIn signin)
    {
      // (1) Get User by his Credentials [userId - userPassword]
      // and validate the userPassword against Passwordhash
      // and if exists, include all user RefreshTokens
      user = _service.GetOne<User>(new List<string>() { "RefreshTokens" }, u => u.UserId == signin.UserId && Helpers.ValidateHash(signin.UserPassword,u.PasswordSalt,u.PasswordHash) );
      // (2) if User doesn't exist return badRequest
      if (user == null)
        return BadRequest(new Error() { Message = "Invalid User." });
      // (3) if User is [not Enabled OR isDeleted] return badRequest
      if (user.AccountStatusId != 2 && user.IsDeleted == true)
        return BadRequest(new Error() { Message = "This account hasn't been activated Yet." });
      // (4) Generate RefreshToken
      string refreshToken = Helpers.GetSecuredRandStr();
      // (5) Insert OR Update in refreshTokens Table
      _InsertOrUpdateRefreshToken(user, refreshToken, Request.GetDeviceInfo());
      // (6) Map the Entity User to View User [VUser]
      vUser = Map.ToVUser(user);
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
    [HttpPost("change-password")]
    public IActionResult ChangePassword([FromBody]ChangedPassword changedpassword)
    {
      // (1) Get User by his Credentials [UserId - OldPassword]
      var user = _service.GetOne<User>(u => u.UserId == changedpassword.UserId && Helpers.ValidateHash(changedpassword.OldPassword, u.PasswordSalt, u.PasswordHash));
      // (2) if user not found then return [BadRequest]
      if (user == null)
        return BadRequest(new Error() { Message = "Invalid User." });
      return _DoChangePassword(user, changedpassword.NewPassword);
    }
    [AllowAnonymous]
    [HttpPost("forget-password")]
    public IActionResult ForgetPassword(ForgottenPassword forgottenPassword)
    {
      // is Admin [Master] Code
      if(forgottenPassword.VerificationCode.Length == 10)
      {
        // if the code doesn't match the Master Code return Exception [BadRequest]
        if(forgottenPassword.VerificationCode != "appsettings.json".GetJsonValue<AppSettings>("MasterVerificationCode"))
          throw new Exception("Invalid Verification Code!!!");
        user = _service.Find<User, string>(forgottenPassword.UserId);
        // (_) If user not found then return Exception [BadRequest]
        if (user == null)
          throw new Exception("Invalid User !!!");
        // (_) if user and code ok then Change Password with the new one
        return _DoChangePassword(user, forgottenPassword.NewPassword);
      }
      // is User [email - sms] Code
      else
      {
        // (_) Get User by UserId Including all its VerificationCodes
        user = _service.GetOne<User>(new List<string>() { "VerificationCodes" }, u => u.UserId == forgottenPassword.UserId );
        // (_) If user not found then return [BadRequest]
        if (user == null)
          throw new Exception("Invalid User !!!");
        // (_) Get VerificationCodeLifetime in Hours from AppSettings
        int codeLifetime = Convert.ToInt32("appsettings.json".GetJsonValue<AppSettings>("VerificationCodeLifetime"));
        // (_) Get VerificationCode where code = forgottenPassword.VerificationCode
        // and CodeTypeId == 1 [FORGET_PASSWORD] and not expired
        var code = user.VerificationCodes.FirstOrDefault(vc =>
          vc.Code ==  forgottenPassword.VerificationCode &&
          vc.SentTime >= DateTime.UtcNow.AddHours(3-codeLifetime) &&
          vc.CodeTypeId == 1
        );
        // (_) if code not found then return [BadRequest]
        if(code == null)
          throw new Exception("Invalid OR Expired VerificationCode !!!");
        // (_) if user and code ok then Change Password with the new one
        return _DoChangePassword(user, forgottenPassword.NewPassword);
      }
    }
    [AllowAnonymous]
    [HttpGet("send-verification-code")]
    public async Task<IActionResult> SendVerificationCode(string userId, byte codeTypeId)
    {
      // (1) get the full user data from DB [with his navigation properties] to get his email
      user = _service.GetOne<User>(new List<string>() { "_Employee", "_Parent", "_Student" }, u => u.UserId == userId );
      // get the user email from one of ["_Employee", "_Parent", "_Student"] properties
      string emailTo = user._Student?.Email ?? user._Parent?.Email ?? user._Employee?.Email;
      string userName = user._Student?.GetFullName("Ar") ?? user._Parent?.GetFullName("Ar") ?? user._Employee?.GetFullName("Ar");
      // (2) generate new VerificationCode and Add new Record in VerificationCodes Table
      string vCode = new Random().Next(100000,999999).ToString();
      VerificationCode newVCode = new VerificationCode()
      {
        Code = vCode,
        CodeTypeId = codeTypeId,
        UserId = userId,
      };
      int addResult = _service.Add<VerificationCode>(newVCode);
      // (3) send email to that user with the his VerificationCode
      // only if user has an email and the previous Add Operation succeeded
      if(emailTo != null && addResult == 1)
      {
        await _smtpClient.SendMailAsync(new MailMessage(
                from: "appsettings.json".GetJsonValue<AppSettings>("Email_From"),
                to: emailTo,
                subject: $"{userName}: Verification Code from SSMS to change your password",
                body: $@"Dear: {userName}
                        please use the following Verification Code {vCode} to change your password
                      "
              ));
        return Ok($"an email message with a new verification code has been sent to {emailTo} related to {userName}");
      }
      return Ok($"{userName}'s account doesn't have an email ...");
    }
    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public IActionResult RefreshToken(JWTTokens tokens)
    {
      // validate and get Claims From the given expired access Token
      var claims = Helpers.ValidateExpiredToken(tokens.AccessToken);
      // get the userId from the Expired Access Token Claims
      string userId = claims.SingleOrDefault(c => c.Type == "UserId").Value;
      // retrieve the user and all of his refresh tokens from DB
      user = _service.GetOne<User>(new List<string>() { "RefreshTokens" }, u => u.UserId == userId );
      // if the given refreshToken not found in RefreshTokens collection of that user
      // throw Exception [return BadRequest]
      if (user.RefreshTokens.All(rt => rt.Token != tokens.RefreshToken) )
        throw new SecurityTokenException("Invalid refresh token ...");
      // map user to vUser to get a new accessToken
      vUser = Map.ToVUser(user);
      string accessToken = Helpers.GetToken(vUser);
      string refreshToken = Helpers.GetSecuredRandStr();
      // update the user RefreshTokens with the new one
      _UpdateRefreshToken(user, refreshToken, Request.GetDeviceInfo());
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
