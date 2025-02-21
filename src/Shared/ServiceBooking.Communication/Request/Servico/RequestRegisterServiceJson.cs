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
        public Guid ServicoId { get;  set; } = Guid.NewGuid();
        public Guid PrestadorId { get;  set; }
        //public PrestadorServico Prestador { get; private set; }
        public string Nome { get;  set; }
        public decimal Preco { get;  set; }
        public TimeSpan Duracao { get;  set; }
    }
}
