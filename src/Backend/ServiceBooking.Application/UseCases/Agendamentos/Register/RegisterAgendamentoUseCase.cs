using AutoMapper;
using ServiceBooking.Communication.Request.Agendamento;
using ServiceBooking.Communication.Response.User;
using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.UseCases.Agendamentos.Register
{
    public class RegisterAgendamentoUseCase : IRegisterAgendamentoUseCase
    {
        private readonly IMapper _map;
        private readonly IRepository<Agendamento> _repo;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterAgendamentoUseCase(IMapper map, IRepository<Agendamento> repo, IUnitOfWork unitOfWork)
        {
            _map = map;
            _repo = repo;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseRegisteredUserJson> RegistrarAgendamento(RequestAgendamentoServicoJson request)
        {
            var agendamento = _map.Map<Agendamento>(request);

            // Adicione ao repositório
            await _repo.Add(agendamento);

            // Salve as alterações
            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = request.Status.ToString(),

            };
        }
    }
}
