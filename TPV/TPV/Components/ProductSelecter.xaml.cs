using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace TPV.Components
{
    public partial class ProductSelecter : UserControl
    {
        private ObservableCollection<SelectedProduct> SelectedProducts = new();
        public event Action <decimal> PrezioaEguneratu;
        public int total = 0;


        public ProductSelecter()
        {
            InitializeComponent();
            lvSelectedProducts.ItemsSource = SelectedProducts;
        }

        public void AddProduct(string name, decimal price)
        {
            var existing = SelectedProducts.FirstOrDefault(p => p.Name == name);
            if (existing != null)
            {
                existing.Quantity++;
                existing.TotalPrice = existing.Price * existing.Quantity;
            }
            else
            {
                SelectedProducts.Add(new SelectedProduct { Name = name, Price = price, Quantity = 1, TotalPrice = price });
            }

            lvSelectedProducts.Items.Refresh();

            decimal totalPrice = SelectedProducts.Sum(p => p.TotalPrice);
            PrezioaEguneratu?.Invoke(totalPrice); 
        }
        public void TotalaEguneratu(int totala)
        {
            if (lvSelectedProducts.SelectedItem is SelectedProduct selected)
            {
                selected.Quantity = totala;
                selected.TotalPrice = selected.Price * totala;

                lvSelectedProducts.Items.Refresh();

                decimal totalPrice = SelectedProducts.Sum(p => p.TotalPrice);
                PrezioaEguneratu?.Invoke(totalPrice);
            }
        }

    }

    public class SelectedProduct
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1; 
        public decimal TotalPrice { get; set; }
    }

}
