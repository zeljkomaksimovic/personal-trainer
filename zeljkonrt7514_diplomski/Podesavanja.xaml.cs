using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
//using System.Windows.Shapes;

namespace zeljkonrt7514_diplomski
{
    public partial class Podesavanja : Page
    {
        Korisnik korisnik;
        private int trenutnaTezina;
        private Menu menu = null;
        public Podesavanja(Korisnik korisnik, Menu menu)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            trenutnaTezina = korisnik.tezina;
            this.menu = menu;
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            Osvezi();
        }
        public void Osvezi()
        {
            txtIzmeniUsername.Text = korisnik.username;
            pbIzmeniPassword.Password = korisnik.password;
            txtIzmeniImePrezime.Text = korisnik.imePrezime;
            txtIzmeniVisinu.Text = korisnik.visina.ToString();
            txtIzmeniTezinu.Text = korisnik.tezina.ToString();
            txtIzmeniGodine.Text = korisnik.godine.ToString();
            cbAktivnost.Items.Add("Neaktivni (Vecinu dana provodite sedeci)");
            cbAktivnost.Items.Add("Malo aktivni (Vezbanje laganim intenzitetom 1-3 puta nedeljno)");
            cbAktivnost.Items.Add("Umereno aktivni (Vezbanje 3-5 puta nedeljno umerenim intenzitetom)");
            cbAktivnost.Items.Add("Izrazito aktivni (Trening visokim intenzitetom 6-7 puta nedeljno)");
            cbAktivnost.Items.Add("Ekstremno aktivni (Svakodnevno vezbanje visokim intenzitetom u kombinaciji s teškim fizičkim poslom)");
            cbAktivnost.SelectedValue = korisnik.aktivnost;
            if (korisnik.smanjiKilazu == 1)
            {
                rbSmanjiKilazu.IsChecked = true;
            }
            else
            {
                rbPovecajKilazu.IsChecked = true;
            }
            if (korisnik.pol.Equals("Musko"))
            {
                rbMusko.IsChecked = true;
            }
            else
            {
                rbZensko.IsChecked = true;
            }
        }
        private void btnDodajSliku_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Dodaj Sliku";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string putanjaSlike = openFileDialog.FileName;                  
                string putanjaFoldera = Path.GetFullPath(@"..\..\Image\profile_picture\");
                string nazivSlike = korisnik.id + Path.GetExtension(putanjaSlike);

                if (!Directory.Exists(putanjaFoldera))
                {
                    Directory.CreateDirectory(putanjaFoldera);
                }

                File.Copy(putanjaSlike, putanjaFoldera + nazivSlike, true);
                korisnik.slika = nazivSlike;          
            }
        }
        private void btnSacuvajPromene_Click(object sender, RoutedEventArgs e)
        {
            korisnik.username = txtIzmeniUsername.Text;
            korisnik.password = pbIzmeniPassword.Password;
            korisnik.imePrezime = txtIzmeniImePrezime.Text;
            int cbIndex = cbAktivnost.SelectedIndex;
            int visina = 0;
            int tezina = 0;
            int godine = 0;
            double tdee = 0;

            if (txtIzmeniUsername.Text.Trim().Length == 0 || txtIzmeniUsername.Text == "Username") { MessageBox.Show("Unesite Username"); return; }
            if (pbIzmeniPassword.Password.Trim().Length == 0) { MessageBox.Show("Unesite Password"); return; }
            if (txtIzmeniImePrezime.Text.Trim().Length == 0 || txtIzmeniImePrezime.Text == "Ime i Prezime") { MessageBox.Show("Unesite Im e i Prezime"); return; }
            if (txtIzmeniVisinu.Text.Trim().Length == 0 || txtIzmeniVisinu.Text == "Visina") { MessageBox.Show("Unesite Visinu"); return; }
            else if (!Int32.TryParse(txtIzmeniVisinu.Text, out visina)) { MessageBox.Show("Unesite Visinu u pravilnom formatu"); return; }
            if (txtIzmeniTezinu.Text.Trim().Length == 0 || txtIzmeniTezinu.Text == "Tezina") { MessageBox.Show("Unesite Tezinu"); return; }
            else if (!Int32.TryParse(txtIzmeniTezinu.Text, out tezina)) { MessageBox.Show("Unesite Tezinu u pravilnom formatu"); return; }
            if (txtIzmeniGodine.Text.Trim().Length == 0 || txtIzmeniGodine.Text == "Godine") { MessageBox.Show("Unesite Godine"); return; }
            else if (!Int32.TryParse(txtIzmeniGodine.Text, out godine)) { MessageBox.Show("Unesite Godine u pravilnom formatu"); return; }       
            if (cbAktivnost.SelectedIndex == -1) { MessageBox.Show("Selektujte nivo vase aktivnosti"); return; }          
            if (rbMusko.IsChecked == false && rbZensko.IsChecked == false) { MessageBox.Show("Izaberite Pol"); return; }
            if (rbPovecajKilazu.IsChecked == false && rbSmanjiKilazu.IsChecked == false) { MessageBox.Show("Izaberite Cilj u dostizanju kilaze"); return; }
            korisnik.aktivnost = cbAktivnost.SelectedItem.ToString();
            korisnik.visina = visina;
            korisnik.tezina = tezina;
            korisnik.godine = godine;

            if (rbSmanjiKilazu.IsChecked == true)
            {
                korisnik.smanjiKilazu = 1;
            }
            else
            {
                korisnik.smanjiKilazu = 0;
            }
            if (rbMusko.IsChecked == true)
            {
                korisnik.pol = "Musko";
            }
            else
            {
                korisnik.pol = "Zensko";
            }
            switch (cbIndex)
            {
                case 0:
                    tdee = 1.2;
                    break;
                case 1:
                    tdee = 1.375;
                    break;
                case 2:
                    tdee = 1.55;
                    break;
                case 3:
                    tdee = 1.725;
                    break;
                case 4:
                    tdee = 2;
                    break;
            }

            if (korisnik.pol.Equals("Musko"))
            {
                if (korisnik.smanjiKilazu == 0)
                {
                    korisnik.pdu = (int)(((66 + (13.7 * tezina) + (5 * visina) - (6.8 * godine)) * tdee) * 1.1 + 300);
                }
                else
                {
                    korisnik.pdu = (int)(((66 + (13.7 * tezina) + (5 * visina) - (6.8 * godine)) * tdee) * 1.1 - 300);
                }
            }
            else
            {
                if (korisnik.smanjiKilazu == 0)
                {
                    korisnik.pdu = (int)(((655 + (9.6 * tezina) + (1.8 * visina) - (4.7 * godine)) * tdee) * 1.1 + 300);
                }
                else
                {
                    korisnik.pdu = (int)(((655 + (9.6 * tezina) + (1.8 * visina) - (4.7 * godine)) * tdee) * 1.1 - 300);
                }
            }

            Sql sql = new Sql();
            sql.UpdateUser(korisnik);

            if (trenutnaTezina != tezina)
            {
                TezinaDnevnik tezinaDnevnik = new TezinaDnevnik(1, korisnik.id, korisnik.tezina, DateTime.Now);
                sql.UserWeightDiaryInsert(tezinaDnevnik);
            }

            korisnik = sql.Login(korisnik.username,korisnik.password);
            menu.Osvezi(korisnik);
        } 
    }
}
