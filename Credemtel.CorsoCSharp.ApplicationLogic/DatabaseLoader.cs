using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Credemtel.CorsoCSharp.ApplicationLogic
{
    public class DatabaseLoader
    {
        public Action DipendeDaOS { get; set; }

        public void Load()
        {
            // Carico da DB
        }

        public void Save()
        {
            this.DipendeDaOS.Invoke();
        }
    }
}