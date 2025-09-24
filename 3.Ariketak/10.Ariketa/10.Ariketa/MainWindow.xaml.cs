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

namespace _10.Ariketa
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

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedImageCombo = ((ComboBoxItem)combo.SelectedItem).Content.ToString();
            if (selectedImageCombo != null)
            {
                switch (selectedImageCombo)
                {
                    case "Imagen 1":
                        imagen1.Visibility = Visibility.Visible;
                        break;
                    case "Imagen 2":
                        imagen1.Visibility = Visibility.Hidden;
                        imagen3.Visibility = Visibility.Hidden;
                        imagen2.Visibility = Visibility.Visible;
                        break;
                    case "Imagen 3":
                        imagen1.Visibility = Visibility.Hidden;
                        imagen2.Visibility = Visibility.Hidden;
                        imagen3.Visibility = Visibility.Visible;
                        break;


                }
            }
        }

        private void Checked(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            if (check == imagen4check)
            {
                imagen4.Visibility = Visibility.Visible;
            }
            else if (check == imagen5check)
            {
                imagen5.Visibility = Visibility.Visible;
            }
            else if (check == imagen6check)
            {
                imagen6.Visibility = Visibility.Visible;

            }
        }
        private void Uncheck(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            if (check == imagen4check)
            {
                imagen4.Visibility = Visibility.Hidden;
            }
            else if (check == imagen5check)
            {
                imagen5.Visibility = Visibility.Hidden;
            }
            else if (check == imagen6check)
            {
                imagen6.Visibility = Visibility.Hidden;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();   
        }
    }
}