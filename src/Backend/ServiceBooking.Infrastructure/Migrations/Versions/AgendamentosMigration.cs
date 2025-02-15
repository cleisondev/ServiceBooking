using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.Migrations.Versions
{
    [Migration(2025021504, "Create table Agendamentos")]
    public class AgendamentosMigration : VersionBase
    {
        public override void Up()
        {
            Create.Table("Agendamentos")
                      .WithColumn("AgendamentoId").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                      .WithColumn("UsuarioId").AsGuid().NotNullable().ForeignKey("Usuarios", "UsuarioId")
                      .WithColumn("ServicoId").AsGuid().NotNullable().ForeignKey("Servicos", "ServicoId")
                      .WithColumn("DataHora").AsDateTime().NotNullable()
                      .WithColumn("Status").AsInt32().NotNullable(); // Enum StatusAgendamento
        }
    }
}
