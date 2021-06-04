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
using Veterinaria.Models;

namespace Veterinaria
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string welcomeMsj { get; set; } = "Bienvenido usuario!";

        public MainWindow()
        {
            InitializeComponent();
            getUserData();
            InitialMsg.DataContext = welcomeMsj;
        }

        private void getUserData()
        {
            ReadData rd = new ReadData();
            User user = new User();
            user = rd.getJSON();
            welcomeMsj = $"¡Hola {user.Name}!";
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "AgendDate":
                    DataContext = new AgendDateModel();
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

        private void buttonAction_Click(object sender, RoutedEventArgs e)
        {
            string action = ((Button)sender).Content.ToString();
            switch (action)
            {
                case "Agendar cita.":
                    DataContext = new AgendDateModel();
                    break;
                case "Registrar mascota.":
                    DataContext = new PetRegisterModel();
                    break;
                case "Ver citas pendientes.":
                    DataContext = new ViewDatesModel();
                    break;
                case "Ver datos de mi cuenta.":
                    DataContext = new EditUserDataModel();
                    break;
            }
        }

    }
}
