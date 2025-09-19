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

namespace Ariketa9
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String seleccionadoAmigo = (String)lista.SelectedItem;
            seleccionado.Text = seleccionadoAmigo;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String nuevoAmigo = nuevo.Text;
            if(nuevoAmigo == "")
            {
                MessageBox.Show("Introduzca datos para poder añadirlos", "Error Añadir");
            }
            else
            {
                lista.Items.Add(nuevoAmigo);
                nuevo.Text = "";
            }
               
        }

        private void eliminar_Click(object sender, RoutedEventArgs e)
        {
            String seleccion = seleccionado.Text;
            if (seleccion == "")
            {
                MessageBox.Show("Introduzca datos para poder eliminarlos", "Error Eliminar");
            }
            else
            {
                lista.Items.Remove(seleccion);
                seleccionado.Text = "";
                MessageBox.Show(seleccion + " eliminado de la lista");
            }
        }

        private void borrar_Click(object sender, RoutedEventArgs e)
        {
            lista.Items.Clear();
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}