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

        //Get und Set Methoden 
        private static string eingabeSuche = "";
        public static string EingabeSuche
        {
            get { return eingabeSuche; }
            set { eingabeSuche = value; }
        }

        private static string tmpAutor = "";
        public static string TmpAutor
        {
            get { return tmpAutor; }
            set { tmpAutor = value; }
        }

        private static string tmpISBN = "";
        public static string TmpISBN
        {
            get { return tmpISBN; }
            set { tmpISBN = value; }
        }

        private static string tmpVerlag = "";
        public static string TmpVerlag
        {
            get { return tmpVerlag; }
            set { tmpVerlag = value; }
        }

        private static string tmpTitel = "";
        public static string TmpTitel
        {
            get { return tmpTitel; }
            set { tmpTitel = value; }
        }

        private static string tmpGenre = "";
        public static string TmpGenre
        {
            get { return tmpGenre; }
            set { tmpGenre = value; }
        }

        private static int autorAendernID;
        public static int AutorAendernID
        {
            get { return autorAendernID; }
            set { autorAendernID = value; }
        }

        private static int genreAendernID;
        public static int GenreAendernID
        {
            get { return genreAendernID; }
            set { genreAendernID = value; }
        }

        private static int verlagAendernID;
        public static int VerlagAendernID
        {
            get { return verlagAendernID; }
            set { verlagAendernID = value; }
        }

        private static string titelEingabe;
        public static string TitelEingabe
        {
            get { return titelEingabe; }
            set { titelEingabe = value; }
        }

        //Alle Button Aktionen
        //Hier wird die Suche durch den Klick auf den Button aufgerufen
        private void btnSuchen_erw_Click(object sender, EventArgs e)
        {
            labelsLoeschen();
            eingabeSuche = txbSuche_erw.Text;
            SucheAnzeigen();
        }

        //Hiermit wird das Erweiterte Fenster geschlossen //Der angemeldete User hat sich ausgeloggt
        private void btnAusloggen_erw_Click(object sender, EventArgs e)
        {

            _isLogout = true;
            this.Close();
            hauptfenster.Show();

        }

        //Hiermit können vorhandene Bücher geändert werden
        private void btnAendern_erw_Click(object sender, EventArgs e)
        {
            Textbox_toggle(true);
            lvErgebnis_erw.Enabled = false;
            btnAbbrechen.Enabled = true;
            btnSpeichern_erw.Enabled = true;
            btnLoeschen_erw.Enabled = false;
            btnNeu_erw.Enabled = false;
        }

        //Hiermit werden die Daten gespeichert, die Eingetragen wurden nachdem der Button Ändern gedruckt wurde
        private void btnSpeichern_erw_Click(object sender, EventArgs e)
        {
            tmpAutor = txbAutor_erw.Text;
            tmpGenre = txbGenre_erw.Text;
            tmpISBN = txbISBN_erw.Text;
            tmpTitel = txbTitel_erw.Text;
            tmpVerlag = txbVerlag_erw.Text;
            TitelEingabe = txbTitel_erw.Text;

            autorAendernID = BuchAendern.AutorAendern();
            genreAendernID = BuchAendern.GenreAendern();
            verlagAendernID = BuchAendern.VerlagAendern();

            if (autorAendernID == 0)
            {
                BuchAendern.AutorErstellen();
                autorAendernID = BuchAendern.AutorAendern();
            }

            if (genreAendernID == 0)
            {
                BuchAendern.GenreErstellen();
                genreAendernID = BuchAendern.GenreAendern();
            }

            if (verlagAendernID == 0)
            {
                BuchAendern.VerlagErstellen();
                verlagAendernID = BuchAendern.VerlagAendern();
            }

            BuchAendern.UpdateBuecher();
            SucheAnzeigen();

            AlleButtonsaufStart();
        }

        //Hier wird ein vorhandener Eintrag komplett aus der Datenbank gelöscht
        private void btnLoeschen_erw_Click(object sender, EventArgs e)
        {
            tmpISBN = txbISBN_erw.Text;

            DialogResult dialogResult = MessageBox.Show("Sind Sie sich sicher, dass sie das Buch löschen möchten? Dieser Vorgang kann nicht rückgängig gemacht werden!", "Buch löschen", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                BuchAendern.BuchLoeschen();
                SucheAnzeigen();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Gute Entscheidung mein junger Padawan!");
                SucheAnzeigen();
            }
        }

        //Dieser Button aktiviert die Textboxen und den Button für das Hinzufügen eines neuen Objektes
        private void btnNeu_erw_Click(object sender, EventArgs e)
        {
            Textbox_clear();
            Textbox_toggle(true);
            lvErgebnis_erw.Enabled = false;
            btnAbbrechen.Enabled = true;
            btnHinzufgn.Enabled = true;
            btnAendern_erw.Enabled = false;
            btnLoeschen_erw.Enabled = false;
            btnSpeichern_erw.Enabled = false;
            btnNeu_erw.Enabled = false;
        }

        //Hier werden die Werte, die in den Textboxen stehen in die Datenbank als neuer Eintrag geschrieben
        private void btnHinzufgn_Click(object sender, EventArgs e)
        {
            lvErgebnis_erw.Enabled = false;

            tmpAutor = txbAutor_erw.Text;
            tmpGenre = txbGenre_erw.Text;
            tmpISBN = txbISBN_erw.Text;
            tmpTitel = txbTitel_erw.Text;
            tmpVerlag = txbVerlag_erw.Text;

            BuchAendern.BuchHinzufuegen();

            SucheAnzeigen();
            AlleButtonsaufStart();
        }

        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            labelsLoeschen();
            AlleButtonsaufStart();
        }

        private void btnReservieren_erw_Click(object sender, EventArgs e)
        {
            FrmReservieren window = new FrmReservieren(hauptfenster);
            window.ShowDialog();
        }

        //Hier werden alle Buttons auf den Startwert gesetzt //Das heißt ob sie Enabled oder Disabled sind
        private void AlleButtonsaufStart()
        {
            lvErgebnis_erw.Enabled = true;
            Textbox_clear();
            Textbox_toggle(false);
            btnAendern_erw.Enabled = true;
            btnLoeschen_erw.Enabled = true;
            btnNeu_erw.Enabled = true;

            btnSpeichern_erw.Enabled = false;
            btnHinzufgn.Enabled = false;
            btnAbbrechen.Enabled = false;
        }

        private void txbSuche_erw_KeyDown_1(object sender, KeyEventArgs e)
        {
            eingabeSuche = txbSuche_erw.Text;
            if (e.KeyCode == Keys.Enter)
            {
                SucheAnzeigen();
            }
            labelsLoeschen();
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

        private void Textbox_toggle(bool b)
        {
            txbAutor_erw.Enabled = b;
            txbGenre_erw.Enabled = b;
            txbTitel_erw.Enabled = b;
            txbVerlag_erw.Enabled = b;
        }

        private void Textbox_clear()
        {
            txbAutor_erw.Clear();
            txbGenre_erw.Clear();
            txbTitel_erw.Clear();
            txbVerlag_erw.Clear();
            txbISBN_erw.Clear();

            txbISBN_erw.ReadOnly = false;
        }
        private void FrmHauptfenster_Erweitert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isLogout)
            {
                Environment.Exit(0);
            }
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
    }
}
