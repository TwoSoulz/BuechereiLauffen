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
        //Dies ist das Startfenster, dass gestartet wird wenn die Anwendung ausgeführt wird
        //MySqlVerbindung
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");

        //Initialisierung
        public FrmHauptfenster()
        {
            InitializeComponent();
        }

        //erstmaliges Laden der Form
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
            btnReservieren.Enabled = false;
        }

        //get und set Methoden
        private static string eingabeSuche = "";
        public static string EingabeSuche
        {
            get { return eingabeSuche; }
            set { eingabeSuche = value; }
        }

        public static string ausgabeBuch = "";
        public static string AusgabeBuch
        {
            get { return ausgabeBuch; }
            set { ausgabeBuch = value; }
        }

        public static Label reserviertAusgabe;
        public static Label ReserviertAusgabe
        {
            get { return reserviertAusgabe; }
            set { reserviertAusgabe = value; }
        }

        public static bool aktiv = true;
        public static bool Aktiv
        {
            get { return aktiv; }
            set { aktiv = value; }
        }

        //Alle Buttons
        //Sobald der Button reservieren gedrückt wird öffnet sich die Form reservieren
        public void btnReservieren_Click(object sender, EventArgs e)
        {
            reserviertAusgabe = lblReserviert_Ausgabe;
            ausgabeBuch = lblTitel_Ausgabe.Text;
            FrmReservieren.AktivesBuch = ausgabeBuch;
            FrmReservieren.AktuelleISBN = lblAusgabe_ISBN.Text;
            FrmReservieren window = new FrmReservieren(this);
            btnReservieren.Enabled = false;
            window.ShowDialog();           
        }

        //Mit Klick auf diesen Button wird geprüft ob die Logindaten in den beiden Textboxen korrekt sind, dies geschieht in der extra Methode "userAnmelden"
        private void btnAnmelden_Click(object sender, EventArgs e)
        {
            labelsLoeschen();
            userAnmeldung();
        }

        //Wenn dieser Button gedrückt wird, wird der Wert, der in der Suche steht an die Klasse "InventarSuche" übertragen und dort wird dann das Ergebnis zurückgegeben
        //Wenn das Ergebnis zurückgegeben wurde, wird die Methode "allesAnzeigen" ausgeführt, die das Ergbenis dann sichtbar macht
        private void btnSuchen_Click(object sender, EventArgs e)
        {
            aktiv = true;
            labelsLoeschen();
            eingabeSuche = txb_Suche.Text;
            SucheAnzeigen();
        }
        
        //Alle Key-Down Events
        //Sobald Enter betätigt wird im Feld suchen führt er die gleichen Schritte aus wie im Button Suchen
        private void txb_Suche_KeyDown(object sender, KeyEventArgs e)
        {
            aktiv = true;
            eingabeSuche = txb_Suche.Text;
            if (e.KeyCode == Keys.Enter)
            {
                SucheAnzeigen();
            }
            labelsLoeschen();
        }

        //Beim betätigen der Entertaste werden genau die gleichen Schritte getätigt wie beim klicken des Buttons Anmelden
        private void txbPasswort_KeyDown(object sender, KeyEventArgs e)
        {
            aktiv = false;
            if (e.KeyCode == Keys.Enter)
            {
                userAnmeldung();
            }
            labelsLoeschen();
        }

        //Auswahl der Listview
        //Sobald ein Item der Listview selektiert wird wird diese Methode ausgeführt und zeigt die einzelnen Daten in den dafür vorgesehenen Labels an
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
            btnReservieren.Enabled = true;
            FrmReservieren.AktuelleISBN = lblAusgabe_ISBN.Text;
            int rescheck = BuchReservieren.ReservierungChecken();
            if (rescheck != 0)
            {
                lblReserviert_Ausgabe.Text = "Ja";
                btnReservieren.Enabled = false;
            }
            else
            {
                lblReserviert_Ausgabe.Text = "Nein";
            }
        }

        //Alle restlichen Methoden
        //In dieser Methode wird überprüft ob die Anmeldedaten, die in den beiden Textfeldern stehen korrekt sind
        //Dies geschieht mithilfe einer Datenbankabfrage
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

        //Mit dieser Methode werden alle Datensätze der Datenbank angezeigt
        private void allesanzeigen()
        {
            lvErgebnis.Items.AddRange(Grunddaten.getalleDaten().ToArray());
            lvErgebnis.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvErgebnis.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        //
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

        //
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