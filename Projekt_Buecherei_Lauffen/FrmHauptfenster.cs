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
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=buecherei;User Id=root;password=''");
        int i = 0;

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

            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from mitarbeiter where Vorname ='" + txbBenutzer.Text + "' and Passwort ='" + txbPasswort.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i==0)
            {
                MessageBox.Show("Wrong username or password");
                i = 0;
            }

            else
            {
                this.Hide();
                FrmHauptfenster_Erweitert window = new FrmHauptfenster_Erweitert(this);
                window.Show();
                i = 0;
            }
            txbPasswort.Clear();
            txbBenutzer.Clear();
            con.Close();
        }

        private void btnSuchen_Click(object sender, EventArgs e)
        {
        }

    }
}
