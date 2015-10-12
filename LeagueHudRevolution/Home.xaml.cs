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


        public Home()
        {

            InitializeComponent();
            
                richTextBox.Document.Blocks.Clear();
                
                //Apresentar HUDS na lista
                string[] cucu = Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\Huds\\");
                richTextBox.AppendText(horas + "Loading assets . . .");
                foreach (string Info in cucu)
                {
                    DirectoryInfo crica = new DirectoryInfo(Info);

                    listBox.Items.Add(crica.Name);
                    richTextBox.AppendText(System.Environment.NewLine + horas + crica.Name + " loaded");
                }
                listBox.SelectedIndex = 0;
                //Fim apresentar
                //informar
                richTextBox.AppendText(System.Environment.NewLine + horas + "Initializing . . .");
                richTextBox.AppendText(System.Environment.NewLine + horas + "League Huds Revolution started successfully.");
                richTextBox.AppendText(System.Environment.NewLine + horas + "Hope you enjoy it!");
            

        }


        private void button_Click(object sender, RoutedEventArgs e)// PATCH
        {
            //patchar o lol
            DirectoryInfo versao = new DirectoryInfo(Directory.GetDirectories(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\")[0]);
            try
            {
                File.Copy(Directory.GetCurrentDirectory() + "\\Huds\\" + listBox.SelectedItem + "\\clarity_hudatlas.dds", File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + versao.Name + "\\deploy\\DATA\\menu\\hud\\clarity_hudatlas.dds", true);
                //File.Delete(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Path.txt") + "\\RADS\\solutions\\lol_game_client_sln\\releases\\" + joao.Name + "\\deploy\\DATA\\menu\\hud\\hudatlas.dds");
            }
            catch(IOException ex)
            {
                MessageBox.Show("Error:" + System.Environment.NewLine + ex.Message);
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
            //obter imagem
            WebClient joao = new WebClient();
            joao.DownloadFile(Decode(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Huds\\" + listBox.SelectedItem + "\\preview.LHR")), Directory.GetCurrentDirectory() + "\\temp.jpg");
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image.UriSource = new Uri(Directory.GetCurrentDirectory() + "\\temp.jpg");
            image.EndInit();
            image2.Source = image;
        }

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
                MessageBox.Show("Error:" + System.Environment.NewLine + ex.Message);
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
    }
}
