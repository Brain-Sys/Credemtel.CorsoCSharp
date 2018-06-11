using Credemtel.CorsoCSharp.Sintassi1.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi1
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona();
            p1.Nome = "glmdlkgmdflkh";
            p1.Cognome = "aaaaaaaaaaaaaaaaaaa";
            p1.SalvataggioFallito += P1_SalvataggioFallito;
            p1.Salva();
            Persona p2 = p1.Clone();
            //ICloneable<Persona> inter = p1;
            //Persona clone = inter.Clone();

            PrintDocument<Persona> engine = new PrintDocument<Persona>();
            engine.Print(p2);
            new PrintDocument<Persona>().Print(p2);

            Type type = Type.GetType("List");
            type.MakeGenericType(new Type[] { typeof(string) });
            Activator.CreateInstance(type);

            // PrintDocument<Fattura> y;

            Fattura f1 = new Fattura("001/2018");
            SaveMemory.Clear<Fattura>(f1);

            StringCollection elencoNomi = new StringCollection();
            elencoNomi.Add("Liborio");
            elencoNomi.Add("Mirko");
            // elencoNomi.Add(90);
            string x = elencoNomi[0];
            bool esiste = elencoNomi.Contains("Mirko");

            if(esiste)
            {
                int index = elencoNomi.IndexOf("Mirko");
            }

            // SaveMemory.ClearCollection<StringCollection>(elencoNomi);

            BitArray ba = new BitArray(20);

            BitVector32 bv = new BitVector32(56);
            System.Collections.Specialized.ListDictionary ld = new ListDictionary();
            ld.Add("dmnlgr", 0);
            object person = ld["dmnlgr"];

            System.Collections.Stack stack = new Stack();
            stack.Push(7);
            stack.Push(DateTime.Now);
            DateTime dt = (DateTime)stack.Pop();

            ArrayList list = new ArrayList();
            list.Add(34);
            // list.Add(77.54333);
            list.Add(true);
            list.Add(8);
            list.Add("fnkjgkjdbgkjdf");

            bool obj1 = (bool)list[1];
            
            if(obj1 == true)
            {

            }

            // GENERICS
            IEnumerable<int> interfaccia;
            List<int> elencoNumeri = new List<int>();
            elencoNumeri.Add(7);
            elencoNumeri.AddRange(new List<int>() { 1, 6, 7 });
            esiste = elencoNumeri.Contains(6);

            List<double> altezze = new List<double>();
            List<Persona> partecipanti = new List<Persona>();
            partecipanti.Add(new Persona());

            Dictionary<string, Persona> anagrafe = new Dictionary<string, Persona>();
            anagrafe.Add("xyz", new Persona());
            // anagrafe.Add(555, true);
        }

        private static void P1_SalvataggioFallito(object sender, SalvataggioFallitoEventArgs e)
        {
            Persona p = sender as Persona;
            Console.WriteLine($"Impossibile salvare {p.Nome} {p.Cognome}");
        }
    }
}