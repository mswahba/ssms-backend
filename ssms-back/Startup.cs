﻿using System;
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
using Microsoft.AspNetCore.SignalR;

namespace SSMS
{
  public class Startup
  {
    private readonly IConfiguration _config;
    public Startup(IConfiguration config)
    {
      _config = config;
      // test code
      Test.onStartupCtor(_config);
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // get the DI
      Helpers.DI = services;
      // AddScoped configures settings to create new instance of this type per http request
      services.AddScoped<BaseService>();
      // Add automapper
      services.AddAutoMapper(typeof(Startup).Assembly);
      // Add SMTP Mail Service
      services.AddScoped<SmtpClient>((serviceProvider) =>
      {
        return new SmtpClient()
        {
          UseDefaultCredentials = false,
          DeliveryMethod = SmtpDeliveryMethod.Network,
          Host = _config.GetValue<String>("Email:Host"),
          Port = _config.GetValue<int>("Email:Port"),
          EnableSsl = _config.GetValue<bool>("Email:SSL"),
          Credentials = new NetworkCredential(
            _config.GetValue<String>("Email:UserName"),
            _config.GetValue<String>("Email:Password")
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
          hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(3);
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
      // test code
      Test.onConfigServices();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app,
                          IHostingEnvironment env,
                          IHubContext<DbHub>  dbHub)
    {
      // Exception Page [Error Page]
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();
      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1") );
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
        routes.MapHub<DbHub>("/db-hub");
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
      // run Test.onConfigure
      Test.onConfigure(dbHub);
    }
  }
}
