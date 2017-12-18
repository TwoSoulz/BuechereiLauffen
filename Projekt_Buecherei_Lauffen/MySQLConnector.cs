using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projekt_Buecherei_Lauffen
{
    class MySQLConnector
    {
        //Durch MySQLConnectionStringBuilder wird die Fehlerhäufigkeit reduziert bei einer Verbindung mit einem MySQL Server

        private MySqlConnectionStringBuilder mysqlConnectionStringBuilder
                                     = new MySqlConnectionStringBuilder();
        public String ConnectionString
        {
            get
            {
                mysqlConnectionStringBuilder.Server = DBHost;
                mysqlConnectionStringBuilder.UserID = DBUser;
                mysqlConnectionStringBuilder.Password = DBPassword;
                mysqlConnectionStringBuilder.Database = DBName;
                return mysqlConnectionStringBuilder.ConnectionString;
            }
        }

        private string dBHost = "localhost"; //oder IP

        public string DBHost
        {
            get { return dBHost; }
            set { dBHost = value; }
        }
        private string dBUser = "root";

        public string DBUser
        {
            get { return dBUser; }
            set { dBUser = value; }
        }
        private string dBPassword = "";

        public string DBPassword
        {
            get { return dBPassword; }
            set { dBPassword = value; }
        }
        private string dBName = "buecherei";

        public string DBName
        {
            get { return dBName; }
            set { dBName = value; }
        }

        //Methode, um die Verbindung zur Datenbank zu testen
        public String testConnection()
        {
            String msg = "DB-Verbindung erfolgreich";
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                msg = ex.GetBaseException().Message;
            }
                return msg;
        }
    }
}
