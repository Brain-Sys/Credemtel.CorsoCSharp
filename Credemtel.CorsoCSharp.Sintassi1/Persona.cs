using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi1
{
    // public delegate void SalvataggioFallitoEventHandler(object sender, SalvataggioFallitoEventArgs args);

    public class Persona
    {
        // Dichiarazione di un evento
        public event EventHandler<SalvataggioFallitoEventArgs> SalvataggioFallito;

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public void Salva()
        {
            if (this.ID == 0)
            {
                var args = new SalvataggioFallitoEventArgs();
                args.ServerName = "192.168.2.188";
                args.CurrentUser = "igor.damiani001";

                if (this.SalvataggioFallito != null)
                {
                    this.SalvataggioFallito(this, args);
                }
            }

            // Dovrei procedere al salvataggio...
        }
    }

    public class SalvataggioFallitoEventArgs : EventArgs
    {
        public string ServerName { get; set; }
        public string CurrentUser { get; set; }
    }
}