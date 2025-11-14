using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Npgsql;

namespace TPV.Components
{
    public partial class StockView : UserControl
    {
        private string connString = "Host=localhost;Port=5432;Database=tpv;Username=tpv;Password=tpv";
        private ObservableCollection<Product> products = new();

        public StockView()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            products.Clear();

            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();

                string query = "SELECT product_id, name, price, stock FROM products ORDER BY product_id;";
                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        Stock = reader.GetFloat(3)
                    });
                }

                dgProducts.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ProductDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    using var conn = new NpgsqlConnection(connString);
                    conn.Open();

                    string query = "INSERT INTO products (name, price, stock) VALUES (@n, @p, @s)";
                    using var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@n", dialog.ProductName);
                    cmd.Parameters.AddWithValue("@p", dialog.ProductPrice);
                    cmd.Parameters.AddWithValue("@s", dialog.ProductStock);
                    cmd.ExecuteNonQuery();

                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding product: {ex.Message}");
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selected)
            {
                try
                {
                    using var conn = new NpgsqlConnection(connString);
                    conn.Open();

                    string query = "UPDATE products SET name=@n, price=@p, stock=@s WHERE product_id=@id";
                    using var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@n", selected.Name);
                    cmd.Parameters.AddWithValue("@p", selected.Price);
                    cmd.Parameters.AddWithValue("@s", selected.Stock);
                    cmd.Parameters.AddWithValue("@id", selected.Id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Producto actualizado correctamente.");
                    }

                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error actualizando producto: {ex.Message}");
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selected)
            {
                if (MessageBox.Show($"¿Seguro que deseas eliminar '{selected.Name}'?", "Confirmar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        using var conn = new NpgsqlConnection(connString);
                        conn.Open();

                        string query = "DELETE FROM products WHERE product_id=@id";
                        using var cmd = new NpgsqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", selected.Id);
                        cmd.ExecuteNonQuery();

                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}");
                    }
                }
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e) => LoadProducts();

      
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public float Stock { get; set; }  
    }
}
