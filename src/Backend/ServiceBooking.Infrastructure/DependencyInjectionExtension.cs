using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBooking.Domain.Repositories;
using ServiceBooking.Infrastructure.DataAccess;
using ServiceBooking.Infrastructure.DataAccess.Repositories;
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
    }
}
