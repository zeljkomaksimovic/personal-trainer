using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace zeljkonrt7514_diplomski
{
    public partial class MainWindow : Window
    {
        private string txtBoxText;
        public static bool OcistiFrame = false;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        public MainWindow()
        {
            InitializeComponent();
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon(@"..\..\Image\tray_ico.ico");
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick +=
            delegate (object sender, EventArgs args)
            {
                this.Show();
                this.WindowState = WindowState.Normal;
            };
        }

        public void Load(object sender, RoutedEventArgs e)
        {
            cbAktivnost.Items.Add("Neaktivni (Vecinu dana provodite sedeci)");
            cbAktivnost.Items.Add("Malo aktivni (Vezbanje laganim intenzitetom 1-3 puta nedeljno)");
            cbAktivnost.Items.Add("Umereno aktivni (Vezbanje 3-5 puta nedeljno umerenim intenzitetom)");
            cbAktivnost.Items.Add("Izrazito aktivni (Trening visokim intenzitetom 6-7 puta nedeljno)");
            cbAktivnost.Items.Add("Ekstremno aktivni (Svakodnevno vezbanje visokim intenzitetom u kombinaciji s teškim fizičkim poslom)");
        }

        public bool MainWindowFrame
        {
            set { frmMain.Content = null; }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                this.Hide();
            base.OnStateChanged(e);
        }
        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            switch (tb.Name)
            {
                case "txtUsernameSingUp":
                case "txtUsername":
                    tb.Text = string.Empty;
                    txtBoxText = "Username";
                    break;
                case "txtPassword":
                    tb.Visibility = Visibility.Hidden;
                    pbPassword.Visibility = Visibility.Visible;
                    pbPassword.Focus();
                    tb.Text = string.Empty;
                    txtBoxText = "Password";
                    break;
                case "txtPasswordSingUp":
                    tb.Visibility = Visibility.Hidden;
                    pbPasswordSingUp.Visibility = Visibility.Visible;
                    pbPasswordSingUp.Focus();
                    tb.Text = string.Empty;
                    txtBoxText = "Password";
                    break;
                case "txtImePrezime":
                    tb.Text = string.Empty;
                    txtBoxText = "Ime i Prezime";
                    break;
                case "txtVisina":
                    tb.Text = string.Empty;
                    txtBoxText = "Visina";
                    break;
                case "txtTezina":
                    tb.Text = string.Empty;
                    txtBoxText = "Tezina";
                    break;
                case "txtGodine":
                    tb.Text = string.Empty;
                    txtBoxText = "Godine";
                    break;
            }
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == string.Empty) { tb.Text = txtBoxText; }
        }

        private void pbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = (PasswordBox)sender;
            if (pb.Name.Equals("pbPasswordSingUp") && pb.Password == string.Empty)
            {
                pb.Visibility = Visibility.Hidden;
                txtPasswordSingUp.Visibility = Visibility.Visible;
                txtPasswordSingUp.Text = "Password";
            }
            else if (pb.Name.Equals("pbPassword") && pb.Password == string.Empty)
            {
                pb.Visibility = Visibility.Hidden;
                txtPassword.Visibility = Visibility.Visible;
                txtPassword.Text = "Password";
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Trim().Length == 0 || txtUsername.Text == "Username") { MessageBox.Show("Unesite Username"); return; }
            if (pbPassword.Password.Trim().Length == 0) { MessageBox.Show("Unesite Password"); return; }
            Sql sql = new Sql();
            Korisnik korisnik = sql.Login(txtUsername.Text, pbPassword.Password);
            if (korisnik == null) { MessageBox.Show("Pogresan Username ili Password"); return; }
            if (korisnik != null && txtUsername.Text != korisnik.username || txtPassword.Text.Equals(korisnik.password)) { MessageBox.Show("Pogresan Username ili Password"); return; }
            frmMain.NavigationService.Navigate(new Menu(korisnik, this));
        }

        private void btnRegisterSingUp_Click(object sender, RoutedEventArgs e)
        {
            int cbIndex = cbAktivnost.SelectedIndex;
            double tdee = 0;
            string pol = "Musko";
            int smanjiKilazu = 0;
            int pdu = 0;
            string username = txtUsernameSingUp.Text;
            string password = pbPasswordSingUp.Password;
            string imePrezime = txtImePrezime.Text;
            int visina = 0;
            int tezina = 0;
            int godine = 0;

            if (txtUsernameSingUp.Text.Trim().Length == 0 || txtUsernameSingUp.Text == "Username") { MessageBox.Show("Unesite Username"); return; }
            if (pbPasswordSingUp.Password.Trim().Length == 0) { MessageBox.Show("Unesite Password"); return; }
            if (txtImePrezime.Text.Trim().Length == 0 || txtImePrezime.Text == "Ime i Prezime") { MessageBox.Show("Unesite Ime i Prezime"); return; }
            if (txtVisina.Text.Trim().Length == 0 || txtVisina.Text == "Visina") { MessageBox.Show("Unesite Visinu"); return; }
            else if (!Int32.TryParse(txtVisina.Text, out visina)) { MessageBox.Show("Unesite Visinu u pravilnom formatu"); return; }
            if (txtTezina.Text.Trim().Length == 0 || txtTezina.Text == "Tezina") { MessageBox.Show("Unesite Tezinu"); return; }
            else if (!Int32.TryParse(txtTezina.Text, out tezina)) { MessageBox.Show("Unesite Tezinu u pravilnom formatu"); return; }
            if (txtGodine.Text.Trim().Length == 0 || txtGodine.Text == "Godine") { MessageBox.Show("Unesite Godine"); return; }
            else if (!Int32.TryParse(txtGodine.Text, out godine)) { MessageBox.Show("Unesite Godine u pravilnom formatu"); return; }
            if (cbAktivnost.SelectedIndex == -1) { MessageBox.Show("Selektujte nivo vase aktivnosti"); return; }
            string aktivnost = cbAktivnost.SelectedItem.ToString();
            if (rbMusko.IsChecked == false && rbZensko.IsChecked == false) { MessageBox.Show("Izaberite Pol"); return; }
            if (rbPovecaj.IsChecked == false && rbSmanji.IsChecked == false) { MessageBox.Show("Izaberite Cilj u dostizanju kilaze"); return; }

            if (rbZensko.IsChecked == true)
            {
                pol = "Zensko";
            }

            if (rbSmanji.IsChecked == true)
            {
                smanjiKilazu = 1;
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

            if (pol.Equals("Musko"))
            {
                if (smanjiKilazu == 0)
                {
                    pdu = (int)(((66 + (13.7 * tezina) + (5 * visina) - (6.8 * godine)) * tdee) * 1.1 + 300);
                }
                else
                {
                    pdu = (int)(((66 + (13.7 * tezina) + (5 * visina) - (6.8 * godine)) * tdee) * 1.1 - 300);
                }
            }
            else
            {
                if (smanjiKilazu == 0)
                {
                    pdu = (int)(((655 + (9.6 * tezina) + (1.8 * visina) - (4.7 * godine)) * tdee) * 1.1 + 300);
                }
                else
                {
                    pdu = (int)(((655 + (9.6 * tezina) + (1.8 * visina) - (4.7 * godine)) * tdee) * 1.1 - 300);
                }
            }

            Sql sql = new Sql();
            sql.Register(username, password, imePrezime, pol, godine, visina, tezina, aktivnost, smanjiKilazu, pdu);
        }

        private void tabButton_Click(object sender, RoutedEventArgs e)
        {
            Button tabButton = (Button)sender;
            int buttonTag = Int32.Parse(tabButton.Tag.ToString());

            switch (buttonTag)
            {
                case 0:
                    this.Close();
                    break;
                case 1:
                    break;
                case 2:
                    this.WindowState = WindowState.Minimized;
                    break;
            }
        }
    }
}
