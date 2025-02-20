using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Domain.Entities
{
    public class PrestadorServico
    {
        public Guid PrestadorServicoId { get; private set; } = Guid.NewGuid();
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public string NomeEmpresa { get; set; }
        public string Categoria { get; private set; }
        public string Descricao { get; private set; }
        public Endereco Endereco { get; private set; }

        public PrestadorServico() { }
        public PrestadorServico(Guid usuarioId, string categoria, string descricao, Endereco endereco, string nomeEmpresa)
        {
            UsuarioId = usuarioId;
            Categoria = categoria;
            Descricao = descricao;
            Endereco = endereco;
            NomeEmpresa = nomeEmpresa;
        }

        public void AtualizarDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao)) throw new ArgumentException("Descrição inválida");
            Descricao = descricao;
        }
    }
}
