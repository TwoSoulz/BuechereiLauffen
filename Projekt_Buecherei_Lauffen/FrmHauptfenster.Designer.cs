namespace Projekt_Buecherei_Lauffen
{
    partial class FrmHauptfenster
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBenutzer = new System.Windows.Forms.Label();
            this.lblPasswort = new System.Windows.Forms.Label();
            this.lblSuche = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblAutor_Ausgabe = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblTitel_Ausgabe = new System.Windows.Forms.Label();
            this.lblVerlag = new System.Windows.Forms.Label();
            this.lblVerlag_Ausgabe = new System.Windows.Forms.Label();
            this.txbBenutzer = new System.Windows.Forms.TextBox();
            this.txbPasswort = new System.Windows.Forms.TextBox();
            this.txb_Suche = new System.Windows.Forms.TextBox();
            this.btnAnmelden = new System.Windows.Forms.Button();
            this.btnSuchen = new System.Windows.Forms.Button();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblGenre_Ausgabe = new System.Windows.Forms.Label();
            this.lblisbn = new System.Windows.Forms.Label();
            this.lblAusgabe_ISBN = new System.Windows.Forms.Label();
            this.lblAusgeliehen = new System.Windows.Forms.Label();
            this.lblAusgeliehen_Ausgabe = new System.Windows.Forms.Label();
            this.lblReserviert = new System.Windows.Forms.Label();
            this.lblReserviert_Ausgabe = new System.Windows.Forms.Label();
            this.btnReservieren = new System.Windows.Forms.Button();
            this.cbAuswahlSuchen = new System.Windows.Forms.ComboBox();
            this.lvErgebnis = new System.Windows.Forms.ListView();
            this.columnHeader_ISBN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Titel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Autor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Genre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Verlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblBenutzer
            // 
            this.lblBenutzer.AutoSize = true;
            this.lblBenutzer.Location = new System.Drawing.Point(35, 28);
            this.lblBenutzer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(104, 17);
            this.lblBenutzer.TabIndex = 0;
            this.lblBenutzer.Text = "Benutzername:";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Location = new System.Drawing.Point(341, 28);
            this.lblPasswort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(69, 17);
            this.lblPasswort.TabIndex = 1;
            this.lblPasswort.Text = "Passwort:";
            // 
            // lblSuche
            // 
            this.lblSuche.AutoSize = true;
            this.lblSuche.Location = new System.Drawing.Point(35, 65);
            this.lblSuche.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuche.Name = "lblSuche";
            this.lblSuche.Size = new System.Drawing.Size(52, 17);
            this.lblSuche.TabIndex = 2;
            this.lblSuche.Text = "Suche:";
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Location = new System.Drawing.Point(665, 572);
            this.lblAutor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(46, 17);
            this.lblAutor.TabIndex = 3;
            this.lblAutor.Text = "Autor:";
            // 
            // lblAutor_Ausgabe
            // 
            this.lblAutor_Ausgabe.AutoSize = true;
            this.lblAutor_Ausgabe.Location = new System.Drawing.Point(720, 572);
            this.lblAutor_Ausgabe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutor_Ausgabe.Name = "lblAutor_Ausgabe";
            this.lblAutor_Ausgabe.Size = new System.Drawing.Size(98, 17);
            this.lblAutor_Ausgabe.TabIndex = 4;
            this.lblAutor_Ausgabe.Text = "AutorAusgabe";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Location = new System.Drawing.Point(292, 572);
            this.lblTitel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(39, 17);
            this.lblTitel.TabIndex = 5;
            this.lblTitel.Text = "Titel:";
            // 
            // lblTitel_Ausgabe
            // 
            this.lblTitel_Ausgabe.AutoSize = true;
            this.lblTitel_Ausgabe.Location = new System.Drawing.Point(353, 572);
            this.lblTitel_Ausgabe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitel_Ausgabe.Name = "lblTitel_Ausgabe";
            this.lblTitel_Ausgabe.Size = new System.Drawing.Size(91, 17);
            this.lblTitel_Ausgabe.TabIndex = 6;
            this.lblTitel_Ausgabe.Text = "TitelAusgabe";
            // 
            // lblVerlag
            // 
            this.lblVerlag.AutoSize = true;
            this.lblVerlag.Location = new System.Drawing.Point(292, 625);
            this.lblVerlag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerlag.Name = "lblVerlag";
            this.lblVerlag.Size = new System.Drawing.Size(53, 17);
            this.lblVerlag.TabIndex = 7;
            this.lblVerlag.Text = "Verlag:";
            // 
            // lblVerlag_Ausgabe
            // 
            this.lblVerlag_Ausgabe.AutoSize = true;
            this.lblVerlag_Ausgabe.Location = new System.Drawing.Point(353, 625);
            this.lblVerlag_Ausgabe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerlag_Ausgabe.Name = "lblVerlag_Ausgabe";
            this.lblVerlag_Ausgabe.Size = new System.Drawing.Size(105, 17);
            this.lblVerlag_Ausgabe.TabIndex = 8;
            this.lblVerlag_Ausgabe.Text = "VerlagAusgabe";
            // 
            // txbBenutzer
            // 
            this.txbBenutzer.Location = new System.Drawing.Point(143, 25);
            this.txbBenutzer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbBenutzer.Name = "txbBenutzer";
            this.txbBenutzer.Size = new System.Drawing.Size(159, 22);
            this.txbBenutzer.TabIndex = 10;
            // 
            // txbPasswort
            // 
            this.txbPasswort.Location = new System.Drawing.Point(416, 25);
            this.txbPasswort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbPasswort.Name = "txbPasswort";
            this.txbPasswort.Size = new System.Drawing.Size(169, 22);
            this.txbPasswort.TabIndex = 11;
            this.txbPasswort.UseSystemPasswordChar = true;
            this.txbPasswort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbPasswort_KeyDown);
            // 
            // txb_Suche
            // 
            this.txb_Suche.Location = new System.Drawing.Point(143, 62);
            this.txb_Suche.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txb_Suche.Name = "txb_Suche";
            this.txb_Suche.Size = new System.Drawing.Size(443, 22);
            this.txb_Suche.TabIndex = 12;
            this.txb_Suche.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_Suche_KeyDown);
            // 
            // btnAnmelden
            // 
            this.btnAnmelden.Location = new System.Drawing.Point(636, 22);
            this.btnAnmelden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnmelden.Name = "btnAnmelden";
            this.btnAnmelden.Size = new System.Drawing.Size(100, 28);
            this.btnAnmelden.TabIndex = 13;
            this.btnAnmelden.Text = "Anmelden";
            this.btnAnmelden.UseVisualStyleBackColor = true;
            this.btnAnmelden.Click += new System.EventHandler(this.btnAnmelden_Click);
            // 
            // btnSuchen
            // 
            this.btnSuchen.Location = new System.Drawing.Point(760, 62);
            this.btnSuchen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSuchen.Name = "btnSuchen";
            this.btnSuchen.Size = new System.Drawing.Size(100, 26);
            this.btnSuchen.TabIndex = 14;
            this.btnSuchen.Text = "Suchen";
            this.btnSuchen.UseVisualStyleBackColor = true;
            this.btnSuchen.Click += new System.EventHandler(this.btnSuchen_Click);
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(35, 625);
            this.lblGenre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(52, 17);
            this.lblGenre.TabIndex = 17;
            this.lblGenre.Text = "Genre:";
            // 
            // lblGenre_Ausgabe
            // 
            this.lblGenre_Ausgabe.AutoSize = true;
            this.lblGenre_Ausgabe.Location = new System.Drawing.Point(95, 625);
            this.lblGenre_Ausgabe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenre_Ausgabe.Name = "lblGenre_Ausgabe";
            this.lblGenre_Ausgabe.Size = new System.Drawing.Size(104, 17);
            this.lblGenre_Ausgabe.TabIndex = 18;
            this.lblGenre_Ausgabe.Text = "GenreAusgabe";
            // 
            // lblisbn
            // 
            this.lblisbn.AutoSize = true;
            this.lblisbn.Location = new System.Drawing.Point(35, 572);
            this.lblisbn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblisbn.Name = "lblisbn";
            this.lblisbn.Size = new System.Drawing.Size(43, 17);
            this.lblisbn.TabIndex = 19;
            this.lblisbn.Text = "ISBN:";
            // 
            // lblAusgabe_ISBN
            // 
            this.lblAusgabe_ISBN.AutoSize = true;
            this.lblAusgabe_ISBN.Location = new System.Drawing.Point(95, 572);
            this.lblAusgabe_ISBN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAusgabe_ISBN.Name = "lblAusgabe_ISBN";
            this.lblAusgabe_ISBN.Size = new System.Drawing.Size(95, 17);
            this.lblAusgabe_ISBN.TabIndex = 20;
            this.lblAusgabe_ISBN.Text = "AusgabeISBN";
            // 
            // lblAusgeliehen
            // 
            this.lblAusgeliehen.AutoSize = true;
            this.lblAusgeliehen.Location = new System.Drawing.Point(941, 625);
            this.lblAusgeliehen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAusgeliehen.Name = "lblAusgeliehen";
            this.lblAusgeliehen.Size = new System.Drawing.Size(90, 17);
            this.lblAusgeliehen.TabIndex = 21;
            this.lblAusgeliehen.Text = "Ausgeliehen:";
            // 
            // lblAusgeliehen_Ausgabe
            // 
            this.lblAusgeliehen_Ausgabe.AutoSize = true;
            this.lblAusgeliehen_Ausgabe.Location = new System.Drawing.Point(1043, 625);
            this.lblAusgeliehen_Ausgabe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAusgeliehen_Ausgabe.Name = "lblAusgeliehen_Ausgabe";
            this.lblAusgeliehen_Ausgabe.Size = new System.Drawing.Size(142, 17);
            this.lblAusgeliehen_Ausgabe.TabIndex = 22;
            this.lblAusgeliehen_Ausgabe.Text = "AusgeliehenAusgabe";
            // 
            // lblReserviert
            // 
            this.lblReserviert.AutoSize = true;
            this.lblReserviert.Location = new System.Drawing.Point(941, 572);
            this.lblReserviert.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReserviert.Name = "lblReserviert";
            this.lblReserviert.Size = new System.Drawing.Size(77, 17);
            this.lblReserviert.TabIndex = 23;
            this.lblReserviert.Text = "Reserviert:";
            // 
            // lblReserviert_Ausgabe
            // 
            this.lblReserviert_Ausgabe.AutoSize = true;
            this.lblReserviert_Ausgabe.Location = new System.Drawing.Point(1043, 572);
            this.lblReserviert_Ausgabe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReserviert_Ausgabe.Name = "lblReserviert_Ausgabe";
            this.lblReserviert_Ausgabe.Size = new System.Drawing.Size(129, 17);
            this.lblReserviert_Ausgabe.TabIndex = 24;
            this.lblReserviert_Ausgabe.Text = "ReserviertAusgabe";
            // 
            // btnReservieren
            // 
            this.btnReservieren.Location = new System.Drawing.Point(1223, 566);
            this.btnReservieren.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReservieren.Name = "btnReservieren";
            this.btnReservieren.Size = new System.Drawing.Size(100, 28);
            this.btnReservieren.TabIndex = 25;
            this.btnReservieren.Text = "Reservieren";
            this.btnReservieren.UseVisualStyleBackColor = true;
            this.btnReservieren.Click += new System.EventHandler(this.btnReservieren_Click);
            // 
            // cbAuswahlSuchen
            // 
            this.cbAuswahlSuchen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuswahlSuchen.FormattingEnabled = true;
            this.cbAuswahlSuchen.Location = new System.Drawing.Point(636, 62);
            this.cbAuswahlSuchen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbAuswahlSuchen.Name = "cbAuswahlSuchen";
            this.cbAuswahlSuchen.Size = new System.Drawing.Size(99, 24);
            this.cbAuswahlSuchen.TabIndex = 26;
            // 
            // lvErgebnis
            // 
            this.lvErgebnis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ISBN,
            this.columnHeader_Titel,
            this.columnHeader_Autor,
            this.columnHeader_Genre,
            this.columnHeader_Verlag});
            this.lvErgebnis.Location = new System.Drawing.Point(38, 118);
            this.lvErgebnis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvErgebnis.Name = "lvErgebnis";
            this.lvErgebnis.Size = new System.Drawing.Size(1267, 440);
            this.lvErgebnis.TabIndex = 70;
            this.lvErgebnis.UseCompatibleStateImageBehavior = false;
            this.lvErgebnis.View = System.Windows.Forms.View.Details;
            this.lvErgebnis.SelectedIndexChanged += new System.EventHandler(this.lvErgebnis_SelectedIndexChanged);
            // 
            // columnHeader_ISBN
            // 
            this.columnHeader_ISBN.Text = "ISBN";
            this.columnHeader_ISBN.Width = 70;
            // 
            // columnHeader_Titel
            // 
            this.columnHeader_Titel.Text = "Titel";
            this.columnHeader_Titel.Width = 70;
            // 
            // columnHeader_Autor
            // 
            this.columnHeader_Autor.Text = "Autor";
            this.columnHeader_Autor.Width = 70;
            // 
            // columnHeader_Genre
            // 
            this.columnHeader_Genre.Text = "Genre";
            this.columnHeader_Genre.Width = 70;
            // 
            // columnHeader_Verlag
            // 
            this.columnHeader_Verlag.Text = "Verlag";
            this.columnHeader_Verlag.Width = 70;
            // 
            // FrmHauptfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 709);
            this.Controls.Add(this.lvErgebnis);
            this.Controls.Add(this.cbAuswahlSuchen);
            this.Controls.Add(this.btnReservieren);
            this.Controls.Add(this.lblReserviert_Ausgabe);
            this.Controls.Add(this.lblReserviert);
            this.Controls.Add(this.lblAusgeliehen_Ausgabe);
            this.Controls.Add(this.lblAusgeliehen);
            this.Controls.Add(this.lblAusgabe_ISBN);
            this.Controls.Add(this.lblisbn);
            this.Controls.Add(this.lblGenre_Ausgabe);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.btnSuchen);
            this.Controls.Add(this.btnAnmelden);
            this.Controls.Add(this.txb_Suche);
            this.Controls.Add(this.txbPasswort);
            this.Controls.Add(this.txbBenutzer);
            this.Controls.Add(this.lblVerlag_Ausgabe);
            this.Controls.Add(this.lblVerlag);
            this.Controls.Add(this.lblTitel_Ausgabe);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lblAutor_Ausgabe);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.lblSuche);
            this.Controls.Add(this.lblPasswort);
            this.Controls.Add(this.lblBenutzer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmHauptfenster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bücherei Lauffen Inventarsuche";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBenutzer;
        private System.Windows.Forms.Label lblPasswort;
        private System.Windows.Forms.Label lblSuche;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblAutor_Ausgabe;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label lblTitel_Ausgabe;
        private System.Windows.Forms.Label lblVerlag;
        private System.Windows.Forms.Label lblVerlag_Ausgabe;
        private System.Windows.Forms.TextBox txbBenutzer;
        private System.Windows.Forms.TextBox txbPasswort;
        private System.Windows.Forms.TextBox txb_Suche;
        private System.Windows.Forms.Button btnAnmelden;
        private System.Windows.Forms.Button btnSuchen;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblGenre_Ausgabe;
        private System.Windows.Forms.Label lblisbn;
        private System.Windows.Forms.Label lblAusgabe_ISBN;
        private System.Windows.Forms.Label lblAusgeliehen;
        private System.Windows.Forms.Label lblAusgeliehen_Ausgabe;
        private System.Windows.Forms.Label lblReserviert;
        private System.Windows.Forms.Label lblReserviert_Ausgabe;
        private System.Windows.Forms.Button btnReservieren;
        private System.Windows.Forms.ComboBox cbAuswahlSuchen;
        private System.Windows.Forms.ListView lvErgebnis;
        private System.Windows.Forms.ColumnHeader columnHeader_ISBN;
        private System.Windows.Forms.ColumnHeader columnHeader_Titel;
        private System.Windows.Forms.ColumnHeader columnHeader_Autor;
        private System.Windows.Forms.ColumnHeader columnHeader_Genre;
        private System.Windows.Forms.ColumnHeader columnHeader_Verlag;
    }
}

