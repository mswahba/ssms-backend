using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SSMS.EntityModels;
using SSMS.Users;
using SSMS.Users.Parents;
using SSMS.Shared;
using Swashbuckle.AspNetCore.Swagger;

namespace SSMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Allow CORS
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }));
            // configure MVC options
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            //Register a type of DbContext so that it can be used in DI (inside dependent classes' constructors)
            services.AddDbContext<SSMSContext>();
            //AddSingleton configues settings to create only one instance of this type
            services.AddSingleton<Ado>();
            //AddScoped configues settings to create new instance of this type per http request
            services.AddScoped<BaseService<User, String>>();
            services.AddScoped<BaseService<Parent, String>>();
            services.AddScoped<BaseService<Student, String>>();
            services.AddScoped<BaseService<Employee, String>>();
            services.AddScoped<BaseService<DocType, Byte>>();
            services.AddScoped<BaseService<Country, Byte>>();
            services.AddScoped<BaseService<School, Byte>>();
            
            // Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors("MyPolicy");


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
