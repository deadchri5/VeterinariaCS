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
using Doctor.Models.ViewsModels;

namespace Doctor.Views
{
    /// <summary>
    /// Lógica de interacción para DataDoc.xaml
    /// </summary>
    public partial class DataDoc : UserControl
    {
        public DataDoc()
        {
            InitializeComponent();
            DataContext = new DataDocModel();
        }
    }
}
