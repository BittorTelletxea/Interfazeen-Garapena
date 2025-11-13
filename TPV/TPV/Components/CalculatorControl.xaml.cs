using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TPV.Components
{
    public partial class CalculatorControl : UserControl
    {
        public event Action<int> totalKalkul;
       public CalculatorControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            txtDisplay.Text += (sender as Button).Content.ToString();
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            
            totalKalkul?.Invoke(int.Parse(txtDisplay.Text));
            txtDisplay.Text = "";

        }
    }
}
