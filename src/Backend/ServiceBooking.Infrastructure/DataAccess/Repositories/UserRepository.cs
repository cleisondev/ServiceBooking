using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.Repositories;
using ServiceBooking.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.DataAccess.Repositories
{
    internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly ServiceBookingDbContext _db;

        public UserRepository(ServiceBookingDbContext db) => _db = db;
        public async Task Add(Usuario user) => await _db.Usuarios.AddAsync(user);

    }
}
