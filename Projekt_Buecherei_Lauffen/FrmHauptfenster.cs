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

namespace Projekt_Buecherei_Lauffen
{
    public partial class FrmHauptfenster : Form
    {
        //MySqlVerbindung
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");

        //Listbox Aufteilung
        string stdDetails = "{0, -45}{1, -45}{2, -45}{3, -45}{4, -45}";
        
        public FrmHauptfenster()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] suchoptionen = new string[] { "Alle", "Titel", "Autor", "Genre", "Verlag", "ISBN" };
            cbAuswahlSuchen.Items.AddRange(suchoptionen);
            cbAuswahlSuchen.SelectedIndex = 0;

            lbErgebnis.Items.Add(String.Format(stdDetails, "ISBN", "Titel", "Autor", "Genre", "Verlag"));
        }

        private void btnReservieren_Click(object sender, EventArgs e)
        {
            FrmReservieren window = new FrmReservieren(this);
            window.ShowDialog();
        }

        private void btnAnmelden_Click(object sender, EventArgs e)
        {
            userAnmeldung();
        }

        private void btnSuchen_Click(object sender, EventArgs e)
        {
            string ISBN, Titel, Autor, Genre, Verlag;
            lbErgebnis.Items.AddRange(Suche.getalleSuche().ToArray());
            normaleSuche();
        }

        private void userAnmeldung()
        {
            //Zähler setzen
            int i = 0;
            //MySqlVerbindung aufbauen
            con.Open();
            //MySql Befehl erstellen
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from mitarbeiter where Vorname ='" + txbBenutzer.Text + "' and Passwort ='" + txbPasswort.Text + "'";
            //Ausführen des Befehls
            cmd.ExecuteNonQuery();
            //Erstellen von DataTable und DataAdapter
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            //Wenn i==0 dann ist entweder username oder passwort falsch, ansonsten Anmeldung erfolgreich
            if (i == 0)
            {
                MessageBox.Show("Wrong username or password");
                i = 0;
            }

            else
            {
                //Hauptfenster Erweitert wird angelegt
                this.Hide();
                FrmHauptfenster_Erweitert window = new FrmHauptfenster_Erweitert(this);
                window.Show();
                i = 0;
            }
            //Database Connection Close und clearen der Textboxen 
            txbPasswort.Clear();
            txbBenutzer.Clear();
            con.Close();
        }

        private void txbPasswort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                userAnmeldung();
        }

        private void normaleSuche ()
        {
            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "select * from buch;";
            if (cbAuswahlSuchen.SelectedText == "Alle")
            {
                search.ExecuteNonQuery();
            }

            
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(search);
            da.Fill(dt);
        }
     
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
