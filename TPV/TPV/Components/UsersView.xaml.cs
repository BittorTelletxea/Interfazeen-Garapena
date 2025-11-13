using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Npgsql;

namespace TPV.Components
{
    public partial class UsersView : UserControl
    {
        private string connString = "Host=localhost;Port=5432;Database=tpv;Username=tpv;Password=tpv";
        private ObservableCollection<User> users = new();

        public UsersView()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            users.Clear();
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();

                string query = "SELECT user_id, username, password_hash, role FROM users ORDER BY user_id;";
                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Contrseña = reader.GetString(2),
                        Role = reader.GetString(3),
                    });
                }

                dgUsers.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando usuarios: {ex.Message}");
            }
        }

        // Añadir usuario como fila editable
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new UserDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    using var conn = new NpgsqlConnection(connString);
                    conn.Open();

                    string query = "INSERT INTO users (username, password_hash, role) VALUES (@n, @p, @r)";
                    using var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@n", dialog.UserName);
                    cmd.Parameters.AddWithValue("@p", dialog.UserContraseña);
                    cmd.Parameters.AddWithValue("@r", dialog.UserRol);
                    cmd.ExecuteNonQuery();

                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding product: {ex.Message}");
                }
            }
        }

        // Eliminar usuario seleccionado
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem is User selected)
            {
                if (MessageBox.Show($"¿Seguro que deseas eliminar '{selected.Username}'?", "Confirmar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        using var conn = new NpgsqlConnection(connString);
                        conn.Open();

                        string query = "DELETE FROM users WHERE user_id=@id";
                        using var cmd = new NpgsqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", selected.UserId);
                        cmd.ExecuteNonQuery();

                        users.Remove(selected);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error eliminando usuario: {ex.Message}");
                    }
                }
            }
        }

        // Refrescar tabla
        private void Refresh_Click(object sender, RoutedEventArgs e) => LoadUsers();

        // Guardar cambios al terminar de editar una celda

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
           
            if (dgUsers.SelectedItem is User selected)
            {
                

                try
                {
                    using var con = new NpgsqlConnection(connString);
                    con.Open();

                    string query = "UPDATE users SET username=@u, password_hash=@p, role=@r WHERE user_id=@id";
                    using var cmd = new NpgsqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@u", selected.Username);
                    cmd.Parameters.AddWithValue("@p", selected.Contrseña);
                    cmd.Parameters.AddWithValue("@r", selected.Role);
                    cmd.Parameters.AddWithValue("@id", selected.UserId);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error actualizando usuario: {ex.Message}");
                }
            }

        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string Contrseña { get; set; } = "";
        public string Role { get; set; } = "User";
    }
}
