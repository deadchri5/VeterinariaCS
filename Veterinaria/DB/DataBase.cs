using System;
using System.Collections.Generic;
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
        private string datos;

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
                    datos += reader.GetString(0) + "\n";
                }
                if (datos != null)
                    MessageBox.Show(datos);
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
            datos = "";
            MySqlConnection connectionDB = new MySqlConnection(connectionString);
            OpenConnection(connectionDB);
            try
            {
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = connectionDB;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datos += reader.GetString(0) + "\n";
                }
                if (datos != null)
                    return datos;
                CloseConnection(connectionDB);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Error en consulta.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return "";
        }

    }
}
