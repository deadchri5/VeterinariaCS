using Doctor.DB;
using Doctor.Models.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Doctor.Models.ViewsModels
{

    class FinalizarCitaModel 
    {

        public List<string> query { set; get; } = new List<string>();
        public DataTable dataTable { set; get; }
        public bool doctorHaveDates { get; set; }
        public FinalizarTareaCommand finalizarTareaCommand { get; private set; }
        public string Folio { set; get; }
        public string Cliente { set; get; }
        public string Mascota { set; get; }
        public string Sexo { set; get; }
        public string Edad { set; get; }
        public string Motivo { set; get; }
        public string Notas { set; get; }
        public string Animal { set; get; }
        public string Apellido { set; get; }
        public string numCita { set; get; }

        
        private DataBase db = new DB.DataBase("localhost", "pet_control", "root");


        public FinalizarCitaModel()
        {
            getDateAsync();
            //finalizarTareaCommand = new FinalizarTareaCommand(nextDate);            
        }

        private void getDateAsync()
        {           
            dataTable = db.fillQuery("SELECT cita.Codigo, cita.Motivo, cita.Notas, mascota.Nombre AS Mascota," +
                " mascota.Sexo, mascota.Edad, typepet.Nombre AS Animal, cliente.Nombre AS Cliente, cliente.Apellidos AS Apellido, cita.Id " +
                "FROM cita INNER JOIN mascota On cita.FK_Mascota = mascota.Id INNER JOIN typepet " +
                "ON mascota.FK_tipo = typepet.Id INNER JOIN cliente ON mascota.FK_dueno = cliente.ID " +
                "WHERE cita.Status = 0 LIMIT 1;");

            if (dataTable.Rows.Count > 0)
            {
                bool onlyOneTime = true;
                doctorHaveDates = true;
                foreach (DataRow row in dataTable.Rows)
                {
                    var  i = (int)0;
                    foreach(var item in row.ItemArray)
                    {                  
                        if (onlyOneTime)
                        {
                            switch (i)
                            {
                                case 0:
                                    this.Folio = (string)item;
                                    break;
                                case 1:
                                    this.Motivo = (string)item;
                                    break;
                                case 2:
                                    this.Notas = (string)item;
                                    break;
                                case 3:
                                    this.Mascota = (string)item;
                                    break;
                                case 4:
                                    this.Sexo = (string)item;
                                    break;
                                case 5:
                                    Edad = item.ToString();
                                    break;
                                case 6:
                                    this.Animal = (string)item;
                                    break;
                                case 7:
                                    this.Cliente = (string)item;
                                    break;
                                case 8:
                                    this.Apellido = (string)item;
                                    break;
                                case 9:
                                    this.numCita = item.ToString();
                                    break;
                            }
                            i++;
                        }
                        
                    }
                    onlyOneTime = false;
                }
            }
            else
            {
                doctorHaveDates = false;
            }
            
        }

        public void nextDate()
        {
            db.executeInsert($"UPDATE cita SET Status = 1 WHERE Id = '{this.numCita}'"); 
            getDateAsync();
        }
    }
}
