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
using Veterinaria.ViewModels;

namespace Veterinaria.Views
{
    /// <summary>
    /// Lógica de interacción para AgendDateView.xaml
    /// </summary>
    public partial class AgendDateView : UserControl
    {

        public string name { get; set; }
        public string date { get; set; }
        public string hour { get; set; }
        public string reason { get; set; }
        public string doctor { get; set; }

        public AgendDateView()
        {
            DataContext = new AgendDateModel();
            InitializeComponent();
        }
        private void agregarCita(object sender, RoutedEventArgs e)
        {
            name = $"Mascota: {ComboBoxPet.Text}";
            date = $"Fecha: {DatePickerAppointment.Text}";
            hour = $"Hora: {Hour.Text}";
            doctor = $"Veterinario: {ComboBoxDoctor.Text}";
            reason = $"Razón: {ComboboxReason.Text}";

            //Set canvas data context 
            CanvasPet.DataContext = name;
            CanvasReason.DataContext = reason;
            CanvasDate.DataContext = date;
            CanvasHour.DataContext = hour;
            CanvasVeterinary.DataContext = doctor;

            ((dynamic)DataContext).reason = ComboboxReason.Text;
            ((dynamic)DataContext).petName = ComboBoxPet.Text;
            ((dynamic)DataContext).doctor = ComboBoxDoctor.Text;
            ((dynamic)DataContext).petName = ComboBoxPet.Text;
            showCanvas();
        }

        private async void showCanvas()
        {
            await Task.Delay(300);
            bool success = ((dynamic)DataContext).success;
            bool error = ((dynamic)DataContext).error;
            if (success)
                CanvasSuccess.Visibility = Visibility.Visible;
            if (error)
                CanvasError.Visibility = Visibility.Visible;
        }

        private void CloseSuccesCanvas_Click(object sender, RoutedEventArgs e)
        {
            CanvasSuccess.Visibility = Visibility.Hidden;
        }

        private void CloseErrorCanvas_Click(object sender, RoutedEventArgs e)
        {
            CanvasError.Visibility = Visibility.Hidden;
        }
    }
}
