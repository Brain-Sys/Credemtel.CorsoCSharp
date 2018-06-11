using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi1
{
    public class Fattura : DomainObject, IDisposable
    {
        public string Numero { get; set; }

        public Fattura(string n)
        {
            this.Numero = n;
        }

        public void Dispose()
        {
            
        }
    }
}