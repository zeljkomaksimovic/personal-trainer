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
    public partial class Dnevnik : Page
    {
        private Sql sql;
        private List<FoodCategory> listaKategorija;
        private List<Namirnice> listaNamirnica;
        private string selektovanaNamirnica;
        private string selektovanObrok;
        //private string selektovanaNamirnicaIzPretrage;
        Korisnik korisnik;
        public Dnevnik(Korisnik korisnik, string selektovanaNamirnicaIzPretrage)
        {
            InitializeComponent();
            sql = new Sql();
            selektovanaNamirnica = "";
            selektovanObrok = "";
            selektovanaNamirnica = selektovanaNamirnicaIzPretrage;
            this.korisnik = korisnik;
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            txtGrami.Visibility = Visibility.Hidden;
            lblGrami.Visibility = Visibility.Hidden;
            btnDodaj.Visibility = Visibility.Hidden;
            listaKategorija = sql.FoodCategoryList();
            foreach (FoodCategory fc in listaKategorija) { cbKategorije.Items.Add(fc.nazivKategorije); }
            if (!selektovanaNamirnica.Equals(""))
            {
                listaNamirnica = sql.MenuNutritionData();               
                lbListaNamirnica.SelectionChanged -= lbListaNamirnica_SelectionChanged;
                lbListaNamirnica.Items.Add(selektovanaNamirnica);
                txtGrami.Visibility = Visibility.Visible;
                lblGrami.Visibility = Visibility.Visible;
                btnDodaj.Visibility = Visibility.Visible;
            }
            Osvezi();
        }

        private void Osvezi()
        {
            List<Obroci> listaDnevnogUnosaNamirnica = sql.UserNutritionInfo(korisnik.id);
            DateTime danasnjiDatum = DateTime.Today;
            foreach (Obroci o in listaDnevnogUnosaNamirnica.ToList())
            {
                if (o.vremeUnosa.Date != danasnjiDatum.Date)
                {
                    listaDnevnogUnosaNamirnica.Remove(o);
                    continue;
                }
                if (o.obrok == "Dorucak")
                {
                    lbDorucak.Items.Add(o);
                }
                else if (o.obrok == "Rucak")
                {
                    lbRucak.Items.Add(o);
                }
                else 
                {
                    lbVecera.Items.Add(o);
                }
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idOdabraneKategorije = 0;
            //POPRAVI -----
            if (lbListaNamirnica.Items.Count > 0)
            {
                //lbListaNamirnica.SelectedItem = -1;
               // selektovanaNamirnica = "";
                lbListaNamirnica.Items.Clear();
            }
                 
            foreach (FoodCategory fc in listaKategorija)
            {
                if (fc.nazivKategorije.Equals(cbKategorije.SelectedItem.ToString()))
                {
                    idOdabraneKategorije = fc.id;
                }
            }

            listaNamirnica = sql.ListBoxPopulate(idOdabraneKategorije);
            foreach (Namirnice n in listaNamirnica)
            {
                lbListaNamirnica.Items.Add(n.foodName);
            }
            lbListaNamirnica.SelectionChanged += lbListaNamirnica_SelectionChanged;
        }

        private void lbListaNamirnica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbListaNamirnica.SelectionChanged -= lbListaNamirnica_SelectionChanged;
            txtGrami.Visibility = Visibility.Visible;
            lblGrami.Visibility = Visibility.Visible;
            btnDodaj.Visibility = Visibility.Visible;
            selektovanaNamirnica = lbListaNamirnica.SelectedItem.ToString();    
                 
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            double grami = 0;           
            if (chckDorucak.IsChecked == false && chckRucak.IsChecked == false && chckVecera.IsChecked == false) { MessageBox.Show("Selektujte Obrok"); return; }
            if (txtGrami.Text.Trim().Length == 0) { MessageBox.Show("Unesite Visinu"); return; }
            else if (!double.TryParse(txtGrami.Text, out grami)) { MessageBox.Show("Unesite Visinu u pravilnom formatu"); return; }
            foreach (Namirnice n in listaNamirnica)
            {
                if (n.foodName.Equals(selektovanaNamirnica))
                {

                    n.kj = ((double.Parse(txtGrami.Text) / 100) * n.kj);
                    n.kcal = ((double.Parse(txtGrami.Text) / 100) * n.kcal);
                    n.protein = ((double.Parse(txtGrami.Text) / 100) * n.protein);
                    n.uh = ((double.Parse(txtGrami.Text) / 100) * n.uh);
                    n.masti = ((double.Parse(txtGrami.Text) / 100) * n.masti);
                    Obroci obrok = new Obroci(0, korisnik.id, n.foodName, n.kj, n.kcal, n.protein, n.uh, n.masti, selektovanObrok, double.Parse(txtGrami.Text), DateTime.Now);
                    sql.UserMealInsert(obrok);
                    break;
                }
            }
            lbDorucak.Items.Clear();
            lbRucak.Items.Clear();
            lbVecera.Items.Clear();
            Osvezi();
        }

        private void chckDorucak_Checked(object sender, RoutedEventArgs e)
        {
            chckRucak.IsChecked = false;
            chckVecera.IsChecked = false;
            selektovanObrok = "Dorucak";
        }

        private void chckRucak_Checked(object sender, RoutedEventArgs e)
        {
            chckDorucak.IsChecked = false;
            chckVecera.IsChecked = false;
            selektovanObrok = "Rucak";
        }

        private void chckVecera_Checked(object sender, RoutedEventArgs e)
        {
            chckDorucak.IsChecked = false;
            chckRucak.IsChecked = false;
            selektovanObrok = "Vecera";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            lbListaNamirnica.UnselectAll();
        }
    }
}
