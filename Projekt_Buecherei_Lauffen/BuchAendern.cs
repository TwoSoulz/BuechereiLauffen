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
    //In dieser Klasse befinden sich alle Methoden um Bücher, Autoren, Verlage und Genre zu verändern, zu löschen und um neue zu erstellen 
    class BuchAendern
    {
        //MySqlVerbindung
        private static MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");

        //Mit dieser Methode wird überprüft, ob der Autor schon in der Datenbank eingetragen ist, falls dies der Fall ist wird die ID zurückgegeben,
        //falls nicht wird eine "0" zurückgegeben
        public static int AutorPruefen()
        {
            //Hier wird mithilfe eines SQL-Befehls überprüft ob der Autor schon in der Datenbank vorhanden ist, dabei wird der Wert aus der Textbox genutzt
            con.Open();                                 //Verbindung zur Datenbank öffnen
            MySqlCommand search = con.CreateCommand();  //Kommando in der Datenbank erstellen
            search.CommandType = CommandType.Text;      //Art des Kommandos
            search.CommandText = "SELECT buecher_autor.ID FROM buecherei.buecher_autor Where buecher_autor.Autor like " + "'%" + FrmHauptfenster_Erweitert.TmpAutor + "%';";    //Das Kommando an sich wird hier übertragen
            search.ExecuteNonQuery();
            MySqlDataReader reader = search.ExecuteReader();    //Ausführen des übertragenen Kommandos

            reader.Read();

            //Falls er vorhanden ist, wird die ID zurückgegeben
            if (reader.HasRows)
            {
                var autorId = reader.GetInt32(0);
                reader.Close();
                con.Close();            //Verbindung schließen
                return autorId;         //Wert zurückgeben
            }

            //Falls er noch nicht vorhanden ist, wird eine "0" zurückgegeben
            reader.Close();
            con.Close();                //Verbindung schließen
            return 0;                   //Wert zurückgeben
        }

        //Mit dieser Methode wird ein neuer Autor erstellt
        public static void AutorErstellen()
        {
            //Hier wird mithilfe eines SQL-Befehls der Name des Autors übergeben und in die Datenbank eingetragen, dabei wird der Wert aus der Textbox genutzt
            con.Open();
            MySqlCommand autorerstellen = con.CreateCommand();
            autorerstellen.CommandType = CommandType.Text;
            autorerstellen.CommandText = "INSERT INTO `buecher_autor` (`Autor`) VALUES ('" + FrmHauptfenster_Erweitert.TmpAutor + "');";
            autorerstellen.ExecuteNonQuery();
            con.Close();
        }

        //Mit dieser Methode wird überprüft, ob das Genre schon in der Datenbank eingetragen ist, falls dies der Fall ist wird die ID zurückgegeben,
        //falls nicht wird eine "0" zurückgegeben
        public static int GenrePruefen()
        {
            //Hier wird mithilfe eines SQL-Befehls überprüft ob das Genre schon in der Datenbank vorhanden ist, dabei wird der Wert aus der Textbox genutzt
            con.Open();
            MySqlCommand aendern = con.CreateCommand();
            aendern.CommandType = CommandType.Text;
            aendern.CommandText = "SELECT buecher_genre.ID FROM buecherei.buecher_genre Where buecher_genre.Genre like " + "'%" + FrmHauptfenster_Erweitert.TmpGenre + "%';";
            aendern.ExecuteNonQuery();
            MySqlDataReader reader = aendern.ExecuteReader();

            reader.Read();

            //Falls das Genre vorhanden ist, wird die ID zurückgegeben
            if (reader.HasRows)
            {
                var genreID = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return genreID;
            }

            //Falls es noch nicht vorhanden ist, wird eine "0" zurückgegeben
            reader.Close();
            con.Close();
            return 0;
        }

        //Mit dieser Methode wird ein neues Genre erstellt
        public static void GenreErstellen()
        {
            //Hier wird mithilfe eines SQL-Befehls der Name des Genres übergeben und in die Datenbank eingetragen, dabei wird der Wert aus der Textbox genutzt
            con.Open();
            MySqlCommand genreerstellen = con.CreateCommand();
            genreerstellen.CommandType = CommandType.Text;
            genreerstellen.CommandText = "INSERT INTO `buecher_genre` (`Genre`) VALUES ('" + FrmHauptfenster_Erweitert.TmpGenre + "');";
            genreerstellen.ExecuteNonQuery();
            con.Close();

        }

        //Mit dieser Methode wird überprüft, ob der Verlag schon in der Datenbank eingetragen ist, falls dies der Fall ist wird die ID zurückgegeben,
        //falls nicht wird eine "0" zurückgegeben
        public static int VerlagPruefen()
        {
            //Hier wird überprüft ob der Verlag schon in der Datenbank vorhanden ist, dabei wird der Wert aus der Textbox genutzt
            con.Open();
            MySqlCommand aendern = con.CreateCommand();
            aendern.CommandType = CommandType.Text;
            aendern.CommandText = "SELECT buecher_verlage.ID FROM buecherei.buecher_verlage Where buecher_verlage.Verlag like " + "'%" + FrmHauptfenster_Erweitert.TmpVerlag + "%';";
            aendern.ExecuteNonQuery();
            MySqlDataReader reader = aendern.ExecuteReader();

            reader.Read();

            //Falls er vorhanden ist, wird die ID zurückgegeben
            if (reader.HasRows)
            {
                var verlagID = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return verlagID;
            }

            //Falls der Verlag noch nicht vorhanden ist, wird eine "0" zurückgegeben
            reader.Close();
            con.Close();
            return 0;
        }

        //Mit dieser Methode wird ein neuer Verlag erstellt
        public static void VerlagErstellen()
        {
            //Hier wird mithilfe eines SQL-Befehls der Name des Verlags übergeben und in die Datenbank eingetragen, dabei wird der Wert aus der Textbox genutzt
            con.Open();
            MySqlCommand verlagerstellen = con.CreateCommand();
            verlagerstellen.CommandType = CommandType.Text;
            verlagerstellen.CommandText = "INSERT INTO `buecher_verlage` (`Verlag`) VALUES ('" + FrmHauptfenster_Erweitert.TmpVerlag + "');";
            verlagerstellen.ExecuteNonQuery();
            con.Close();
        }

        //Mit dieser Methode wird überprüft, ob die ISBN-Nummer schon in der Datenbank eingetragen ist, falls dies der Fall ist wird die Nummer zurückgegeben,
        //falls nicht wird eine "0" zurückgegeben
        public static int ISBNPruefen()
        {
            //Hier wird überprüft ob die ISBN-Nummer schon in der Datenbank vorhanden ist, dabei wird der Wert aus der Textbox genutzt
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buch.ISBN FROM buecherei.buch Where buch.ISBN like " + "'%" + FrmHauptfenster_Erweitert.TmpISBN + "%';";
            search.ExecuteNonQuery();
            MySqlDataReader reader = search.ExecuteReader();

            reader.Read();

            //Falls sie vorhanden ist, wird diese zurückgegeben
            if (reader.HasRows)
            {
                reader.Close();
                con.Close();
                return 1;
            }

            //Falls sie noch nicht vorhanden ist, wird eine "0" zurückgegeben
            reader.Close();
            con.Close();
            return 0;
        }

        //Mit dieser Methode wird ein vorhandenes Buch aus der Datenbank gelöscht
        public static void BuchLoeschen()
        {
            //Hier wird mithilfe eines SQL-Befehls der Eintrag aus der Datenbank entfernt, dies geschieht anhand der ISBN-Nummer
            con.Open();
            MySqlCommand verlagerstellen = con.CreateCommand();
            verlagerstellen.CommandType = CommandType.Text;
            verlagerstellen.CommandText = "Delete From buch Where ISBN =" + "'" + FrmHauptfenster_Erweitert.TmpISBN + "';";
            verlagerstellen.ExecuteNonQuery();
            con.Close();
        }

        //Mit dieser Methode wird ein neues Buch in die Datenbank hinzugefügt
        public static void BuchHinzufuegen()
        {
            //lokale Variablen
            int localautor = 0;
            int localverlag = 0;
            int localgenre = 0;

            //Hier wird überprüft ob die ISBN-Nummer schon vergeben ist, da sie eindeutig sein muss
            if (ISBNPruefen() == 1)
            {
                DialogResult dialogResult = MessageBox.Show("ISBN ist schon vergeben.", "Fehler beim erstellen", MessageBoxButtons.OK);
            }
            //Hier werden nacheinander alle Möglichkeiten überprüft ob der Autor, der Verlag oder das Genre schon vorhanden sind
            //Dabei werden die obigen Methoden genutzt und es wird überprüft ob diese Methoden eine "0" zurückgeben.
            //Falls diese eine "0" zurückgeben werden die noch fehlenden Einträge erstellt
            //Falls sie vorhanden sind, werden die IDs in die lokalen Variablen geschrieben
            else
            {
                if (AutorPruefen() == 0)
                {
                    if (VerlagPruefen() == 0)
                    {
                        if (GenrePruefen() == 0)
                        {
                            //Es fehlen Autor, Verlag und Genre
                            AutorErstellen();
                            VerlagErstellen();
                            GenreErstellen();
                            localautor = AutorPruefen();
                            localverlag = VerlagPruefen();
                            localgenre = GenrePruefen();
                        }
                        else
                        {
                            //Es fehlen der Auto und der Verlag
                            AutorErstellen();
                            VerlagErstellen();
                            localautor = AutorPruefen();
                            localverlag = VerlagPruefen();
                            localgenre = GenrePruefen();
                        }
                    }
                    else
                    {
                        if (GenrePruefen() == 0)
                        {
                            //Es fehlen der Autor und das Genre
                            AutorErstellen();
                            GenreErstellen();
                            localautor = AutorPruefen();
                            localverlag = VerlagPruefen();
                            localgenre = GenrePruefen();
                        }
                        else
                        {
                            //Es fehlen der Autor und der Verlag
                            AutorErstellen();
                            VerlagErstellen();
                            localautor = AutorPruefen();
                            localverlag = VerlagPruefen();
                            localgenre = GenrePruefen();
                        }
                    }
                }
                else
                {
                    if (VerlagPruefen() == 0)
                    {
                        if (GenrePruefen() == 0)
                        {
                            //Es fehlen der Verlag und das Genre
                            VerlagErstellen();
                            GenreErstellen();
                            localautor = AutorPruefen();
                            localverlag = VerlagPruefen();
                            localgenre = GenrePruefen();
                        }
                        else
                        {
                            //Es fehlt nur der Verlag
                            VerlagErstellen();
                            localautor = AutorPruefen();
                            localverlag = VerlagPruefen();
                            localgenre = GenrePruefen();
                        }
                    }
                    else
                    {
                        if (GenrePruefen() == 0)
                        {
                            //Es fehlt nur das Genre
                            GenreErstellen();
                            localautor = AutorPruefen();
                            localverlag = VerlagPruefen();
                            localgenre = GenrePruefen();
                        }
                        else
                        {
                            //Alle sind schon in der Datenbank und müssen nicht neu erstellt werden
                            localautor = AutorPruefen();
                            localverlag = VerlagPruefen();
                            localgenre = GenrePruefen();
                        }
                    }
                }
                //Hier wird mithilfe eines SQL-Befehls das neue Buch angelegt, dafür werden die ISBN, der Titel, die AutorID, die GenreID und die VerlagsID benötigt
                //und an die Datenbank übergeben
                //Diese werden alle in die Tabelle "buch" geschrieben
                //Die drei IDs sind in den lokalen Variablen gespeichert
                con.Open();
                MySqlCommand verlagerstellen = con.CreateCommand();
                verlagerstellen.CommandType = CommandType.Text;
                verlagerstellen.CommandText = " INSERT INTO `buch` (`ISBN`,`Titel`,`buecher_autor_ID`,`buecher_genre_ID`,`verlage_ID`)" +
                " VALUES(" + "'" + FrmHauptfenster_Erweitert.TmpISBN + "', " + "'" + FrmHauptfenster_Erweitert.TmpTitel + "', " + "'" + localautor + "', " +
                "'" + localgenre + "', " + "'" + localverlag + "');";
                verlagerstellen.ExecuteNonQuery();
                con.Close();
            }
        }

        //Mit dieser Methode werden alle neuen Daten eines veränderten Eintrags in die Datenbank geschrieben
        public static void UpdateBuecher()
        {
            //Mithilfe eines SQL-Befehls werden hier alle Werte aus den einzelnen Textboxen in die Datenbank übertragen und der vorhandene Eintrag wird mit den neuen Werten verändert
            con.Open();
            MySqlCommand updatebuch = con.CreateCommand();
            updatebuch.CommandType = CommandType.Text;
            updatebuch.CommandText = "UPDATE buch Set buecher_Autor_ID=" + FrmHauptfenster_Erweitert.AutorAendernID + ", verlage_ID=" + FrmHauptfenster_Erweitert.VerlagAendernID + ", buecher_genre_ID=" + FrmHauptfenster_Erweitert.GenreAendernID +
            ", buch.Titel=" + "'" + FrmHauptfenster_Erweitert.TitelEingabe + "'" + "Where buch.ISBN = " + FrmHauptfenster_Erweitert.TmpISBN + ";";
            updatebuch.ExecuteNonQuery();
            con.Close();
        }
    }
}
