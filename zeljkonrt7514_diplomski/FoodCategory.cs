using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeljkonrt7514_diplomski
{
    class FoodCategory
    {
        public int id { get; set; }
        public string nazivKategorije { get; set; }

        public FoodCategory(int id, string nazivKategorije)
        {
            this.id = id;
            this.nazivKategorije = nazivKategorije;
        }
    }
}
