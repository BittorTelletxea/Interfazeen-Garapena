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

namespace _13.Ariketa
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
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEditor.SelectedText))
                txtEditor.SelectedText = "";
            else
                txtEditor.Clear();
        }

        private void Arial_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.FontFamily = new FontFamily("Arial");
        }

        private void Courier_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.FontFamily = new FontFamily("Courier New");
        }

        private void Impact_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.FontFamily = new FontFamily("Impact");
        }

        private void Symbol_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.FontFamily = new FontFamily("Symbol");
        }

       
    }
}