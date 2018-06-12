using Credemtel.CorsoCSharp.Interfaces;
using Credemtel.CorsoCSharp.Repository.ExtensionMethods;
using Credemtel.CorsoCSharp.Repository.SQLite;
using Credemtel.CorsoCSharp.Sintassi3.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi3
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 45;
            bool pari = x.IsPari();

            string fiscalCode = "DMNLRG76B28I274H";
            bool ok1 = fiscalCode.IsCorrectFiscalCode();
            bool ok2 = fiscalCode.IsCorrectFiscalCode("us");
            bool ok3 = fiscalCode.IsCorrectFiscalCode("fr");
            int anno = fiscalCode.GetBirthYear();

            //ILoader dbLoader = DependencyService.Get<ILoader>();
            //dbLoader.GetName(23434);

            string value = ConfigurationManager.AppSettings["DbEngine"];
            Type type = Type.GetType(value);

            if (type != null)
            {
                ILoader loader = Activator.CreateInstance(type) as ILoader;
                var bytes = loader.GetDump();

                var dt = DateTime.Now.ToItaly();

                object loader2 = Activator.CreateInstance(type);
                MethodInfo mi = type.GetMethod("GetNames");
                object result = mi.Invoke(loader2, null);
            }

            //var names = repo.GetNames();

            //foreach (var item in names)
            //{

            //}
        }
    }
}