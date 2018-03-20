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

    public partial class FrmHauptfenster_Erweitert : Form
    {
        //MySqlVerbindung
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");
        
        private FrmHauptfenster hauptfenster = null;
        private bool _isLogout;

        public FrmHauptfenster_Erweitert(FrmHauptfenster hauptfenster)
        {
            InitializeComponent();
            this.hauptfenster = hauptfenster;

            //Suchoption der Kombobox
            string[] suchoptionen = new string[] { "Alle", "Titel", "Autor", "Genre", "Verlag", "ISBN" };
            cbAuswahlSuchen_erw.Items.AddRange(suchoptionen);
            cbAuswahlSuchen_erw.SelectedIndex = 0;
            //Spalten werden automatisch an Textlänge angepasst
            lvErgebnis_erw.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            allesanzeigen_erw();

            Textbox_toggle(false);
        }

        private static string eingabeSuche = "";

        public static string EingabeSuche
        {
            get { return eingabeSuche; }
            set { eingabeSuche = value; }
        }

        private void btnAendern_erw_Click(object sender, EventArgs e)
        {
            Textbox_toggle(true);
        }


        private void Textbox_toggle(bool b)
        {
            txbAutor_erw.Enabled = b;
            txbGenre_erw.Enabled = b;
            txbISBN_erw.Enabled = b;
            txbJahr_erw.Enabled = b;
            txbTitel_erw.Enabled = b;
            txbVerlag_erw.Enabled = b;
        }

        private void btnAusloggen_erw_Click(object sender, EventArgs e)
        {
            
            _isLogout = true;
            this.Close();
            hauptfenster.Show();
           
        }

        private void FrmHauptfenster_Erweitert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!_isLogout)
            {
                Environment.Exit(0);
            }
        }

        private void btnReservieren_erw_Click(object sender, EventArgs e)
        {
            FrmReservieren window = new FrmReservieren(hauptfenster);
            window.ShowDialog();
        }

        private void allesanzeigen_erw()
        {
            lvErgebnis_erw.Items.AddRange(Grunddaten.getalleDaten().ToArray());
            lvErgebnis_erw.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvErgebnis_erw.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void SucheAnzeigen()
        {
            lvErgebnis_erw.Items.Clear();
            //hier wird per If die Combobox Auswahl angeschaut und dann die richtige Suche gewählt
            if (cbAuswahlSuchen_erw.SelectedIndex == cbAuswahlSuchen_erw.FindStringExact("Alle"))
            {
                lvErgebnis_erw.Items.AddRange(InventarSuche.AllesSuchen().ToArray());
            }
            if (cbAuswahlSuchen_erw.SelectedIndex == cbAuswahlSuchen_erw.FindStringExact("Titel"))
            {
                lvErgebnis_erw.Items.AddRange(InventarSuche.TitelSuchen().ToArray());
            }
            if (cbAuswahlSuchen_erw.SelectedIndex == cbAuswahlSuchen_erw.FindStringExact("Autor"))
            {
                lvErgebnis_erw.Items.AddRange(InventarSuche.AutorSuchen().ToArray());
            }
            if (cbAuswahlSuchen_erw.SelectedIndex == cbAuswahlSuchen_erw.FindStringExact("Genre"))
            {
                lvErgebnis_erw.Items.AddRange(InventarSuche.GenreSuchen().ToArray());
            }
            if (cbAuswahlSuchen_erw.SelectedIndex == cbAuswahlSuchen_erw.FindStringExact("Verlag"))
            {
                lvErgebnis_erw.Items.AddRange(InventarSuche.VerlagSuchen().ToArray());
            }
            if (cbAuswahlSuchen_erw.SelectedIndex == cbAuswahlSuchen_erw.FindStringExact("ISBN"))
            {
                lvErgebnis_erw.Items.AddRange(InventarSuche.ISBNSuchen().ToArray());
            }
            lvErgebnis_erw.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvErgebnis_erw.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void labelsLoeschen()
        {
            txbISBN_erw.Text = "";
            lblAusgeliehen_Ausgabe_erw.Text = "";
            txbAutor_erw.Text = "";
            txbGenre_erw.Text = "";
            lblReserviert_Ausgabe_erw.Text = "";
            txbTitel_erw.Text = "";
            txbVerlag_erw.Text = "";
        }

        private void lvErgebnis_erw_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvErgebnis_erw.SelectedIndices.Count > 0)
            {
                ListViewItem item = lvErgebnis_erw.SelectedItems[0];

                {
                    for (int i = 0; i < lvErgebnis_erw.Items.Count; i++)
                    {
                        if (lvErgebnis_erw.Items[i].Selected)
                        {
                            txbISBN_erw.Text = lvErgebnis_erw.Items[i].SubItems[0].Text;
                            txbTitel_erw.Text = lvErgebnis_erw.Items[i].SubItems[1].Text;
                            txbAutor_erw.Text = lvErgebnis_erw.Items[i].SubItems[2].Text;
                            txbGenre_erw.Text = lvErgebnis_erw.Items[i].SubItems[3].Text;
                            txbVerlag_erw.Text = lvErgebnis_erw.Items[i].SubItems[4].Text;
                        }
                    }

                }
            }
        }

        private void btnSuchen_erw_Click(object sender, EventArgs e)
        {
            labelsLoeschen();
            eingabeSuche = txbSuche_erw.Text;
            SucheAnzeigen();
        }

        private void txbSuche_erw_KeyDown(object sender, KeyEventArgs e)
        {
            eingabeSuche = txbSuche_erw.Text;
            if (e.KeyCode == Keys.Enter)
            {
                SucheAnzeigen();
            }
            labelsLoeschen();
        }

        private void btnSpeichern_erw_Click(object sender, EventArgs e)
        {
            string tmpAutor;
            string tmpISBN;
            string tmpVerlag;
            string tmpTitel;
            string tmpGenre;

            int ID_Genre;
            int ID_Verlag;
            int ID_Autor;

            tmpAutor = txbAutor_erw.Text;
            tmpGenre = txbGenre_erw.Text;
            tmpISBN = txbISBN_erw.Text;
            tmpTitel = txbTitel_erw.Text;
            tmpVerlag = txbVerlag_erw.Text;

            int autorsql;

            con.Open();
            MySqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT buecher_autor.ID FROM buecherei.buecher_autor Where buecher_autor.Autor like " + "'%" + tmpAutor + "%';";
            search.ExecuteNonQuery();
            MySqlDataReader result = search.ExecuteReader();
            result.Read();
            autorsql = result.GetInt32(0);
            con.Close();
            ID_Autor = autorsql;

            con.Open();
            MySqlCommand updatebuch = con.CreateCommand();
            updatebuch.CommandType = CommandType.Text;
            updatebuch.CommandText = "UPDATE buch Set buecher_Autor_ID=" + ID_Autor + " Where buch.ISBN = " + tmpISBN + ";";

            updatebuch.ExecuteNonQuery();
            con.Close();

        }
    }
}
