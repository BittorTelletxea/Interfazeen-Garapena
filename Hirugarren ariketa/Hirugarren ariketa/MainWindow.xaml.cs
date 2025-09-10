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

namespace Hirugarren_ariketa
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

        private void numero_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private int[] numeros = new int[4]; 
        private int kont = 0;

        private void siguiente_Click(object sender, RoutedEventArgs e)
        {
            if (kont < 4)
            {
                numeros[kont] = int.Parse(numero.Text);
                numero.Clear();

                kont++;

                if (kont == 1)
                {
                    label.Content = "Numero 2";
                }
                else if (kont == 2)
                {
                    label.Content = "Numero 3";
                }
                else if (kont == 3)
                {
                    label.Content = "Numero 4";
                }
                else if (kont == 4)
                {
                    label.Content = "Resultado";

                    int num1 = numeros[0];
                    int num2 = numeros[1];
                    int num3 = numeros[2];
                    int num4 = numeros[3];

                    numero.Text = ((num1 + (num1 * num2) + (num2 * num3) + (num3 * num4)) / 4).ToString();
                       
                    siguiente.Content = "Limpiar";  

                    siguiente.Click -= siguiente_Click;
                    siguiente.Click += Limpiar_Click;
                }
            }
        }
        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "Numero 1";
            siguiente.Content = "Siguiente";
            numero.Clear();

            siguiente.Click -= Limpiar_Click;   
            siguiente.Click += siguiente_Click; 
        }
        private void cerrark(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}