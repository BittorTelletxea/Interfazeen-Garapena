using System;
using System.Windows;
using Npgsql;
using TPV.Views; 

namespace TPV
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = usuario.Text.Trim();
            string password = contraseña.Password.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string connectionString = "Host=localhost;Port=5432;Database=tpv;Username=tpv;Password=tpv";

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string query = "SELECT role FROM users WHERE username = @username AND password_hash = @password LIMIT 1;";
                using var cmd = new NpgsqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string role = result.ToString();
                    MessageBox.Show($"✅ Login successful! Role: {role}");

                    if(role == "Admin")
                    {
                        AdminPanel adminView = new AdminPanel();
                        adminView.Show();
                    }
                    else
                    {
                        ErreserbaPanel mainView = new ErreserbaPanel();
                        mainView.Show();
                    }





                        this.Close();
                }
                else
                {
                    MessageBox.Show("❌ Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
        }
    }
}
