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

        }

        private void btnReservieren_res_Click(object sender, EventArgs e)
        {
            einlesen();
            
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
