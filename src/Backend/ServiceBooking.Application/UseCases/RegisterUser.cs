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

namespace ServiceBooking.Application.UseCases
{
    internal class RegisterUser : IRegisterUser
    {
        private readonly IMapper _map;
        private readonly IUserWriteOnlyRepository _writeOnlyRepository;
        private readonly IUserReadOnlyRepository _readOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PasswordEncripter _passwordEncripter;

        public RegisterUser(IMapper map, IUserWriteOnlyRepository writeOnlyRepository, IUserReadOnlyRepository readOnlyRepository, IUnitOfWork unitOfWork, PasswordEncripter passwordEncripter)
        {
            _map = map;
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
            _unitOfWork = unitOfWork;
            _passwordEncripter = passwordEncripter;
        }

        public Task<ResponseRegisteredUserJson> Registrar(RequestRegisterUserJson request)
        {
            throw new NotImplementedException();
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
