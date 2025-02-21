using ServiceBooking.Communication.Request.Servico;
using ServiceBooking.Communication.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.UseCases.Servicos.Register
{
    public interface IRegisterServicosUseCase
    {
        public Task<ResponseRegisteredUserJson> RegistrarServico(RequestRegisterServiceJson request);
    }
}
