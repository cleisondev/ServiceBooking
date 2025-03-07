using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Application.Services.Jwt
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string userEmail);
    }
}
