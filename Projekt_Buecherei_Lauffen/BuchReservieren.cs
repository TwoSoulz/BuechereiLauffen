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
    //In dieser Klasse befinden sich alle Methoden, die zum Reservieren des Buchs notwendig sind 
    class BuchReservieren
    {
        //MySqlVerbindung
        private static MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");

        //Mit dieser Methode wird die LeserID herrausgefunden 
        public static int LeserFinden()
        {
            //Mithilfe eines SQL-Befehls wird überprüft ob es eine LeserID gibt
            con.Open();
            MySqlCommand check = con.CreateCommand();
            check.CommandType = CommandType.Text;
            check.CommandText = "SELECT leser.ID FROM buecherei.leser Where leser.Vorname like " + "'" + FrmReservieren.EingabeVorname + "' And leser.Nachname like " + "'" + FrmReservieren.EingabeNachname +
            "' And leser.Hausnummer like " + "'" + FrmReservieren.EingabeHausnummer + "' And leser.Straße like " + "'" + FrmReservieren.EingabeStrasse + "' And leser.PLZ like " + "'" + FrmReservieren.EingabePLZ + "';";
            check.ExecuteNonQuery();
            MySqlDataReader reader = check.ExecuteReader();

            reader.Read();

            //falls es diese gibt, wird sie hier zurückgegeben
            if (reader.HasRows)
            {
                var leserID = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return leserID;
            }

            //Falls es keine gibt wird eine "0" zurückgegeben
            reader.Close();
            con.Close();
            return 0;
        }

        //Mit dieser Methode wird ein neuer Leser in der Datenbank erstellterstellt
        public static void LeserErstellen()
        {
            //Mithilfe eines SQL-Befehls wird der Leser erstellt, dazu werden Vorname, Nachname, Straße, Ort und PLZ von der Form Reservieren übergeben
            con.Open();
            MySqlCommand lesererstellen = con.CreateCommand();
            lesererstellen.CommandType = CommandType.Text;
            lesererstellen.CommandText = "Insert Into `leser` (`Vorname`, `Nachname`, `Hausnummer`, `Straße`, `Ort`, `PLZ`) VALUES (" + " '" + FrmReservieren.EingabeVorname + "'," +
            " '" + FrmReservieren.EingabeNachname + "'," + " '" + FrmReservieren.EingabeHausnummer + "'," + " '" + FrmReservieren.EingabeStrasse + "'," +
            " '" + FrmReservieren.EingabeOrt + "'," + " '" + FrmReservieren.EingabePLZ + "');";
            lesererstellen.ExecuteNonQuery();
            con.Close();
        }

        //Mit dieser Methode wird überprüft ob eine Reservierung vorhanden ist
        public static int ReservierungChecken()
        {
            //Mithilfe eines SQL-Befehls wird überprüft ob eine Reservierung mit dieser ISBN verknüpft ist
            con.Open();
            MySqlCommand check = con.CreateCommand();
            check.CommandType = CommandType.Text;
            check.CommandText = "Select reservierungen.reservierungs_id From reservierungen Where Buch_ISBN like " + "'" + FrmReservieren.AktuelleISBN + "';";
            check.ExecuteNonQuery();
            MySqlDataReader reader = check.ExecuteReader();

            reader.Read();

            //Hier wird die ReservierungsID zurückgegeben, falls vorhanden
            if (reader.HasRows)
            {
                var resWert = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return resWert;
            }

            //Falls keine vorhanden ist, wird eine "0" zurückgegeben
            reader.Close();
            con.Close();
            return 0;
        }

        //Mit dieser Methode wird die reservierungsID in der Datenbank in der Tabelle "reservierungen" um eins erhöht
        //Und danach wird diese neue "ID" zurückgegeben
        public static int ManuelleID()
        {
            con.Open();
            MySqlCommand manuelleID = con.CreateCommand();
            manuelleID.CommandType = CommandType.Text;
            manuelleID.CommandText = "Select Count(reservierungs_id) + 1 From reservierungen;";
            manuelleID.ExecuteNonQuery();
            MySqlDataReader reader = manuelleID.ExecuteReader();
            reader.Read();

            var resWert = reader.GetInt32(0);
            reader.Close();
            con.Close();
            return resWert;
        }

        //Mit dieser Methode wird eine Reservierung in der Datenbank zu dem ausgewählten Buch erstellt
        public static void ReservierungErstellen()
        {
            //Hierbei wird anhand der LeserID, der ISBN-Nummer und der manuellen reservierungsID eine Eintrag in der Tabelle reservieren erstellt
            con.Open();
            MySqlCommand reserstellen = con.CreateCommand();
            reserstellen.CommandType = CommandType.Text;
            reserstellen.CommandText = "Insert Into `reservierungen` (`reservierungs_id`,`Leser_ID`, `Buch_ISBN`) Values (" + "'"+FrmReservieren.ManuelleID+"', " +"'" +FrmReservieren.LeserID +
            "', "+"'"+ FrmReservieren.AktuelleISBN + "');";
            reserstellen.ExecuteNonQuery();
            con.Close();
        }

        //Mit dieser Methode wird die Reservierung des ausgewählten Buchs in der Datenbnak gelöscht
        public static void ReservierungLoeschen()
        {
           //Mithilfe eines SQL-Befehls wird anhand der ISBN-Nummer der Eintrag in der Tabelle reservierungen aus der Datenbank gelöscht
            con.Open();
            MySqlCommand reserstellen = con.CreateCommand();
            reserstellen.CommandType = CommandType.Text;
            reserstellen.CommandText = "Delete FROM reservierungen Where buch_ISBN like " + FrmReservieren.AktuelleISBN + ";";
            reserstellen.ExecuteNonQuery();
            con.Close();
        }
    }
}
