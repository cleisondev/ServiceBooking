using ServiceBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.DataAccess
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


            modelBuilder.Entity<Usuario>()
       .OwnsOne(u => u.Endereco, endereco =>
       {
           endereco.Property(e => e.Rua).HasColumnName("Endereco_Rua");
           endereco.Property(e => e.Numero).HasColumnName("Endereco_Numero");
           endereco.Property(e => e.Bairro).HasColumnName("Endereco_Bairro");
           endereco.Property(e => e.Cidade).HasColumnName("Endereco_Cidade");
           endereco.Property(e => e.Estado).HasColumnName("Endereco_Estado");
           endereco.Property(e => e.Cep).HasColumnName("Endereco_Cep");
       });

            modelBuilder.Entity<Usuario>()
    .Property(u => u.Tipo)
    .HasConversion<int>();

            // Relacionamento Usuario -> Agendamento
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioId);

            // Relacionamento Usuario -> PrestadorServico (Um usuário pode ser um prestador)
            modelBuilder.Entity<PrestadorServico>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.UsuarioId);

            // Relacionamento PrestadorServico -> Servico (Um prestador pode ter vários serviços)
            modelBuilder.Entity<Servico>()
                .HasOne(s => s.Prestador)
                .WithMany()
                .HasForeignKey(s => s.PrestadorId);

            // Relacionamento Agendamento -> Servico (Cada agendamento é para um serviço específico)
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Servico)
                .WithMany()
                .HasForeignKey(a => a.ServicoId);

            // Relacionamento Agendamento -> Pagamento (Cada pagamento está associado a um agendamento)
            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.Agendamento)
                .WithOne()
                .HasForeignKey<Pagamento>(p => p.AgendamentoId);
        }


    }
}
