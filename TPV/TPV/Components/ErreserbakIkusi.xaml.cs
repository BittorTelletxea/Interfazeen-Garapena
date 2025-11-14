using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TPV.Components
{
    partial class ErreserbakIkusi
    {
        private string connString = "Host=localhost;Port=5432;Database=tpv;Username=tpv;Password=tpv";
        private bool bazkariada = true;

        public ErreserbakIkusi()
        {
            InitializeComponent();
            kargatuErreserbak();
        }
        private void kargatuErreserbak()
        {
            bazkariada = true;
            btnBazkaria.Background = System.Windows.Media.Brushes.LightBlue;
            btnAfaria.Background = System.Windows.Media.Brushes.LightGray;

            btn1.Background = System.Windows.Media.Brushes.Green;
            btn2.Background = System.Windows.Media.Brushes.Green;
            btn3.Background = System.Windows.Media.Brushes.Green;
            btn4.Background = System.Windows.Media.Brushes.Green;
            btn5.Background = System.Windows.Media.Brushes.Green;
            btn6.Background = System.Windows.Media.Brushes.Green;
            btn7.Background = System.Windows.Media.Brushes.Green;
            btn8.Background = System.Windows.Media.Brushes.Green;
            btn9.Background = System.Windows.Media.Brushes.Green;
            btn1.Content = "1";
            btn2.Content = "2";
            btn3.Content = "3";
            btn4.Content = "4";
            btn5.Content = "5";
            btn6.Content = "6";
            btn7.Content = "7";
            btn8.Content = "8";
            btn9.Content = "9";

            string eguna = btnAukeratuData.Content.ToString();
            string gaurkoEguna = DateTime.Now.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(eguna) || eguna.Equals("Aukeratu data"))
            {
                eguna = gaurkoEguna;
            }

            try
            {
                using var con = new NpgsqlConnection(connString);
                con.Open();
                string query = "SELECT mahaia FROM erreserbak WHERE bazkaria=true and eguna = @e ORDER BY erreserba_id";
                using var cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@e", eguna);
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
            string eguna = btnAukeratuData.Content.ToString();
            string gaurkoEguna = DateTime.Now.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(eguna) || eguna.Equals("Aukeratu data"))
            {
                eguna = gaurkoEguna;
            }

            var dialog = new Erreserbatu();

            if (mahaiaString.Equals("Erreserbatua"))
            {
                using var con = new NpgsqlConnection(connString);
                con.Open();
                string query = "SELECT izena, ordua ,eguna, pertsonak,mahaia FROM  erreserbak WHERE mahaia = @m and eguna = @e";
                using var cmd = new NpgsqlCommand(query, con);

                cmd.Parameters.AddWithValue("@m",mahaiaNumberStr);
                
                cmd.Parameters.AddWithValue("@e", eguna);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var izena = reader.GetString(0).ToString();
                    var ordua = reader.GetString(1).ToString();
                    var egunaSelect = reader.GetString(2).ToString();
                    var pertsonak =  reader.GetInt32(3).ToString();
                    var datuakIkusi = new ErreserbatutaDago(izena, ordua, egunaSelect, pertsonak);

                    bool? result = datuakIkusi.ShowDialog();
                    if (result == true)
                    {
                        try
                        {
                            using var conDel = new NpgsqlConnection(connString);
                            conDel.Open();
                            string queryDel = "DELETE FROM erreserbak WHERE mahaia = @m and eguna = @e;";
                            using var cmdDel = new NpgsqlCommand(queryDel, conDel);
                            cmdDel.Parameters.AddWithValue("@m", mahaiaNumberStr);
                            cmdDel.Parameters.AddWithValue("@e", eguna);
                            cmdDel.ExecuteNonQuery();
                            kargatuErreserbak();
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show($"Errorea erreserba ezabatzerakoan: {ex.Message}");
                        }
                    }
                }
            
            } else {
                int mahaia = int.Parse(mahaiaString);
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        using var con = new NpgsqlConnection(connString);
                        con.Open();
                        string query = "INSERT INTO erreserbak (izena, ordua ,bazkaria, pertsonak,mahaia,eguna ) VALUES (@i, @o, @b, @p, @m, @e);";
                        using var cmd = new NpgsqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@i", dialog.izena);
                        cmd.Parameters.AddWithValue("@o", dialog.ordua);
                        if (bazkariada)
                        {
                            cmd.Parameters.AddWithValue("@b", true);

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@b", false);

                        }
                        cmd.Parameters.AddWithValue("@p", dialog.pertsonak);
                        cmd.Parameters.AddWithValue("@m", mahaia);
                        cmd.Parameters.AddWithValue("@e", eguna);
                        cmd.ExecuteNonQuery();

                        if(bazkariada)
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
            bazkariada = false;
            btnBazkaria.Background = System.Windows.Media.Brushes.LightGray;
            btnAfaria.Background = System.Windows.Media.Brushes.LightBlue;

            btn1.Background = System.Windows.Media.Brushes.Green;
            btn2.Background = System.Windows.Media.Brushes.Green;
            btn3.Background = System.Windows.Media.Brushes.Green;
            btn4.Background = System.Windows.Media.Brushes.Green;
            btn5.Background = System.Windows.Media.Brushes.Green;
            btn6.Background = System.Windows.Media.Brushes.Green;
            btn7.Background = System.Windows.Media.Brushes.Green;
            btn8.Background = System.Windows.Media.Brushes.Green;
            btn9.Background = System.Windows.Media.Brushes.Green;
            btn1.Content = "1";
            btn2.Content = "2";
            btn3.Content = "3";
            btn4.Content = "4";
            btn5.Content = "5";
            btn6.Content = "6";
            btn7.Content = "7";
            btn8.Content = "8";
            btn9.Content = "9";

            string eguna = btnAukeratuData.Content.ToString();
            string gaurkoEguna = DateTime.Now.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(eguna) || eguna.Equals("Aukeratu data"))
            {
                eguna = gaurkoEguna;
            }

            try
            {
                using var con = new NpgsqlConnection(connString);
                con.Open();
                string query = "SELECT mahaia FROM erreserbak WHERE bazkaria=false and eguna = @e ORDER BY erreserba_id";
                using var cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@e", eguna);
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
            btnBazkaria.Background = System.Windows.Media.Brushes.LightBlue;
            btnAfaria.Background = System.Windows.Media.Brushes.LightGray;

            btn1.Background = System.Windows.Media.Brushes.Green;
            btn2.Background = System.Windows.Media.Brushes.Green;
            btn3.Background = System.Windows.Media.Brushes.Green;
            btn4.Background = System.Windows.Media.Brushes.Green;
            btn5.Background = System.Windows.Media.Brushes.Green;
            btn6.Background = System.Windows.Media.Brushes.Green;
            btn7.Background = System.Windows.Media.Brushes.Green;
            btn8.Background = System.Windows.Media.Brushes.Green;
            btn9.Background = System.Windows.Media.Brushes.Green;
            btn1.Content = "1";
            btn2.Content = "2";
            btn3.Content = "3";
            btn4.Content = "4";
            btn5.Content = "5";
            btn6.Content = "6";
            btn7.Content = "7";
            btn8.Content = "8";
            btn9.Content = "9";

            string eguna = btnAukeratuData.Content.ToString();
            string gaurkoEguna = DateTime.Now.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(eguna) || eguna.Equals("Aukeratu data"))
            {
                eguna = gaurkoEguna;
            }

            try
            {
                using var con = new NpgsqlConnection(connString);
                con.Open();
                string query = "SELECT mahaia FROM erreserbak WHERE bazkaria=true and eguna = @e ORDER BY erreserba_id";
                using var cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@e", eguna);
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
        private void btnAukeratuData_Click(object sender, RoutedEventArgs e)
        {
            popupKalendarioa.IsOpen = true;
        }

        private void eguna_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (eguna.SelectedDate != null)
            {
                btnAukeratuData.Content = eguna.SelectedDate.Value.ToString("yyyy-MM-dd");
                kargatuErreserbak();
            }

            popupKalendarioa.IsOpen = false; 
        }
        


    }
}
