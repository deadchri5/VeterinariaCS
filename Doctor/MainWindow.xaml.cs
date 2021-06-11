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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using Doctor.DB;

namespace Doctor
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
  
    public partial class MainWindow : Window
    {

        public string email { get; set; }
        public string constrasena { get; set; }
        SerialPort arduinoPort;
         
        public MainWindow()
        {
            
            InitializeComponent();
            DataContext = this;
            initializePort();
            TextBoxEmail.Text = "chris@veterinaria.com";
            PasswordBoxContraseña.Password = "123";
        }


        void initializePort()
        {
            arduinoPort = new SerialPort
            {
                BaudRate = 9600,
                PortName = "COM3",            
            };
            arduinoPort.Open();
            arduinoPort.Write("Bienvenido");
        }

        private void windowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(arduinoPort.IsOpen)
            {
                arduinoPort.Close();
            }
        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Properties.Regis reg = new Properties.Regis();
            reg.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            email = TextBoxEmail.Text;
            constrasena = PasswordBoxContraseña.Password;
            DataBase db = new DataBase("localhost", "pet_control", "root");
            if (!email.Equals("") && !constrasena.Equals(""))
            {
                string ContrasenaDB = db.executeQuery($"SELECT Password from doctor WHERE Email='{email}'").Trim();
                if (constrasena.Equals(ContrasenaDB))
                {
                    string nombreDoctor = db.executeQuery($"SELECT Nombre from doctor WHERE Email='{email}'").Trim();
                    string apellidoDoctor = db.executeQuery($"SELECT Apellidos from doctor WHERE Email='{email}'").Trim();
                    string idDoctor = db.executeQuery($"SELECT Id from doctor WHERE Email = '{email}'").Trim();
                    int id = int.Parse(idDoctor);
                    ReadData rd = new ReadData();
                    rd.saveUserInJSON(id, email, nombreDoctor, apellidoDoctor, constrasena);
                    MessageBox.Show($"Bienvendo al panel de control {nombreDoctor} {apellidoDoctor}", "Hola.");
                    Properties.Dashboard dash = new Properties.Dashboard();
                    dash.Show();
                    this.Close();
                }
            }
        }
    }
}
