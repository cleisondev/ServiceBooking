using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceBooking.Application.Services.Jwt;
using ServiceBooking.Domain.Repositories;
using ServiceBooking.Infrastructure.DataAccess;
using ServiceBooking.Infrastructure.DataAccess.Repositories;
using ServiceBooking.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            AddRepositories(services);
            AddJwtAuth(services, config);
            AddDbContext_SqlServer(services, config); // Registra o DbContext
            AddFluentMigrator(services, config);
        }


        private static void AddDbContext_SqlServer(IServiceCollection services, IConfiguration config)
        {


            services.AddDbContext<ServiceBookingDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("ConnectionSqlServer"));
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        private static void AddFluentMigrator(IServiceCollection services, IConfiguration config)
        {
            services.AddFluentMigratorCore().ConfigureRunner(opt =>
            {
                opt.AddSqlServer()
                .WithGlobalConnectionString(config.GetConnectionString("ConnectionSqlServer"))
                .ScanIn(Assembly.Load("ServiceBooking.Infrastructure")).For.All();
            });
        }

        private static void AddJwtAuth(IServiceCollection services, IConfiguration config)
        {
            services.Configure<JwtSettings>(config.GetSection("jwt"));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<JwtSettings>>().Value);



            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = config["jwt:issuer"],
                    ValidAudience = config["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(config["jwt:secretKey"])),
                    ClockSkew = TimeSpan.Zero
                };

            });
        }
    }
}
