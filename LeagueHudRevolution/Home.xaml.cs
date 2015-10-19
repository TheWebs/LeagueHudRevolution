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
using System.IO;
using System.Net;

namespace LeagueHudRevolution
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        BrushConverter ze = new BrushConverter();
        
        //Little hack to bypass version changes in LoL
        string horas = "[" + DateTime.Now.ToString("HH:mm:ss") + "] - ";
        string Dia = "------------------- [" + DateTime.Now.ToShortDateString() + "]-------------------";
        string ficheiro = Directory.GetCurrentDirectory() + "\\Log.txt";
        string urlencri;





        public Home()
        {
            File.WriteAllText(ficheiro, Environment.NewLine + Dia);
            InitializeComponent();
            
                
                //Apresentar HUDS na lista
                string[] cucu = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\Huds\\");
                Loggar(horas + "Loading assets . . .");
                foreach (string Info in cucu)
                {
                    DirectoryInfo crica = new DirectoryInfo(Info);
                Loggar(Environment.NewLine + horas + "Loaded asset \"" + crica.Name + "\" ...");
                    listBox.Items.Add(crica.Name);
                }
                listBox.SelectedIndex = 0;
            //Fim apresentar
            //informar
            Loggar(System.Environment.NewLine + horas + "Initializing . . .");
            Loggar(System.Environment.NewLine + horas + "League Hud Revolution started successfully.");


        }


        private void button_Click(object sender, RoutedEventArgs e)// PATCH
        {
            //patchar o lol
            DirectoryInfo versao = new DirectoryInfo(Directory.GetDirectories(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\")[0]);
            try
            {
                File.Copy(Directory.GetCurrentDirectory() + "\\Huds\\" + listBox.SelectedItem + "\\clarity_hudatlas.dds", File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu\\hud\\clarity_hudatlas.dds", true);
                textBlock.Text = "Patched! You are now using " + listBox.SelectedItem.ToString() + " HUD!";
                //File.Delete(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + joao.Name + "\\deploy\\DATA\\menu\\hud\\hudatlas.dds");
            }
            catch(IOException ex)
            {
                textBlock.Text = "Error, something went wrong!";
                Loggar(System.Environment.NewLine + horas + "Error:" + ex.Message);
            }



        }

        public string Decode(string texto)
        {
            SimpleAES joao = new SimpleAES();
            return joao.Decrypt(texto);
        }

        public string Encode(string texto)
        {
            SimpleAES joao = new SimpleAES();
            return joao.Encrypt(texto);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //obter e desenhar imagem
            try
            {
                urlencri = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Huds\\" + listBox.SelectedItem + "\\preview.LHR");
                textBlock.Text = "";
            }catch(IOException ex)
            {
                textBlock.Text = "Error, something went wrong!";
                Loggar(Environment.NewLine + horas + "ERROR: " + ex.Message);
            }
            try
            {
                WebClient joao = new WebClient();
                joao.DownloadFile(Decode(urlencri), Directory.GetCurrentDirectory() + "\\temp.jpg");
            }catch(WebException ex)
            {
                textBlock.Text = "Error, something went wrong!";
                Loggar(Environment.NewLine + horas + "ERROR: " + ex.Message);
            }
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image.UriSource = new Uri(Directory.GetCurrentDirectory() + "\\temp.jpg");
            image.EndInit();
            image2.Source = image;
        }

        //Apresentar janela so com imagem
        private void image2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BitmapImage image = new BitmapImage();
            Window ze = new Window();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image.UriSource = new Uri(Directory.GetCurrentDirectory() + "\\temp.jpg");
            image.EndInit();

            ze.Width = image.Width;
            ze.Height = image.Height;
            ze.Background = new ImageBrush(image);
            ze.Title = "League Hud Revolution : Preview";
            ze.Show();
        }

        

        private void button1_Click(object sender, RoutedEventArgs e) //Restore
        {
            DirectoryInfo versao = new DirectoryInfo(Directory.GetDirectories(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\")[0]);
            try
            {
                File.Delete(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu\\hud\\clarity_hudatlas.dds");
            
            }catch(IOException ex)
            {
                textBlock.Text = "Error, something went wrong!";
                Loggar(System.Environment.NewLine + horas + "ERROR: " + ex.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate(new Dev());
        }
        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            
        }

        private void textBlock_TargetUpdated(object sender, DataTransferEventArgs e)
        {
        }

        private void Loggar(string texto) // Funcao criada de raiz
        {
                   
            if (File.Exists(ficheiro) == true)
            {
                File.WriteAllText(ficheiro, File.ReadAllText(ficheiro) + Environment.NewLine + texto);
            }
            else
            {
                File.WriteAllText(ficheiro, Environment.NewLine + texto);
            }
        }

        private void button_Drop(object sender, DragEventArgs e)
        {
            button2.Visibility = Visibility.Visible;
        }

        private void button_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.OemQuestion)
            {
                button2.Visibility = Visibility.Visible;
            }
            else
            {
                //nothing
            }
        }
    }
}
