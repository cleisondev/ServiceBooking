using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Communication.Request.PrestadorServico
{
    public class RequestPrestadorServicoJson
    {
        public Guid PrestadorServicoId { get; private set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public string NomeEmpresa { get; set; }
        public Endereco Endereco { get; set; }
    }
}
