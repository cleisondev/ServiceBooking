using ServiceBooking.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Infrastructure.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ServiceBookingDbContext _db;
        public UnitOfWork(ServiceBookingDbContext db) => _db = db;

        public async Task Commit() => await _db.SaveChangesAsync();
    }
}
