using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.ApplicationLogic.Exceptions
{
    public class CredemtelDatabaseException : Exception
    {
        public string DBSource { get; set; }
        public string ServerName { get; set; }

        public CredemtelDatabaseException()
        {

        }

        public CredemtelDatabaseException(string message) : base(message)
        {

        }

        public CredemtelDatabaseException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}