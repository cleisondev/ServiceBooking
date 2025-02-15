using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.Migrations.Versions
{
    [Migration(2025021503, "Create table Servicos")]
    public class ServicosMigration : VersionBase
    {
        public override void Up()
        {
            Create.Table("Servicos")
                .WithColumn("ServicoId").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                .WithColumn("PrestadorId").AsGuid().NotNullable().ForeignKey("PrestadorServico", "PrestadorServicoId")
                .WithColumn("Nome").AsString(100).NotNullable()
                .WithColumn("Preco").AsDecimal().NotNullable()
                .WithColumn("Duracao").AsTime().NotNullable();
        }
    }
}
