using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Veterinaria.DB;
using Newtonsoft.Json;
using System.IO;

namespace Veterinaria.Views
{
    /// <summary>
    /// Lógica de interacción para loginView.xaml
    /// </summary>
    public partial class loginView : Window
    {

        public loginView()
        {
            InitializeComponent();
        }

        private void OpenRegisterView_Click(object sender, RoutedEventArgs e)
        {
            UserRegisterView registerView = new UserRegisterView();
            this.Close();
            registerView.Show();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private async void LogIn_Click(object sender, RoutedEventArgs e)
        {
            CanvasLoading.Visibility = Visibility.Visible;
            string email = TextBoxEmail.Text;
            string password = TextBoxPassword.Password;
            DataBase db = new DataBase("localhost", "pet_control", "root");
            string DBpassword = db.executeQuery($"SELECT Password from Cliente WHERE Email='{email}'").Trim();
            await Task.Delay(1500);
            if (password.Equals(DBpassword) && password.Length > 0)
            {
                CanvasLoading.Visibility = Visibility.Hidden;
                string userName = db.executeQuery($"SELECT Nombre from Cliente WHERE Email='{email}'").Trim();
                string userSurename = db.executeQuery($"SELECT Apellidos from Cliente WHERE Email='{email}'").Trim();
                string idStr = db.executeQuery($"SELECT Id from Cliente WHERE Email = '{email}'").Trim();
                int id = int.Parse(idStr);
                ReadData rd = new ReadData();
                rd.saveUserInJSON(id, email, userName, userSurename, password);
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }
            else
            {
                CanvasLoading.Visibility = Visibility.Hidden;
                CanvasError.Visibility = Visibility.Visible;
            }
        }

        private void closeCanvas_Click(object sender, RoutedEventArgs e)
        {
            CanvasError.Visibility = Visibility.Hidden;
        }

    }
}
