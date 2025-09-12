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

namespace Bostgarren_ariketa
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
            Button boton_clickado = sender as Button;
            if (boton_clickado != null)
            {
                switch (boton_clickado.Name)
                {
                    case "comic_sans":
                        prueba.FontFamily = new FontFamily("Comic Sans MS");
                        break;
                    case "negrita":
                        prueba.FontWeight = FontWeights.Bold ;
                        break;
                    case "tachado":
                        prueba.TextDecorations = TextDecorations.Strikethrough;
                        break;
                    case "mas_tamano":
                        prueba.FontSize += 2;
                        break;
                    case "courier":
                        prueba.FontFamily = new FontFamily("Courier");
                        break;
                    case "cursiva":
                        prueba.FontStyle = FontStyles.Italic;
                        break;
                    case "subrayado":
                        prueba.TextDecorations = TextDecorations.Underline;
                        break;
                    case "menos_tamano":
                        prueba.FontSize -= 2;
                        break;
                }
            }
        }
        private void seleccionado_click(object sender, RoutedEventArgs e)
        {
            String seleccion = seleccionado.SelectedText;
            int caractere =  seleccion.Length;

            if (seleccion != "") {
                resultado.Content = "El texto tiene " + caractere + " caracteres, y el texto seleccionado es: " + seleccion;
            }
            else
            {
                resultado.Content = "No has seleccionado nada";
            }
        }
        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void seleccionar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
     
}