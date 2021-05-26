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

namespace Veterinaria.Views
{
    /// <summary>
    /// Lógica de interacción para UserRegisterView.xaml
    /// </summary>
    public partial class UserRegisterView : Window
    {
        public UserRegisterView()
        {
            InitializeComponent();
        }

        private void OpenLoginView_Click(object sender, RoutedEventArgs e)
        {
            loginView loginView = new loginView();
            this.Close();
            loginView.Show();
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
