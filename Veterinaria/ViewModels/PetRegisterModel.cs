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
        public string gender { get; set; }
        public int ownerID { get; set; }

        public bool isRegister = false;

        private bool[] _radioButtons = new bool[] { false, false };

        public PetRegisterCommand petRegisterCommand { get; private set; }

        public PetRegisterModel()
        {
            petRegisterCommand = new PetRegisterCommand(registerNewPet);
        }

        public bool[] RadioArray
        {
            get { return _radioButtons; }
        }
        public int SelectedMode
        {
            get { return Array.IndexOf(_radioButtons, true); }
        }

        private void registerNewPet()
        {
            isRegister = false;
            if (RadioArray[0])
                gender = "Macho";
            else if (RadioArray[1])
                gender = "Hembra";
            setUserID();
            if (dataValidate())
            {
                int petInDBformat = assignPetType();
                DB.DataBase db = new DB.DataBase("localhost", "pet_control", "root");
                db.executeInsert("INSERT INTO mascota (Nombre, Sexo, Edad, Fk_tipo, Fk_dueno)"
                                 + $"VALUES('{petName}', '{gender}', {petAge}, {petInDBformat}, {ownerID})");
                isRegister = true;
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
            if (petName != null && kindOfPet != null)
            {
                if (petAge >= 0)
                    return true;
            }
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
