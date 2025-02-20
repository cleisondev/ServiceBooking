using AutoMapper;
using ServiceBooking.Communication.Request.PrestadorServico;
using ServiceBooking.Communication.Request.User;
using ServiceBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore());

            CreateMap<RequestPrestadorServicoJson, PrestadorServico>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore()); ;
        }
    }
}
