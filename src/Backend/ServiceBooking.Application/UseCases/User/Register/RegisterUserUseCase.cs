using AutoMapper;
using ServiceBooking.Application.Services.Cryptography;
using ServiceBooking.Communication.Request;
using ServiceBooking.Communication.Response;
using ServiceBooking.Domain.Repositories.User;
using ServiceBooking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceBooking.Exceptions;
using ServiceBooking.Exceptions.ExceptionsBase;

namespace ServiceBooking.Application.UseCases.User.Register
{
    internal class RegisterUserUseCase : IRegisterUseCase
    {
        private readonly IMapper _map;
        private readonly IUserWriteOnlyRepository _writeOnlyRepository;
        private readonly IUserReadOnlyRepository _readOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PasswordEncripter _passwordEncripter;

        public RegisterUserUseCase(IMapper map, IUserWriteOnlyRepository writeOnlyRepository, IUserReadOnlyRepository readOnlyRepository, IUnitOfWork unitOfWork, PasswordEncripter passwordEncripter)
        {
            _map = map;
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
            _unitOfWork = unitOfWork;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseRegisteredUserJson> RegistrarUsuario(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _map.Map<Domain.Entities.Usuario>(request);
            user.AtualizarSenha(_passwordEncripter.Encrypt(request.SenhaHash));

            await _writeOnlyRepository.Add(user);
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

            var emailExiste = await _readOnlyRepository.ExistActiveUserWithEmail(request.Email);

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
