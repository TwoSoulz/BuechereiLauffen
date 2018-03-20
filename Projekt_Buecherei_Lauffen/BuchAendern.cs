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

        int ID_Genre;
        int ID_Verlag;

        public static int AutorAendern()
        {
            int ID_Autor;

            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buecher_autor.ID FROM buecherei.buecher_autor Where buecher_autor.Autor like " + "'%" + FrmHauptfenster_Erweitert.TmpAutor + "%';";
            search.ExecuteNonQuery();
            MySqlDataReader result = search.ExecuteReader();
            result.Read();
            ID_Autor = result.GetInt32(0);
            con.Close();

            return ID_Autor;
        }

    }
}
