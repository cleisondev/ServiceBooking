using ServiceBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Communication.Request.Servico
{
    public class RequestRegisterServiceJson
    {
        public Guid ServicoId { get; private set; } = Guid.NewGuid();
        public Guid PrestadorId { get; private set; }
        public PrestadorServico Prestador { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public TimeSpan Duracao { get; private set; }
    }
}
