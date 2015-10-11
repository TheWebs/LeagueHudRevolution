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
using MahApps.Metro.Controls;
using System.IO;

namespace LeagueHudRevolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            //2 HORAS PARA FAZER LOAD DA PORRA DO ICON DAS RESOURCES -.- FINALLY DID IT
            InitializeComponent();
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,,/LeagueHudRevolution;component/Resources/trophy.png");
            logo.EndInit();
            this.Icon = logo;
            this.Navigate(new Home());
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            File.Delete(Directory.GetCurrentDirectory() + "\\temp.jpg");
        }
    }
}
