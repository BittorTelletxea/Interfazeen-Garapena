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

namespace Laugarren_ariketa
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String usuario_insert = usuario.Text;
            String contrasena_insert = contrasena.Password;

            if (usuario_insert == "bittor" && contrasena_insert == "bittor")
            {
                saludo.Content = "Bienvenido al Sistema, " + usuario_insert;
            }
            else
            {
                saludo.Content = "Identifikatu gabeko erabiltzailea";
            }
        }
        private void limpiar_Click(object sender, RoutedEventArgs e)
        {
            usuario.Text = "";
            contrasena.Password = "";
            saludo.Content = " ";
        }
        private void salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void usuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}