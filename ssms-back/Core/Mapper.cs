using System;
using System.Collections.Generic;
using SSMS.EntityModels;
using SSMS.ViewModels;

namespace SSMS
{
  public static class Mapper
  {
    // Mapping from SignUp [View Model] to User [Entity Model]
    // and fill in all default data values [not entered by the user]
    public static User Map(SignUp signup, string deviceInfo, string refreshToken)
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
    public static VUser Map(User user)
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

  }
}
