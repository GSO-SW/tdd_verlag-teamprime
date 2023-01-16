using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlag
{
    internal class Buch
    {
        private string autor;
        private string titel;
        private int auflage;

        public Buch (string autor, string titel)
        {
            this.autor = autor;
            this.titel = titel;
            this.auflage = 1;
        }

        public Buch(string autor, string titel, int auflage):this(autor,titel)
        {
           
            this.auflage = auflage;
        }

        
    }
}
