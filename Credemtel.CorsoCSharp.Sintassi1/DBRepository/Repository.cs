using Credemtel.CorsoCSharp.Sintassi1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi1.DBRepository
{
    public class Repository<T> where T : IAggregateRoot
    {
        public List<T> Ricerca(List<string> parametri)
        {
            return null;
        }
    }
}