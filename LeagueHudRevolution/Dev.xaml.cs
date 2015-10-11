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

namespace LeagueHudRevolution
{
    /// <summary>
    /// Interaction logic for Dev.xaml
    /// </summary>
    public partial class Dev : UserControl
    {
        public Dev()
        {
            InitializeComponent();
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate(new Home());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SimpleAES joao = new SimpleAES();
            textBox.Text = joao.Encrypt(textBox.Text);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SimpleAES joao = new SimpleAES();
            textBox.Text = joao.Decrypt(textBox.Text);
        }
    }
}
