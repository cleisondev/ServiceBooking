using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.Migrations.Versions.Usuarios
{
    [Migration(20250221)]
    public class AddTipoUsuario : VersionBase
    {
        public override void Up()
        {
            Alter.Table("Usuarios")
        .AddColumn("Tipo").AsInt32().Nullable();

            // Passo 2: Atualizar registros existentes com um valor padrão
            Execute.Sql("UPDATE Usuarios SET Tipo = 0 WHERE Tipo IS NULL");

            // Passo 3: Alterar a coluna para NOT NULL
            Alter.Column("Tipo").OnTable("Usuarios").AsInt32().NotNullable();

        }
    }
}
