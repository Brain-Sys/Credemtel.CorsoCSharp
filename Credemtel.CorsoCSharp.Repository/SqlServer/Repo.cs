using Credemtel.CorsoCSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Repository.SqlServer
{
    public class Repo : ILoader
    {
        public string GetName(int id)
        {
            return "abc";
        }

        public List<string> GetNames()
        {
            return new List<string>();
        }
    }
}