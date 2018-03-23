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
    public class Grunddaten
    {
        //In dieser Klasse werden die kompletten Daten der Datenbank beim Start des Programms geladen und an das Programm in einer ListView übergeben

        //MySqlVerbindung
        private static MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");
        
        //Diese Methode erstellt eine ListView und speichert dort alle Daten aus der Datenbank
        public static List<ListViewItem> getalleDaten()
        {
            //ListView erstellen
            List<ListViewItem> daten = new List<ListViewItem>();
           
            //Mithilfe eines SQL-Befehls alle Daten aus der Datenbank auslesen
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag FROM buecherei.buch JOIN buecher_autor ON buch.buecher_autor_ID = buecher_autor.ID JOIN buecher_genre ON buch.buecher_genre_ID = buecher_genre.ID JOIN buecher_verlage ON buch.verlage_ID = buecher_verlage.ID;";         
            search.ExecuteNonQuery();
           
            MySqlDataReader result = search.ExecuteReader();
            int n = 0;
            while (result.Read())
            {
                //Hier werden alle Daten in die ListView geschrieben
                //Wie eine Tabelle werden alle Einträge eines Buchs in eine Zeile geschrieben
                //Danach wird eine neue Zeile erstellt in die der nächste Datensatz geschrieben wird
                //Dies geschieht so lange bis alle Datensaätze aus der Datenbank in der ListView sind
                daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                n++;
            }
            //Verbindung schließen
            con.Close();
            //Die ListView zurückgeben
            return daten;
        }
         
    }
}