using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Collections;

namespace Projekt_Buecherei_Lauffen
{
    class BuchAusleihen
    {
        //MySqlVerbindung
        private static MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");

        public static int ReservierungIDRausfinden_Ausleihe()
        {
            con.Open();
            MySqlCommand check = con.CreateCommand();
            check.CommandType = CommandType.Text;
            check.CommandText = "Select reservierungs_ID From reservierungen Where Buch_ISBN like " + FrmAusleihen.AktuelleISBN_Ausleihe + ";";
            check.ExecuteNonQuery();
            MySqlDataReader reader = check.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                var resID = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return resID;
            }

            reader.Close();
            con.Close();
            return 0;
        }
        public static int LeserRausfinden_Ausleihe()
        {
            con.Open();
            MySqlCommand check = con.CreateCommand();
            check.CommandType = CommandType.Text;
            check.CommandText = "Select Leser_ID From reservierungen Where reservierungs_ID like " + "'" + FrmHauptfenster_Erweitert.ErwReservierungsID + "';";
            check.ExecuteNonQuery();
            MySqlDataReader reader = check.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                var leserid = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return leserid;
            }

            reader.Close();
            con.Close();
            return 0;
        }

        public static void ReservierungLöschen_Ausleihe ()
        {
            con.Open();
            MySqlCommand reserstellen = con.CreateCommand();
            reserstellen.CommandType = CommandType.Text;
            reserstellen.CommandText = "Delete From reservierungen Where reservierungs_ID like " + FrmAusleihen.ResID_Ausleihe + ";";
            reserstellen.ExecuteNonQuery();
            con.Close();
        }
        public static int AusgeliehenCheck()
        {
            con.Open();
            MySqlCommand check = con.CreateCommand();
            check.CommandType = CommandType.Text;
            check.CommandText = "Select ausleihenid From ausleihen Where Buch_ISBN like " + FrmAusleihen.AktuelleISBN_Ausleihe + ";"; 
            check.ExecuteNonQuery();
            MySqlDataReader reader = check.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                var ausgeliehen = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return ausgeliehen;
            }

            reader.Close();
            con.Close();
            return 0;
        }

        public static int Ausleihe_ManuelleID()
        {
            con.Open();
            MySqlCommand manuelleID = con.CreateCommand();
            manuelleID.CommandType = CommandType.Text;
            manuelleID.CommandText = "Select Count(ausleihenid) + 1 From ausleihen;";
            manuelleID.ExecuteNonQuery();
            MySqlDataReader reader = manuelleID.ExecuteReader();
            reader.Read();

            var manuelleid = reader.GetInt32(0);
            reader.Close();
            con.Close();
            return manuelleid;
        }

        public static void AusleiheErstellen()
        {
            con.Open();
            MySqlCommand reserstellen = con.CreateCommand();
            reserstellen.CommandType = CommandType.Text;
            reserstellen.CommandText = "Insert Into `ausleihen` (`ausleihenid`,`Leser_ID`, `Buch_ISBN`) Values (" + "'" + FrmAusleihen.ManuelleID_Ausleihe + "', " + "'" + FrmAusleihen.LeserID_Ausleihe +
            "', " + "'" + FrmAusleihen.AktuelleISBN_Ausleihe + "');";
            reserstellen.ExecuteNonQuery();
            con.Close();
        }

        public static void AusleiheLoeschen()
        {
            con.Open();
            MySqlCommand reserstellen = con.CreateCommand();
            reserstellen.CommandType = CommandType.Text;
            reserstellen.CommandText = "DELETE From ausleihen Where Buch_ISBN like " + FrmAusleihen.AktuelleISBN_Ausleihe + ";";
            reserstellen.ExecuteNonQuery();
            con.Close();
        }
    }
}
