using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Veterinaria.Models;
using Veterinaria.DB;
using Veterinaria.ViewModels.Commands;

namespace Veterinaria.ViewModels
{
    public class EditUserDataModel
    {

        public int id { get; set; }
        public string name { get; set; }
        public string sureName { get; set; }
        public string email { get; set; }
        private string password { get; set; }
        public List<string> pets { get; set; }

        public string confirmPassword { get; set; }
        public bool isSuccess { get; set; } = false;
        public bool isError { get; set; } = false;

        public EditUserDataCommand editUserDataCommand { get; private set; }

        public EditUserDataModel()
        {
            loadUserJSON();
            showUserPets();
            editUserDataCommand = new EditUserDataCommand(updateDataInfo);
        }

        public string Password {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        private void updateDataInfo()
        {
            isError = false;
            isSuccess = false;
            if (Password != null)
            {
                if (Password.Equals(confirmPassword))
                {
                    if (name != null && sureName != null && email != null)
                    {
                        DataBase db = new DataBase("localhost", "pet_control", "root");
                        db.executeInsert($"UPDATE cliente SET Nombre = '{name}', Apellidos = '{sureName}', Email = '{email}'" +
                                                                                                            $"WHERE Id = {id}");
                        ReadData rd = new ReadData();
                        rd.saveUserInJSON(id, email, name, sureName, password);
                        isSuccess = true;
                    }
                }
                else
                {
                    isError = true;
                }
            }
        }

        private void loadUserJSON()
        {
            ReadData rd = new ReadData();
            User user = rd.getJSON();
            id = user.Id;
            name = user.Name;
            sureName = user.SureName;
            email = user.Email;
            confirmPassword = user.Password;
        }

        private void showUserPets()
        {
            DataBase db = new DataBase("localhost", "pet_control", "root");
            pets = db.exectueAdvancedQuery($"SELECT Nombre FROM mascota WHERE Fk_dueno = {id}");
        }

    }
}
