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
    public partial class FrmReservieren : Form
    {
        private FrmHauptfenster hauptfenster_res = null;
        public FrmReservieren(FrmHauptfenster hauptfenster_res)
        {
            InitializeComponent();
            this.hauptfenster_res = hauptfenster_res;
        }

        private void Reservieren_Load(object sender, EventArgs e)
        {
            lblBuch_Ausgabe_res.Text = aktivesBuch;
        }

        private void btnReservieren_res_Click(object sender, EventArgs e)
        {
            einlesen();
            leserid = BuchReservieren.LeserFinden();
            rescheck = BuchReservieren.ReservierungChecken();

            if (eingabePLZ.Length == 5)
            {
                if (leserid == 0)
                {
                    BuchReservieren.LeserErstellen();
                    leserid = BuchReservieren.LeserFinden();
                }

                if (rescheck != 0)
                {
                    MessageBox.Show("Dieses Buch ist bereits reserviert. Bitte wählen Sie ein anderes Buch aus.");
                    //hier muss ein totaler clear rein
                    this.Close();
                }

                if (rescheck == 0)
                {
                    manuelleid = BuchReservieren.ManuelleID();
                    BuchReservieren.ReservierungErstellen();
                    MessageBox.Show("Ihr Buch "+ "'" + FrmHauptfenster.ausgabeBuch + "'"+ " wurde erfolgreich auf Ihren Namen reserviert.");
                    this.Close();
                }
            }

            else
            {
                MessageBox.Show("Bitte die Postleitzahl überprüfen.");
            }
        }

        private void btnAbbrechen_res_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static string eingabeVorname = "";
        public static string EingabeVorname
        {
            get { return eingabeVorname; }
            set { eingabeVorname = value; }
        }

        private static string eingabeNachname = "";
        public static string EingabeNachname
        {
            get { return eingabeNachname; }
            set { eingabeNachname = value; }
        }

        private static string eingabeStrasse = "";
        public static string EingabeStrasse
        {
            get { return eingabeStrasse; }
            set { eingabeStrasse = value; }
        }

        private static string eingabeHausnummer = "";
        public static string EingabeHausnummer
        {
            get { return eingabeHausnummer; }
            set { eingabeHausnummer = value; }
        }

        private static string eingabePLZ = "";
        public static string EingabePLZ
        {
            get { return eingabePLZ; }
            set { eingabePLZ = value; }
        }

        private static string eingabeOrt = "";
        public static string EingabeOrt
        {
            get { return eingabeOrt; }
            set { eingabeOrt = value; }
        }

        private static int leserid;
        public static int LeserID
        {
            get { return leserid; }
            set { leserid = value; }
        }

        private static int rescheck;
        public static int ResCheck
        {
            get { return rescheck; }
            set { rescheck = value; }
        }

        private static int manuelleid;
        public static int ManuelleID
        {
            get { return manuelleid; }
            set { manuelleid = value; }
        }

        private static string hauptfenster_isbn;
        public static string Hauptfenster_ISBN
        {
            get { return hauptfenster_isbn; }
            set { hauptfenster_isbn = value; }
        }

        public static string aktivesBuch;
        public static string AktivesBuch
        {
            get { return aktivesBuch; }
            set { aktivesBuch = value; }
        }

        private void einlesen()
        {
            eingabeVorname = txbVorname_res.Text;
            eingabeNachname = txbNachname_res.Text;
            eingabeStrasse = txbStrasse_res.Text;
            eingabeOrt = txbOrt_res.Text;
            eingabeHausnummer = txbHausnummer_res.Text;
            eingabePLZ = txbPLZ_res.Text;
        }
    }
}
