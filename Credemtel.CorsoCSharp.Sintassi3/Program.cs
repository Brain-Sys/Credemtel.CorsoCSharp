﻿using Credemtel.CorsoCSharp.Interfaces;
using Credemtel.CorsoCSharp.Repository.ExtensionMethods;
using Credemtel.CorsoCSharp.Repository.SQLite;
using Credemtel.CorsoCSharp.Sintassi3.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi3
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            //WebClient client = new WebClient();
            ////string xml1 = client.DownloadString("");
            //client.DownloadStringCompleted += Client_DownloadStringCompleted;
            //client.DownloadStringAsync(new Uri("http://www.ilcittadino.it"));
            test1();

            //ThreadPool.QueueUserWorkItem(
            //    new WaitCallback((o) => { test2(); }));

            // Task.Run(() => test2());
            Task t1 = new Task(() => test2());
            // t1.Status = TaskStatus.
            // t1.RunSynchronously();   // Gira nel thread della UI
            t1.Start();
            t1.ContinueWith((taskAppenaConcluso) => {
                if (taskAppenaConcluso.Exception == null)
                {
                    test1();
                }
            });

            Console.ReadLine();

            List<string> marche = new List<string>() { "Honda", "Fiat", "Citroen" };
            List<MarcaAuto> marche2 = new List<MarcaAuto>()
            {
                new MarcaAuto(){ Nome = "Honda" },
                new MarcaAuto(){ Nome = "BMW" },
                new MarcaAuto(){ Nome = "Audi" }
            };

            DirectoryInfo di = new DirectoryInfo(@"Z:\Database");
            DirectoryInfo[] dirs = di.GetDirectories();

            var lista1 = marche.Join(dirs, nm => nm, dir => dir.Name,
                (ogg1, ogg2) => new
                {
                    NomeMarca = ogg1,
                    NumeroPreventivi = ogg2.GetFiles("*.pdf")
                }).ToList();

            var lista2 = marche2.Join(dirs, nm => nm.Nome, dir => dir.Name,
                (ogg1, ogg2) => new
                {
                    NomeMarca = ogg1.Nome,
                    NumeroPreventivi = ogg2.GetFiles("*.pdf")
                }).ToList();

            // Dim abc as new XDocument = <tag></tag>

            di = new DirectoryInfo(@"C:\Windows\System32");
            FileInfo[] files = di.GetFiles("*.*");

            Func<FileInfo, bool> puntatore = ricerca;
            string filtro = ".dll";

            var soloDll1 = files
                .Where(f => f.IsBigMoreThan50K())
                .Select(f => new SmallFileInfo(f.Name));

            List<FileInfo> soloDll3 = files
                .Where(f => f.LastAccessTime.Year == 2017)
                //.Where(f => !f.DirectoryName.Contains("Temp"))
                .Where(f => f.LastAccessTime.Hour == 12)
                // .Take(200)
                .OrderByDescending(f => f.Name)
                .ToList();

            if (DateTime.Now.Month == 6)
            {
                soloDll1 = soloDll1.OrderBy(f => f.NOMEFILE);
            }

            soloDll1 = soloDll1.Take(100);


            var eseguoSulSerio = soloDll1.ToList();


            var soloDll2 = from f in files where f.IsBigMoreThan50K() && f.Extension == ".dll" select f;

            foreach (var item in soloDll1)
            {
                Console.WriteLine(item.NOMEFILE);
            }

            var x = 45;
            var pari = x.IsPari();

            double? numero;
            numero = 3433.857439853;
            numero++;

            if (numero > 6765.222)
            {
                numero = null;
            }

            short? u = null;
            short valore = u.GetValueOrDefault();

            //if (u.HasValue)
            //{
            //    return u.Value;
            //}
            //else
            //{
            //    short s = default(short);
            //}

            string fiscalCode = "DMNLRG76B28I274H";
            bool ok1 = fiscalCode.IsCorrectFiscalCode();
            bool ok2 = fiscalCode.IsCorrectFiscalCode("us");
            bool ok3 = fiscalCode.IsCorrectFiscalCode("fr");
            int anno = fiscalCode.GetBirthYear();

            var pippo = fiscalCode
                .ToUpper()
                .Substring(0, 1)[0]
                == 'a';

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

        //private static void Client_DownloadStringCompleted(object sender,
        //    DownloadStringCompletedEventArgs e)
        //{
        //    int id = Thread.CurrentThread.ManagedThreadId;
        //    string xml = e.Result;
        //    // this.NomeProgressBar.Value++;
        //}

        private static bool ricerca(FileInfo fi)
        {
            return fi.Extension == ".dll";
        }

        private async static void test1()
        {
            HttpClient client = new HttpClient();
            string xyz = await client.GetStringAsync
                ("http://www.ilcittadino.it");
        }

        private async static Task<int> countTagAsync(string url, string tagName)
        {
            HttpClient client = new HttpClient();
            string html = await client.GetStringAsync(url);

            return new Random().Next(0, 900);
        }

        public static void test2()
        {
            while (true)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            }
        }
    }

    class SmallFileInfo
    {
        private string name;

        public SmallFileInfo(string name)
        {
            this.name = name;
        }

        public string NOMEFILE { get; set; }
    }

    class MarcaAuto
    {
        public string Nome { get; set; }
    }
}