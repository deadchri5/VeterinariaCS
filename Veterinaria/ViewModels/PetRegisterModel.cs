using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.ViewModels
{
    public class PetRegisterModel
    {
        String Name;
        int Age;
        String Genere;

        public PetRegisterModel()
        {

        }

        public PetRegisterModel(String Name, int Age, String Genere) {
            this.Name = Name;
            this.Age = Age;
            this.Genere = Genere;
        }
    }
}
