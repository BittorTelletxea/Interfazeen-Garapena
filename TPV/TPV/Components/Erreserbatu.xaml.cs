using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TPV.Components
{
    partial class Erreserbatu
    {
        public string izena => txtName.Text.Trim();
        public int pertsonak => int.Parse( txtPertsonak.Text.Trim());
        public string ordua => txtOrdua.Text.Trim();
        public string bazkaria =>bazkariCombo.SelectedItem?.ToString();


        public Erreserbatu()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(izena) && string.IsNullOrEmpty(ordua) )
            {
                MessageBox.Show("Sartu datuak mesedez.");
                return;

            }
                DialogResult = true;
        }
        private void Cancel_Click(object sender, System.Windows.RoutedEventArgs e) => DialogResult = false;
    }
}
