using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Domain.Entities
{
    internal class Pagamento
    {
        public int Id { get; set; }
        public int AgendamentoId { get; set; }
        public Agendamento Agendamento { get; set; } = null!;

        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public StatusPagamento Status { get; set; } = StatusPagamento.Pendente;
    }
    public enum StatusPagamento
    {
        Pendente,
        Pago,
        Cancelado
    }
}
