using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    public class User
    {

        public string name { get; set; }
        public string sureName { get; set; }
        public string email { get; set; }

        public User(string email, string name, string sureName)
        {
            this.name = name;
            this.sureName = sureName;
            this.email = email;
        }

    }
}
