using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SmartShop.DataApi.HostedServices;
using SmartShop.DataApi.Hubs;
using SmartShop.DataApi.Models.Identity;
using SmartShop.DataLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.DataApi
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
            #region DbContext injections
            services.AddDbContext<SmartShopDbContext>(o => o.UseSqlServer(this.Configuration.GetConnectionString("data"),
                assembly=> assembly.MigrationsAssembly(typeof(SmartShop.DataLib.Models.Data.SmartShopDbContext).Assembly.FullName)));
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(this.Configuration.GetConnectionString("identity")));
            #endregion
            #region CORS Configuration
            services.AddCors(options => {
                options.AddPolicy("EnableCORS",
                    builder => {
                        builder
                            .WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .Build();
                    });
            });
            #endregion
            #region identity seederservice injectors

            services.AddScoped<IdentityDbInitializer>();
            services.AddHostedService<SetupIdentityDataSeeder>();
            #endregion
            #region Identy Configurations
            services.AddIdentity<IdentityUser, IdentityRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
            #endregion
            #region Authentication/JWT Configuration
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options => {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidAudience = Configuration["Jwt:Site"],
                        ValidIssuer = Configuration["Jwt:Site"],
                        IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))
                    };
                });
            #endregion
            services.AddControllersWithViews()
                .AddNewtonsoftJson(option => {
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
                option.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCors("EnableCORS");
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<OrderCreatedNotificationHub>("/orderHub");

            });
        }
    }
}
