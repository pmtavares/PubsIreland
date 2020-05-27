using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Configurations;
using Application.Services;
using AutoMapper;
using Infrastructured.Errors;
using Infrastructured.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.Repository;
using Persistence.Repository.Auth;
using Persistence.Repository.Cities;
using Persistence.Repository.Pubs;

namespace PubsIreland
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(
                 options => {
                     options.UseMySql(Configuration.GetConnectionString("DefaultConnection")); //MySQL

                 }
             );

            ConfigureServices(services);
        }


        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(
                 options => {
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

                 }
             );

            ConfigureServices(services);
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

         /*   services.AddDbContext<DataContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                }
            );

        */

            
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", policy => {
                    policy
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                    //.WithOrigins("http://localhost", "http://localhost");
                });
            });

            //Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            services.AddAutoMapper(typeof(AutoMapperProfile)); //AutoMapper injection
            services.AddScoped<IPubServices, PubServicesImpl>();
            services.AddScoped<IPubRepository, PubRepository>();
            services.AddScoped<ICityServices, CityServicesImpl>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddHttpContextAccessor();
            services.AddScoped<IUserAccessor, UserAccessor>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opt => {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseCors(x=> x.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
            //app.UseCors("CorsPolicy");

            app.UseAuthentication();

            

            //After changing angular.json file to point the build to wwwroot folder, insert the
            //Following two lines
            app.UseDefaultFiles(); //Look for index file
            app.UseStaticFiles(); //Look for files in the wwwroot folder
            app.UseMvc(routes => {
                routes.MapSpaFallbackRoute(
                name: "spa-fallback",
                defaults: new { controller = "Fallback", action = "Index" }
                );
            });
            
        }
    }
}
