using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zeljkonrt7514_diplomski
{
    /// <summary>
    /// Interaction logic for Pocetna.xaml
    /// </summary>
    public partial class Pocetna : Page
    {
        Korisnik korisnik;
        private Sql sql;
        public Pocetna(Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            sql = new Sql();
        }

        public void Load(object sender, RoutedEventArgs e)
        {
            List<Obroci> listaObroka = sql.UserNutritionInfo(korisnik.id);
            DateTime danasnjiDatum = DateTime.Today;
            foreach (Obroci o in listaObroka.ToList())
            {
                Console.WriteLine(o.vremeUnosa.Date + " | " + danasnjiDatum.Date);
                if (!o.vremeUnosa.Date.Equals(danasnjiDatum.Date))
                {
                    listaObroka.Remove(o);                 
                }
            }

            double kolicinaUnetihKalorija = 0;
            double zbirPrUhMa = 0;
            double zbirProteina = 0;
            double zbirUh = 0;
            double zbirMasti = 0;
            
            foreach (Obroci o in listaObroka)
            {
                kolicinaUnetihKalorija += o.kcal;
            }

            foreach (Obroci o in listaObroka)
            {
                zbirPrUhMa += Math.Round(o.protein + o.uh + o.masti, 0);
                zbirProteina += Math.Round(o.protein, 0);
                zbirUh += Math.Round(o.uh, 0);
                zbirMasti += Math.Round(o.masti, 0);
            }

            lblKalorije.Content = korisnik.pdu - kolicinaUnetihKalorija;

            double postotakKalorije = (100 * kolicinaUnetihKalorija) / korisnik.pdu;
            rectPostotak.Width = postotakKalorije * 6;

            double postotakProteina = 0;
            double postotakUh = 0;
            double postotakMasti = 0;

            if (zbirPrUhMa != 0)
            {
                postotakProteina = Math.Round((100 * zbirProteina) / zbirPrUhMa, 0);
                postotakUh = Math.Round((100 * zbirUh) / zbirPrUhMa, 0);
                postotakMasti = Math.Round((100 * zbirMasti) / zbirPrUhMa, 0);
            }
            
            lblProteiniPrikaz.Content = postotakProteina + " %";
            lblUhPrikaz.Content = postotakUh + " %";
            lblMastiPrikaz.Content = postotakMasti + " %";

            lblProteiniPrikazGrami.Content = zbirProteina + " g";
            lblUhPrikazGrami.Content = zbirUh + " g";
            lblMastiPrikazGrami.Content = zbirMasti + " g";

            rectProtein.Width = postotakProteina * 1.5;
            rectUh.Width = postotakUh * 1.5;
            rectMasti.Width = postotakMasti * 1.5;

            lblUnetoKolicina.Content = kolicinaUnetihKalorija;
            lblUkupnoKolicina.Content = korisnik.pdu;
        }
    }
}
