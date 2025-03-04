using AutoMapper;
using ServiceBooking.Application.Services.Cryptography;
using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.UseCases.User.GetUser
{
    public class GetUsersUseCase : IGetUsersUseCase
    {    

        private readonly IRepository<Usuario> _repo;

        public GetUsersUseCase(IRepository<Usuario> repo)
        {
            _repo = repo;
        }

        public async Task<IList<Usuario>> GetAllUsers()
        {
            return await _repo.GetAllUsers();
        }
    }
}
