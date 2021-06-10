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

namespace Doctor.Properties
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
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
    }
}
