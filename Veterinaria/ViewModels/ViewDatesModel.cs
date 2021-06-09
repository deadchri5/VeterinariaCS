using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinaria.Models;

namespace Veterinaria.ViewModels
{
    class ViewDatesModel
    {

        public List<string> query { set; get; } = new List<string>();
        public DataTable dataTable { set; get; }
        public User user { set; get; }

        public bool UserhavePets { get; set; }

        public ViewDatesModel()
        {
            getUser();
            fillList();
        }

        private void fillList()
        {
            DB.DataBase db = new DB.DataBase("localhost", "pet_control", "root");
            //Console.WriteLine(dataTable.Rows.Count);
            //dataTable.
            dataTable = db.fillQuery("SELECT cita.Fecha AS Fecha,"
                                                + "cita.Hora AS Hora,"
                                                + "cita.Codigo AS Codigo,"
                                                + "doctor.Nombre AS Doctor,"
                                                + "mascota.Nombre AS Mascota,"
                                                + "cita.Motivo AS Motivo "
                                                + "FROM cita "
                                                + "INNER JOIN mascota ON cita.Fk_Mascota = mascota.Id "
                                                + "INNER JOIN doctor ON cita.Fk_doctor = doctor.Id "
                                                + $"WHERE mascota.Fk_dueno = {user.Id}");
            if (dataTable.Rows.Count > 0)
                UserhavePets = true;
            else
                UserhavePets = false;
        }

        private void getUser()
        {
            ReadData rd = new ReadData();
            user = rd.getJSON();
        }
    }
}
