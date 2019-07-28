using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using SSMS.EntityModels;
using SSMS.ViewModels;
using Microsoft.AspNetCore.SignalR;
using SSMS.Hubs;

namespace SSMS
{
  public static class Test
  {
    public static void onStartupCtor(IConfiguration config)
    {
      //   Console.WriteLine(string.Join("\n", Helpers.GetAllClasses("SSMS.Hubs")));
      //   Console.WriteLine(string.Join("\n",
      //       new Student()
      //           .GetProperties()
      //           .Where(prop =>
      //           {
      //             var propertyType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
      //             return Type.GetTypeCode(propertyType) != TypeCode.Object;
      //           })
      //           .Select(prop => prop.Name)
      //   ));

      //   var vUser = Map.ToVUser("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI1NTY2NTU2NjU1IiwiVXNlclR5cGVJZCI6IjMiLCJBY2NvdW50U3RhdHVzSWQiOiIxIiwiU3Vic2NyaWJlRGF0ZSI6IjA5LzExLzIwMTggMTA6NTM6MDAgUE0iLCJMYXN0QWN0aXZlIjoiMDkvMTEvMjAxOCAxMDo1Mjo1NSBQTSIsIklzRGVsZXRlZCI6IkZhbHNlIiwiZXhwIjoxNTQyNjA4ODg4LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAifQ.jk-Zl-MDlU8riZbAZNFCwxKftNvDys9P7uClbXVLxpU");
      //   foreach (var prop in vUser.GetProperties())
      //     Console.WriteLine(prop.Name + ": " + prop.GetValue(vUser));
      //   int hours = config.GetValue<int>("JWT:Lifetime");
      //   Console.WriteLine(hours);

      //   Console.WriteLine(Helpers.ValidateHash("000000", "idtMPnx4UqHp3zOaBQ6YvN41JSqXAmUikDU/FiKh3TI", "mY63vmpNbk2F+gp1bROTIPZZdV3x7y6gtribcLrsirI"));

      //   var Host = config.GetValue<String>("Email:Host");
      //   var Port = config.GetValue<int>("Email:Port");
      //   var UserName = config.GetValue<String>("Email:UserName");
      //   var Password = config.GetValue<String>("Email:Password");
      //   Console.WriteLine($"{Host}\n{Port}\n{UserName}\n{Password}");
      //   Random rand = new Random();
      //   Console.WriteLine(rand.Next(100000, 999999));

      //   Console.WriteLine(nameof(User) == nameof(ViewModels.VUser));
    }
    public static void onConfigServices()
    {
      // var _db = (SSMSContext)Activator.CreateInstance(typeof(SSMSContext));
      // Console.WriteLine(_db.Users.Count());

      // Console.WriteLine(Helpers.GetSecuredRandStr());

      // try
      // {
      //   var principal = Helpers.ValidateExpiredToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI1NTY2NTU2NjU1IiwiVXNlclR5cGVJZCI6IjMiLCJBY2NvdW50U3RhdHVzSWQiOiIxIiwiU3Vic2NyaWJlRGF0ZSI6IjA5LzExLzIwMTggMTA6NTM6MDAgUE0iLCJMYXN0QWN0aXZlIjoiMDkvMTEvMjAxOCAxMDo1Mjo1NSBQTSIsIklzRGVsZXRlZCI6IkZhbHNlIiwiZXhwIjoxNTQyNjA4ODg4LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAifQ.jk-Zl-MDlU8riZbAZNFCwxKftNvDys9P7uClbXVLxpU");
      //   foreach (var item in principal.Where(c => c.Type == "UserId"))
      //     Console.WriteLine(item.Type + " " + item.Value);
      // }
      // catch (Exception ex)
      //   {
      //     Console.WriteLine(ex.Message);
      //   }
      //   // Test GetService from DI
      // var db = Helpers.GetService<SSMSContext>();
      // Console.WriteLine(db.Model.FindEntityType(typeof(User)).Relational().TableName);
      // Console.WriteLine(db.Users.Count());

      // var config = Helpers.GetService<IConfiguration>();
      // Console.WriteLine(config.GetValue<bool>("Logging:IncludeScopes"));

    }
    public static void onConfigure(IHubContext<DbHub> dbHub)
    {
      // SqlTableWatcher._dbHub = dbHub;
      // SqlTableWatcher.WatchAll(new string[] { "User", "School", "Country", "Action" });
      // SqlTableWatcher.Watch<User>("users");
      // SqlTableWatcher.Stop("users");
      // SqlTableWatcher.WatchAll();
      // SqlTableWatcher.StopAll(new string[] { "User", "School", "Country", "Action" });
    }
  }
}