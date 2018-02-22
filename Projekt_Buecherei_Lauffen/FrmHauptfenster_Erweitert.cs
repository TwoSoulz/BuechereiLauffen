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
    public partial class FrmHauptfenster_Erweitert : Form
    {
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
            allesanzeigen();

            Textbox_toggle(false);
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
            txbJahr_erw.Enabled = b;     txbTitel_erw.Enabled = b;
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

        private void FrmHauptfenster_Erweitert_Load(object sender, EventArgs e)
        {

        }

        private void allesanzeigen()
        {
            lvErgebnis_erw.Items.AddRange(Grunddaten.getalleDaten().ToArray());
            lvErgebnis_erw.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvErgebnis_erw.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
