using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.ViewModels.Commands;

namespace Veterinaria.ViewModels
{
    public class AgendDateModel
    {
        public string date { get; set; }
        public string hour { get; set; }
        public List<string> reasonOfAppointment { get; set; } = new List<string>() {    "Consulta medica",
                                                                                        "Desparacitación",
                                                                                        "Esterilización",
                                                                                        "Tratamiento",
                                                                                        "Continuación de tratamiento",
                                                                                        "Corte de pelo y baño",
                                                                                        "Otro"
                                                                                    };
        public List<string> petsList { get; set; }
        public List<string> veterinariesList { get; set; }
        public string additionalNote { get; set; }

        public Models.User user;

        public GenericCommand genericCommand { get; private set; }

        public AgendDateModel()
        {
            readUserData();
            fillPetsList();
            fillVeterinariesList();
            date = DateTime.Today.ToString("MM/dd/yyyy");
            hour = DateTime.Now.ToString("hh:mm");
            genericCommand = new GenericCommand(generateDate);
        }

        private void generateDate()
        {
            Console.WriteLine("El usuario hizo click en la acción");
        }

        private void fillPetsList()
        {
            petsList = new List<string>();
            DB.DataBase db = new DB.DataBase("localhost", "pet_control", "root");
            petsList = db.exectueAdvancedQuery($"SELECT Nombre FROM mascota WHERE Fk_dueno='{user.Id}'");
        }

        private void fillVeterinariesList()
        {
            DB.DataBase db = new DB.DataBase("localhost", "pet_control", "root");
            veterinariesList = new List<string>();
            List<string> list = db.exectueAdvancedQuery(@"SELECT Id, Nombre, Apellidos FROM doctor");
            int counter = 0;
            string doc = "";
            foreach(string i in list)
            {
                doc += i + " ";
                counter++;
                if (counter >= 3)
                {
                    veterinariesList.Add(doc);
                    doc = "";
                    counter = 0;
                }
            }
        }

        private void readUserData()
        {
            ReadData rd = new ReadData();
            user = rd.getJSON();
        }
    }
}
