using ServiceBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Domain.Entities
{
    public class Agendamento
    {
        public Guid AgendamentoId { get; private set; } = Guid.NewGuid();
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public Guid ServicoId { get; private set; }
        public Servico Servico { get; private set; }
        public DateTime DataHora { get; private set; }
        public StatusAgendamento Status { get; private set; } = StatusAgendamento.Pendente;
        private Agendamento() { }
        public Agendamento(Guid clienteId, Guid servicoId, DateTime dataHora)
        {
            if (dataHora < DateTime.Now) throw new ArgumentException("A data do agendamento não pode ser no passado");

            UsuarioId = clienteId;
            ServicoId = servicoId;
            DataHora = dataHora;
        }

        public void Confirmar()
        {
            if (Status != StatusAgendamento.Pendente) throw new InvalidOperationException("O agendamento não pode ser confirmado");
            Status = StatusAgendamento.Confirmado;
        }

        public void Cancelar()
        {
            if (Status == StatusAgendamento.Concluido) throw new InvalidOperationException("Não é possível cancelar um agendamento concluído");
            Status = StatusAgendamento.Cancelado;
        }

        public void Concluir()
        {
            if (Status != StatusAgendamento.Confirmado) throw new InvalidOperationException("O agendamento precisa estar confirmado para ser concluído");
            Status = StatusAgendamento.Concluido;
        }
    }
    public enum StatusAgendamento
    {
        Pendente,
        Confirmado,
        Cancelado,
        Concluido
    }
}
