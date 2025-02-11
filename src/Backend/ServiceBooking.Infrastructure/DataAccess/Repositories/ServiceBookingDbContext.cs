using ServiceBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.DataAccess.Repositories
{
    public class ServiceBookingDbContext : DbContext
    {
        public ServiceBookingDbContext(DbContextOptions options) : base(options)
        {
        }

        internal DbSet<Usuario> Usuarios { get; set; }
        internal DbSet<Agendamento> Agendamentos { get; set; }
        internal DbSet<PrestadorServico> Prestadores { get; set; }
        internal DbSet<Servico> Servicos { get; set; }
        internal DbSet<Pagamento> Pagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceBookingDbContext).Assembly);
        }


    }
}
