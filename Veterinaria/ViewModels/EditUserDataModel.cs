using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Veterinaria.Models;
using Veterinaria.DB;
using Newtonsoft.Json;
using System.IO;

namespace Veterinaria.ViewModels
{
    public class EditUserDataModel
    {

        public int id { get; set; }
        public string name { get; set; }
        public string sureName { get; set; }
        public string email { get; set; }

        public List<string> pets { get; set; }

        public EditUserDataModel()
        {
            loadUserJSON();
            showUserPets();
        }

        private void loadUserJSON()
        {
            ReadData rd = new ReadData();
            User user = rd.getJSON();
            id = user.Id;
            name = user.Name;
            sureName = user.SureName;
            email = user.Email;
        }

        private void showUserPets()
        {
            DataBase db = new DataBase("localhost", "pet_control", "root");
            pets = db.exectueAdvancedQuery($"SELECT Nombre FROM mascota WHERE Fk_dueno = {id}");
        }

    }
}
