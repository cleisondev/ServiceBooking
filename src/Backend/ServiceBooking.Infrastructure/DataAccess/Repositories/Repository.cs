using Microsoft.EntityFrameworkCore;
using ServiceBooking.Domain.Entities;
using ServiceBooking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ServiceBooking.Infrastructure.DataAccess.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly ServiceBookingDbContext _db;

        public Repository(ServiceBookingDbContext db) => _db = db;
        public async Task Add(T entity) => await _db.Set<T>().AddAsync(entity);


        public async Task<List<T?>> GetAllUsers() => await _db.Set<T>().ToListAsync();

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            if (typeof(T) == typeof(Usuario))
            {
                return await _db.Set<Usuario>().AnyAsync(user => user.Email.Equals(email));
            }

            return false;
        }

        public async Task<Usuario?> GetByEmailAndPassword(string email, string password)
        {
            return await _db.Set<Usuario>().AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email.Equals(email) && user.SenhaHash.Equals(password));

        }

    }
}
