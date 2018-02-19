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
     public class Suche
     {
         //MySqlVerbindung
         private static MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");
         
         private string Titel;
         private string Autor;


        //TITEL
        public string getTitel()
        {
            return Titel;
        }
        public void setTitel(string t)
        {
            Titel = t;
        }

        //AUTOR
        public string getAutor()
        {
            return Autor;
        }
        public void setAutor(string a)
        {
            Autor = a;
        }

         public static List<Suche> getalleSuche()
         {
            
            List<Suche> daten = new List<Suche>();
            //List<Tuple<string[], List<object>>> l = new List<Tuple<string[],List<object>>>();
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "select * from buch";
            search.ExecuteNonQuery();
            MySqlDataReader result = search.ExecuteReader();
 
             while (result.Read())
             {
                 Suche s = new Suche();
                 //s.setAutor(result.GetString(2));
                 s.setTitel(result.GetString(1));
                 daten.Add(s);
             }
             con.Close();
             return daten;
         }

         public override string ToString()
         {
             return Titel;
         }
          
     }
 }