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
    /// Interaction logic for APITest.xaml
    /// </summary>
    public partial class APITest : Page
    {
        public APITest()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.endPoint = textBox.Text;

            Console.WriteLine("Rest Client kreiran");

            string strResponse = string.Empty;

            strResponse = rClient.MakeRequest();

            // Console.WriteLine(strResponse);
            listBox.Items.Add(strResponse);
        }
    }
}
