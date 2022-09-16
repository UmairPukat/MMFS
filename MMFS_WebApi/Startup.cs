using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MMFS_AutoMapper;
using MMFS_Common.EmailSendProcess;
using MMFS_Context;
using MMFS_Models.EmailSendDto;
using MMFS_POCO.UserManagement;
using MMFS_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMFS_WebApi
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

            services.AddControllers();
            services.AddSingleton<AutoMapperConfig>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<MailService>();
            services.AddTransient<UserService>();
            services.AddTransient<UserProfileService>();
            services.AddTransient<SecurityService>();
            services.AddDbContext<_DbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, ApplicationRole>(
               option => {
                   option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(2000);
                   option.Lockout.MaxFailedAccessAttempts = 5;
                   option.Lockout.AllowedForNewUsers = false;
               })
              .AddEntityFrameworkStores<_DbContext>()
              .AddDefaultTokenProviders();
            services.AddCors(options =>
            {
                //options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:4200").WithOrigins("https://localhost:8085").WithOrigins("http://localhost:8085").WithOrigins("https://localhost:44317")
                options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:4200").WithOrigins("http://localhost:9095").WithOrigins("http://13.76.227.169:9095")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddDistributedMemoryCache();
            //services.AddSession();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MMFS_WebApi", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MMFS_WebApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
