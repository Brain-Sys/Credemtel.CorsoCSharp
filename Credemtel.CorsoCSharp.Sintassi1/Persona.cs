using Credemtel.CorsoCSharp.Sintassi1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credemtel.CorsoCSharp.Sintassi1
{
    // public delegate void SalvataggioFallitoEventHandler(object sender, SalvataggioFallitoEventArgs args);

    public class Persona : DomainObject, IEquatable<Persona>, IComparable,
        IComparable<Persona>, ICloneable<Persona> //, ICloneable
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

        public bool Equals(Persona other)
        {
            return this.ID == other.ID;
        }

        // SENZA Generics (vecchio)
        public int CompareTo(object obj)
        {
            //  0 == i due oggetti sono uguali
            //  1 == this è > obj
            // -1 == obj è > this
            Persona p = (Persona)obj;
            return p.Cognome.CompareTo(this.Cognome);
        }

        public int CompareTo(Persona other)
        {
            return other.Cognome.CompareTo(this.Cognome);
        }

        // Implementazione implicita
        //public object Clone()
        //{
        //    Persona clone = new Persona();
        //    clone.ID = this.ID;
        //    clone.Nome = this.Nome;
        //    clone.Cognome = this.Cognome;

        //    return clone;
        //}

        // Implementazione esplicita
        public Persona Clone()
        {
            Persona clone = new Persona();
            clone.ID = this.ID;
            clone.Nome = this.Nome;
            clone.Cognome = this.Cognome;

            return clone;
        }
    }

    public class SalvataggioFallitoEventArgs : EventArgs
    {
        public string ServerName { get; set; }
        public string CurrentUser { get; set; }
    }
}