using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeljkonrt7514_diplomski
{
    class Namirnice
    {
        public int id{get; set;}
        public int categoryId { get; set; }
        public string foodName { get; set; }
        public double kj { get; set; }
        public double kcal { get; set; }
        public double protein { get; set; }
        public double uh { get; set; }
        public double masti { get; set; }
        public Namirnice(int id, int categoryId, string foodName, double kj, double kcal, double protein, double uh, double masti)
        {
            this.id = id;
            this.categoryId = categoryId;
            this.foodName = foodName;
            this.kj = kj;
            this.kcal = kcal;
            this.protein = protein;
            this.uh = uh;
            this.masti = masti;
        }
        public override string ToString()
        {
            return this.id + "|" + this.categoryId + "|" + this.foodName + "|" + this.kj + "|" + this.kcal + "|" + this.protein + "|" + this.uh + "|" + this.masti;
        }
    }
}
