using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using SSMS.Hubs;
using SSMS.EntityModels;
using SSMS.Users;
using SSMS.Shared;

namespace SSMS
{
  public class Startup
  {
    public IConfiguration Config { get; }
    public Startup(IConfiguration config)
    {
      Config = config;
      // Console.WriteLine( string.Join("\n", Helpers.GetAllClasses("SSMS.Hubs")));
      // Console.WriteLine( string.Join("\n",
      //     new Student()
      //         .GetProperties()
      //         .Where(prop => {
      //           var propertyType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
      //           return Type.GetTypeCode(propertyType) != TypeCode.Object;
      //         })
      //         .Select( prop => prop.Name)
      // ));

      // Console.WriteLine(Helpers.GetSecuredRandStr());
      // var principal = Helpers.ValidateExpiredToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI1NTY2NTU2NjU1IiwiVXNlclR5cGVJZCI6IjMiLCJBY2NvdW50U3RhdHVzSWQiOiIxIiwiU3Vic2NyaWJlRGF0ZSI6IjA5LzExLzIwMTggMTA6NTM6MDAgUE0iLCJMYXN0QWN0aXZlIjoiMDkvMTEvMjAxOCAxMDo1Mjo1NSBQTSIsIklzRGVsZXRlZCI6IkZhbHNlIiwiZXhwIjoxNTQyNjA4ODg4LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAifQ.jk-Zl-MDlU8riZbAZNFCwxKftNvDys9P7uClbXVLxpU");
      // foreach (var item in principal.Claims.Where(c => c.Type == "UserId"))
      //   Console.WriteLine(item.Type + " " + item.Value);

      // var vUser = Mapper.Map<VUser>("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOiI1NTY2NTU2NjU1IiwiVXNlclR5cGVJZCI6IjMiLCJBY2NvdW50U3RhdHVzSWQiOiIxIiwiU3Vic2NyaWJlRGF0ZSI6IjA5LzExLzIwMTggMTA6NTM6MDAgUE0iLCJMYXN0QWN0aXZlIjoiMDkvMTEvMjAxOCAxMDo1Mjo1NSBQTSIsIklzRGVsZXRlZCI6IkZhbHNlIiwiZXhwIjoxNTQyNjA4ODg4LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAifQ.jk-Zl-MDlU8riZbAZNFCwxKftNvDys9P7uClbXVLxpU");
      // foreach (var prop in vUser.GetProperties())
      //   Console.WriteLine(prop.Name + ": " + prop.GetValue(vUser));
      // int hours = Config.GetValue<int>("JWT:Lifetime");
      // Console.WriteLine(hours);

      // Console.WriteLine(Helpers.ValidateHash("000000","idtMPnx4UqHp3zOaBQ6YvN41JSqXAmUikDU/FiKh3TI","mY63vmpNbk2F+gp1bROTIPZZdV3x7y6gtribcLrsirI"));

      // var Host = Config.GetValue<String>("Email:Host");
      // var Port = Config.GetValue<int>("Email:Port");
      // var UserName = Config.GetValue<String>("Email:UserName");
      // var Password = Config.GetValue<String>("Email:Password");
      // Console.WriteLine($"{Host}\n{Port}\n{UserName}\n{Password}");
      // Random randm = new Random();
      // Console.WriteLine(randm.Next(100000,999999));

      // Console.WriteLine(nameof(User) == nameof(ViewModels.VUser));
      // var db = (SSMSContext)Activator.CreateInstance(typeof(SSMSContext));
      // Console.WriteLine(db.Users.Count());
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // get the DI
      Helpers.DI = services;
      // AddScoped configues settings to create new instance of this type per http request
      services.AddScoped<BaseService>();
      // Add automapper
      services.AddAutoMapper();
      // Add SMTP Mail Service
      services.AddScoped<SmtpClient>((serviceProvider) =>
      {
        return new SmtpClient()
        {
          UseDefaultCredentials = false,
          DeliveryMethod = SmtpDeliveryMethod.Network,
          Host = Config.GetValue<String>("Email:Host"),
          Port = Config.GetValue<int>("Email:Port"),
          EnableSsl = Config.GetValue<bool>("Email:SSL"),
          Credentials = new NetworkCredential(
            Config.GetValue<String>("Email:UserName"),
            Config.GetValue<String>("Email:Password")
          )
        };
      });
      // Register a type of DbContext so that it can be used in DI (inside dependent classes' constructors)
      services.AddDbContext<SSMSContext>();
      // Configure Swagger
      services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }));
      // Allow CORS
      services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
        {
          builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        }));
      // JWT Authentication
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => {
          options.TokenValidationParameters = Helpers.GetTokenValidationOptions(validateLifetime: true);
          options.Events = new JwtBearerEvents()
          {
            OnAuthenticationFailed = context => {
              if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                context.Response.Headers.Add("Token-Expired", "true");
              return Task.CompletedTask;
            }
          };
        });
      // Add SignalR
      services.AddSignalR(hubOptions =>
        {
          hubOptions.EnableDetailedErrors = true;
          hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
        })
        .AddJsonProtocol(options =>
        {
          options.PayloadSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
          options.PayloadSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
      // configure MVC options
      // config => config.Filters.Add(typeof(ApiExceptionFilterAttribute))
      services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
        .AddJsonOptions(options =>
        {
          options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
          options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
      // Test GetService from DI
      // var db = Helpers.GetService<SSMSContext>();
      // Console.WriteLine(db.Model.FindEntityType(typeof(User)).Relational().TableName);
      // Console.WriteLine(db.Users.Count());
      // var config = Helpers.GetService<IConfiguration>();
      // Console.WriteLine(config.GetValue<bool>("Logging:IncludeScopes"));
      // SqlTableWatcher.Watch<User>("users");
      // SqlTableWatcher.WatchAll(null);
      SqlTableWatcher.WatchAll(new string[] { "User", "School", "Country", "Action" });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      // get the DI
      // Helpers.DI = app.ApplicationServices;
      // Exception Page [Error Page]
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();
      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });
      // Shows UseCors with CorsPolicyBuilder.
      app.UseCors("CorsPolicy");
      // using JWT Authentication
      app.UseAuthentication();
      // global exception handler
      app.UseExceptionHandler(appError =>
      {
        appError.Run(async context =>
        {
          context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          context.Response.ContentType = "application/json";
          var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
          if(contextFeature != null)
            await context.Response.WriteAsync(JsonConvert.SerializeObject(contextFeature.Error));
        });
      });
      // use SignalR and define client-side connection routes [url]
      app.UseSignalR(routes =>
      {
        // // get all classes in SSMS.Hubs namespace and loop through them
        // foreach (Type T in Helpers.GetAllClasses("SSMS.Hubs"))
        // {
        //   // dynamically invoke the Generic [MapHub] Method in [routes] object
        //   routes.GetType()
        //         .GetMethod("MapHub")
        //         .MakeGenericMethod(T)
        //         .Invoke(routes, new object[] { T.Name });
        // }
        routes.MapHub<UsersHub>("/users-hub");
        routes.MapHub<ParentsHub>("/parents-hub");
        routes.MapHub<StudentsHub>("/students-hub");
        routes.MapHub<EmployeesHub>("/employees-hub");
        routes.MapHub<SchoolsHub>("/schools-hub");
        routes.MapHub<CountriesHub>("/countries-hub");
        routes.MapHub<DocTypesHub>("/doctypes-hub");
      });
      // using MVC
      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
