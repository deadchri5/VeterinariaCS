using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Doctor.Properties
{
    /// <summary>
    /// Lógica de interacción para Regis.xaml
    /// </summary>
    public partial class Regis : Window
    {

        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string confirmacionContraseña { get; set; }

        public Regis()
        {
            DataContext = this;
            InitializeComponent();
            Btn_Registrar.Content = "Registrar";
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonRegistrar_Click(object sender, RoutedEventArgs e)
        {
            nombre = TextBoxNombre.Text;
            apellidos = TextBoxApellido.Text;
            email = TextBoxEmail.Text;
            contraseña = PasswordBoxPass.Password;
            confirmacionContraseña = PasswordBoxConfirmPass.Password;
            if (!nombre.Equals("") && !email.Equals("") && !contraseña.Equals("")
                && !confirmacionContraseña.Equals("") && !apellidos.Equals(""))
            {
                if (contrasenaCoinside())
                {
                    if (comprobarSiYaEstaRegistrado())
                    {
                        DB.DataBase db = new DB.DataBase("localhost", "pet_control", "root");
                        db.executeInsert("INSERT INTO doctor(Nombre, Apellidos, Email, Password, FK_tipo) " 
                                    + $"VALUES('{nombre}', '{apellidos}', '{email}', '{contraseña}', 1)");
                        MessageBox.Show($"Te has registrado con exito: {email}", "Registrado!", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("El correo ya está registgrado en el sistema.\nInicia sesión.", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Los campos de contraseña deben de ser iguales.");
            }
            else
                MessageBox.Show("Error", "Llena TODOS los campos antes de continuar.");
        }

        private bool comprobarSiYaEstaRegistrado()
        {
            DB.DataBase db = new DB.DataBase("localhost", "pet_control", "root");
            string resultadoConsulta = db.executeQuery($"SELECT COUNT(Email) FROM doctor WHERE Email = '{email}'");
            int bandera = int.Parse(resultadoConsulta);
            if (bandera > 0)
            {
                return false;
            }
            return true;
        }

        private bool contrasenaCoinside() {
            if (contraseña.Equals(confirmacionContraseña))
                return true;
            return false;
        }
    }
}
