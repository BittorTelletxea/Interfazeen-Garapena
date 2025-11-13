using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TPV.Components
{
    public partial class ProductsGridControl : UserControl
    {

        private string connString = "Host=localhost;Port=5432;Database=tpv;Username=tpv;Password=tpv";
        public event Action<string, decimal> ProductClicked;

        public ProductsGridControl()
        {
            InitializeComponent();
            cargarProductos();
        }

        public void cargarProductos()
        {
            using var con = new Npgsql.NpgsqlConnection(connString);
            con.Open();
            string query = "SELECT product_id, name, price FROM products ORDER BY product_id;";
            using var cmd = new Npgsql.NpgsqlCommand(query, con);
            using var reader = cmd.ExecuteReader();

            try
            {
                
                while (reader.Read())
                {
                    var productName = reader.GetString(1);
                    var productPrice = reader.GetDecimal(2);
                    var button = new Button
                    {
                        Content = $"{productName}",
                        Tag = reader.GetInt32(0),
                        Margin = new Thickness(5),
                        Height = 50,
                        FontSize = 10,
                        Background = System.Windows.Media.Brushes.SteelBlue,
                        Foreground = System.Windows.Media.Brushes.White,
                    };
                    button.Click += (s, e) =>
                    {
                        ProductClicked?.Invoke(productName, productPrice);
                    };

                    productGrid.Children.Add(button);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }


        }
        

    }
}

