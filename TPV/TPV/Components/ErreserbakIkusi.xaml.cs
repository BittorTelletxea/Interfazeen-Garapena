using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TPV.Components
{
    partial class ErreserbakIkusi
    {
        private string connString = "Host=localhost;Port=5432;Database=tpv;Username=tpv;Password=tpv";

        public ErreserbakIkusi()
        {
            InitializeComponent();
            kargatuErreserbak();
        }
        private void kargatuErreserbak()
        {
            btn1.Background = System.Windows.Media.Brushes.LightGreen;
            btn2.Background = System.Windows.Media.Brushes.LightGreen;
            btn3.Background = System.Windows.Media.Brushes.LightGreen;
            btn4.Background = System.Windows.Media.Brushes.LightGreen;
            btn5.Background = System.Windows.Media.Brushes.LightGreen;
            btn6.Background = System.Windows.Media.Brushes.LightGreen;
            btn7.Background = System.Windows.Media.Brushes.LightGreen;
            btn8.Background = System.Windows.Media.Brushes.LightGreen;
            btn9.Background = System.Windows.Media.Brushes.LightGreen;
            btn1.Content = "1";
            btn2.Content = "2";
            btn3.Content = "3";
            btn4.Content = "4";
            btn5.Content = "5";
            btn6.Content = "6";
            btn7.Content = "7";
            btn8.Content = "8";
            btn9.Content = "9";

            try
            {
                using var con = new NpgsqlConnection(connString);
                con.Open();
                string query = "SELECT mahaia FROM erreserbak WHERE bazkaria=true ORDER BY erreserba_id";
                using var cmd = new NpgsqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var mahaia = reader.GetInt32(0);
                    switch (mahaia)
                    {
                        case 1:
                            btn1.Content = "Erreserbatua";
                            btn1.Background = System.Windows.Media.Brushes.Red;
                            break;
                        case 2:
                            btn2.Content = "Erreserbatua";
                            btn2.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 3:
                            btn3.Content = "Erreserbatua";
                            btn3.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 4:
                            btn4.Content = "Erreserbatua";
                            btn4.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 5:
                            btn5.Content = "Erreserbatua";
                            btn5.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 6:
                            btn6.Content = "Erreserbatua";
                            btn6.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 7:
                            btn7.Content = "Erreserbatua";
                            btn7.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 8:
                            btn8.Content = "Erreserbatua";
                            btn8.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 9:
                            btn9.Content = "Erreserbatua";
                            btn9.Background = System.Windows.Media.Brushes.Red;

                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Errorea erreserbak kargatzerakoan: {ex.Message}");
            }
        }

        private void btn1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var boton = sender as Button;
            string mahaiaString = boton.Content.ToString();
            int mahaiaNumberStr = int.Parse(boton.Name.Replace("btn", ""));

            var dialog = new Erreserbatu();

            if (mahaiaString.Equals("Erreserbatua"))
            {
                using var con = new NpgsqlConnection(connString);
                con.Open();
                string query = "SELECT izena, ordua ,bazkaria, pertsonak,mahaia FROM  erreserbak WHERE mahaia = @m";
                using var cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@m",mahaiaNumberStr);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var izena = reader.GetString(0).ToString();
                    var ordua = reader.GetString(1).ToString();
                    var bazkaria = reader.GetBoolean(2);
                    var pertsonak =  reader.GetInt32(3).ToString();
                    var datuakIkusi = new ErreserbatutaDago(izena, ordua, bazkaria, pertsonak);
                    datuakIkusi.ShowDialog();
                }
            
            } else {
                int mahaia = int.Parse(mahaiaString);
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        using var con = new NpgsqlConnection(connString);
                        con.Open();
                        string query = "INSERT INTO erreserbak (izena, ordua ,bazkaria, pertsonak,mahaia ) VALUES (@i, @o, @b, @p, @m);";
                        using var cmd = new NpgsqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@i", dialog.izena);
                        cmd.Parameters.AddWithValue("@o", dialog.ordua);
                        if (dialog.bazkariCombo.Equals("Bazkaria"))
                        {
                            cmd.Parameters.AddWithValue("@b", true);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@b", false);

                        }
                        cmd.Parameters.AddWithValue("@p", dialog.pertsonak);
                        cmd.Parameters.AddWithValue("@m", mahaia);
                        cmd.ExecuteNonQuery();

                        if(dialog.bazkariCombo.Equals("Bazkaria"))
                        {
                            loadAfariak(sender, e);
                        }
                        else
                        {
                            kargatuBazkariak(sender, e);
                        }

                        kargatuErreserbak();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show($"Errorea erreserba gordetzerakoan: {ex.Message}");
                    }
                }
            }
        }

        private void loadAfariak(object sender, System.Windows.RoutedEventArgs e)
        {
            btn1.Background = System.Windows.Media.Brushes.LightGreen;
            btn2.Background = System.Windows.Media.Brushes.LightGreen;
            btn3.Background = System.Windows.Media.Brushes.LightGreen;
            btn4.Background = System.Windows.Media.Brushes.LightGreen;
            btn5.Background = System.Windows.Media.Brushes.LightGreen;
            btn6.Background = System.Windows.Media.Brushes.LightGreen;
            btn7.Background = System.Windows.Media.Brushes.LightGreen;
            btn8.Background = System.Windows.Media.Brushes.LightGreen;
            btn9.Background = System.Windows.Media.Brushes.LightGreen;
            btn1.Content = "1";
            btn2.Content = "2";
            btn3.Content = "3";
            btn4.Content = "4";
            btn5.Content = "5";
            btn6.Content = "6";
            btn7.Content = "7";
            btn8.Content = "8";
            btn9.Content = "9";

            try
            {
                using var con = new NpgsqlConnection(connString);
                con.Open();
                string query = "SELECT mahaia FROM erreserbak WHERE bazkaria=false ORDER BY erreserba_id";
                using var cmd = new NpgsqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var mahaia = reader.GetInt32(0);
                    switch (mahaia)
                    {
                        case 1:
                            btn1.Content = "Erreserbatua";
                            btn1.Background = System.Windows.Media.Brushes.Red;
                            break;
                        case 2:
                            btn2.Content = "Erreserbatua";
                            btn2.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 3:
                            btn3.Content = "Erreserbatua";
                            btn3.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 4:
                            btn4.Content = "Erreserbatua";
                            btn4.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 5:
                            btn5.Content = "Erreserbatua";
                            btn5.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 6:
                            btn6.Content = "Erreserbatua";
                            btn6.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 7:
                            btn7.Content = "Erreserbatua";
                            btn7.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 8:
                            btn8.Content = "Erreserbatua";
                            btn8.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 9:
                            btn9.Content = "Erreserbatua";
                            btn9.Background = System.Windows.Media.Brushes.Red;

                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Errorea erreserbak kargatzerakoan: {ex.Message}");
            }
        }

        private void kargatuBazkariak(object sender, System.Windows.RoutedEventArgs e) {

            btn1.Background = System.Windows.Media.Brushes.LightGreen;
            btn2.Background = System.Windows.Media.Brushes.LightGreen;
            btn3.Background = System.Windows.Media.Brushes.LightGreen;
            btn4.Background = System.Windows.Media.Brushes.LightGreen;
            btn5.Background = System.Windows.Media.Brushes.LightGreen;
            btn6.Background = System.Windows.Media.Brushes.LightGreen;
            btn7.Background = System.Windows.Media.Brushes.LightGreen;
            btn8.Background = System.Windows.Media.Brushes.LightGreen;
            btn9.Background = System.Windows.Media.Brushes.LightGreen;
            btn1.Content = "1";
            btn2.Content = "2";
            btn3.Content = "3";
            btn4.Content = "4";
            btn5.Content = "5";
            btn6.Content = "6";
            btn7.Content = "7";
            btn8.Content = "8";
            btn9.Content = "9";
            try
            {
                using var con = new NpgsqlConnection(connString);
                con.Open();
                string query = "SELECT mahaia FROM erreserbak WHERE bazkaria=true ORDER BY erreserba_id ";
                using var cmd = new NpgsqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var mahaia = reader.GetInt32(0);
                    switch (mahaia)
                    {
                        case 1:
                            btn1.Content = "Erreserbatua";
                            btn1.Background = System.Windows.Media.Brushes.Red;
                            break;
                        case 2:
                            btn2.Content = "Erreserbatua";
                            btn2.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 3:
                            btn3.Content = "Erreserbatua";
                            btn3.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 4:
                            btn4.Content = "Erreserbatua";
                            btn4.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 5:
                            btn5.Content = "Erreserbatua";
                            btn5.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 6:
                            btn6.Content = "Erreserbatua";
                            btn6.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 7:
                            btn7.Content = "Erreserbatua";
                            btn7.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 8:
                            btn8.Content = "Erreserbatua";
                            btn8.Background = System.Windows.Media.Brushes.Red;

                            break;
                        case 9:
                            btn9.Content = "Erreserbatua";
                            btn9.Background = System.Windows.Media.Brushes.Red;

                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Errorea erreserbak kargatzerakoan: {ex.Message}");
            }
        }
    
    }
}
