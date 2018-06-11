using Credemtel.CorsoCSharp.ApplicationLogic;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi2
{
    class Program
    {
        static void Main(string[] args)
        {
            Action a1 = new Action(() => { });
            Action<bool> a2 = new Action<bool>((b) => {
                if (b == true) writeLog();
            });

            Func<int, int> f3 = new Func<int, int>((int pippo) => {
                return pippo * 4;
            });

            Func<Uri, int, int> f4 = new Func<Uri, int, int>((url, number) => {
                HttpClient client = new HttpClient();
                var bytes = client.GetByteArrayAsync(url).Result;
                return bytes.Length + number;
            });

            f4.Invoke(new Uri("http://www.google.com"), 890);

            Func<List<DateTime>> x1 = getDates;
            List<DateTime> date = x1();

            Func<int, int, int, long> funzione = bigNumbers;
            var y = funzione(53456734, 9000, 46237462);


            DatabaseLoader loader = new DatabaseLoader();
            loader.DipendeDaOS = new Action(salvataggio);

            string[] linee = new string[5];

            Action<int, int> puntatore = null;

            foreach (var item in linee)
            {
                if (item.StartsWith("S;"))
                {
                    puntatore = somma;
                }
                else if (item.StartsWith("M;"))
                {
                    puntatore = moltiplicazione;
                }

                puntatore(5, 6);
            }

            Action<bool, DateTime, List<string>, StringBuilder> funz = metodoComplesso;
            funz(true, DateTime.Now, null, new StringBuilder());


            Action<int, double> action = new Action<int, double>(task);
            action.Invoke(4, 9.2523);

            //Action funz1 = new Action(writeLog);
            Action funz1 = writeLog;
            Action funz2 = new Action(openWindow);

            Action funz3 = funz1 + funz2 + funz2 + funz2 + funz1;
            //Delegate funz3 = Action.Combine(new Delegate[] { funz1, funz2 });
            funz3.Invoke();

            Action todo = null;

            if (DateTime.Now.Month == 6)
                todo = writeLog;
            else
                todo = openWindow;

            // CLR
            // DLR 
            //dynamic x = new ExpandoObject();
            //x.Surname = "";
            //Console.WriteLine(x.FiscalCode);

            // todo.Invoke();
            //funz3.DynamicInvoke(new AsyncCallback(hoFinito), 1);
            //funz3.BeginInvoke(new AsyncCallback(hoFinito), 2);
            //funz3.BeginInvoke(new AsyncCallback(hoFinito), 3);

            Console.ReadLine();
        }

        private static long bigNumbers(int x, int y, int z)
        {
            return x * y * z;
        }

        private static void salvataggio()
        {
            
        }

        static void writeLog()
        {
            Console.WriteLine("writeLog");
        }

        static void openWindow()
        {
            Console.WriteLine("openWindow");
        }

        static void task(int x, double y)
        {
            Console.WriteLine($"Il doppio di {x} è {x * 2}");
            Console.WriteLine($"Il doppio di {y} è {y * 2}");
        }

        static void somma(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void moltiplicazione(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        static void hoFinito(IAsyncResult result)
        {
            int v = (int)result.AsyncState;
            bool sync = result.CompletedSynchronously;
        }

        static List<DateTime> getDates()
        {
            return new List<DateTime>();
        }

        static void metodoComplesso(bool v1, DateTime v2, List<string> v3, StringBuilder v4)
        {

        }
    }
}