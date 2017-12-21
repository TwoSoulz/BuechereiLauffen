using HelperLibrary.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Buecherei_Lauffen
{
    public class User
    {
        private static MySQLDatabaseManager _dbManager = MySQLDatabaseManager.GetInstance();
        
        private string username;
        private string password;

        public string getUsername()
        {
            return username;
        }

        public void setUsername(string name)
        {
            username = name;
        }

        public string getPassword()
        {
            return password;
        }

        public void setPassword(string pass)
        {
            password = pass;
        }


        public static List<User> getalleUser()
        {            
            List<User> daten = new List<User>();

            string query = "select * from mitarbeiter;";
            MySqlDataReader reader = _dbManager.Select(query);


            while (reader.Read())
            {
                User neuerUser = new User();
                neuerUser.setUsername(reader.GetString(1));
                neuerUser.setPassword(reader.GetString(2));
                daten.Add(neuerUser);
            }

            reader.Close();
            return daten;
        }

    }
}
