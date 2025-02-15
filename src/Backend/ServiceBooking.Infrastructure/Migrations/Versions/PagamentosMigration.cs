using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.Migrations.Versions
{
    [Migration(2025021505, "Create table Pagamentos")]
    public class PagamentosMigration : VersionBase
    {
        public override void Up()
        {
            Create.Table("Pagamentos")
               .WithColumn("PagamentoId").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
               .WithColumn("AgendamentoId").AsGuid().NotNullable().ForeignKey("Agendamentos", "AgendamentoId")
               .WithColumn("Valor").AsDecimal().NotNullable()
               .WithColumn("DataPagamento").AsDateTime().NotNullable()
               .WithColumn("Status").AsInt32().NotNullable(); // Enum StatusPagamento
        }
    }
}
