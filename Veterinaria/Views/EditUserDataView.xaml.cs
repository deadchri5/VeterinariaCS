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

namespace Veterinaria.Views
{
    /// <summary>
    /// Lógica de interacción para EditUserDataView.xaml
    /// </summary>
    public partial class EditUserDataView : UserControl
    {

        public EditUserDataView()
        {
            InitializeComponent();
            checkItemsControl();
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

    }
}
