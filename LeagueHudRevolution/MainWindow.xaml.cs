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
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Path.txt"))
            {
                DirectoryInfo versao = new DirectoryInfo(Directory.GetDirectories(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\")[0]);
                if (Directory.Exists(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu") == true)
                {
                    CheckHUD();
                }
                else
                {
                    Directory.CreateDirectory(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu");
                    Directory.CreateDirectory(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu\\hud");
                }
                InitializeComponent();
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri("pack://application:,,,/LeagueHudRevolution;component/Resources/trophy.png");
                logo.EndInit();
                this.Icon = logo;
                this.Navigate(new Home());
            }
            else
            {
                EscolhePasta();
                DirectoryInfo versao = new DirectoryInfo(Directory.GetDirectories(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\")[0]);
                if (Directory.Exists(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu") == true)
                {
                    CheckHUD();
                }
                else
                {
                    Directory.CreateDirectory(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu");
                    Directory.CreateDirectory(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu\\hud");
                }
                InitializeComponent();
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri("pack://application:,,,/LeagueHudRevolution;component/Resources/trophy.png");
                logo.EndInit();
                this.Icon = logo;
                this.Navigate(new Home());
            }
            }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            File.Delete(Directory.GetCurrentDirectory() + "\\temp.jpg");
        }

        private void EscolhePasta()
        {
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog pasta = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            pasta.Description = "Please select your League of Legends folder";
            pasta.RootFolder = Environment.SpecialFolder.MyComputer;
            pasta.ShowDialog();
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\path.txt", pasta.SelectedPath.ToString());
        }

        private void CheckHUD()
        {
            DirectoryInfo versao = new DirectoryInfo(Directory.GetDirectories(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\")[0]);

            if (Directory.Exists(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu\\hud") == true)
            {
                //ta tudo bem, nao se faz nada
            }
            else
            {
                Directory.CreateDirectory(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu\\hud");
            }
        }
    }
}
