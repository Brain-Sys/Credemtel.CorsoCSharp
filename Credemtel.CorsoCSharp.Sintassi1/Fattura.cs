using Credemtel.CorsoCSharp.Sintassi1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi1
{
    public class Fattura : DomainObject, IDisposable, IAggregateRoot
    {
        public string Numero { get; set; }
        public List<Recapito> Recapiti { get; set; }

        public Fattura(string n)
        {
            this.Numero = n;
        }

        public void Dispose()
        {
            
        }
    }
}