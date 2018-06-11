using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi1
{
    public class PrintDocument<T> where T : DomainObject, new()
    {
        public void Print(T oggetto)
        {
            foreach (var item in oggetto.PrintInformations)
            {

            }
        }
    }

    public static class SaveMemory
    {
        public static bool Clear<T>(T oggetto) where T : class, IDisposable
        {
            oggetto.Dispose();
            oggetto = null;

            return true;
        }

        public static bool ClearCollection<T>(T oggetto)
            where T : class, IDisposable, IEnumerable
        {
            foreach (var item in oggetto)
            {
                
            }

            oggetto.Dispose();
            oggetto = null;

            return true;
        }

        public static void Test<T1, T2>(T1 ogg1, T2 ogg2) where T1 : IDisposable
            where T2 : struct
        {
            ogg1.Dispose();
        }
    }
}