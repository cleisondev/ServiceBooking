using ServiceBooking.Communication.Request.Agendamento;
using ServiceBooking.Communication.Request.PrestadorServico;
using ServiceBooking.Communication.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.UseCases.Agendamentos.Register
{
    internal interface IRegisterAgendamentoUseCase
    {
        public Task<ResponseRegisteredUserJson> RegistrarAgendamento(RequestAgendamentoServicoJson request);
    }
}
