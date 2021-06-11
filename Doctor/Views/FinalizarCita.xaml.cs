using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;
using Doctor.Models.ViewsModels;
using System.ComponentModel;

namespace Doctor.Views
{

    public partial class FinalizarCita : Page
    {
        FinalizarCitaModel finalizarCitaModel;
        private SerialPort arduinoPort;
        public FinalizarCita()
        {
            InitializeComponent();
            finalizarCitaModel = new FinalizarCitaModel();
            DataContext = finalizarCitaModel;
            initializePort();
            checkNumberOfDates();
            txtFolio.DataContext = ((dynamic)DataContext).Folio;
            txtCliente.DataContext = ((dynamic)DataContext).Cliente;
            txtMascota.DataContext = ((dynamic)DataContext).Mascota;
            txtAnimal.DataContext = ((dynamic)DataContext).Animal;
            txtSexo.DataContext = ((dynamic)DataContext).Sexo;
            txtAge.DataContext = ((dynamic)DataContext).Edad;
            txtMotivo.DataContext = ((dynamic)DataContext).Motivo;
            txtNotas.DataContext = ((dynamic)DataContext).Notas;
            txtNumCita.DataContext = ((dynamic)DataContext).numCita;
        }

        void initializePort()
        {
            arduinoPort = new SerialPort
            {
                BaudRate = 9600,
                PortName = "COM3",
            };
            arduinoPort.Open();
        }

        private void checkNumberOfDates()
        {
            if (finalizarCitaModel.doctorHaveDates)
            {
                dateData.Visibility = Visibility.Visible;
                withoutDateData.Visibility = Visibility.Hidden;
                arduinoPort.Write($"Cita Num: 00{finalizarCitaModel.numCita}");
            }
            else
            {
                withoutDateData.Visibility = Visibility.Visible;
                dateData.Visibility = Visibility.Hidden;
                txtNumCita.Text = "00";
                arduinoPort.Write("Sin citas.");
            }
        }
        private void btnSkipDate(object sender, RoutedEventArgs e)
        { 
            finalizarCitaModel.nextDate();
            checkNumberOfDates();
            DataContext = finalizarCitaModel;
            txtFolio.DataContext = ((dynamic)DataContext).Folio;
            txtCliente.DataContext = ((dynamic)DataContext).Cliente;
            txtMascota.DataContext = ((dynamic)DataContext).Mascota;
            txtAnimal.DataContext = ((dynamic)DataContext).Animal;
            txtSexo.DataContext = ((dynamic)DataContext).Sexo;
            txtAge.DataContext = ((dynamic)DataContext).Edad;
            txtMotivo.DataContext = ((dynamic)DataContext).Motivo;
            txtNotas.DataContext = ((dynamic)DataContext).Notas;
            txtNumCita.DataContext = ((dynamic)DataContext).numCita;
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            arduinoPort.Close();
        }
    }
}
