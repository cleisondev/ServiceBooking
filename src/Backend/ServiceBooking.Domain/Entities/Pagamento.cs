using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Domain.Entities
{
    public class Pagamento
    {
        public Guid PagamentoId { get; private set; } = Guid.NewGuid();
        public Guid AgendamentoId { get; private set; }
        public Agendamento Agendamento { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public StatusPagamento Status { get; private set; } = StatusPagamento.Pendente;
        private Pagamento() { } // Para o EF

        public Pagamento(Guid agendamentoId, decimal valor, DateTime dataPagamento)
        {
            AgendamentoId = agendamentoId;
            Valor = valor;
            DataPagamento = dataPagamento;
        }
    }

    public enum StatusPagamento
    {
        Pendente,
        Pago,
        Cancelado
    }
}
