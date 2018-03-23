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

    //In dieser Klasse befinden sich alle Methoden die für die Suche notwendig sind
    public class InventarSuche
    {

        //MySqlVerbindung
        private static MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");

        //In dieser Methode wird in allen Spalten gesucht
        //Das heißt es wird in der Spalte ISBN, Autor, Titel, Verlag und Genre gesucht
        public static List<ListViewItem> AllesSuchen()
        {
            //lokale Variable
            string aktiveForm = "";

            //Überprüfung welches Fenster aktiv ist
            if (FrmHauptfenster.aktiv == false)
            {
                //Falls ein Mitarbeiter sich angemeldet hat wird in die Variable der unten stehende String eingetragen
                //Dabei ist wichtig, dass es der Wert in dem aktiven Fenster ist
                //Dieser String wird nachher an die Datenbank übergeben
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                //Falls kein Mitarbeiter angemeldet ist wird in die Variable der unten stehende String eingetragen
                //Dabei ist wichtig, dass es der Wert in dem aktiven Fenster ist
                //Dieser String wird nachher an die Datenbank übergeben
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }

            //ListView erstellen
            List<ListViewItem> daten = new List<ListViewItem>();

            //In der Datenbank mithilfe des SQL-Befehls nach dem Wert suchen, der in das Suchfeld des aktiven Fensters eingetragen wurde
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag FROM buecherei.buch " +
                                "JOIN buecher_autor ON buch.buecher_autor_ID = buecher_autor.ID JOIN buecher_genre ON buch.buecher_genre_ID = buecher_genre.ID JOIN buecher_verlage ON buch.verlage_ID = buecher_verlage.ID " +
                                "Where buch.Titel LIKE " + "'%" + aktiveForm + "%'" + " or buecher_autor.Autor LIKE " + "'%" + aktiveForm + "%'" + " or buecher_genre.Genre LIKE " + "'%" + aktiveForm + "%'" +
                                " or buecher_verlage.Verlag LIKE " + "'%" + aktiveForm + "%'" + " or buch.ISBN like " + "'%" + aktiveForm + "%';"; 

            search.ExecuteNonQuery();
            MySqlDataReader result = search.ExecuteReader();
            int n = 0;
            while (result.Read())
            {
                //Suchergebnis in die ListView eintragen
                daten.Add(new ListViewItem(new string[]{ result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                n++;
            }
            //Datenbankverbindung schließen
            con.Close();
            //ListView mistammt der Daten zurückgeben
            return daten;
        }

        //In dieser Methode wird nur in der Spalte Titel gesucht, also nur nach dem Titel
        public static List<ListViewItem> TitelSuchen()
        {

            //lokale Variable
            string aktiveForm = "";

            //Überprüfung welches Fenster aktiv ist
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }

            //ListView erstellen
            List<ListViewItem> daten = new List<ListViewItem>();

            //In der Datenbank mithilfe des SQL-Befehls nach dem Wert suchen, der in das Suchfeld des aktiven Fensters eingetragen wurde
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag FROM buecherei.buch JOIN buecher_autor ON buch.buecher_autor_ID = buecher_autor.ID " +
            "JOIN buecher_genre ON buch.buecher_genre_ID = buecher_genre.ID JOIN buecher_verlage ON buch.verlage_ID = buecher_verlage.ID Where buch.Titel like "+ "'%" + aktiveForm + "%';";
            search.ExecuteNonQuery();
            MySqlDataReader result = search.ExecuteReader();

            int n = 0;
            while (result.Read())
            {
                //Suchergebnis in die ListView eintragen
                daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                n++;
            }
            con.Close();
            //Suchergebnis zurückgeben
            return daten;
        }

        //In dieser Methode wird nur in der Spalte Autor gesucht, also nur nach dem Autor
        public static List<ListViewItem> AutorSuchen()
        {

            //lokale Variable
            string aktiveForm = "";

            //Überprüfung welches Fenster aktiv ist
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }

            //ListView erstellen
            List<ListViewItem> daten = new List<ListViewItem>();

            //In der Datenbank mithilfe des SQL-Befehls nach dem Wert suchen, der in das Suchfeld des aktiven Fensters eingetragen wurde
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag FROM buecherei.buch JOIN buecher_autor ON buch.buecher_autor_ID = buecher_autor.ID " +
            "JOIN buecher_genre ON buch.buecher_genre_ID = buecher_genre.ID JOIN buecher_verlage ON buch.verlage_ID = buecher_verlage.ID Where buecher_autor.Autor like " + "'%" + aktiveForm + "%';";
            search.ExecuteNonQuery();
            MySqlDataReader result = search.ExecuteReader();
            int n = 0;
            while (result.Read())
            {
                //Suchergebnis in die ListView eintragen
                daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                n++;
            }
            con.Close();
            //Suchergebnis zurückgeben
            return daten;
        }

        //In dieser Methode wird nur in der Spalte Genre gesucht, also nur nach dem Genre
        public static List<ListViewItem> GenreSuchen()
        {

            //lokale Variable
            string aktiveForm = "";

            //Überprüfung welches Fenster aktiv ist
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }

            //ListView erstellen
            List<ListViewItem> daten = new List<ListViewItem>();

            //In der Datenbank mithilfe des SQL-Befehls nach dem Wert suchen, der in das Suchfeld des aktiven Fensters eingetragen wurde
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag FROM buecherei.buch JOIN buecher_autor ON buch.buecher_autor_ID = buecher_autor.ID " +
            "JOIN buecher_genre ON buch.buecher_genre_ID = buecher_genre.ID JOIN buecher_verlage ON buch.verlage_ID = buecher_verlage.ID Where buecher_genre.Genre like " + "'%" + aktiveForm + "%';";
            search.ExecuteNonQuery();
            MySqlDataReader result = search.ExecuteReader();
            int n = 0;
            while (result.Read())
            {
                //Suchergebnis in die ListView eintragen
                daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                n++;
            }
            con.Close();
            //Suchergebnis zurückgeben
            return daten;
        }

        //In dieser Methode wird nur in der Spalte Verlag gesucht, also nur nach dem Verlag
        public static List<ListViewItem> VerlagSuchen()
        {

            //lokale Variable
            string aktiveForm = "";

            //Überprüfung welches Fenster aktiv ist
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }

            //ListView erstellen
            List<ListViewItem> daten = new List<ListViewItem>();

            //In der Datenbank mithilfe des SQL-Befehls nach dem Wert suchen, der in das Suchfeld des aktiven Fensters eingetragen wurde
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag FROM buecherei.buch JOIN buecher_autor ON buch.buecher_autor_ID = buecher_autor.ID " +
            "JOIN buecher_genre ON buch.buecher_genre_ID = buecher_genre.ID JOIN buecher_verlage ON buch.verlage_ID = buecher_verlage.ID Where buecher_verlage.Verlag like " + "'%" + aktiveForm + "%';";
            search.ExecuteNonQuery();
            MySqlDataReader result = search.ExecuteReader();
            int n = 0;
            while (result.Read())
            {
                //Suchergebnis in die ListView eintragen
                daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                n++;
            }
            con.Close();
            //Suchergebnis zurückgeben
            return daten;
        }

        //In dieser Methode wird nur in der Spalte ISBN gesucht, also nur nach der ISBN-Nummer
        public static List<ListViewItem> ISBNSuchen()
        {

            //lokale Variable
            string aktiveForm = "";

            //Überprüfung welches Fenster aktiv ist
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }

            //ListView erstellen
            List<ListViewItem> daten = new List<ListViewItem>();

            //In der Datenbank mithilfe des SQL-Befehls nach dem Wert suchen, der in das Suchfeld des aktiven Fensters eingetragen wurde
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag FROM buecherei.buch JOIN buecher_autor ON buch.buecher_autor_ID = buecher_autor.ID " +
            "JOIN buecher_genre ON buch.buecher_genre_ID = buecher_genre.ID JOIN buecher_verlage ON buch.verlage_ID = buecher_verlage.ID Where buch.ISBN like " + "'%" + aktiveForm + "%';";
            search.ExecuteNonQuery();
            MySqlDataReader result = search.ExecuteReader();
            int n = 0;
            while (result.Read())
            {
                //Suchergebnis in die ListView eintragen
                daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                n++;
            }
            con.Close();
            //Suchergebnis zurückgeben
            return daten;
        }
    }
}
