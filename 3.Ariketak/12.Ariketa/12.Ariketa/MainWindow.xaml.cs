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

namespace _12.Ariketa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double totalDietas;
        double totalViajes;
        double totalTrabajo;


        public MainWindow()
        {
            InitializeComponent();
        }

       

        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                UIElement seleccion = Keyboard.FocusedElement as UIElement;

                (Keyboard.FocusedElement as UIElement)?.MoveFocus(
                    new TraversalRequest(FocusNavigationDirection.Next)
                );
                if((seleccion as FrameworkElement)?.Name == "cena")
                {
                    totalDietas = 0;
                    if (desayuno.IsChecked == true)
                    {
                        totalDietas += 3;
                    }
                    if (comida.IsChecked == true)
                    {
                        totalDietas += 9;
                    }
                    if (cena.IsChecked == true)
                    {
                        totalDietas +=15.5;
                    }
                    total_dietas.Text = totalDietas.ToString();

                }else if((seleccion as FrameworkElement)?.Name == "horas_viajes")
                {
                    double totalKilometros = double.Parse(kilometros.Text) * 0.25;
                    double totalHoras = double.Parse(horas_viajes.Text) * 18;
                    total_viajes.Text = (totalKilometros + totalHoras).ToString();

                }else if((seleccion as FrameworkElement)?.Name == "horas_trabajo")
                {
                    double totalTrabajo = double.Parse(horas_trabajo.Text) * 42;

                    double totalDietas = double.Parse(total_dietas.Text);
                    double totalViajes = double.Parse(total_viajes.Text);
                    total.Text = (totalDietas + totalViajes + totalTrabajo).ToString();

                    total_trabajo.Text = totalTrabajo.ToString();

                }
            }
        }

        private void horas_trabajo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void limpiar_Click(object sender, RoutedEventArgs e)
        {
            totalDietas = 0;
            totalViajes = 0;
            totalTrabajo = 0;
            desayuno.IsChecked = false;
            comida.IsChecked = false;
            cena.IsChecked = false;
            kilometros.Text = string.Empty;
            horas_viajes.Text = string.Empty;
            horas_trabajo.Text= string.Empty;
            total.Text= string.Empty;

            total_dietas.Text= string.Empty;
            total_trabajo.Text = string.Empty;
            total_viajes.Text = String.Empty;
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}