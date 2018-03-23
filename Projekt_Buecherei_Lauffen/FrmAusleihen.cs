using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Buecherei_Lauffen
{
    public partial class FrmAusleihen : Form
    {
        private FrmHauptfenster hauptfenster_ausleihe = null;
        public FrmAusleihen(FrmHauptfenster hauptfenster_ausleihe)
        {
            InitializeComponent();
            this.hauptfenster_ausleihe = hauptfenster_ausleihe;
        }

        private void Ausleihen_Load(object sender, EventArgs e)
        {
            lblAusgabeBuch_ausleihe.Text = aktivesBuch;
        }
        private static string aktuelle_isbn_ausleihe;
        public static string AktuelleISBN_Ausleihe
        {
            get { return aktuelle_isbn_ausleihe; }
            set { aktuelle_isbn_ausleihe = value; }
        }

        private static int resID_ausleihe;
        public static int ResID_Ausleihe
        {
            get { return resID_ausleihe; }
            set { resID_ausleihe = value; }
        }
        private static int leserID_ausleihe;
        public static int LeserID_Ausleihe
        {
            get { return leserID_ausleihe; }
            set { leserID_ausleihe = value; }
        }

        private static int manuelleID_Ausleihe;
        public static int ManuelleID_Ausleihe
        {
            get { return manuelleID_Ausleihe; }
            set { manuelleID_Ausleihe = value; }
        }
        public static string aktivesBuch;
        public static string AktivesBuch
        {
            get { return aktivesBuch; }
            set { aktivesBuch = value; }
        }
        private void btnAusleihen_ausleihe_Click(object sender, EventArgs e)
        {
            //ReservierungsID, LeserID und manuelleID wird gespeichert sodass sie in der Klasse BuchAusleihen verwendet werden kann
            LeserID_Ausleihe = BuchAusleihen.LeserRausfinden_Ausleihe();
            manuelleID_Ausleihe = BuchAusleihen.Ausleihe_ManuelleID();

            BuchAusleihen.AusleiheErstellen();
            MessageBox.Show("Ihr Buch wurde erfolgreich reserviert.");
            FrmHauptfenster_Erweitert.ErwAusgeliehenAusgabe.Text = "Ja";
            FrmHauptfenster_Erweitert.BtnReservierung_Loeschen_Ausleihe.Enabled = false;
            this.Close();
        }

        private void btnAbbruch_ausleihe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
