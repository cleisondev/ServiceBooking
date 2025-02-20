using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.Migrations.Versions
{
    [Migration(2025021502, "Create table PrestadorServico")]
    public class PrestadorServicoMigration : VersionBase
    {
        public override void Up()
        {
            Create.Table("Prestadores")
                .WithColumn("PrestadorServicoId").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                .WithColumn("UsuarioId").AsGuid().NotNullable().ForeignKey("Usuarios", "UsuarioId")
                .WithColumn("Categoria").AsString(100).NotNullable()
                .WithColumn("Descricao").AsString(500).NotNullable()
                .WithColumn("Endereco").AsString(300).NotNullable();
        }
    }
}
