using BarberBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Domain.Entities
{
    internal class Agendamento
    {
        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public Usuario Cliente { get; private set; }
        public int ServicoId { get; private set; }
        public Servico Servico { get; private set; }
        public DateTime DataHora { get; private set; }
        public StatusAgendamento Status { get; private set; }

        public Agendamento(int clienteId, int servicoId, DateTime dataHora)
        {
            if (dataHora < DateTime.Now) throw new ArgumentException("A data do agendamento não pode ser no passado");

            ClienteId = clienteId;
            ServicoId = servicoId;
            DataHora = dataHora;
            Status = StatusAgendamento.Pendente;
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
