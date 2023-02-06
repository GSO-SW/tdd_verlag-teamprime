using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlag
{
    public class Buch
    {
        private string autor;
        private string titel;
        private int auflage;
        public string ISBN;

        public Buch (string autor, string titel, string ISBN)
        {
            this.autor = autor;
            this.titel = titel;
            this.auflage = 1;
            this.ISBN = ISBN;
        }

        public Buch(string autor, string titel, int auflage) : this(autor, titel, ISBN)
        {
            this.auflage = auflage;
        }

        public int Auflage
        {
            get { return auflage; }
            set { auflage = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public string Titel
        {
            get { return titel; }
            set { titel = value; }
        }
    }
}
