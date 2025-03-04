using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Exceptions.ExceptionsBase
{
    public class ServiceBookingException : SystemException
    {
        public ServiceBookingException(string? message) : base(message)
        {
        }
    }
}
