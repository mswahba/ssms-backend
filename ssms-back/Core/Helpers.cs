using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SSMS.EntityModels;
using SSMS.Users;

namespace SSMS
{
  public static class Helpers
  {
    // Mapping between SignUp [View Model] to User [Entity Model]
    // and fill in all default data values [not entered by the user]
    public static User Map(SignUp signup)
    {
      return new User()
      {
        UserId = signup.UserId,
        UserPassword = signup.UserPassword,
        UserTypeId = signup.UserType,
        SubscribeDate = DateTime.UtcNow.AddHours(3),
        IsActive = false
      };
    }
    // get SecretKey from appsettings.json file
    public static SymmetricSecurityKey GetSecretKey() {
      return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("appsettings.json".GetJsonValue<AppSettings>("SecretKey")));
    }
    // Generate JWT [JSON Web Token]
    public static string GetToken(User user) {
      // get the secret string
      var secret = GetSecretKey();
      // hashing the secret string
      var creds = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
      // get all user properties excluding any [Type = Collection]
      // then return new Collection<Claims> [ holding KeyValue pair of each User Property ]
      var claims = user.GetProperties()
                      .Where(property => !property.PropertyType.FullName.Contains("Collections"))
                      .Select(property => new Claim(property.Name, (property.GetValue(user) != null)? property.GetValue(user).ToString() : "" ));
      // Create Token with Token Options
      var token = new JwtSecurityToken(
          issuer: "appsettings.json".GetJsonValue<AppSettings>("JWTIssuer"),
          audience: "appsettings.json".GetJsonValue<AppSettings>("JWTAudience"),
          claims: claims,
          expires: DateTime.Now.AddDays(7),
          signingCredentials: creds);
      // finally return the Token String
      return new JwtSecurityTokenHandler().WriteToken(token);
    }


  }
}