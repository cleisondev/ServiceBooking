using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.Migrations.Versions.PrestadorServico
{
    [Migration(20250222)]
    public class AddPrestadorColumns : VersionBase
    {


        public override void Up()
        {
            Alter.Table("PrestadorServico")
        .AddColumn("NomeEmpresa").AsString(200).NotNullable()
    .AddColumn("Endereco_Rua").AsString(200).Nullable()
    .AddColumn("Endereco_Numero").AsString(50).Nullable()
    .AddColumn("Endereco_Bairro").AsString(100).Nullable()
    .AddColumn("Endereco_Cidade").AsString(100).Nullable()
    .AddColumn("Endereco_Estado").AsString(50).Nullable()
    .AddColumn("Endereco_Cep").AsString(20).Nullable();
        }
    }
}
