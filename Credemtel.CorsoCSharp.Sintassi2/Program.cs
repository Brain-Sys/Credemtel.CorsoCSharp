using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi2
{
    class Program
    {
        static void Main(string[] args)
        {
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

        static void metodoComplesso(bool v1, DateTime v2, List<string> v3, StringBuilder v4)
        {

        }
    }
}