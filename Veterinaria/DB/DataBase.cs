using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Veterinaria.DB
{
    class DataBase
    {
        private string server;
        private string bd;
        private string user;
        private string connectionString;
        private string data;

        private int count;
        private List<string> list = new List<string>();

        public DataBase(string server, string bd, string user)
        {
            this.server = server;
            this.bd = bd;
            this.user = user;
            this.connectionString = $"Database={bd}; Data Source={server}; User Id={user}; Password=;";
        }

        private void OpenConnection(MySqlConnection con)
        {
            try
            {
                con.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseConnection(MySqlConnection con)
        {
            try
            {
                con.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void executeInsert(string query)
        {
            MySqlConnection connectionDB = new MySqlConnection(connectionString);
            OpenConnection(connectionDB);
            try
            {
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = connectionDB;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data += reader.GetString(0) + "\n";
                }
                if (data != null)
                    //MessageBox.Show(data);
                    CloseConnection(connectionDB);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Error en consulta.", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public string executeQuery(string query)
        {
            data = "";
            MySqlConnection connectionDB = new MySqlConnection(connectionString);
            OpenConnection(connectionDB);
            try
            {
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = connectionDB;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data += reader.GetString(0) + "\n";
                }
                if (data != null)
                    return data;
                CloseConnection(connectionDB);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "SQL error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "SQL error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return "";
        }

        public List<string> exectueAdvancedQuery(string query)
        {
            MySqlConnection connectionDB = new MySqlConnection(connectionString);
            OpenConnection(connectionDB);
            try
            {
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = connectionDB;
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    count = reader.FieldCount;
                    while (reader.Read())
                    {
                        for (var i = 0; i < count; i++)
                        {
                            list.Add(reader.GetValue(i).ToString());
                        }
                    }
                    reader.Close();
                }
                CloseConnection(connectionDB);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "SQL error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "SQL error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return list;
        }

        public DataTable fillQuery(string query)
        {
            DataTable dt = new DataTable("Cita");
            MySqlConnection connectionDB = new MySqlConnection(connectionString);
            OpenConnection(connectionDB);
            try
            {
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = connectionDB;
                MySqlDataAdapter sda = new MySqlDataAdapter(command);
                sda.Fill(dt);
                CloseConnection(connectionDB);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "SQL error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "SQL error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }
    }
}
