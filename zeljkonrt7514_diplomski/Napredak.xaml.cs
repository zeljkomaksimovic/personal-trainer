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
    public partial class Napredak : Page
    {
        Korisnik korisnik;
        private Sql sql;
        public Napredak(Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            sql = new Sql();
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            List<TezinaDnevnik> listaTezinaDnevnik = sql.UserWeightDiarySelect(korisnik.id);
            int brojElemenataUListi = listaTezinaDnevnik.Count;
            if (brojElemenataUListi >= 4)
            {
                for (int i = brojElemenataUListi - 4; i < brojElemenataUListi; i++)
                {
                    string vremeUnosa = listaTezinaDnevnik[i].vremeUnosa.ToShortDateString();
                    lbGrafikKilaza.Items.Add(listaTezinaDnevnik[i]);
                    lbGrafikDatum.Items.Add(vremeUnosa);
                }
            }
            else if (brojElemenataUListi < 4)
            {
                foreach (TezinaDnevnik tezinaDnevnik in listaTezinaDnevnik)
                {
                    string vremeUnosa = tezinaDnevnik.vremeUnosa.ToShortDateString();
                    lbGrafikKilaza.Items.Add(tezinaDnevnik);
                    lbGrafikDatum.Items.Add(vremeUnosa);
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<object> listaobjekata = new List<object>();
            listaobjekata.Add(lblDanas);
            listaobjekata.Add(gridNapredak);
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(this, "Napredak");
        }
    }
}
