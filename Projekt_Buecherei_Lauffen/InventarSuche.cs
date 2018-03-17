﻿using System;
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
    public class InventarSuche
    {

        
        //MySqlVerbindung
        private static MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");


        public static List<ListViewItem> AllesSuchen()
        {
            string aktiveForm = "";
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }

            List<ListViewItem> daten = new List<ListViewItem>();

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

                daten.Add(new ListViewItem(new string[]{ result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                n++;
            }
            con.Close();
            return daten;
        }

            public static List<ListViewItem> TitelSuchen()
            {

            string aktiveForm = "";
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }
            List<ListViewItem> daten = new List<ListViewItem>();

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

                    daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                    n++;
                }
                con.Close();
                return daten;
            }

            public static List<ListViewItem> AutorSuchen()
            {
            string aktiveForm = "";
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }
            List<ListViewItem> daten = new List<ListViewItem>();

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

                    daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                    n++;
                }
                con.Close();
                return daten;
            }

            public static List<ListViewItem> GenreSuchen()
            {
            string aktiveForm = "";
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }
            List<ListViewItem> daten = new List<ListViewItem>();

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

                    daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                    n++;
                }
                con.Close();
                return daten;
            }
            public static List<ListViewItem> VerlagSuchen()
            {
            string aktiveForm = "";
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }
            List<ListViewItem> daten = new List<ListViewItem>();

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

                    daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                    n++;
                }
                con.Close();
                return daten;
            }
            public static List<ListViewItem> ISBNSuchen()
            {
            string aktiveForm = "";
            if (FrmHauptfenster.aktiv == false)
            {
                aktiveForm = FrmHauptfenster_Erweitert.EingabeSuche;
            }
            else
            {
                aktiveForm = FrmHauptfenster.EingabeSuche;
            }
            List<ListViewItem> daten = new List<ListViewItem>();

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
                    daten.Add(new ListViewItem(new string[] { result.GetString(0), result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4) }));
                    n++;
                }
                con.Close();
                return daten;
            }



    }
}
