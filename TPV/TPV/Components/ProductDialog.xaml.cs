using System;
using System.Windows;

namespace TPV.Components
{
    public partial class ProductDialog : Window
    {
        public string ProductName => txtName.Text.Trim();
        public decimal ProductPrice => decimal.TryParse(txtPrice.Text, out var p) ? p : 0;
        public int ProductStock => int.TryParse(txtStock.Text, out var s) ? s : 0;

        public ProductDialog()
        {
            InitializeComponent();
        }

        public ProductDialog(Product product) : this()
        {
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString("0.00");
            txtStock.Text = product.Stock.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductName))
            {
                MessageBox.Show("Introduce un nombre de producto.");
                return;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}
