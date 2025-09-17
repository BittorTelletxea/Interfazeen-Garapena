using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bigarren_ariketa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                string buttonName = clickedButton.Name;
                if (buttonName == "frase1")
                {
                    resultado.Text = "Frase 1";
                    clickedButton.IsEnabled = false;
                    frase2.IsEnabled = true;
                }
                else if (buttonName == "frase2")
                {
                    resultado.Text = "Frase 2";
                    clickedButton.IsEnabled = false;
                    frase3.IsEnabled = true;
                }
                else if (buttonName == "frase3")
                {
                    resultado.Text = "Frase 3";
                    clickedButton.IsEnabled = false;
                    frase4.IsEnabled = true;
                }
                else if (buttonName == "frase4")
                {
                    resultado.Text = "Frase 4";
                    clickedButton.IsEnabled = false;
                    frase5.IsEnabled = true;
                }
                else if (buttonName == "frase5")
                {
                    resultado.Text = "Frase 5";
                    clickedButton.IsEnabled = false;
                    unir.IsEnabled = true;
                }
                else if (buttonName == "unir")
                {
                    resultado.Text = "Frase 1, Frase 2, Frase 3, Frase 4, Frase 5";
                    clickedButton.IsEnabled = false;
                    unir.IsEnabled = true;
                }
            }
        }
        private void limpieza(object sender, RoutedEventArgs e)
        {
            resultado.Text = "";
            frase1.IsEnabled = true;
            frase2.IsEnabled = false;
            frase3.IsEnabled = false;
            frase4.IsEnabled = false;
            frase5.IsEnabled = false;
            unir.IsEnabled = false;
        }
        private void cerrar(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}