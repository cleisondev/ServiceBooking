using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Communication.Request.User
{
    public class RequestRegisterUserJson
    {
        public Guid UsuarioId { get; private set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public Endereco endereco { get; set; }
        public TipoUsuario Tipo { get;  set; }
    }
}
