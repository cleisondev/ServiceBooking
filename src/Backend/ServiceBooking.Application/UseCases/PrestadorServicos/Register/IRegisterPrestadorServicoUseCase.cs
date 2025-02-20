using ServiceBooking.Communication.Request.PrestadorServico;
using ServiceBooking.Communication.Request.User;
using ServiceBooking.Communication.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.UseCases.PrestadorServicos.Register
{
    public interface IRegisterPrestadorServicoUseCase
    {
        public Task<ResponseRegisteredUserJson> RegistrarPrestadorServico(RequestPrestadorServicoJson request);
    }
}
