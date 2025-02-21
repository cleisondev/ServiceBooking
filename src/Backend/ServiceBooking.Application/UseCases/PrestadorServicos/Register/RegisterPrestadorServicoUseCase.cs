using AutoMapper;
using ServiceBooking.Application.Services.Cryptography;
using ServiceBooking.Communication.Request.PrestadorServico;
using ServiceBooking.Communication.Request.User;
using ServiceBooking.Communication.Response.User;
using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceBooking.Domain.Entities;

namespace ServiceBooking.Application.UseCases.PrestadorServicos.Register
{
    public class RegisterPrestadorServicoUseCase : IRegisterPrestadorServicoUseCase
    {
        private readonly IMapper _map;
        private readonly IRepository<PrestadorServico> _repo;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterPrestadorServicoUseCase(IMapper map, IRepository<PrestadorServico> repo, IUnitOfWork unitOfWork)
        {
            _map = map;
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredUserJson> RegistrarPrestadorServico(RequestPrestadorServicoJson request)
        {
            var prestadorServico = _map.Map<PrestadorServico>(request);

            // Adicione ao repositório
            await _repo.Add(prestadorServico);

            // Salve as alterações
            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = request.NomeEmpresa
            };
        }

    }
}
