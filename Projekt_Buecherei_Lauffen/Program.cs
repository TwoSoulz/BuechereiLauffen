using HelperLibrary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Buecherei_Lauffen
{
    static class Program
    {
        private static string dBHost = "localhost"; //oder IP

        public static string DBHost
        {
            get { return dBHost; }
            set { dBHost = value; }
        }
        private static string dBUser = "root";

        public static string DBUser
        {
            get { return dBUser; }
            set { dBUser = value; }
        }
        private static string dBPassword = "";

        public static string DBPassword
        {
            get { return dBPassword; }
            set { dBPassword = value; }
        }
        private static string dBName = "buecherei";

        public static string DBName
        {
            get { return dBName; }
            set { dBName = value; }
        }

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmHauptfenster());

            MySQLDatabaseManager.CreateInstance();
            MySQLDatabaseManager dbManager = MySQLDatabaseManager.GetInstance();

            dbManager.SetConnectionString(DBHost, DBUser, dBPassword, dBName);
        }
    }
}
