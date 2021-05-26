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
    /// Lógica de interacción para PetRegisterView.xaml
    /// </summary>
    public partial class PetRegisterView : UserControl
    {

        public PetRegisterView()
        {
            InitializeComponent();
        }

        private void showAgeLegend(String _type, int _age)
        {
            MessageBox.Show($"Un {_type} no puede tener más de {_age} años", "Comprueba los datos",
                                                             MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool checkAge(String _type, int _age)
        {
            switch (_type)
            {
                case "Perro":
                    if (_age > 29)
                    {
                        showAgeLegend(_type, _age);
                        return false;
                    }
                    break;
                case "Gato":
                    if (_age > 32)
                    {
                        showAgeLegend(_type, _age);
                        return false;
                    }
                    break;
                default:
                    return true;
            }
            return true;
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            String name = TextBoxName.Text;
            int age = 0;
            String genere = "Desconocido";
            String type = ComboBoxType.Text;

            if (name.Length <= 0 || TextBoxAge.Text.Length <= 0 || type.Length <= 0)
            {
                MessageBox.Show("Hay campos vacios.", "Llena el formulario por favor", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try { age = int.Parse(TextBoxAge.Text); }
            catch(Exception ex) { 
                MessageBox.Show($"El campo de edad solo admite valores númericos positivos.\nMotivo: {ex.Message}", 
                        "Error en campo de edad", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (age < 0)
            {
                age *= -1;
                TextBoxAge.Text = age.ToString();
            }
            if (RadioButtonMacho.IsChecked == true)
                genere = "Macho";
            if (RadioButtonHembra.IsChecked == true)
                genere = "Hembra";
            if (checkAge(type, age)) {
                //Registro de animal a la base de datos
                MessageBox.Show($"Nombre: {name}\nEdad: {age}\nSexo: {genere}\nTipo: {type}", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
