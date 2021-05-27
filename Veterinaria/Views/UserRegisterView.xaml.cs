using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Veterinaria.Views
{
    /// <summary>
    /// Lógica de interacción para UserRegisterView.xaml
    /// </summary>
    public partial class UserRegisterView : Window
    {
        public UserRegisterView()
        {
            InitializeComponent();
        }

        DataBase db = new DataBase("localhost", "pet_control", "root");

        private void OpenLoginView_Click(object sender, RoutedEventArgs e)
        {
            loginView loginView = new loginView();
            this.Close();
            loginView.Show();
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            CanvasLoading.Visibility = Visibility.Visible;
            string name = TextBoxName.Text;
            string apellido = TextBoxApellido.Text;
            string email = TextBoxEmail.Text;
            string password = TextBoxPassword.Password;

            if (name.Length > 0 && apellido.Length > 0 && password.Length > 0)
            {
                if (IsValidEmailAddress(email))
                {
                    db.executeInsert("INSERT INTO cliente(Nombre, Apellidos, Email, Password, FK_tipo) " +
                                    $"VALUES ('{name}', '{apellido}', '{email}', '{password}', '2')");
                    CanvasLoading.Visibility = Visibility.Hidden;
                    CanvasDone.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Ingresa una dirección de correo eléctronico en formato correcto.",
                                        "Error en registro", MessageBoxButton.OK, MessageBoxImage.Error);
                    CanvasLoading.Visibility = Visibility.Hidden;
                }
                    
            }
            else
            {
                MessageBox.Show("Porfavor llena todos los campos del formulario.",
                    "Error en registro", MessageBoxButton.OK, MessageBoxImage.Error);
                CanvasLoading.Visibility = Visibility.Hidden;
            }
        }

        private bool IsValidEmailAddress(string email)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }
    }
}
