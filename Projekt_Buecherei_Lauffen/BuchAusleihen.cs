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
    //In dieser Klasse befinden sich alle Methoden um ein Buch als ausgeliehen zu markieren
    class BuchAusleihen
    {
        //MySqlVerbindung
        private static MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");

        //Mit dieser Methode wird geprüft ob es eine ReservierungsID gibt
        //Falls es diese gibt wird sie zurückgegeben
        public static int ReservierungIDRausfinden_Ausleihe()
        {
            //Hier wird mit einem SQL-Befehl überprüft ob es eine Reservierung in der Datenbank zu diesem Buch gibt, dabei wird der Wert aus der Textbox genutzt
            con.Open();
            MySqlCommand check = con.CreateCommand();
            check.CommandType = CommandType.Text;
            check.CommandText = "Select reservierungs_ID From reservierungen Where Buch_ISBN like " + FrmAusleihen.AktuelleISBN_Ausleihe + ";";
            check.ExecuteNonQuery();
            MySqlDataReader reader = check.ExecuteReader();

            reader.Read();

            //Falls eine Reservierung vorhanden ist wird die ID zurückgegeben
            if (reader.HasRows)
            {
                var resID = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return resID;
            }

            //Falls keine Reservierung vorhanden ist wird eine "0" zurückgegeben
            reader.Close();
            con.Close();
            return 0;
        }

        //Mit dieser Methode wird anhand der ReservierungsID die LeserID überpüft und zurückgegeben
        public static int LeserRausfinden_Ausleihe()
        {
            //Hier wird mithile eines SQL-Befehls anhand der ReservierungsID nach der LeserID gesucht
            con.Open();
            MySqlCommand check = con.CreateCommand();
            check.CommandType = CommandType.Text;
            check.CommandText = "Select Leser_ID From reservierungen Where reservierungs_ID like " + "'" + FrmHauptfenster_Erweitert.ErwReservierungsID + "';";
            check.ExecuteNonQuery();
            MySqlDataReader reader = check.ExecuteReader();

            reader.Read();

            //Hier wird die LeserID zurückgegeben
            if (reader.HasRows)
            {
                var leserid = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return leserid;
            }

            //Falls keine LeserID vorhanden sein sollte wird eine "0" zurückgegeben
            reader.Close();
            con.Close();
            return 0;
        }

        //Mit dieser Methode wird die Reservierung des ausgeliehenen Buchs gelöscht
        public static void ReservierungLöschen_Ausleihe ()
        {
            con.Open();
            MySqlCommand reserstellen = con.CreateCommand();
            reserstellen.CommandType = CommandType.Text;
            reserstellen.CommandText = "Delete From reservierungen Where reservierungs_ID like " + FrmAusleihen.ResID_Ausleihe + ";";
            reserstellen.ExecuteNonQuery();
            con.Close();
        }

        //Mit dieser Methode wird überprüft ob ein Buch ausgeliehen ist
        public static int AusgeliehenCheck()
        {
            //Hier wird mithilfe eines SQL-Befehls überprüft ob es einen Eintrag in der Tabelle "ausleihen" mit dieser ISBN-Nummer gibt
            con.Open();
            MySqlCommand check = con.CreateCommand();
            check.CommandType = CommandType.Text;
            check.CommandText = "Select ausleihenid From ausleihen Where Buch_ISBN like " + FrmAusleihen.AktuelleISBN_Ausleihe + ";"; 
            check.ExecuteNonQuery();
            MySqlDataReader reader = check.ExecuteReader();

            reader.Read();

            //Hier wird diese ausleihenID zurückgegeben, falls sie vorhanden ist
            if (reader.HasRows)
            {
                var ausgeliehen = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return ausgeliehen;
            }

            //Falls sie nicht vorhanden ist wird eine "0" zurückgegeben
            reader.Close();
            con.Close();
            return 0;
        }

        //Mit dieser Methode wird die ausleihenID in der Datenbank in der Tabelle "ausleihen" um eins erhöht
        //Und danach wird diese neue "ID" zurückgegeben
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

        //Mit dieser Methode wird in der Datenbank gespeichert, dass das Buch ausgeliehen ist
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

        //Mit dieser Methode wird das Buch wieder zurückgegeben
        //Der Eintrag in der Datenbank,dass das Buch ausgeliehen ist wird hier gelöscht
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
