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

namespace Lehen_ariketa
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
            int primerNum = int.TryParse(primer.Text, out int zenb1) ? zenb1 : 0;
            int segundoNum = int.TryParse(segundo.Text, out int zenb2) ? zenb2 : 0;
            int tercerNum = int.TryParse(tercer.Text, out int zenb3) ? zenb3 : 0;
            int cuartoNum = int.TryParse(cuarto.Text, out int zenb4) ? zenb4 : 0;

            double gehiketa =( primerNum + (2 *segundoNum) + (3 * tercerNum) + (4 * cuartoNum))/4;

            resultado.Text = gehiketa.ToString();
        }
        private void limpiar(object sender, RoutedEventArgs e)
        {
            primer.ClearValue(TextBox.TextProperty);
            segundo.ClearValue(TextBox.TextProperty);
            tercer.ClearValue(TextBox.TextProperty);
            cuarto.ClearValue(TextBox.TextProperty);
            resultado.ClearValue(TextBox.TextProperty);
        }
        private void salir(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}