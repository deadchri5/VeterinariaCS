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
    /// Lógica de interacción para PetRegisterView.xaml
    /// </summary>
    public partial class PetRegisterView : UserControl
    {

        PetRegisterModel reg;

        public PetRegisterView()
        {
            InitializeComponent();
            reg = new PetRegisterModel();
            DataContext = reg;
        }

        private async void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(1000);
            bool isRegister = reg.isRegister;
            if (isRegister)
                CanvasSuccess.Visibility = Visibility.Visible;
            else
                CanvasError.Visibility = Visibility.Visible;
        }

        private void NotificactionCanvasClose_Click(object sender, RoutedEventArgs e)
        {
            CanvasSuccess.Visibility = Visibility.Hidden;
        }

        private void NotificationErrorCanvasClose_Click(object sender, RoutedEventArgs e)
        {
            CanvasError.Visibility = Visibility.Hidden;
            reg.petName = "";
            reg.petAge = 0;
            reg.kindOfPet = null;
        }
    }
}
