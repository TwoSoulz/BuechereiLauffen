namespace Projekt_Buecherei_Lauffen
{
    partial class frmReservieren
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_reservieren_überschrift = new System.Windows.Forms.Label();
            this.lblReservieren_vorname = new System.Windows.Forms.Label();
            this.lblReservieren_nachname = new System.Windows.Forms.Label();
            this.lblReservieren_straße = new System.Windows.Forms.Label();
            this.lblReservieren_hausnummer = new System.Windows.Forms.Label();
            this.txbReservieren_vorname = new System.Windows.Forms.TextBox();
            this.txbReservieren_nachname = new System.Windows.Forms.TextBox();
            this.txbReservieren_straße = new System.Windows.Forms.TextBox();
            this.txbReservieren_hausnummer = new System.Windows.Forms.TextBox();
            this.btnReservieren_res = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_reservieren_überschrift
            // 
            this.lbl_reservieren_überschrift.AutoSize = true;
            this.lbl_reservieren_überschrift.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reservieren_überschrift.Location = new System.Drawing.Point(65, 29);
            this.lbl_reservieren_überschrift.Name = "lbl_reservieren_überschrift";
            this.lbl_reservieren_überschrift.Size = new System.Drawing.Size(205, 39);
            this.lbl_reservieren_überschrift.TabIndex = 0;
            this.lbl_reservieren_überschrift.Text = "Reservieren";
            // 
            // lblReservieren_vorname
            // 
            this.lblReservieren_vorname.AutoSize = true;
            this.lblReservieren_vorname.Location = new System.Drawing.Point(69, 99);
            this.lblReservieren_vorname.Name = "lblReservieren_vorname";
            this.lblReservieren_vorname.Size = new System.Drawing.Size(52, 13);
            this.lblReservieren_vorname.TabIndex = 1;
            this.lblReservieren_vorname.Text = "Vorname:";
            // 
            // lblReservieren_nachname
            // 
            this.lblReservieren_nachname.AutoSize = true;
            this.lblReservieren_nachname.Location = new System.Drawing.Point(69, 140);
            this.lblReservieren_nachname.Name = "lblReservieren_nachname";
            this.lblReservieren_nachname.Size = new System.Drawing.Size(62, 13);
            this.lblReservieren_nachname.TabIndex = 2;
            this.lblReservieren_nachname.Text = "Nachname:";
            // 
            // lblReservieren_straße
            // 
            this.lblReservieren_straße.AutoSize = true;
            this.lblReservieren_straße.Location = new System.Drawing.Point(69, 179);
            this.lblReservieren_straße.Name = "lblReservieren_straße";
            this.lblReservieren_straße.Size = new System.Drawing.Size(41, 13);
            this.lblReservieren_straße.TabIndex = 3;
            this.lblReservieren_straße.Text = "Straße:";
            // 
            // lblReservieren_hausnummer
            // 
            this.lblReservieren_hausnummer.AutoSize = true;
            this.lblReservieren_hausnummer.Location = new System.Drawing.Point(72, 215);
            this.lblReservieren_hausnummer.Name = "lblReservieren_hausnummer";
            this.lblReservieren_hausnummer.Size = new System.Drawing.Size(72, 13);
            this.lblReservieren_hausnummer.TabIndex = 4;
            this.lblReservieren_hausnummer.Text = "Hausnummer:";
            // 
            // txbReservieren_vorname
            // 
            this.txbReservieren_vorname.Location = new System.Drawing.Point(152, 96);
            this.txbReservieren_vorname.Name = "txbReservieren_vorname";
            this.txbReservieren_vorname.Size = new System.Drawing.Size(100, 20);
            this.txbReservieren_vorname.TabIndex = 5;
            // 
            // txbReservieren_nachname
            // 
            this.txbReservieren_nachname.Location = new System.Drawing.Point(152, 140);
            this.txbReservieren_nachname.Name = "txbReservieren_nachname";
            this.txbReservieren_nachname.Size = new System.Drawing.Size(100, 20);
            this.txbReservieren_nachname.TabIndex = 6;
            // 
            // txbReservieren_straße
            // 
            this.txbReservieren_straße.Location = new System.Drawing.Point(152, 171);
            this.txbReservieren_straße.Name = "txbReservieren_straße";
            this.txbReservieren_straße.Size = new System.Drawing.Size(100, 20);
            this.txbReservieren_straße.TabIndex = 7;
            // 
            // txbReservieren_hausnummer
            // 
            this.txbReservieren_hausnummer.Location = new System.Drawing.Point(151, 215);
            this.txbReservieren_hausnummer.Name = "txbReservieren_hausnummer";
            this.txbReservieren_hausnummer.Size = new System.Drawing.Size(100, 20);
            this.txbReservieren_hausnummer.TabIndex = 8;
            // 
            // btnReservieren_res
            // 
            this.btnReservieren_res.Location = new System.Drawing.Point(75, 260);
            this.btnReservieren_res.Name = "btnReservieren_res";
            this.btnReservieren_res.Size = new System.Drawing.Size(177, 54);
            this.btnReservieren_res.TabIndex = 9;
            this.btnReservieren_res.Text = "Reservieren";
            this.btnReservieren_res.UseVisualStyleBackColor = true;
            // 
            // frmReservieren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 349);
            this.Controls.Add(this.btnReservieren_res);
            this.Controls.Add(this.txbReservieren_hausnummer);
            this.Controls.Add(this.txbReservieren_straße);
            this.Controls.Add(this.txbReservieren_nachname);
            this.Controls.Add(this.txbReservieren_vorname);
            this.Controls.Add(this.lblReservieren_hausnummer);
            this.Controls.Add(this.lblReservieren_straße);
            this.Controls.Add(this.lblReservieren_nachname);
            this.Controls.Add(this.lblReservieren_vorname);
            this.Controls.Add(this.lbl_reservieren_überschrift);
            this.Name = "frmReservieren";
            this.Text = "Reservieren";
            this.Load += new System.EventHandler(this.Reservieren_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_reservieren_überschrift;
        private System.Windows.Forms.Label lblReservieren_vorname;
        private System.Windows.Forms.Label lblReservieren_nachname;
        private System.Windows.Forms.Label lblReservieren_straße;
        private System.Windows.Forms.Label lblReservieren_hausnummer;
        private System.Windows.Forms.TextBox txbReservieren_vorname;
        private System.Windows.Forms.TextBox txbReservieren_nachname;
        private System.Windows.Forms.TextBox txbReservieren_straße;
        private System.Windows.Forms.TextBox txbReservieren_hausnummer;
        private System.Windows.Forms.Button btnReservieren_res;
    }
}