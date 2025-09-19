using Microsoft.VisualBasic;
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

namespace _8.Ariketa
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

        private void ejecutar(object sender, RoutedEventArgs e)
        {
            ahora.Text = DateTime.Now.ToString();
            hoy.Text = DateTime.Today.ToString("d");
            hora.Text = DateTime.Now.ToString("T");

            String suma1 = Interaction.InputBox("Ingrese una fecha de la forma dd/mm/aaaa");
            String numeroMeses = Interaction.InputBox("Ingrese un numero de meses a sumar");
            
            
            try
            {
                DateTime fecha1 = DateTime.Parse(suma1);
                int meses = int.Parse(numeroMeses);
                DateTime fecha2 = fecha1.AddMonths(meses);
                suma.Text = fecha2.ToString("d");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error en el formato de la fecha");
            }
            String fechaInicialString = Interaction.InputBox("Ingese fecha inicial de la forma dd/mm/aaaa");
            String fechaFinalString = Interaction.InputBox("Ingese fecha final de la forma dd/mm/aaaa");
            try
            {
                DateTime fechaInicial = DateTime.Parse(fechaInicialString);
                DateTime fechaFinal = DateTime.Parse(fechaFinalString);
                TimeSpan diferenciaDias = fechaFinal - fechaInicial;
                int dias = diferenciaDias.Days;
                diferencia.Text = "Desde " + fechaInicial.ToString("d") + " hasta " + fechaFinal.ToString("d") + " hay " + dias;
            }catch(FormatException ex)
            {
                MessageBox.Show("Error en el formato de la fecha");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ahora.Text = "";
            hoy.Text = "";
            hora.Text = "";
            suma.Text = "";
            diferencia.Text = "";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}