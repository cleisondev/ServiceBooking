using Microsoft.EntityFrameworkCore;
using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.DataAccess.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly ServiceBookingDbContext _db;

        public Repository(ServiceBookingDbContext db) => _db = db;
        public async Task Add(T entity) => await _db.Set<T>().AddAsync(entity);
        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            if (typeof(T) == typeof(Usuario))
            {
                return await _db.Set<Usuario>().AnyAsync(user => user.Email.Equals(email));
            }
            // Caso a lógica precise de algo diferente, você pode tratar aqui.
            return false;
        }

    }
}
