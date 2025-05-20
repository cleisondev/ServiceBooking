using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBooking.Application.Services.AutoMapper;
using ServiceBooking.Application.Services.Cryptography;
using ServiceBooking.Application.UseCases.Login.DoLogin;
using ServiceBooking.Application.UseCases.PrestadorServicos.Register;
using ServiceBooking.Application.UseCases.Servicos.Register;
using ServiceBooking.Application.UseCases.User.GetUser;
using ServiceBooking.Application.UseCases.User.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration config)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {

            services.AddScoped(options => new AutoMapper.MapperConfiguration(opt =>
            {
                opt.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IRegisterPrestadorServicoUseCase, RegisterPrestadorServicoUseCase>();
            services.AddScoped<IRegisterServicosUseCase, RegisterServicoUseCase>();
            services.AddScoped<IRegisterServicosUseCase, RegisterServicoUseCase>();
            services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();
            services.AddScoped<PasswordEncripter>();
        }

    }
}
