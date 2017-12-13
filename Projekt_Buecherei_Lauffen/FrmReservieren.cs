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
           
        }

        private void btnAbbrechen_res_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
