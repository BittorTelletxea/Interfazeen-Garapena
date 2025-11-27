using Npgsql;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TPV.Components
{
    public partial class ProductSelecter : UserControl
    {
        private ObservableCollection<SelectedProduct> SelectedProducts = new();
        public event Action<decimal> PrezioaEguneratu;
        public event Action<int> setTotala0;
        public int total = 0;
        private string connString = "Host=localhost;Port=5432;Database=tpv;Username=tpv;Password=tpv";


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
        private void RemoveSelectedProduct_Click(object sender, RoutedEventArgs e)
        {
            if (lvSelectedProducts.SelectedItem is SelectedProduct selected)
            {
                SelectedProducts.Remove(selected);
                decimal totalPrice = SelectedProducts.Sum(p => p.TotalPrice);
                PrezioaEguneratu?.Invoke(totalPrice);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public ObservableCollection<SelectedProduct> GetSelectedProducts()
        {
            return SelectedProducts;
        }
        public void UpdateStockFromListView()
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            var stockGutxiegi = false;

            foreach (var item in lvSelectedProducts.Items)
            {
                if (item is SelectedProduct selected)
                {
                    string selectQuery = "SELECT stock FROM products WHERE name = @n";
                    using var selectCmd = new NpgsqlCommand(selectQuery, conn);
                    selectCmd.Parameters.AddWithValue("@n", selected.Name);

                    object result = selectCmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int currentStock))
                    {
                        int newStock = currentStock - selected.Quantity;
                        if (newStock < 0)
                        {
                            stockGutxiegi = true;
                            MessageBox.Show($"Ez dago stock nahiko zure eskaera betetzeko! ");
                            break;
                        } 

                        string updateQuery = "UPDATE products SET stock = @s WHERE name = @n";
                        using var updateCmd = new NpgsqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@s", newStock);
                        updateCmd.Parameters.AddWithValue("@n", selected.Name);
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }

            SelectedProducts.Clear();
            setTotala0?.Invoke(0);
            stockGu = stockGutxiegi;

            
        }
        public bool stockGu{ get; set; }



    }

    public class SelectedProduct
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1; 
        public decimal TotalPrice { get; set; }
    }
 


}
