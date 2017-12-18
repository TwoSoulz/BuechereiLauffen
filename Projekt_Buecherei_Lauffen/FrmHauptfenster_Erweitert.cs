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
            txbJahr_erw.Enabled = b;
            txbSuche_erw.Enabled = b;
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
    }
}
