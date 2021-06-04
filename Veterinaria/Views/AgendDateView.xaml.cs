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
        public AgendDateView()
        {
            DataContext = new AgendDateModel();
            InitializeComponent();
        }

        private void agregarCita(object sender, RoutedEventArgs e)
        {
            if (ComboboxReason.SelectedItem != null && ComboBoxPet.SelectedItem != null
                && ComboBoxDoctor.SelectedItem != null)
            {
                ((dynamic)DataContext).reason = ComboboxReason.SelectedItem.ToString();
                ((dynamic)DataContext).petName = ComboBoxPet.SelectedItem.ToString();
                ((dynamic)DataContext).doctor = ComboBoxDoctor.SelectedItem.ToString();
            }
            else
                MessageBox.Show("Tienes que llenar todos los campos obligatiorios para agendar una cita",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
