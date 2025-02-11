using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Domain.Entities
{
    public class Servico
    {
        public int ServicoId { get; private set; }
        public int PrestadorId { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public TimeSpan Duracao { get; private set; }

        public Servico(int prestadorId, string nome, decimal preco, TimeSpan duracao)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome do serviço é obrigatório");
            if (preco <= 0) throw new ArgumentException("Preço deve ser maior que zero");
            if (duracao.TotalMinutes < 1) throw new ArgumentException("Duração inválida");

            PrestadorId = prestadorId;
            Nome = nome;
            Preco = preco;
            Duracao = duracao;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            if (novoPreco <= 0) throw new ArgumentException("Preço deve ser maior que zero");
            Preco = novoPreco;
        }
    }
}
