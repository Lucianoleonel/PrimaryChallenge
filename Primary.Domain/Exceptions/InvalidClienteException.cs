using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary.Domain.Exceptions
{
    public class InvalidClienteException : Exception
    {
        public InvalidClienteException(string message) : base(message)
        {
        }
    }
}
