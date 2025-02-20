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
        public string Categoria { get; private set; }
        public string Descricao { get; private set; }
        public Endereco Endereco { get; private set; }
        public List<Servico> Servicos { get; private set; } = new();

        public PrestadorServico() { }
        public PrestadorServico(Guid usuarioId, string categoria, string descricao, Endereco endereco)
        {
            UsuarioId = usuarioId;
            Categoria = categoria;
            Descricao = descricao;
            Endereco = endereco;
        }

        public void AtualizarDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao)) throw new ArgumentException("Descrição inválida");
            Descricao = descricao;
        }

        public void AdicionarServico(Servico servico)
        {
            if (Servicos.Any(s => s.Nome == servico.Nome))
                throw new InvalidOperationException("Este serviço já foi adicionado");

            Servicos.Add(servico);
        }

        public bool OfereceServico(string nomeServico) => Servicos.Any(s => s.Nome == nomeServico);
    }
}
