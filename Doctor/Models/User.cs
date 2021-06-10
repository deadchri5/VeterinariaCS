using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Models
{
    class User
    {
        private int id;
        private string name;
        private string sureName;
        private string email;
        private string password;

        public User()
        {

        }

        //Get y set
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string SureName { get { return sureName; } set { sureName = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
    }
}
