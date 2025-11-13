using System.Windows;
using TPV.Components;

namespace TPV.Views
{
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
            navMenu.StockClicked += (s, e) => MainContent.Content = new StockView();
            navMenu.UsersClicked += (s, e) => MainContent.Content = new UsersView();
            MainContent.Content = new StockView();
        }
    }
}
