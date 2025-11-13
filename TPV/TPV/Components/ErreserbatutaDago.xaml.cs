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
        public ErreserbatutaDago(string izena, string ordua, Boolean mota, string pertsonak)
        {
            InitializeComponent();

            txtizena.Content = $"{izena}";
            txtordua.Content = $"{ordua}";
            txtmota.Content = $"{mota}";
            txtpertsonak.Content = $"{pertsonak}";

            
        }

        private void Cancel_click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = false;

        }
    }
}
