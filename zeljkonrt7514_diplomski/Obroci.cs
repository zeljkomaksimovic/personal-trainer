using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeljkonrt7514_diplomski
{
    class Obroci
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string foodName { get; set; }
        public double kj { get; set; }
        public double kcal { get; set; }
        public double protein { get; set; }
        public double uh { get; set; }
        public double masti { get; set; }
        public string obrok { get; set; }
        public double kolicina { get; set; }
        public DateTime vremeUnosa { get; set; }
        public Obroci(int id, int userId, string foodName, double kj, double kcal, double protein, double uh, double masti, string obrok, double kolicina, DateTime vremeUnosa)
        {
            this.id = id;
            this.userId = userId;
            this.foodName = foodName;
            this.kj = kj;
            this.kcal = kcal;
            this.protein = protein;
            this.uh = uh;
            this.masti = masti;
            this.obrok = obrok;
            this.kolicina = kolicina;
            this.vremeUnosa = vremeUnosa;
        }
        public override string ToString()
        {
            return this.id + "|" + this.userId + "|" + this.userId + "|" + this.foodName + "|" + this.kj + "|" + this.kcal + "|" + this.protein + "|" + this.uh + "|" + this.masti + " | " + this.vremeUnosa;
        }
    }
}
