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

namespace Projekt_Buecherei_Lauffen
{
    public partial class FrmHauptfenster : Form
    {

        //MySqlVerbindung
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");



        public FrmHauptfenster()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelsLoeschen();
            //Suchoption der Kombobox
            string[] suchoptionen = new string[] { "Alles", "Titel", "Autor", "Genre", "Verlag", "ISBN" };
            cbAuswahlSuchen.Items.AddRange(suchoptionen);
            cbAuswahlSuchen.SelectedIndex = 0;
            //Spalten werden automatisch an Textlänge angepasst
            lvErgebnis.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            allesanzeigen();
            lvErgebnis.FullRowSelect = true;
        }

        private static string eingabeSuche = "";

        public static string EingabeSuche
        {
            get { return eingabeSuche; }
            set { eingabeSuche = value; }
        }

        private void btnReservieren_Click(object sender, EventArgs e)
        {
            FrmReservieren window = new FrmReservieren(this);
            window.ShowDialog();
        }

        private void btnAnmelden_Click(object sender, EventArgs e)
        {
            labelsLoeschen();
            userAnmeldung();
        }

        private void btnSuchen_Click(object sender, EventArgs e)
        {
            labelsLoeschen();
            eingabeSuche = txb_Suche.Text;
            SucheAnzeigen();
        }
        private void txb_Suche_KeyDown(object sender, KeyEventArgs e)
        {
            eingabeSuche = txb_Suche.Text;
            if (e.KeyCode == Keys.Enter)
            {
                SucheAnzeigen();
            }
            labelsLoeschen();
        }

        private void txbPasswort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                userAnmeldung();
            }
            labelsLoeschen();
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

        private List<ListViewItem> AllesSuchen()
        {
            List<ListViewItem> daten = new List<ListViewItem>();

            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buch.ISBN, buch.Titel, buecher_autor.Autor, buecher_genre.Genre, buecher_verlage.Verlag FROM buecherei.buch " +
                "JOIN buecher_autor ON buch.buecher_autor_ID = buecher_autor.ID JOIN buecher_genre ON buch.buecher_genre_ID = buecher_genre.ID JOIN buecher_verlage ON buch.verlage_ID = buecher_verlage.ID " +
                "Where buch.Titel LIKE " + "'%" + txb_Suche.Text + "%'" + " or buecher_autor.Autor LIKE " + "'%" + txb_Suche.Text + "%'" + " or buecher_genre.Genre LIKE " + "'%" + txb_Suche.Text + "%'" +
                " or buecher_verlage.Verlag LIKE " + "'%" + txb_Suche.Text + "%'" + " or buch.ISBN like " + "'%" + txb_Suche.Text + "%';"; 

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

        private void allesanzeigen()
        {
            lvErgebnis.Items.AddRange(Grunddaten.getalleDaten().ToArray());
            lvErgebnis.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvErgebnis.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void lvErgebnis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvErgebnis.SelectedIndices.Count > 0)
            {
                ListViewItem item = lvErgebnis.SelectedItems[0];

                {
                    for (int i = 0; i < lvErgebnis.Items.Count; i++)
                    {
                        if (lvErgebnis.Items[i].Selected)
                        {
                            lblAusgabe_ISBN.Text = lvErgebnis.Items[i].SubItems[0].Text;
                            lblTitel_Ausgabe.Text = lvErgebnis.Items[i].SubItems[1].Text;
                            lblAutor_Ausgabe.Text = lvErgebnis.Items[i].SubItems[2].Text;
                            lblGenre_Ausgabe.Text = lvErgebnis.Items[i].SubItems[3].Text;
                            lblVerlag_Ausgabe.Text = lvErgebnis.Items[i].SubItems[4].Text;
                        }
                    }

                }
            }
        }
        
        private void SucheAnzeigen ()
        {
            lvErgebnis.Items.Clear();
            //hier wird per If die Combobox Auswahl angeschaut und dann die richtige Suche gewählt
            if (cbAuswahlSuchen.SelectedIndex == cbAuswahlSuchen.FindStringExact("Alles"))
            {
                lvErgebnis.Items.AddRange(InventarSuche.AllesSuchen().ToArray());
            }
            if (cbAuswahlSuchen.SelectedIndex == cbAuswahlSuchen.FindStringExact("Titel"))
            {
                lvErgebnis.Items.AddRange(InventarSuche.TitelSuchen().ToArray());
            }
            if (cbAuswahlSuchen.SelectedIndex == cbAuswahlSuchen.FindStringExact("Autor"))
            {
                lvErgebnis.Items.AddRange(InventarSuche.AutorSuchen().ToArray());
            }
            if (cbAuswahlSuchen.SelectedIndex == cbAuswahlSuchen.FindStringExact("Genre"))
            {
                lvErgebnis.Items.AddRange(InventarSuche.GenreSuchen().ToArray());
            }
            if (cbAuswahlSuchen.SelectedIndex == cbAuswahlSuchen.FindStringExact("Verlag"))
            {
                lvErgebnis.Items.AddRange(InventarSuche.VerlagSuchen().ToArray());
            }
            if (cbAuswahlSuchen.SelectedIndex == cbAuswahlSuchen.FindStringExact("ISBN"))
            {
                lvErgebnis.Items.AddRange(InventarSuche.ISBNSuchen().ToArray());
            }
            lvErgebnis.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvErgebnis.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void labelsLoeschen()
        {
            lblAusgabe_ISBN.Text = "";
            lblAusgeliehen_Ausgabe.Text = "";
            lblAutor_Ausgabe.Text = "";
            lblGenre_Ausgabe.Text = "";
            lblReserviert_Ausgabe.Text = "";
            lblTitel_Ausgabe.Text = "";
            lblVerlag_Ausgabe.Text = "";
        }
        
       
    }
}