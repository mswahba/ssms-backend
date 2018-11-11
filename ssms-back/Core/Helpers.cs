using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using SSMS.EntityModels;
using SSMS.ViewModels;
using SSMS.Users;

namespace SSMS
{
  public static class Helpers
  {
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
      // get all user properties excluding any [Type = Collection]
      // then return new Collection<Claims> [ holding KeyValue pair of each User Property ]
      var claims = user.GetProperties()
                      .Where(property => !property.PropertyType.FullName.Contains("Collections"))
                      .Select(property => new Claim(property.Name, (property.GetValue(user) != null) ? property.GetValue(user).ToString() : ""));
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

  }
}