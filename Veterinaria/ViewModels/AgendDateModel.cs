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
        public DateTime date { get; set; } = DateTime.Now;
        public string hour { get; set; }
        public string reason { get; set; }
        public string petName { get; set; }
        public string doctor { get; set; }
        public string note { get; set; }

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
        string codeOfDate;
        public bool success = false;
        public bool error = false;

        public AgendDateModel()
        {
            readUserData();
            fillPetsList();
            fillVeterinariesList();
            genericCommand = new GenericCommand(generateDate);
        }

        private void generateDate()
        {
            success = false;
            error = false;
            if (date != null && hour != null && reason != null
                && petName != null && doctor != null && !doctor.Equals(""))
            {
                string _date = date.ToString("yyyy-MM-dd");
                string _hour = (hour.Remove(0, hour.Length - 11).Remove(8)).Trim();
                string doctorID = doctor.Remove(1, doctor.Length - 1);
                Guid guid = Guid.NewGuid();
                string str = guid.ToString();
                codeOfDate = str.Remove(8, str.Length - 8);
                DB.DataBase db = new DB.DataBase("localhost", "pet_control", "root");
                string petID = db.executeQuery($"SELECT Id FROM mascota WHERE Nombre = '{petName}' AND Fk_dueno = '{user.Id}'");
                if (petID != null)
                {
                    success = true;
                    if (note != null)
                    {
                        db.executeQuery("INSERT INTO cita (Fecha, Hora, Codigo, Fk_doctor, Fk_Mascota, Motivo, Notas, Status)" +
                                    $"VALUES('{_date}', '{_hour}', '{codeOfDate}', '{doctorID}', '{petID}', '{reason}', '{note}', 0)");
                    }
                    else
                    {
                        db.executeQuery("INSERT INTO cita (Fecha, Hora, Codigo, Fk_doctor, Fk_Mascota, Motivo, Status)" +
                                    $"VALUES('{_date}', '{_hour}', '{codeOfDate}', '{doctorID}', '{petID}', '{reason}', 0)");
                    }
                }
                else
                    error = true;
            }
            else
                error = true;
        }

        /*
        private async void setAppoinmentInPetTable()
        {
            await Task.Delay(100);
            DB.DataBase db = new DB.DataBase("localhost", "pet_control", "root");
            string petID = db.executeQuery($"SELECT Id FROM mascota WHERE Nombre = '{petName}' AND Fk_dueno = '{user.Id}'");
            string appointmentID = db.executeQuery($"SELECT Id FROM cita WHERE Codigo = '{codeOfDate}'");
            db.executeInsert($"UPDATE mascota SET Fk_cita = {appointmentID} WHERE Id = {petID}");
        }
        */

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
