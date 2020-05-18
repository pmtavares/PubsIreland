using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Configurations;
using Application.Services;
using AutoMapper;
using Infrastructured.Errors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence;
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


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DataContext>(options =>
                {
                    options.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
                }
            );



            
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", policy => {
                    policy
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                    //.WithOrigins("http://localhost", "http://localhost");
                });
            });

            services.AddAutoMapper(typeof(AutoMapperProfile)); //AutoMapper injection
            services.AddScoped<IPubServices, PubServicesImpl>();
            services.AddScoped<IPubRepository, PubRepository>();
            services.AddScoped<ICityServices, CityServicesImpl>();
            services.AddScoped<ICityRepository, CityRepository>();



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
                //app.UseHsts();
            }
            app.UseCors(x=> x.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
            //app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
