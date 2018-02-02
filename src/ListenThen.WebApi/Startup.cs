using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using ListenThen.Infra.CrossCutting.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ListenThen.Infra.CrossCutting.Identity.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ListenThen.Infra.CrossCutting.IoC;
using AutoMapper;
using ListenThen.Infra.Data.Context;

namespace ListenThen.WebApi
{
    public class Startup
    {
        private static IConfigurationRoot appSettings
        {
            get
            {
                return new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json")
                           .Build();
            }
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = appSettings.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<ListenThenContext>(options => options.UseSqlServer(connection));

            RegisterAuthentication(services);

            RegisterServices(services);

            services.AddMvc();

            services.AddAutoMapper();
        }
        private static void RegisterAuthentication(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            var tokenConfig = appSettings.GetSection("Jwt");
            var symmetricKeyAsBase64 = tokenConfig["Secret"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!  
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim  
                ValidateIssuer = true,
                ValidIssuer = tokenConfig["Iss"],

                // Validate the JWT Audience (aud) claim  
                ValidateAudience = true,
                ValidAudience = tokenConfig["Aud"],

                // Validate the token expiry  
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("CanChicoFeelingsRead", policy => policy.RequireClaim("ChicoFeelings", "Get"));
                //options.AddPolicy("CanChicoFeelingsCreate", policy => policy.RequireClaim("ChicoFeelings", "Create"));
                //options.AddPolicy("CanChicoFeelingsSudoCreate", policy => policy.RequireClaim("ChicoFeelings", "SudoCreate"));
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseMvc();
        }
        private void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}