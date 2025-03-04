using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Exceptions.ExceptionsBase
{
    public class InvalidLoginException : ServiceBookingException
    {
        public InvalidLoginException() : base(ResourceMessageExceptions.ACCESS_INVALID)
        {
        }
    }
}
