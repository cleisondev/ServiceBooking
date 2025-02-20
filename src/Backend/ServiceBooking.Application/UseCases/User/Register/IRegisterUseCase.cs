using ServiceBooking.Communication.Request.User;
using ServiceBooking.Communication.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.UseCases.User.Register
{
    public interface IRegisterUseCase
    {
        public Task<ResponseRegisteredUserJson> RegistrarUsuario(RequestRegisterUserJson request);
    }
}
