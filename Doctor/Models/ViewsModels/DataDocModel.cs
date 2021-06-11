using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Models.ViewsModels
{
    class DataDocModel
    {
        public User user;
        public string name { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }

        public DataDocModel()
        {
            getUser();
        }

        private void getUser()
        {
            ReadData rd = new ReadData();
            user = rd.getJSON();
            name = user.Name;
            apellido = user.SureName;
            email = user.Email;
        }
    }
}
