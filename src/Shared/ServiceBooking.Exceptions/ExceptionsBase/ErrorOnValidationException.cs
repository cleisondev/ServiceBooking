using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBooking.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException :ServiceBookingException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessagess)
        {
            ErrorMessages = errorMessagess;

        }
    }
}
