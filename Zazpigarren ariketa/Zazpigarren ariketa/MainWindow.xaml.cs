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

namespace Zazpigarren_ariketa
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

        }
        double[] zenbakiak = new double[2];
        String operadore_hautatua = "";
        Boolean puntua_dago = false;
        Boolean zenbaki_bat_dago = false;

        private void numeros_click(object sender, RoutedEventArgs e)
        {
            Button zenbakia = (Button)sender;
            if (zenbakia.Name == "punto")
            {
                puntua_dago = true;

            }
            if (puntua_dago) { 
                pantalla.Text += zenbakia.Content.ToString();
                zenbaki_bat_dago = true;
            }
            else if (pantalla.Text == "0")
            {
                pantalla.Text = zenbakia.Content.ToString();
                zenbaki_bat_dago = true;
            }
            else if (zenbaki_bat_dago)
            {
                pantalla.Text += zenbakia.Content.ToString();
            }
            else
            {
                pantalla.Text = zenbakia.Content.ToString();
                zenbaki_bat_dago = true;


            }

        }
        private void operadoreak_click(object sender, RoutedEventArgs e)
        {
            Button operadorea = (Button)sender;
            puntua_dago = false;
            zenbakiak[0] = double.Parse(pantalla.Text);
            operadore_hautatua = operadorea.Content.ToString();
            pantalla.Text = "";

        }
        private void operazioa(Object sender, RoutedEventArgs e)
        {
            double zenbaki1 = zenbakiak[0];
            double zenbaki2 = double.Parse(pantalla.Text);
            String operador = operadore_hautatua;
            

            switch(operador)
            {
                case "+":
                    pantalla.Text = (zenbaki1 + zenbaki2).ToString();
                    zenbaki_bat_dago = false;
                    break;
                case "-":
                    pantalla.Text = (zenbaki1 - zenbaki2).ToString();
                    zenbaki_bat_dago = false;
                    break;
                case "X":
                    pantalla.Text = (zenbaki1 * zenbaki2).ToString();
                    zenbaki_bat_dago = false;
                    break;
                case "/":
                    pantalla.Text = (zenbaki1 / zenbaki2).ToString();
                    zenbaki_bat_dago = false;
                    break;
                case "%":
                    pantalla.Text = (zenbaki1 % zenbaki2).ToString();
                    zenbaki_bat_dago = false;
                    break;
            }

        }
        

        private void c_Click(object sender, RoutedEventArgs e)
        {
            
            pantalla.Text = "0";
            zenbakiak[0] = 0;
            zenbakiak[1] = 0;
            operadore_hautatua = "";

            puntua_dago = false;

        }

        private void ce_Click(object sender, RoutedEventArgs e)
        {
            pantalla.Text = "0";
            puntua_dago = false;
        }
    }
}