using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Veterinaria.ViewModels.Commands;
using Veterinaria.Models;

namespace Veterinaria.ViewModels
{
    public class PetRegisterModel
    {
        public string petName { get; set; }
        public uint petAge { get; set; }
        public string kindOfPet { get; set; }
        public string genere { get; set; }
        public int ownerID { get; set; }

        public PetRegisterCommand petRegisterCommand { get; private set; }

        public PetRegisterModel()
        {
            petRegisterCommand = new PetRegisterCommand(registerNewPet);
        }

        private void registerNewPet()
        {
            setUserID();
            if (dataValidate())
            {
                int petInDBformat = assignPetType();
                DB.DataBase db = new DB.DataBase("localhost", "pet_control", "root");
                string q = db.executeQuery("INSERT INTO mascota (Nombre, Sexo, Edad, Fk_tipo, Fk_dueno)"
                                                + $"VALUES('{petName}', 'Macho', {petAge}, {petInDBformat}, {ownerID})");
                MessageBox.Show(q);
            }
        }

        private void setUserID()
        {
            User user = new User();
            ReadData rd = new ReadData();
            user = rd.getJSON();
            ownerID = user.Id;
        }

        private bool dataValidate()
        {
            if (petName != null && petAge >= 0 && kindOfPet != null)
                return true;
            return false;
        }

        private int assignPetType()
        {
            int kind;
            string specie = kindOfPet.Remove(0, 38);
            switch (specie)
            {
                case "Perro":
                    kind = 1;
                    break;
                case "Gato":
                    kind = 2;
                    break;
                case "Roedor":
                    kind = 3;
                    break;
                case "Reptil":
                    kind = 4;
                    break;
                case "Ave":
                    kind = 5;
                    break;
                default:
                    kind = 6;
                break;
            }
            return kind;
        }

    }
}
