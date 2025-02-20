using FluentValidation;
using ServiceBooking.Communication.Request.User;
using ServiceBooking.Exceptions;

namespace ServiceBooking.Application.UseCases.User.Register
{
    internal class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Nome).NotEmpty().WithMessage(ResourceMessageExceptions.NAME_EMPTY);

            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessageExceptions.EMAIL_EMPTY)
                .EmailAddress().WithMessage(ResourceMessageExceptions.EMAIL_INVALID);

            RuleFor(user => user.Telefone)
            .NotEmpty().WithMessage(ResourceMessageExceptions.PHONE_EMPTY)
            .Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$")
            .WithMessage(ResourceMessageExceptions.PHONE_INVALID);

            RuleFor(user => user.SenhaHash.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessageExceptions.PASSWORD_EMPTY);
            When(user => !string.IsNullOrEmpty(user.Email), () =>
            {
                RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessageExceptions.EMAIL_INVALID);
            });
        }
    }
}
