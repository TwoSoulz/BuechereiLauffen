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
                    FrmHauptfenster_Erweitert.erw_reserviertAusgabe.Text = "Nein";
                    FrmHauptfenster.reserviertAusgabe.Text = "Nein";
                    this.Close();
                }

                if (rescheck == 0)
                {
                    manuelleid = BuchReservieren.ManuelleID();
                    BuchReservieren.ReservierungErstellen();
                    if (FrmHauptfenster.ausgabeBuch == "")
                    {
                        MessageBox.Show("Ihr Buch " + "'" + FrmHauptfenster_Erweitert.ausgabeBuch + "'" + " wurde erfolgreich auf Ihren Namen reserviert.");
                        this.Close();
                        FrmHauptfenster_Erweitert.erw_reserviertAusgabe.Text = "Ja";
                    }
                    else
                    {
                        MessageBox.Show("Ihr Buch " + "'" + FrmHauptfenster.ausgabeBuch + "'" + " wurde erfolgreich auf Ihren Namen reserviert.");
                        this.Close();
                        FrmHauptfenster.reserviertAusgabe.Text = "Ja";
                    }
                }
            }

            else
            {
                MessageBox.Show("Bitte die Postleitzahl überprüfen.");
            }

            int rescheck2 = BuchReservieren.ReservierungChecken();
            if (rescheck2 != 0)
            {
                FrmHauptfenster_Erweitert.ausgabeBuch = "Ja";
            }
            else
            {
                FrmHauptfenster_Erweitert.ausgabeBuch = "Nein";
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

        private static string aktuelle_isbn;
        public static string AktuelleISBN
        {
            get { return aktuelle_isbn; }
            set { aktuelle_isbn = value; }
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
