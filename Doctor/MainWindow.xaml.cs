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
            //InicializarPantalla();
            InitializeComponent();
            
        }

        void InicializarPantalla()
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
            arduinoPort.Close();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            open.Visibility = Visibility.Visible;
            close.Visibility = Visibility.Collapsed;
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            open.Visibility = Visibility.Collapsed;
            close.Visibility = Visibility.Visible;
        }
    }
}
