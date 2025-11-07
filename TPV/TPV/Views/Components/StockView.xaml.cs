using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Npgsql;

namespace TPV.Views.Components
{
    public partial class StockView : UserControl
    {
        private string connString = "Host=localhost;Port=5432;Database=tpvdb;Username=tpvadmin;Password=tpv1234";
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

                string query = "SELECT id, name, price, stock FROM products ORDER BY id;";
                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        Stock = reader.GetInt32(3)
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
                var dialog = new ProductDialog(selected);
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        using var conn = new NpgsqlConnection(connString);
                        conn.Open();

                        string query = "UPDATE products SET name=@n, price=@p, stock=@s WHERE id=@id";
                        using var cmd = new NpgsqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@n", dialog.ProductName);
                        cmd.Parameters.AddWithValue("@p", dialog.ProductPrice);
                        cmd.Parameters.AddWithValue("@s", dialog.ProductStock);
                        cmd.Parameters.AddWithValue("@id", selected.Id);
                        cmd.ExecuteNonQuery();

                        LoadProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error editing product: {ex.Message}");
                    }
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

                        string query = "DELETE FROM products WHERE id=@id";
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
        public int Stock { get; set; }
    }
}
