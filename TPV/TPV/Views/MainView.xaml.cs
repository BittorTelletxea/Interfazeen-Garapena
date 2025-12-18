using System.Windows;
using System.Windows.Media;
using TPV.Components;
using TPV.Services;

namespace TPV.Views
{
    public partial class MainView : Window
    {
        
        public MainView()
        {

            InitializeComponent();
            productsGrid.ProductClicked += (name, price) => productSelecter.AddProduct(name, price);
            productSelecter.PrezioaEguneratu += (price) => prezioTotala.setPrezioa(price);
            calculadora.totalKalkul += (totala) => productSelecter.TotalaEguneratu(totala);
            productSelecter.setTotala0 += (totala) => prezioTotala.setPrezioa(0);

        }
        private void btnTPV_Click(object sender, RoutedEventArgs e)
        {
            gridTPV.Visibility = Visibility.Visible;
            gridErreserbak.Visibility = Visibility.Collapsed;

            btnTPV.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3498DB"));
            btnErreserbak.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BDC3C7"));
        }

        private void btnErreserbak_Click(object sender, RoutedEventArgs e)
        {
            gridTPV.Visibility = Visibility.Collapsed;
            gridErreserbak.Visibility = Visibility.Visible;

            btnTPV.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BDC3C7"));
            btnErreserbak.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3498DB"));
        }
        private void BtnImprimir_Click(object sender, RoutedEventArgs e)
        {
            bool ezStock = productSelecter.stockGu;

            if (ezStock)
            {
                return;
            }
            else
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = System.IO.Path.Combine(desktopPath, "Ticket.pdf");

                TicketPrinter.PrintTicket(filePath, productSelecter);

                MessageBox.Show($"Ticket generado en: {filePath}", "Ticket", MessageBoxButton.OK, MessageBoxImage.Information);

                productSelecter.UpdateStockFromListView();

            
        }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            Application.Current.Windows[0].Close();
        }
    }
}
