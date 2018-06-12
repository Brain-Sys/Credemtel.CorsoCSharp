using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.ApplicationLogic.Exceptions
{
    public class InvalidPinException : Exception
    {
        public InvalidPinException()
        {

        }

        public InvalidPinException(string message) : base(message)
        {

        }

        public InvalidPinException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
