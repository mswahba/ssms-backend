using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.DependencyInjection;
using SSMS.EntityModels;
using SSMS.ViewModels;
using SSMS.Users;
using SSMS.Hubs;

namespace SSMS
{
  public static class Helpers
  {
    // get the DI [Dependency Injection Service]
    public static IServiceCollection DI { get; set; }
    // get SecretKey from appsettings.json file
    public static SymmetricSecurityKey GetSecretKey()
    {
      return new SymmetricSecurityKey(Encoding.UTF8.GetBytes("appsettings.json".GetJsonValue<AppSettings>("SecretKey")));
    }
    // Generate JWT [JSON Web Token]
    public static string GetToken(VUser user)
    {
      // get the secret string
      var secret = GetSecretKey();
      // hashing the secret string
      var creds = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
      // get the token Lifetime in hours
      int hours = Convert.ToInt32("appsettings.json".GetJsonValue<AppSettings>("JWT_Lifetime"));
      // get all user properties excluding any [Type = Collection]
      // then return new Collection<Claims> [ holding KeyValue pair of each User Property ]
      var claims = user.GetProperties()
                      .Where(property => !property.PropertyType.FullName.Contains("Collections"))
                      .Select(property => new Claim(property.Name, (property.GetValue(user) != null) ? property.GetValue(user).ToString() : ""));
      // Create Token with Token Options
      var token = new JwtSecurityToken(
          issuer: "appsettings.json".GetJsonValue<AppSettings>("JWT_Issuer"),
          audience: "appsettings.json".GetJsonValue<AppSettings>("JWT_Audience"),
          claims: claims,
          expires: DateTime.UtcNow.AddHours(hours),
          signingCredentials: creds);
      // finally return the Token String
      return new JwtSecurityTokenHandler().WriteToken(token);
    }
    // A Function that generates a Random Salt
    public static string GetSecuredRandStr()
    {
      byte[] randNum = new byte[32];
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(randNum);
        return Convert.ToBase64String(randNum);
      }
    }
    // A Function to return new TokenValidationParameters object
    public static TokenValidationParameters GetTokenValidationOptions(bool validateLifetime)
    {
      return new TokenValidationParameters
      {
        ValidateLifetime = validateLifetime,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "appsettings.json".GetJsonValue<AppSettings>("JWT_Issuer"),
        ValidAudience = "appsettings.json".GetJsonValue<AppSettings>("JWT_Audience"),
        IssuerSigningKey = Helpers.GetSecretKey()
      };
    }
    // Validate and Get Claims From the given Expired access Token
    public static IEnumerable<Claim> ValidateExpiredToken(string accessToken)
    {
      // get the Token Validation Options
      var tokenValidationOptions = GetTokenValidationOptions(validateLifetime: true);
      var tokenHandler = new JwtSecurityTokenHandler();
      SecurityToken securityToken;
      // validate the token with the choosen Token Validation Options
      ClaimsPrincipal principal = tokenHandler.ValidateToken(accessToken, tokenValidationOptions, out securityToken);
      JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
      // checking that the algorithm used to sign the token is HmacSha256
      // to prevent exchanging a fake token for a real JWT token
      if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        throw new SecurityTokenException("Invalid accessToken!!");
      // finally return the token principal
      return principal.Claims;
    }
    // A Function to hash the given string Value using the given Salt
    public static string Hashing(string value, string salt)
    {
      var valueBytes = KeyDerivation.Pbkdf2(
                          password: value,
                          salt: Encoding.UTF8.GetBytes(salt),
                          prf: KeyDerivationPrf.HMACSHA1,
                          iterationCount: 10000,
                          numBytesRequested: 32);

      return Convert.ToBase64String(valueBytes);
    }
    // A Function to Validate The Hashed Strings
    public static bool ValidateHash(string value, string salt, string hash) => Hashing(value, salt) == hash;
    // A Function that return either All Classes Within A Namespace
    // OR All Classes in the entire project [Assembly]
    public static IEnumerable<Type> GetAllClasses(string nameSpace)
    {
      IEnumerable<Type> types = Assembly.GetExecutingAssembly().ExportedTypes;
      return (!String.IsNullOrWhiteSpace(nameSpace))
              ? types.Where(t => t.Namespace == nameSpace)
              : types;
    }
    public static T GetService<T>() where T : class
    {
      return DI.BuildServiceProvider().GetService<T>();
    }

  }
}