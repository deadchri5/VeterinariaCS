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
            MessageBox.Show("Nito was here");
        }
    }
}
