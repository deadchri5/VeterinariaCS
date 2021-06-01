using Newtonsoft.Json;
using Veterinaria.Models;
using System.Windows;
using System.IO;
using System;

namespace Veterinaria
{
    public class ReadData
    {

        public static string path = "../../sessionJSON/us.json";

        public ReadData()
        {
            
        }

        public User getJSON()
        {
            User user = null;
            try
            {
                string json = File.ReadAllText(path);
                user = JsonConvert.DeserializeObject<User>(json);
            }
            catch (FileLoadException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return user;
        }

        public void saveUserInJSON(int _id, string _email, string _usName, string _srName, string _psw)
        {
            User user = new User()
            {
                Id = _id,
                Email = _email,
                Name = _usName,
                SureName = _srName,
                Password = _psw
            };

            string JSONstring = JsonConvert.SerializeObject(user);

            try
            {
                File.WriteAllText(path, JSONstring);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

    }
}
