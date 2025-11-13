using System;
using System.Windows;

namespace TPV.Components
{
    public partial class UserDialog : Window
    {
        public string UserName => txtName.Text.Trim();
        public string UserContraseña => txtContraseña.Password;
        public string UserRol => txtRol.Text;

        public UserDialog()
        {
            InitializeComponent();
        }

        public UserDialog(User user) : this()
        {
            txtName.Text = user.Username;
            txtContraseña.Password = user.Contrseña;
            txtRol.Text = user.Role;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                MessageBox.Show("Introduce un nombre de producto.");
                return;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}
