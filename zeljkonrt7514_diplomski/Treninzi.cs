using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeljkonrt7514_diplomski
{
    class Treninzi
    {
        public int id { get; set; }
        public string nazivVezbe { get; set; }
        public int kategorijaVezbe { get; set; }
        public int serije { get; set; }
        public int ponavljanja { get; set; }
        public string grupaMisica { get; set; }
        public int nedelja { get; set; }

        public Treninzi(int id, string nazivVezbe, int kategorijaVezbe, int serije, int ponavljanja, string grupaMisica, int nedelja)
        {
            this.id = id;
            this.nazivVezbe = nazivVezbe;
            this.kategorijaVezbe = kategorijaVezbe;
            this.serije = serije;
            this.ponavljanja = ponavljanja;
            this.grupaMisica = grupaMisica;
            this.nedelja = nedelja;
        }

        public override string ToString()
        {
            return this.nazivVezbe + " " + this.serije + " " + this.ponavljanja + " " + this.nedelja;
        }
    }
}
