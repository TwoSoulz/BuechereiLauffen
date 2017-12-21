using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelperLibrary.Database;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Projekt_Buecherei_Lauffen
{
    public partial class FrmHauptfenster : Form
    {

        private static MySQLDatabaseManager _dbManager = MySQLDatabaseManager.GetInstance();

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
            
            string cmd = "select COUNT (*) from mitarbeiter where Vorname ='" + txbBenutzer.Text + "' and Passwort ='" + txbPasswort.Text + "'";
            MySqlDataReader reader = _dbManager.Select(cmd);
            
            int count = 0;

            while (reader.Read())
            {
                count += 1;
            }

            if (count == 1)
            {
                MessageBox.Show("Anmeldung erfolgreich");
                this.Hide();
                FrmHauptfenster_Erweitert window = new FrmHauptfenster_Erweitert(this);
                window.Show();
            }

            else if (count > 0)
            {
                MessageBox.Show("Doppelter Nutzername und Passwort");
            }

            else
            {
                MessageBox.Show("Username oder Passwort falsch");
            }

            txbPasswort.Clear();
            txbBenutzer.Clear();

            //this.Hide();
            //FrmHauptfenster_Erweitert window = new FrmHauptfenster_Erweitert(this);
            //window.Show();
        }

        private void btnSuchen_Click(object sender, EventArgs e)
        {
        }

    }
}
