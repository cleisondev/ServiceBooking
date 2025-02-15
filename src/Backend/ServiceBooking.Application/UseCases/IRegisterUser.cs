using ServiceBooking.Communication.Request;
using ServiceBooking.Communication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.UseCases
{
    internal interface IRegisterUser
    {
        public Task<ResponseRegisteredUserJson> Registrar(RequestRegisterUserJson request);
    }
}
