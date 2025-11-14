using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPV.Components
{
    partial class ErreserbatutaDago
    {
        public ErreserbatutaDago()
        {
            InitializeComponent();
        }
        public ErreserbatutaDago(string izena, string ordua, string eguna, string pertsonak)
        {
            InitializeComponent();

            txtizena.Content = $"{izena}";
            txtordua.Content = $"{ordua}";
            txtpertsonak.Content = $"{pertsonak}";
            txteguna.Content = $"{eguna}";

            
        }

        private void Cancel_click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = false;

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
