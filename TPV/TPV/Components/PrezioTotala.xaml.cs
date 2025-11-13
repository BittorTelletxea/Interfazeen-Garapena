using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPV.Components
{
    partial class PrezioTotala
    {
        decimal prezioTotala = 0;
        public PrezioTotala()
        {
            InitializeComponent();
        }
        public void setPrezioa(decimal prezioa)
        {
                prezioTotala = prezioa;
                txtTotal.Text = prezioTotala.ToString();
            
            
        }
    }
}
