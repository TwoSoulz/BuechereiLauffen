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
            hauptfenster.Show();
        }

    }
}
