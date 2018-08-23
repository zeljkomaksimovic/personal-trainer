using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace zeljkonrt7514_diplomski
{
    public partial class Menu : Page
    {
        private Button lastClickedButton;
        Korisnik korisnik;
        private Sql sql;
        private List<Obroci> listaObroka;
        List<Namirnice> listaNamirnica;
        private MainWindow mainWindow = null;
        public Menu(Korisnik korisnik, MainWindow mainWindow)
        {
            InitializeComponent();
            lastClickedButton = btnPocetna;
            this.korisnik = korisnik;
            sql = new Sql();
            listaObroka = sql.UserNutritionInfo(korisnik.id);
            listaNamirnica = sql.MenuNutritionData();
            this.mainWindow = mainWindow;
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            frmMenu.NavigationService.Navigate(new Pocetna(korisnik));
            Osvezi(korisnik);
            lbRezultatPretrage.Visibility = Visibility.Hidden;
        }

        public void Osvezi(Korisnik korisnik)
        {
            string putanjaFoldera = Path.GetFullPath(@"..\..\Image\profile_picture\");
            if (korisnik.slika != "")
            {
                BitmapImage slika = new BitmapImage();
                slika.BeginInit();
                slika.CacheOption = BitmapCacheOption.Default;
                slika.UriSource = new Uri(putanjaFoldera + korisnik.slika);
                slika.EndInit();
                imgAvatar.Source = slika;
            }
            lblImePrezime.Content = korisnik.imePrezime;
            Console.WriteLine("==== Menu osvezen ====");
        }

        private void menuButtons_Click(object sender, RoutedEventArgs e)
        {
            Style buttonPressedStyle = Application.Current.FindResource("MenuBarPressButtonStyle") as Style;
            Style buttonInactiveStyle = Application.Current.FindResource("MenuBarButtonStyle") as Style;
            Button buttonSender = (Button)sender;

            int buttonTag = Int32.Parse(buttonSender.Tag.ToString());
            lastClickedButton.Style = buttonInactiveStyle;
            buttonSender.Style = buttonPressedStyle;
            lastClickedButton = buttonSender;

            switch (buttonTag)
            {
                case 0:
                    frmMenu.NavigationService.Navigate(new Pocetna(korisnik));
                    break;
                case 1:
                    string selektovanaNamirnicaIzPretrage = "";
                    frmMenu.NavigationService.Navigate(new Dnevnik(korisnik, selektovanaNamirnicaIzPretrage));
                    break;
                case 2:
                    frmMenu.NavigationService.Navigate(new Trening());
                    break;
                case 3:
                    frmMenu.NavigationService.Navigate(new Napredak(korisnik));
                    break;
                case 4:
                    frmMenu.NavigationService.Navigate(new Podesavanja(korisnik, this));
                    break;
                case 5:
                    this.mainWindow.MainWindowFrame = false;
                    break;
            }
        }

        private void txtPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!txtPretraga.Text.Equals("Pretrazi") && !txtPretraga.Text.Equals(""))
            {
                lbRezultatPretrage.Items.Clear();
                lbRezultatPretrage.SelectionChanged += lbRezultatPretrage_SelectionChanged;
                int brojKaraktera = txtPretraga.Text.Length;
                foreach (Namirnice n in listaNamirnica)
                {
                    if (n.foodName.Length >= brojKaraktera && n.foodName.Substring(0, brojKaraktera).ToLower().Equals(txtPretraga.Text.ToLower()))
                    {
                        lbRezultatPretrage.Items.Add(n.foodName);
                        lbRezultatPretrage.Visibility = Visibility.Visible;
                    }
                }
            }
            else if (txtPretraga.Text.Equals(""))
            {
                lbRezultatPretrage.Visibility = Visibility.Hidden;
            }
        }

        private void lbRezultatPretrage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbRezultatPretrage.SelectionChanged -= lbRezultatPretrage_SelectionChanged;

            string selektovanaNamirnica = lbRezultatPretrage.SelectedItem.ToString();
            lbRezultatPretrage.Visibility = Visibility.Hidden;
            frmMenu.NavigationService.Navigate(new Dnevnik(korisnik, selektovanaNamirnica));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            lblImePrezime.Content = korisnik.imePrezime;
        }
    }
}
