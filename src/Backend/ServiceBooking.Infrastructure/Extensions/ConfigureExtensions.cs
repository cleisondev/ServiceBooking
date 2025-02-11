using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.Extensions
{
    public static class ConfigureExtensions
    {
        public static string ConnectionString(this IConfiguration config)
        {
            return AddDbContext_SqlServer(config); // Registra o DbContext
        }

        private static string AddDbContext_SqlServer(this IConfiguration config)
        {
            return config.GetConnectionString("ConnectionSqlServer");

        }
    }
}
