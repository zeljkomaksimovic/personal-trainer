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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zeljkonrt7514_diplomski
{
    /// <summary>
    /// Interaction logic for Trening.xaml
    /// </summary>
    public partial class Trening : Page
    {
        private Sql sql;
        private List<ListBox> listaListBox;
        private int vrednost;
        private int brojac;
        private int brojacNedelja;
        public Trening()
        {
            InitializeComponent();
            sql = new Sql();
            listaListBox = new List<ListBox>();
            vrednost = 0;
            brojac = 0;
            brojacNedelja = 1;
        }
        public void Load(object sender, RoutedEventArgs e)
        {
            listaListBox.Add(lbPrvaTabela);
            listaListBox.Add(lbDrugaTabela);
            listaListBox.Add(lbTrecaTabela);
            listaListBox.Add(lbCetvrtaTabela);
            listaListBox.Add(lbPetaTabela);
            listaListBox.Add(lbSestaTabela);
            listaListBox.Add(lbSedmaTabela);
            Osvezi();
        }
        private void Osvezi()
        {
            List<Treninzi> listaTreninga = new List<Treninzi>();
            listaTreninga = sql.NapuniTreningTabele();
            string[] nedelja = lblNedelja.Content.ToString().Split(':');

            foreach (ListBox lb in listaListBox)
            {
                if (lb.Items.Count > 0)
                {
                    lb.Items.Clear();
                }
            }
            foreach (Treninzi t in listaTreninga)
            {
                #region GRUDI
                if (t.grupaMisica.Equals("Grudi") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 1)
                {
                    lbPrvaTabela.Items.Add(t);
                    lblMisicnaGrupaPrvaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Grudi") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 2)
                {
                    lbPrvaTabela.Items.Add(t);
                    lblMisicnaGrupaPrvaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Grudi") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 3)
                {
                    t.ponavljanja -= 4;
                    lbPrvaTabela.Items.Add(t);
                    lblMisicnaGrupaPrvaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Grudi") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 4)
                {
                    t.ponavljanja -= 4;
                    lbPrvaTabela.Items.Add(t);
                    lblMisicnaGrupaPrvaTabela.Content = t.grupaMisica;
                }
                #endregion
                #region BICEPS
                else if (t.grupaMisica.Equals("Biceps") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 1)
                {
                    lbDrugaTabela.Items.Add(t);
                    lblMisicnaGrupaDrugaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Biceps") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 2)
                {
                    lbDrugaTabela.Items.Add(t);
                    lblMisicnaGrupaDrugaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Biceps") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 3)
                {
                    t.ponavljanja -= 4;
                    lbDrugaTabela.Items.Add(t);
                    lblMisicnaGrupaDrugaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Biceps") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 4)
                {
                    t.ponavljanja -= 4;
                    lbDrugaTabela.Items.Add(t);
                    lblMisicnaGrupaDrugaTabela.Content = t.grupaMisica;
                }
                #endregion
                #region LEDJA
                else if (t.grupaMisica.Equals("Ledja") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 1)
                {
                    lbTrecaTabela.Items.Add(t);
                    lblMisicnaGrupaTrecaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Ledja") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 2)
                {
                    lbTrecaTabela.Items.Add(t);
                    lblMisicnaGrupaTrecaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Ledja") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 3)
                {
                    t.ponavljanja -= 4;
                    lbTrecaTabela.Items.Add(t);
                    lblMisicnaGrupaTrecaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Ledja") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 4)
                {
                    t.ponavljanja -= 4;
                    lbTrecaTabela.Items.Add(t);
                    lblMisicnaGrupaTrecaTabela.Content = t.grupaMisica;
                }
                #endregion
                #region TRICEPS
                else if (t.grupaMisica.Equals("Triceps") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 1)
                {
                    lbCetvrtaTabela.Items.Add(t);
                    lblMisicnaGrupaCetvrtaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Triceps") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 2)
                {
                    lbCetvrtaTabela.Items.Add(t);
                    lblMisicnaGrupaCetvrtaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Triceps") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 3)
                {
                    t.ponavljanja -= 4;
                    lbCetvrtaTabela.Items.Add(t);
                    lblMisicnaGrupaCetvrtaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Triceps") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 4)
                {
                    t.ponavljanja -= 4;
                    lbCetvrtaTabela.Items.Add(t);
                    lblMisicnaGrupaCetvrtaTabela.Content = t.grupaMisica;
                }

                #endregion
                #region NOGE
                else if (t.grupaMisica.Equals("Noge") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 1)
                {
                    lbPetaTabela.Items.Add(t);
                    lblMisicnaGrupaPetaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Noge") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 2)
                {
                    lbPetaTabela.Items.Add(t);
                    lblMisicnaGrupaPetaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Noge") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 3)
                {
                    t.ponavljanja -= 4;
                    lbPetaTabela.Items.Add(t);
                    lblMisicnaGrupaPetaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Noge") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 4)
                {
                    t.ponavljanja -= 4;
                    lbPetaTabela.Items.Add(t);
                    lblMisicnaGrupaPetaTabela.Content = t.grupaMisica;
                }
                #endregion
                #region RAMENA
                else if (t.grupaMisica.Equals("Ramena") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 1)
                {
                    lbSestaTabela.Items.Add(t);
                    lblMisicnaGrupaSestaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Ramena") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 2)
                {
                    lbSestaTabela.Items.Add(t);
                    lblMisicnaGrupaSestaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Ramena") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 3)
                {
                    t.ponavljanja -= 4;
                    lbSestaTabela.Items.Add(t);
                    lblMisicnaGrupaSestaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Ramena") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 4)
                {
                    t.ponavljanja -= 4;
                    lbSestaTabela.Items.Add(t);
                    lblMisicnaGrupaSestaTabela.Content = t.grupaMisica;
                }
                #endregion
                #region TRBUSNJACI
                else if (t.grupaMisica.Equals("Trbusnjaci") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 1)
                {
                    lbSedmaTabela.Items.Add(t);
                    lblMisicnaGrupaSedmaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Trbusnjaci") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 2)
                {
                    lbSedmaTabela.Items.Add(t);
                    lblMisicnaGrupaSedmaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Trbusnjaci") && t.nedelja == 1 && Int32.Parse(nedelja[1]) == 3)
                {
                    t.ponavljanja -= 4;
                    lbSedmaTabela.Items.Add(t);
                    lblMisicnaGrupaSedmaTabela.Content = t.grupaMisica;
                }
                else if (t.grupaMisica.Equals("Trbusnjaci") && t.nedelja == 2 && Int32.Parse(nedelja[1]) == 4)
                {
                    t.ponavljanja -= 4;
                    lbSedmaTabela.Items.Add(t);
                    lblMisicnaGrupaSedmaTabela.Content = t.grupaMisica;
                }
                #endregion
            }
        }

        private void btnLevaStrelica_Click(object sender, RoutedEventArgs e)
        {
            vrednost += 750;
            brojac--;

            if (brojac == 0)
            {
                btnLevaStrelica.Visibility = Visibility.Hidden;
            }
            else if (brojac == 1)
            {
                btnLevaStrelica.Visibility = Visibility.Visible;
                btnDesnaStrelica.Visibility = Visibility.Visible;
            }

            DoubleAnimation doubleAnimation = new DoubleAnimation();
            PowerEase powerEase = new PowerEase();
            powerEase.EasingMode = EasingMode.EaseInOut;
            powerEase.Power = 10;

            doubleAnimation.To = vrednost;
            doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 700));
            // doubleAnimation.EasingFunction = powerEase;

            Grid1.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid2.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid3.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid4.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid5.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid6.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid7.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
        }

        private void btnDesnaStrelica_Click(object sender, RoutedEventArgs e)
        {
            vrednost -= 750;
            brojac++;
            if (brojac == 3)
            {
                btnDesnaStrelica.Visibility = Visibility.Hidden;
            }
            else if (brojac == 0 || brojac == 1)
            {
                btnLevaStrelica.Visibility = Visibility.Visible;
                btnDesnaStrelica.Visibility = Visibility.Visible;
            }

            DoubleAnimation doubleAnimation = new DoubleAnimation();
            PowerEase powerEase = new PowerEase();
            powerEase.EasingMode = EasingMode.EaseInOut;
            powerEase.Power = 10;

            doubleAnimation.To = vrednost;
            doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 700));
            // doubleAnimation.EasingFunction = powerEase;

            Grid1.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid2.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid3.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid4.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid5.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid6.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
            Grid7.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
        }

        private void btnNedeljaUpArrow_Click(object sender, RoutedEventArgs e)
        {
            brojacNedelja++;
            if (brojacNedelja > 4)
            {
                brojacNedelja = 4;
            }
            lblNedelja.Content = "Nedelja: " + brojacNedelja;
            string[] nedelja = lblNedelja.Content.ToString().Split(':');
            ///// POPRAVI LOGIKU!!!///
            switch (Int32.Parse(nedelja[1]))
            {
                case 1:
                    Osvezi();
                    break;
                case 2:
                    Osvezi();
                    break;
                case 3:
                    Osvezi();
                    break;
                case 4:
                    Osvezi();
                    break;
            }
        }

        private void btnNedeljaDownArrow_Click(object sender, RoutedEventArgs e)
        {
            brojacNedelja--;
            if (brojacNedelja <= 0)
            {
                brojacNedelja = 1;
            }
            lblNedelja.Content = "Nedelja: " + brojacNedelja;
            string[] nedelja = lblNedelja.Content.ToString().Split(':');
            ///// POPRAVI LOGIKU!!!///
            switch (Int32.Parse(nedelja[1]))
            {
                case 1:
                    Osvezi();
                    break;
                case 2:
                    Osvezi();
                    break;
                case 3:
                    Osvezi();
                    break;
                case 4:
                    Osvezi();
                    break;
            }
        }
    }
}
