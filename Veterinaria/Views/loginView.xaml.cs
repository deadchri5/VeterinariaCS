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
    /// Lógica de interacción para loginView.xaml
    /// </summary>
    public partial class loginView : Window
    {
        public loginView()
        {
            InitializeComponent();
        }

        private void OpenRegisterView_Click(object sender, RoutedEventArgs e)
        {
            UserRegisterView registerView = new UserRegisterView();
            this.Close();
            registerView.Show();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
