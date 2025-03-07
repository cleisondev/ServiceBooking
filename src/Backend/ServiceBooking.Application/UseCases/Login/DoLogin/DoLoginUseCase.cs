using AutoMapper;
using ServiceBooking.Application.Services.Cryptography;
using ServiceBooking.Application.Services.Jwt;
using ServiceBooking.Communication.Request.Login;
using ServiceBooking.Communication.Response.User;
using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.Repositories;
using ServiceBooking.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IMapper _map;
        private readonly IRepository<Usuario> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PasswordEncripter _passwordEncripter;
        private readonly IJwtService _jwtService;

        public DoLoginUseCase(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public async Task<ResponseRegisteredUserJson> Login(RequestLoginJson request)
        {
            var encriptedPassword = _passwordEncripter.Encrypt(request.Password);

            var user = await _repo.GetByEmailAndPassword(request.Email, encriptedPassword) ?? throw new InvalidLoginException();

            var result = _jwtService.GenerateToken(user.UsuarioId.ToString(), user.Email);

            return new ResponseRegisteredUserJson
            {
                Name = user.Nome,
                Token = result
            };

        }
    }
}
