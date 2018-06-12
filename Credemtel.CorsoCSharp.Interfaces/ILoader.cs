using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Interfaces
{
    public interface ILoader
    {
        List<string> GetNames();
        string GetName(int id);
    }
}