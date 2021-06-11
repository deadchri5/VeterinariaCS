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
using Doctor.DB;
using Doctor.Models;
using Doctor.Models.ViewsModels;

namespace Doctor.Views
{
    /// <summary>
    /// Interaction logic for FinalizarCita.xaml
    /// </summary>
    public partial class FinalizarCita : Page
    {
        FinalizarCitaModel finalizarCitaModel;
        public FinalizarCita()
        {
            InitializeComponent();
            finalizarCitaModel = new FinalizarCitaModel();
            DataContext = finalizarCitaModel;
            checkNumberOfDates();                     
        }

        private void checkNumberOfDates()
        {
            if (finalizarCitaModel.doctorHaveDates)
            {
                dateData.Visibility = Visibility.Visible;
                withoutDateData.Visibility = Visibility.Hidden;
            }
            else
            {
                withoutDateData.Visibility = Visibility.Visible;
                dateData.Visibility = Visibility.Hidden;
                txtNumCita.Text = "00";
            }
        }
        private void btnSkipDate(object sender, RoutedEventArgs e)
        {
            finalizarCitaModel.nextDate();
            checkNumberOfDates();
            DataContext = finalizarCitaModel;
        }
    }
}
