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
using System.Windows.Shapes;


namespace WPFforelasning20oktober
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal StyledWebsiteGenerator website { get; set; }
        public MainWindow()
        {

            InitializeComponent();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Websitegenerator";
            dlg.DefaultExt = ".html";
            dlg.Filter = "HTML file (.html)|*.html";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string fileName = dlg.FileName;
                string read = "";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    read = sr.ReadToEnd();
                }
                myTextBox.Text = read;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Websitegenerator";
            dlg.DefaultExt = ".html";
            dlg.Filter = "HTML file (.html)|*.html";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string fileName = dlg.FileName;
                using (StreamWriter sw = new StreamWriter($"{fileName}.html"))
                {
                    sw.WriteLine(myTextBox.Text);
                }
                MessageBox.Show($"Saved as {fileName}");
                myTextBox.Text = "waiting...";
            }
        }

        private void Save2_Click(object sender, RoutedEventArgs e)
        {            
            string inputKlass = klassTextBox.Text;
            //Om man vill lägga till mer techniques eller meddelande, man får separera sin input med ; tecken i respektiva rutor
            string[] inputTechniques = techniquessTextBox.Text.Split(";");
            string[] inputMeddelande = meddelandeTextBox.Text.Split(";");
            string colour = " ";
            if (myLabel.Content.ToString() == "röd")
            {
                 colour = "red";
            }
            else if (myLabel.Content.ToString() == "blå")
            {
                colour = "blue";
            }
            else if (myLabel.Content.ToString() == "gul")
            {
                colour = "yellow";
            }
            StyledWebsiteGenerator perfectWebsite = new StyledWebsiteGenerator(inputKlass, colour, inputMeddelande, inputTechniques);
            perfectWebsite.Print();
        }
        private void Action(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            myLabel.Content = rb.Content.ToString();
            

        }
    }
}
