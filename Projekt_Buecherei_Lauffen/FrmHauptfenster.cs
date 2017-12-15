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
    public partial class FrmHauptfenster : Form
    {
        public FrmHauptfenster()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnReservieren_Click(object sender, EventArgs e)
        {
            FrmReservieren window = new FrmReservieren(this);
            window.ShowDialog();
        }

        private void btnAnmelden_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmHauptfenster_Erweitert window = new FrmHauptfenster_Erweitert(this);
            window.Show();
        }

        private void btnSuchen_Click(object sender, EventArgs e)
        {
            
        }
    }
}
