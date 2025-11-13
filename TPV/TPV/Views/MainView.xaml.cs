using System.Windows;
using TPV.Components;

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

        }
    }
}
