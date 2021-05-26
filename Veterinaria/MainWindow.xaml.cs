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

namespace Veterinaria
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "AgendDate":
                    DataContext = new AgendDateModel();
                    MessageBox.Show("hola, soy el trunco lopez");
                    break;
                case "RegisterPet":
                    DataContext = new PetRegisterModel();
                    break;
                case "PendingDates":
                    DataContext = new ViewDatesModel();
                    break;
                case "Account":
                    DataContext = new EditUserDataModel();
                    break;
                default:
                    break;
            }
        }
    }
}
