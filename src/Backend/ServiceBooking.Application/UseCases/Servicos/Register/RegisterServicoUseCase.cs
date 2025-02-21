using AutoMapper;
using ServiceBooking.Communication.Request.Servico;
using ServiceBooking.Communication.Response;
using ServiceBooking.Communication.Response.User;
using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.Repositories;
using ServiceBooking.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.UseCases.Servicos.Register
{
    internal class RegisterServicoUseCase : IRegisterServicosUseCase
    {
        private readonly IMapper _map;
        private readonly IRepository<PrestadorServico> _prestadorRepo;
        private readonly IRepository<Servico> _servicoRepo;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterServicoUseCase(IMapper map, IRepository<PrestadorServico> prestadorRepo, IRepository<Servico> servicoRepo, IUnitOfWork unitOfWork)
        {
            _map = map;
            _prestadorRepo = prestadorRepo;
            _servicoRepo = servicoRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredUserJson> RegistrarServico(RequestRegisterServiceJson request)
        {

            var existePrestadorServico = await _prestadorRepo.GetAsync(c => c.PrestadorServicoId == request.PrestadorId);

            if (existePrestadorServico is null)
                throw new ErrorOnValidationException(new List<string> { "Prestador de serviço não encontrado." });


            var servico = _map.Map<Servico>(request);

            await _servicoRepo.Add(servico);

            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = request.Nome
            };
        }
    }
}
