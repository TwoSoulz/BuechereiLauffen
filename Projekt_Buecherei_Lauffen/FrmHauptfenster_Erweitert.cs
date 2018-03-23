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
            txbISBN_erw.Enabled = false;
            btnReservieren_erw.Enabled = false;
            btnReservierung_loeschen_erw.Enabled = false;
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
        public static string ausgabeBuch = "";
        public static string AusgabeBuch
        {
            get { return ausgabeBuch; }
            set { ausgabeBuch = value; }
        }

        public static Label erw_reserviertAusgabe;
        public static Label ErwReserviertAusgabe
        {
            get { return erw_reserviertAusgabe; }
            set { erw_reserviertAusgabe = value; }
        }

        public static Label erw_ausgeliehenAusgabe;
        public static Label ErwAusgeliehenAusgabe
        {
            get { return erw_ausgeliehenAusgabe; }
            set { erw_ausgeliehenAusgabe = value; }
        }

        public static int reservierungsID;
        public static int ErwReservierungsID
        {
            get { return reservierungsID; }
            set { reservierungsID = value; }
        }

        public static Button btnReservierung_Loeschen_Ausleihe;
        public static Button BtnReservierung_Loeschen_Ausleihe
        {
            get { return btnReservierung_Loeschen_Ausleihe; }
            set { btnReservierung_Loeschen_Ausleihe = value; }
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
            TmpVarsSetzen();

            autorAendernID = BuchAendern.AutorPruefen();
            genreAendernID = BuchAendern.GenrePruefen();
            verlagAendernID = BuchAendern.VerlagPruefen();

            if (autorAendernID == 0)
            {
                BuchAendern.AutorErstellen();
                autorAendernID = BuchAendern.AutorPruefen();
            }

            if (genreAendernID == 0)
            {
                BuchAendern.GenreErstellen();
                genreAendernID = BuchAendern.GenrePruefen();
            }

            if (verlagAendernID == 0)
            {
                BuchAendern.VerlagErstellen();
                verlagAendernID = BuchAendern.VerlagPruefen();
            }

            BuchAendern.UpdateBuecher();
            SucheAnzeigen();

            AlleButtonsaufStart();
        }

        //Hier wird ein vorhandener Eintrag komplett aus der Datenbank gelöscht
        private void btnLoeschen_erw_Click(object sender, EventArgs e)
        {
            tmpISBN = txbISBN_erw.Text;

            if (lblReserviert_Ausgabe_erw.Text == "Ja" || lblAusgeliehen_Ausgabe_erw.Text == "Ja")
            {
                MessageBox.Show("Buch ist reserviert oder ausgeliehen. Bitte erst das Buch zurückgeben oder die Reservierung löschen.");
            }
            else
            {
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
            Textbox_clear();
        }

        //Dieser Button aktiviert die Textboxen und den Button für das Hinzufügen eines neuen Objektes
        private void btnNeu_erw_Click(object sender, EventArgs e)
        {
            TmpVarsSetzen();

            Textbox_clear();
            Textbox_toggle(true);
            txbISBN_erw.Enabled = true;
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

            TmpVarsSetzen();

            BuchAendern.BuchHinzufuegen();

            SucheAnzeigen();
            AlleButtonsaufStart();
            txbISBN_erw.Enabled = false;
        }

        //Mit diesem Button werden sowohl die Eingaben beim Neuerstellen eines Buchs als auch beim Ändern gelöscht und die Textboxen wieder gesperrt
        private void btnAbbrechen_Click(object sender, EventArgs e)
        {
            labelsLoeschen();
            AlleButtonsaufStart();
            txbISBN_erw.Enabled = false;
        }

        //Hier werden Bücher reserviert //Es ist nur eine Reservierung pro Buch möglich
        private void btnReservieren_erw_Click(object sender, EventArgs e)
        {
            erw_reserviertAusgabe = lblReserviert_Ausgabe_erw;
            ausgabeBuch = txbTitel_erw.Text;
            FrmReservieren.AktivesBuch = ausgabeBuch;
            FrmReservieren.AktuelleISBN = txbISBN_erw.Text;
            FrmReservieren window = new FrmReservieren(hauptfenster);
            btnReservieren_erw.Enabled = false;
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

        //Alle Key-Down Events
        //Siehe BUtton suchen
        private void txbSuche_erw_KeyDown_1(object sender, KeyEventArgs e)
        {
            eingabeSuche = txbSuche_erw.Text;
            if (e.KeyCode == Keys.Enter)
            {
                SucheAnzeigen();
            }
            labelsLoeschen();
        }

        //Alle Textboxen enablen oder Disablen
        private void Textbox_toggle(bool b)
        {
            txbAutor_erw.Enabled = b;
            txbGenre_erw.Enabled = b;
            txbTitel_erw.Enabled = b;
            txbVerlag_erw.Enabled = b;
        }

        //Denn Ihalt aller Textboxen löschen
        private void Textbox_clear()
        {
            txbAutor_erw.Clear();
            txbGenre_erw.Clear();
            txbTitel_erw.Clear();
            txbVerlag_erw.Clear();
            txbISBN_erw.Clear();
        }

        private void TmpVarsSetzen()
        {
            tmpAutor = txbAutor_erw.Text;
            tmpGenre = txbGenre_erw.Text;
            tmpISBN = txbISBN_erw.Text;
            tmpTitel = txbTitel_erw.Text;
            tmpVerlag = txbVerlag_erw.Text;
            TitelEingabe = txbTitel_erw.Text;
        }

        //Wird ausgeführt, wenn der User sich ausgeloggt hat //Schließt das Fenster
        private void FrmHauptfenster_Erweitert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isLogout)
            {
                Environment.Exit(0);
            }
        }

        //Beim Start des Programms werden hiermit alle Einträge der Datenbank angezeigt
        private void allesanzeigen_erw()
        {
            lvErgebnis_erw.Items.AddRange(Grunddaten.getalleDaten().ToArray());
            lvErgebnis_erw.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvErgebnis_erw.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        //Sobald in der Suche etwas eingegeben wurde und die Suche gestartet wurde, werden hiermit alle Ergebnisse angezeigt
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

        //Hier wird der Inhalt aller Labels und alle Textboxen gelöscht
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

        //Sobald ein Item in der Listview selektiert wird, wird dieses mithilfe diser Methode ausgewählt und in den Textboxen angezeigt
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

            //Reservieren Ja und Nein sowie Buttons Aktivieren/Deaktivieren
            btnReservieren_erw.Enabled = true;
            btnReservierung_loeschen_erw.Enabled = true;
            FrmReservieren.AktuelleISBN = txbISBN_erw.Text;
            int rescheck = BuchReservieren.ReservierungChecken();
            if (rescheck != 0)
            {
                lblReserviert_Ausgabe_erw.Text = "Ja";
                btnReservieren_erw.Enabled = false;
            }
            else
            {
                lblReserviert_Ausgabe_erw.Text = "Nein";
                btnReservierung_loeschen_erw.Enabled = false;
            }

            //Ausgeliehen Ja und Nein sowie Buttons aktivieren/deaktivieren
            btnAusleihen_erw.Enabled = true;
            btnZurueck_erw.Enabled = false;
            FrmAusleihen.AktuelleISBN_Ausleihe = txbISBN_erw.Text;
            int ausgeliehen_check = BuchAusleihen.AusgeliehenCheck();
            if (ausgeliehen_check != 0)
            {
                lblAusgeliehen_Ausgabe_erw.Text = "Ja";
                btnAusleihen_erw.Enabled = false;
                btnZurueck_erw.Enabled = true;
                btnReservierung_loeschen_erw.Enabled = false;
            }
            else
            {
                lblAusgeliehen_Ausgabe_erw.Text = "Nein";
            }
        }

        private void btnReservierung_loeschen_erw_Click(object sender, EventArgs e)
        {
            //Reservierung löschen beim zurückgeben
            BuchAusleihen.ReservierungLöschen_Ausleihe();

            BuchReservieren.ReservierungLoeschen();
            int rescheck = BuchReservieren.ReservierungChecken();
            if (rescheck != 0)
            {
                lblReserviert_Ausgabe_erw.Text = "Ja";
                btnReservieren_erw.Enabled = false;
            }
            else
            {
                lblReserviert_Ausgabe_erw.Text = "Nein";
                btnReservierung_loeschen_erw.Enabled = false;
            }
        }

        private void btnAusleihen_erw_Click(object sender, EventArgs e)
        {
            btnReservierung_Loeschen_Ausleihe = btnReservierung_loeschen_erw;
            FrmAusleihen.aktivesBuch = txbTitel_erw.Text;
            erw_ausgeliehenAusgabe = lblAusgeliehen_Ausgabe_erw;
            FrmAusleihen.AktuelleISBN_Ausleihe = txbISBN_erw.Text;
            reservierungsID = BuchAusleihen.ReservierungIDRausfinden_Ausleihe();

            if (reservierungsID != 0)
            {
                FrmAusleihen window = new FrmAusleihen(hauptfenster);
                window.ShowDialog();
            }

            else
            {
                MessageBox.Show("Sie müssen das Buch zuerst reservieren!");
            }

        }

        private void btnZurueck_erw_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sind Sie sicher das Sie das Buch zurückgeben wollen?", "Buch löschen", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Reservierung löschen beim zurückgeben
                BuchAusleihen.ReservierungLöschen_Ausleihe();
                //Ausleihe löschen
                BuchAusleihen.AusleiheLoeschen();
                //Reservieren Ja und Nein sowie Buttons Aktivieren/Deaktivieren
                btnReservieren_erw.Enabled = true;
                btnReservierung_loeschen_erw.Enabled = true;
                FrmReservieren.AktuelleISBN = txbISBN_erw.Text;
                int rescheck = BuchAusleihen.ReservierungIDRausfinden_Ausleihe();
                if (rescheck != 0)
                {
                    lblReserviert_Ausgabe_erw.Text = "Ja";
                    btnReservieren_erw.Enabled = false;
                }
                else
                {
                    lblReserviert_Ausgabe_erw.Text = "Nein";
                    btnReservierung_loeschen_erw.Enabled = false;
                }

                //Ausgeliehen Ja und Nein sowie Buttons aktivieren/deaktivieren
                btnAusleihen_erw.Enabled = true;
                btnZurueck_erw.Enabled = false;
                int ausgeliehen_check = BuchAusleihen.AusgeliehenCheck();
                if (ausgeliehen_check != 0)
                {
                    lblAusgeliehen_Ausgabe_erw.Text = "Ja";
                    btnAusleihen_erw.Enabled = false;
                    btnZurueck_erw.Enabled = true;
                    btnReservierung_loeschen_erw.Enabled = false;
                }
                else
                {
                    lblAusgeliehen_Ausgabe_erw.Text = "Nein";
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Gute Entscheidung mein junger Padawan!");
                //Reservieren Ja und Nein sowie Buttons Aktivieren/Deaktivieren
                btnReservieren_erw.Enabled = true;
                btnReservierung_loeschen_erw.Enabled = true;
                FrmReservieren.AktuelleISBN = txbISBN_erw.Text;
                int rescheck = BuchReservieren.ReservierungChecken();
                if (rescheck != 0)
                {
                    lblReserviert_Ausgabe_erw.Text = "Ja";
                    btnReservieren_erw.Enabled = false;
                }
                else
                {
                    lblReserviert_Ausgabe_erw.Text = "Nein";
                    btnReservierung_loeschen_erw.Enabled = false;
                }

                //Ausgeliehen Ja und Nein sowie Buttons aktivieren/deaktivieren
                btnAusleihen_erw.Enabled = true;
                btnZurueck_erw.Enabled = false;
                int ausgeliehen_check = BuchAusleihen.AusgeliehenCheck();
                if (ausgeliehen_check != 0)
                {
                    lblAusgeliehen_Ausgabe_erw.Text = "Ja";
                    btnAusleihen_erw.Enabled = false;
                    btnZurueck_erw.Enabled = true;
                }
                else
                {
                    lblAusgeliehen_Ausgabe_erw.Text = "Nein";
                }
            }


        }
    }
}
