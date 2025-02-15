using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Domain.Repositories.User
{
    public interface IUserWriteOnlyRepository
    {
        public Task Add(Entities.Usuario user);
    }
}
