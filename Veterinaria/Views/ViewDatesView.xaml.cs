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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Veterinaria.Views
{
    /// <summary>
    /// Lógica de interacción para ViewDatesView.xaml
    /// </summary>
    public partial class ViewDatesView : UserControl
    {

        public bool canvas { get; set; }

        public ViewDatesView()
        {
            DataContext = new ViewDatesModel();
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            grdEmployee.ItemsSource = ((dynamic)DataContext).dataTable.DefaultView;
            canvas = ((dynamic)DataContext).UserhavePets;
            if (!canvas)
            {
                CanvasNoPets.Visibility = Visibility.Visible;
                grdEmployee.Visibility = Visibility.Hidden;
            }
        }
    }
}
