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
    public static User Map(SignUp signup)
    {
      // generate salt and hash
      string salt = Helpers.GetRandSalt();
      string hash = Helpers.Hashing(signup.UserPassword, salt);
      // mapping
      return new User()
      {
        UserId = signup.UserId,
        PasswordSalt = salt,
        PasswordHash = hash,
        UserTypeId = signup.UserType,
        SubscribeDate = DateTime.UtcNow.AddHours(3),
        AccountStatusId = 1
      };
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
