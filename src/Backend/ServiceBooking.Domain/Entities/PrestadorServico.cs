using ServiceBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Domain.Entities
{
    public class PrestadorServico
    {
        public int PrestadorServicoId { get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public string Categoria { get; private set; }
        public string Descricao { get; private set; }
        public string Endereco { get; private set; }
        public List<Servico> Servicos { get; private set; } = new();

        public PrestadorServico(int usuarioId, string categoria, string descricao, string endereco)
        {
            if (string.IsNullOrWhiteSpace(categoria)) throw new ArgumentException("Categoria inválida");
            if (string.IsNullOrWhiteSpace(endereco)) throw new ArgumentException("Endereço inválido");

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
