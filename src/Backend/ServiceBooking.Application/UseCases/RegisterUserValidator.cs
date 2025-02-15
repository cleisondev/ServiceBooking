using FluentValidation;
using ServiceBooking.Communication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.UseCases
{
    internal class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            //RuleFor(user => user.Nome).NotEmpty().WithMessage(ResourceMessageExceptions.NAME_EMPTY);
            //RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessageExceptions.EMAIL_EMPTY);
            //RuleFor(user => user.SenhaHash.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessageExceptions.PASSWORD_EMPTY);
            //When(user => !string.IsNullOrEmpty(user.Email), () =>
            //{
            //    RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessageExceptions.EMAIL_INVALID);
            //});
        }
    }
}
