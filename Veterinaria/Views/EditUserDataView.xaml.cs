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
using Veterinaria.Models;
using Veterinaria.ViewModels;

namespace Veterinaria.Views
{
    /// <summary>
    /// Lógica de interacción para EditUserDataView.xaml
    /// </summary>
    public partial class EditUserDataView : UserControl
    {

        EditUserDataModel userDataModel;

        public EditUserDataView()
        {
            InitializeComponent();
            checkItemsControl();
            userDataModel = new EditUserDataModel();
            DataContext = userDataModel;
        }

        private void checkItemsControl()
        {
            int pets = itemControlPets.Items.Count;
            if (pets <= 0)
            {
                itemControlPets.Visibility = Visibility.Hidden;
                CanvasPetsInfo.Visibility = Visibility.Visible;
            }
            else
            {
                itemControlPets.Visibility = Visibility.Visible;
                CanvasPetsInfo.Visibility = Visibility.Hidden;
            }
        }

        private void Password_Changed(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
            }
        }

        private void EditData_Click(object sender, RoutedEventArgs e)
        {
            CanvasPassword.Visibility = Visibility.Visible;
        }

        private void ClosePasswordCanvas_Click(object sender, RoutedEventArgs e)
        {
            CanvasPassword.Visibility = Visibility.Hidden;
        }

        private async void ConfirmPassword_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(1000);
            if (((dynamic)DataContext).isSuccess)
            {
                CanvasSuccess.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                CanvasSuccess.Visibility = Visibility.Hidden;
            }
            if (((dynamic)DataContext).isError)
            {
                CanvasError.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                CanvasError.Visibility = Visibility.Hidden;
            }
        }
    }
}
