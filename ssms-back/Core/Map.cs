using System;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SSMS.EntityModels;
using SSMS.ViewModels;

namespace SSMS
{
  public static class Map
  {
    // Mapping from SignUp [View Model] to User [Entity Model]
    // and fill in all default data values [not entered by the user]
    public static User ToUser(SignUp signup, string deviceInfo, string refreshToken)
    {
      // generate salt and hash
      string salt = Helpers.GetSecuredRandStr();
      string hash = Helpers.Hashing(signup.UserPassword, salt);
      HashSet<RefreshToken> tokens = new HashSet<RefreshToken>()
            {
              new RefreshToken()
              {
                Token = refreshToken,
                DeviceInfo = deviceInfo,
                UserId = signup.UserId
              }
            };
      // mapping
      switch (signup.UserTypeId)
      {
        case 1:
          return new User()
          {
            UserId = signup.UserId,
            PasswordSalt = salt,
            PasswordHash = hash,
            UserTypeId = signup.UserTypeId,
            RefreshTokens = tokens,
            _Employee = signup.Employee
          };
        case 2:
          return new User()
          {
            UserId = signup.UserId,
            PasswordSalt = salt,
            PasswordHash = hash,
            UserTypeId = signup.UserTypeId,
            RefreshTokens = tokens,
            _Student = signup.Student
          };
        case 3:
          return new User()
          {
            UserId = signup.UserId,
            PasswordSalt = salt,
            PasswordHash = hash,
            UserTypeId = signup.UserTypeId,
            RefreshTokens = tokens,
            _Parent = signup.Parent
          };
        default:
          return new User()
          {
            UserId = signup.UserId,
            PasswordSalt = salt,
            PasswordHash = hash,
            UserTypeId = signup.UserTypeId,
            RefreshTokens = tokens
          };
      }
    }
    // Mapping from user [Entity Model] to vUser [View Model]
    public static VUser ToVUser(User user)
    {
      return new VUser()
      {
        UserId = user.UserId,
        UserTypeId = user.UserTypeId,
        AccountStatusId = user.AccountStatusId,
        SubscribeDate = user.SubscribeDate,
        LastActive = user.LastActive,
        IsDeleted = user.IsDeleted
      };
    }
    // Read accessToken Claims and convert it to its Type [VUser]
    public static VUser ToVUser(string accessToken)
    {
      // get claims from the access token string
      IEnumerable<Claim> claims = new JwtSecurityTokenHandler().ReadJwtToken(accessToken).Claims;
      VUser vUser = new VUser();
      // get all vUser Propperties
      var props = vUser.GetProperties();
      // loop through vUser props and set each prop value with the corresponding claim value
      foreach (var prop in props)
        vUser.SetValue(prop.Name,claims.FirstOrDefault(c => c.Type == prop.Name).Value);
      // finally return the fulfilled vUser object
      return vUser;
    }

  }
}
