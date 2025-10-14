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

namespace _11.Ariketa
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

        private void aceptar_Click(object sender, RoutedEventArgs e)
        {
            String nombreText = nombre.Text;
            String apellido1Text = apellido1.Text;
            String apellido2Text = apellido2.Text;
            String dniText = dni.Text;

            if(dni.GetLineLength(0) != 9)
            {
                MessageBox.Show("El DNI debe tener 9 caracteres.");
                return;
            }
            else
            {
                User user = new User(nombreText, apellido1Text, apellido2Text, dniText);
                MessageBox.Show("Datos guardados correctamente. ");
            }

        }

        private void cargar_Click(object sender, RoutedEventArgs e)
        {
            String nombreText = nombre.Text;
            String apellido1Text = apellido1.Text;
            String apellido2Text = apellido2.Text;
            String dniText = dni.Text;

            if (dni.GetLineLength(0) != 9)
            {
                MessageBox.Show("El DNI debe tener 9 caracteres.");
                return;
            }
            else
            {
                User user = new User(nombreText, apellido1Text, apellido2Text, dniText);
                MessageBox.Show("Bienvenido al sistema \n " + nombreText + "  " + dniText + "\n " + apellido1Text + "\n " + apellido2Text);
            }
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}