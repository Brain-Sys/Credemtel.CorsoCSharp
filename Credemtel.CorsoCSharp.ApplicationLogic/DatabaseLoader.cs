using Credemtel.CorsoCSharp.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Credemtel.CorsoCSharp.ApplicationLogic
{
    public class DatabaseLoader
    {
        public Action DipendeDaOS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="InvalidPinException">Ho inserito il pin non valido</exception>
        /// <see cref="http://www.google.com?q=xyz">KB:459901 - help su come funziona il pin</see>
        /// <param name="pin"></param>
        public void Load(int pin)
        {
            if (pin != 12345)
            {
                InvalidPinException ex = new InvalidPinException($"Il pin {pin} non è valido...");
                throw ex;
            }

            // Carico da DB
            try
            {
                HttpClient client = new HttpClient();
                var xml = client.GetStringAsync("http://www.google.com").Result;
            }
            catch (AggregateException ex)
            {
                // Log

                throw new CredemtelDatabaseException("Database corrotto e/o non trovato", ex.InnerException)
                {
                    ServerName = "server",
                    DBSource = "db_source"
                };
            }
        }

        public void Save()
        {
            this.DipendeDaOS.Invoke();
        }
    }
}