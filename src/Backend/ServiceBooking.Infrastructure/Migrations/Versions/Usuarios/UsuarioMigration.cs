using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.Migrations.Versions.Usuarios
{
    [Migration(DataBaseVersions.TABLE_USER, "Create table Usuarios")]
    public class UsuarioMigration : VersionBase
    {
        public override void Up()
        {



            Create.Table("Usuarios")
        .WithColumn("UsuarioId").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
        .WithColumn("Nome").AsString(200).NotNullable()
        .WithColumn("Email").AsString(200).NotNullable().Unique()
        .WithColumn("SenhaHash").AsString(2000).NotNullable()
        .WithColumn("Telefone").AsString(15).Nullable()
        .WithColumn("DataCriacao").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime) // Garantir que a data seja UTC
        .WithColumn("Endereco_Rua").AsString(200).Nullable()
        .WithColumn("Endereco_Numero").AsString(50).Nullable()
        .WithColumn("Endereco_Bairro").AsString(100).Nullable()
        .WithColumn("Endereco_Cidade").AsString(100).Nullable()
        .WithColumn("Endereco_Estado").AsString(50).Nullable()
        .WithColumn("Endereco_Cep").AsString(20).Nullable();

        }
    }
}
