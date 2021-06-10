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

namespace Doctor
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
  
    public partial class MainWindow : Window
    {
        SerialPort arduinoPort;
         
        public MainWindow()
        {
            
            InitializeComponent();
            //initializePort();
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
            Properties.Dashboard dash = new Properties.Dashboard();
            dash.Show();
            this.Close();
        }
    }
}
