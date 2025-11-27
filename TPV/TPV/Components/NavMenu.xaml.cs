using System;
using System.Windows;
using System.Windows.Controls;


namespace TPV.Components
{
    public partial class NavMenu : UserControl
    {
        public event EventHandler StockClicked;
        public event EventHandler UsersClicked;

        public NavMenu()
        {
            InitializeComponent();
        }

        private void Stock_Click(object sender, RoutedEventArgs e) => StockClicked?.Invoke(this, EventArgs.Empty);
        private void Users_Click(object sender, RoutedEventArgs e) => UsersClicked?.Invoke(this, EventArgs.Empty);
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            Application.Current.Windows[0].Close();
        }
    }
}
