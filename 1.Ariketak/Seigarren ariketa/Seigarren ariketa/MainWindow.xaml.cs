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

namespace Seigarren_ariketa
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
        int kont = 2;

        private void TextBox_intro(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox text_puesto = (TextBox)sender;

                if (kont < 4)
                {
                    if (kont == 1)
                    {
                        box1.Text = text_puesto.Text;
                        text_puesto.Clear();
                        kont++;

                    }
                    else if (kont == 2)
                    {
                        box2.Text = text_puesto.Text;
                        text_puesto.Clear();
                        kont++;
                    }
                    else if (kont == 3)
                    {
                        box3.Text = text_puesto.Text;
                        text_puesto.Clear();
                        kont = 1;

                    }
                }
            }
        }
        private void limpiar_Click(object sender, RoutedEventArgs e)
        {
            box1.Clear();
            box2.Clear();
            box3.Clear();
            kont = 1;
        }
        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

      
    }
}