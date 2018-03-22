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
    class BuchReservieren
    {
        //MySqlVerbindung
        private static MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");

        public static int LeserFinden()
        {
            con.Open();
            MySqlCommand check = con.CreateCommand();
            check.CommandType = CommandType.Text;
            check.CommandText = "SELECT leser.ID FROM buecherei.leser Where leser.Vorname like " + "'" + FrmReservieren.EingabeVorname + "' And leser.Nachname like " + "'" + FrmReservieren.EingabeNachname +
            "' And leser.Hausnummer like " + "'" + FrmReservieren.EingabeHausnummer + "' And leser.Straße like " + "'" + FrmReservieren.EingabeStrasse + "' And leser.PLZ like " + "'" + FrmReservieren.EingabePLZ + "';";
            check.ExecuteNonQuery();
            MySqlDataReader reader = check.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                var leserID = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return leserID;
            }

            reader.Close();
            con.Close();
            return 0;
        }

        public static void LeserErstellen()
        {
            con.Open();
            MySqlCommand lesererstellen = con.CreateCommand();
            lesererstellen.CommandType = CommandType.Text;
            lesererstellen.CommandText = "Insert Into `leser` (`Vorname`, `Nachname`, `Hausnummer`, `Straße`, `Ort`, `PLZ`) VALUES (" + " '" + FrmReservieren.EingabeVorname + "'," +
            " '" + FrmReservieren.EingabeNachname + "'," + " '" + FrmReservieren.EingabeHausnummer + "'," + " '" + FrmReservieren.EingabeStrasse + "'," +
            " '" + FrmReservieren.EingabeOrt + "'," + " '" + FrmReservieren.EingabePLZ + "');";
            lesererstellen.ExecuteNonQuery();
            con.Close();
        }

        public static int ReservierungChecken()
        {
            con.Open();
            MySqlCommand check = con.CreateCommand();
            check.CommandType = CommandType.Text;
            check.CommandText = "Select reservierungen.reservierungs_id From reservierungen Where Buch_ISBN like " + "'" + FrmReservieren.AktuelleISBN + "';";
            check.ExecuteNonQuery();
            MySqlDataReader reader = check.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                var resWert = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return resWert;
            }

            reader.Close();
            con.Close();
            return 0;
        }
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
        public static void ReservierungErstellen()
        {
            con.Open();
            MySqlCommand reserstellen = con.CreateCommand();
            reserstellen.CommandType = CommandType.Text;
            reserstellen.CommandText = "Insert Into `reservierungen` (`reservierungs_id`,`Leser_ID`, `Buch_ISBN`) Values (" + "'"+FrmReservieren.ManuelleID+"', " +"'" +FrmReservieren.LeserID +
            "', "+"'"+ FrmReservieren.AktuelleISBN + "');";
            reserstellen.ExecuteNonQuery();
            con.Close();
        }

        public static void ReservierungLoeschen()
        {
            con.Open();
            MySqlCommand reserstellen = con.CreateCommand();
            reserstellen.CommandType = CommandType.Text;
            reserstellen.CommandText = "Delete FROM reservierungen Where buch_ISBN like " + FrmReservieren.AktuelleISBN + ";";
            reserstellen.ExecuteNonQuery();
            con.Close();
        }
    }
}

