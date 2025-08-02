using Application.Abstractions.Common;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace PrizeWebAPI.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureAuthenticationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            //var jwtSecret = configuration.GetSection("AppSettings").GetValue<string>("JwtSecret");
            //var frontUrl = configuration.GetSection("AppSettings").GetValue<string>("FrontUrl");
            
            var masterKey = configuration.GetSection("JWTValidator").GetValue<string>("MasterKey");
            var issuer = configuration.GetSection("AppSettings").GetValue<string>("issuer");
            var key = Encoding.ASCII.GetBytes(masterKey);

            services.AddAuthentication(
                x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer, //some string, normally web url,
                        ValidAudience = issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            //Transient??
            services.AddTransient<ICurrentUserService, CurrentUserService>();
        }

        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Authorization: Bearer {token}"
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                swagger.IncludeXmlComments(xmlPath);
            });

        }

        public static void UseCustomSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}

