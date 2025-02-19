using ServiceBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Communication.Request
{
    public class RequestRegisterUserJson
    {
        public Guid UsuarioId { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string SenhaHash { get; private set; } = string.Empty;
        public string Telefone { get; private set; } = string.Empty;
        public TipoUsuario Tipo { get; private set; } // Cliente ou Prestador
    }
}
