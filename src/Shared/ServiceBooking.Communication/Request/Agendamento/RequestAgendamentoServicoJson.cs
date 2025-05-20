using ServiceBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Communication.Request.Agendamento
{
    public class RequestAgendamentoServicoJson
    {
        public Guid AgendamentoId { get; private set; } = Guid.NewGuid();
        public Guid UsuarioId { get; private set; }
        public Guid ServicoId { get; private set; }
        public DateTime DataHora { get; private set; }
        public StatusAgendamento Status { get; private set; } = StatusAgendamento.Pendente;
    }
}
