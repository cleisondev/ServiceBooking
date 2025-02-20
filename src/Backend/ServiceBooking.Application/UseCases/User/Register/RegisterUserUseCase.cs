using AutoMapper;
using ServiceBooking.Application.Services.Cryptography;
using ServiceBooking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceBooking.Exceptions;
using ServiceBooking.Exceptions.ExceptionsBase;
using ServiceBooking.Communication.Request.User;
using ServiceBooking.Communication.Response.User;
using ServiceBooking.Domain.Entities;

namespace ServiceBooking.Application.UseCases.User.Register
{
    internal class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _map;
        private readonly IRepository<Usuario> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PasswordEncripter _passwordEncripter;

        public RegisterUserUseCase(IMapper map, IRepository<Usuario> repo, IUnitOfWork unitOfWork, PasswordEncripter passwordEncripter)
        {
            _map = map;
            _repo = repo;
            _unitOfWork = unitOfWork;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseRegisteredUserJson> RegistrarUsuario(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _map.Map<Domain.Entities.Usuario>(request);
            user.AtualizarSenha(_passwordEncripter.Encrypt(request.SenhaHash));

            await _repo.Add(user);
            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = request.Nome
            };
        }

        private async Task Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            var emailExiste = await _repo.ExistActiveUserWithEmail(request.Email);

            if (emailExiste)
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessageExceptions.EMAIL_ALREADY_REGISTERED));

            if (result.IsValid == false)
            {
                var erroMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(erroMessages);
            }



        }
    }
}
