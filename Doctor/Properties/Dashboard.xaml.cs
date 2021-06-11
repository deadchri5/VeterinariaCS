using Doctor.Models;
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
using System.Windows.Shapes;
using Doctor.Models.ViewsModels;

namespace Doctor.Properties
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {

        string userName { get; set; }
        User user {get; set;}

        public Dashboard()
        {
            InitializeComponent();
            getUserData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu.Visibility = Visibility.Visible;
            CloseMenu.Visibility = Visibility.Collapsed;
        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu.Visibility = Visibility.Collapsed;
            CloseMenu.Visibility = Visibility.Visible;
        }

        private void getUserData() 
        {
            ReadData rd = new ReadData();
            user = rd.getJSON();
            userName = $"{user.Name} {user.SureName}";
            TextBlockUserName.DataContext = userName;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "AgendDate":
                    DataContext = new FinalizarCitaModel();
                    break;
                case "verDatos":
                    DataContext = new DataDocModel();
                    break;
                default:
                    break;
            }
        }
    }
}
