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
    class BuchAendern
    {
        //MySqlVerbindung
        private static MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");

        //int ID_Genre;
        //int ID_Verlag;

        

        public static int AutorAendern()
        {                           
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buecher_autor.ID FROM buecherei.buecher_autor Where buecher_autor.Autor like " + "'%" + FrmHauptfenster_Erweitert.TmpAutor + "%';";
            search.ExecuteNonQuery();
            MySqlDataReader reader = search.ExecuteReader();

            reader.Read();           

            if(reader.HasRows)
            {
                var autorId = reader.GetInt32(0);                
                reader.Close();
                con.Close();
                return autorId;
            }

            reader.Close();
            con.Close();
            return 0;
        }

        public static void AutorErstellen()
        {
            con.Open();
            MySqlCommand autorerstellen = con.CreateCommand();
            autorerstellen.CommandType = CommandType.Text;
            autorerstellen.CommandText = "INSERT INTO `buecher_autor` (`Autor`) VALUES ('" + FrmHauptfenster_Erweitert.TmpAutor + "');";
            autorerstellen.ExecuteNonQuery();
            con.Close();

        }

        public static int GenreAendern()
        {
            con.Open();
            MySqlCommand aendern = con.CreateCommand();
            aendern.CommandType = CommandType.Text;
            aendern.CommandText = "SELECT buecher_genre.ID FROM buecherei.buecher_genre Where buecher_genre.Genre like " + "'%" + FrmHauptfenster_Erweitert.TmpGenre + "%';";
            aendern.ExecuteNonQuery();
            MySqlDataReader reader = aendern.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                var genreID = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return genreID;
            }

            reader.Close();
            con.Close();
            return 0;
        }

        public static void GenreErstellen()
        {
            con.Open();
            MySqlCommand genreerstellen = con.CreateCommand();
            genreerstellen.CommandType = CommandType.Text;
            genreerstellen.CommandText = "INSERT INTO `buecher_genre` (`Genre`) VALUES ('" + FrmHauptfenster_Erweitert.TmpGenre + "');";
            genreerstellen.ExecuteNonQuery();
            con.Close();

        }

        public static int VerlagAendern()
        {
            con.Open();
            MySqlCommand aendern = con.CreateCommand();
            aendern.CommandType = CommandType.Text;
            aendern.CommandText = "SELECT buecher_verlage.ID FROM buecherei.buecher_verlage Where buecher_verlage.Verlag like " + "'%" + FrmHauptfenster_Erweitert.TmpVerlag + "%';";
            aendern.ExecuteNonQuery();
            MySqlDataReader reader = aendern.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                var verlagID = reader.GetInt32(0);
                reader.Close();
                con.Close();
                return verlagID;
            }

            reader.Close();
            con.Close();
            return 0;
        }

        public static void VerlagErstellen()
        {
            con.Open();
            MySqlCommand verlagerstellen = con.CreateCommand();
            verlagerstellen.CommandType = CommandType.Text;
            verlagerstellen.CommandText = "INSERT INTO `buecher_verlage` (`Verlag`) VALUES ('" + FrmHauptfenster_Erweitert.TmpVerlag + "');";
            verlagerstellen.ExecuteNonQuery();
            con.Close();
        }

        public static void BuchLoeschen()
        {
            con.Open();
            MySqlCommand verlagerstellen = con.CreateCommand();
            verlagerstellen.CommandType = CommandType.Text;
            verlagerstellen.CommandText = "Delete From buch Where ISBN =" + "'" + FrmHauptfenster_Erweitert.TmpISBN + "';";
            verlagerstellen.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateBuecher()
        {
            con.Open();
            MySqlCommand updatebuch = con.CreateCommand();
            updatebuch.CommandType = CommandType.Text;
            updatebuch.CommandText = "UPDATE buch Set buecher_Autor_ID=" + FrmHauptfenster_Erweitert.AutorAendernID + ", verlage_ID=" + FrmHauptfenster_Erweitert.VerlagAendernID + ", buecher_genre_ID=" + FrmHauptfenster_Erweitert.GenreAendernID + 
            ", buch.Titel=" +"'" + FrmHauptfenster_Erweitert.TitelEingabe + "'" + "Where buch.ISBN = " + FrmHauptfenster_Erweitert.TmpISBN + ";";
            updatebuch.ExecuteNonQuery();
            con.Close();
        }

        public static int ISBNPruefen()
        {
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buch.ISBN FROM buecherei.buch Where buch.ISBN like " + "'%" + FrmHauptfenster_Erweitert.TmpISBN + "%';";
            search.ExecuteNonQuery();
            MySqlDataReader reader = search.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                reader.Close();
                con.Close();
                return 1;
            }

            reader.Close();
            con.Close();
            return 0;
        }

        public static void BuchHinzufuegen()
        {
            {
                //lokale Variablen
                int localautor = 0;
                int localverlag = 0;
                int localgenre = 0;


                if (ISBNPruefen() == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("ISBN ist schon vergeben.", "Fehler beim erstellen", MessageBoxButtons.OK);
                }
                else
                {
                    if (AutorAendern() == 0)
                    {
                        if (VerlagAendern() == 0)
                        {
                            if (GenreAendern() == 0)
                            {
                                AutorErstellen();
                                VerlagErstellen();
                                GenreErstellen();
                                localautor = AutorAendern();
                                localverlag = VerlagAendern();
                                localgenre = GenreAendern();
                            }
                            else
                            {
                                AutorErstellen();
                                VerlagErstellen();
                                localautor = AutorAendern();
                                localverlag = VerlagAendern();
                                localgenre = GenreAendern();
                            }
                        }
                        else
                        {
                            if (GenreAendern() == 0)
                            {
                                AutorErstellen();
                                GenreErstellen();
                                localautor = AutorAendern();
                                localverlag = VerlagAendern();
                                localgenre = GenreAendern();
                            }
                            else
                            {
                                AutorErstellen();
                                VerlagErstellen();
                                localautor = AutorAendern();
                                localverlag = VerlagAendern();
                                localgenre = GenreAendern();
                            }
                        }
                    }
                    else
                    {
                        if (VerlagAendern() == 0)
                        {
                            if (GenreAendern() == 0)
                            {
                                VerlagErstellen();
                                GenreErstellen();
                                localautor = AutorAendern();
                                localverlag = VerlagAendern();
                                localgenre = GenreAendern();
                            }
                            else
                            {
                                VerlagErstellen();
                                localautor = AutorAendern();
                                localverlag = VerlagAendern();
                                localgenre = GenreAendern();
                            }
                        }
                        else
                        {
                            if (GenreAendern() == 0)
                            {
                                GenreErstellen();
                                localautor = AutorAendern();
                                localverlag = VerlagAendern();
                                localgenre = GenreAendern();
                            }
                            else
                            {
                                localautor = AutorAendern();
                                localverlag = VerlagAendern();
                                localgenre = GenreAendern();
                            }
                        }
                    }
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
        }
    }
}
