using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeljkonrt7514_diplomski
{
    class TezinaDnevnik
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int tezina { get; set; }
        public DateTime vremeUnosa { get; set; }

        public TezinaDnevnik(int id, int userId, int tezina, DateTime vremeUnosa)
        {
            this.id = id;
            this.userId = userId;
            this.tezina = tezina;
            this.vremeUnosa = vremeUnosa;
        }

        public override string ToString()
        {
            return this.id + "|" + this.userId + "|" + this.tezina + "|" + this.vremeUnosa;
        }
    }
}
