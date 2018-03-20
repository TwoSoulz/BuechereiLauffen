namespace Projekt_Buecherei_Lauffen
{
    partial class FrmHauptfenster_Erweitert
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
            this.btnReservieren_erw = new System.Windows.Forms.Button();
            this.lblReserviert_erw = new System.Windows.Forms.Label();
            this.lblAusgeliehen_erw = new System.Windows.Forms.Label();
            this.lblisbn_erw = new System.Windows.Forms.Label();
            this.lblGenre_erw = new System.Windows.Forms.Label();
            this.btnSuchen_erw = new System.Windows.Forms.Button();
            this.btnAusloggen_erw = new System.Windows.Forms.Button();
            this.txbSuche_erw = new System.Windows.Forms.TextBox();
            this.lblJahr_erw = new System.Windows.Forms.Label();
            this.lblVerlag_erw = new System.Windows.Forms.Label();
            this.lblTitel_erw = new System.Windows.Forms.Label();
            this.lblAutor_erw = new System.Windows.Forms.Label();
            this.lblSuche = new System.Windows.Forms.Label();
            this.lblBenutzer_erw = new System.Windows.Forms.Label();
            this.txbAutor_erw = new System.Windows.Forms.TextBox();
            this.txbTitel_erw = new System.Windows.Forms.TextBox();
            this.txbVerlag_erw = new System.Windows.Forms.TextBox();
            this.txbJahr_erw = new System.Windows.Forms.TextBox();
            this.txbGenre_erw = new System.Windows.Forms.TextBox();
            this.txbISBN_erw = new System.Windows.Forms.TextBox();
            this.btnReservierung_loeschen_erw = new System.Windows.Forms.Button();
            this.lblBenutzer_eingeloggt_erw = new System.Windows.Forms.Label();
            this.lblAusgeliehen_Ausgabe_erw = new System.Windows.Forms.Label();
            this.lblReserviert_Ausgabe_erw = new System.Windows.Forms.Label();
            this.btnAendern_erw = new System.Windows.Forms.Button();
            this.btnLoeschen_erw = new System.Windows.Forms.Button();
            this.btnNeu_erw = new System.Windows.Forms.Button();
            this.btnAusleihen_erw = new System.Windows.Forms.Button();
            this.btnZurueck_erw = new System.Windows.Forms.Button();
            this.btnSpeichern_erw = new System.Windows.Forms.Button();
            this.cbAuswahlSuchen_erw = new System.Windows.Forms.ComboBox();
            this.lvErgebnis_erw = new System.Windows.Forms.ListView();
            this.columnHeader_ISBN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Titel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Autor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Genre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Verlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnReservieren_erw
            // 
            this.btnReservieren_erw.Location = new System.Drawing.Point(633, 569);
            this.btnReservieren_erw.Name = "btnReservieren_erw";
            this.btnReservieren_erw.Size = new System.Drawing.Size(75, 23);
            this.btnReservieren_erw.TabIndex = 51;
            this.btnReservieren_erw.Text = "Reservieren";
            this.btnReservieren_erw.UseVisualStyleBackColor = true;
            this.btnReservieren_erw.Click += new System.EventHandler(this.btnReservieren_erw_Click);
            // 
            // lblReserviert_erw
            // 
            this.lblReserviert_erw.AutoSize = true;
            this.lblReserviert_erw.Location = new System.Drawing.Point(640, 522);
            this.lblReserviert_erw.Name = "lblReserviert_erw";
            this.lblReserviert_erw.Size = new System.Drawing.Size(58, 13);
            this.lblReserviert_erw.TabIndex = 49;
            this.lblReserviert_erw.Text = "Reserviert:";
            // 
            // lblAusgeliehen_erw
            // 
            this.lblAusgeliehen_erw.AutoSize = true;
            this.lblAusgeliehen_erw.Location = new System.Drawing.Point(640, 472);
            this.lblAusgeliehen_erw.Name = "lblAusgeliehen_erw";
            this.lblAusgeliehen_erw.Size = new System.Drawing.Size(68, 13);
            this.lblAusgeliehen_erw.TabIndex = 47;
            this.lblAusgeliehen_erw.Text = "Ausgeliehen:";
            // 
            // lblisbn_erw
            // 
            this.lblisbn_erw.AutoSize = true;
            this.lblisbn_erw.Location = new System.Drawing.Point(434, 522);
            this.lblisbn_erw.Name = "lblisbn_erw";
            this.lblisbn_erw.Size = new System.Drawing.Size(35, 13);
            this.lblisbn_erw.TabIndex = 45;
            this.lblisbn_erw.Text = "ISBN:";
            // 
            // lblGenre_erw
            // 
            this.lblGenre_erw.AutoSize = true;
            this.lblGenre_erw.Location = new System.Drawing.Point(229, 522);
            this.lblGenre_erw.Name = "lblGenre_erw";
            this.lblGenre_erw.Size = new System.Drawing.Size(39, 13);
            this.lblGenre_erw.TabIndex = 43;
            this.lblGenre_erw.Text = "Genre:";
            // 
            // btnSuchen_erw
            // 
            this.btnSuchen_erw.Location = new System.Drawing.Point(513, 57);
            this.btnSuchen_erw.Name = "btnSuchen_erw";
            this.btnSuchen_erw.Size = new System.Drawing.Size(83, 23);
            this.btnSuchen_erw.TabIndex = 40;
            this.btnSuchen_erw.Text = "Suchen";
            this.btnSuchen_erw.UseVisualStyleBackColor = true;
            this.btnSuchen_erw.Click += new System.EventHandler(this.btnSuchen_erw_Click);
            // 
            // btnAusloggen_erw
            // 
            this.btnAusloggen_erw.Location = new System.Drawing.Point(241, 20);
            this.btnAusloggen_erw.Name = "btnAusloggen_erw";
            this.btnAusloggen_erw.Size = new System.Drawing.Size(75, 23);
            this.btnAusloggen_erw.TabIndex = 39;
            this.btnAusloggen_erw.Text = "Ausloggen";
            this.btnAusloggen_erw.UseVisualStyleBackColor = true;
            this.btnAusloggen_erw.Click += new System.EventHandler(this.btnAusloggen_erw_Click);
            // 
            // txbSuche_erw
            // 
            this.txbSuche_erw.Location = new System.Drawing.Point(70, 58);
            this.txbSuche_erw.Name = "txbSuche_erw";
            this.txbSuche_erw.Size = new System.Drawing.Size(333, 20);
            this.txbSuche_erw.TabIndex = 38;
            // 
            // lblJahr_erw
            // 
            this.lblJahr_erw.AutoSize = true;
            this.lblJahr_erw.Location = new System.Drawing.Point(29, 522);
            this.lblJahr_erw.Name = "lblJahr_erw";
            this.lblJahr_erw.Size = new System.Drawing.Size(30, 13);
            this.lblJahr_erw.TabIndex = 35;
            this.lblJahr_erw.Text = "Jahr:";
            // 
            // lblVerlag_erw
            // 
            this.lblVerlag_erw.AutoSize = true;
            this.lblVerlag_erw.Location = new System.Drawing.Point(429, 472);
            this.lblVerlag_erw.Name = "lblVerlag_erw";
            this.lblVerlag_erw.Size = new System.Drawing.Size(40, 13);
            this.lblVerlag_erw.TabIndex = 33;
            this.lblVerlag_erw.Text = "Verlag:";
            // 
            // lblTitel_erw
            // 
            this.lblTitel_erw.AutoSize = true;
            this.lblTitel_erw.Location = new System.Drawing.Point(238, 472);
            this.lblTitel_erw.Name = "lblTitel_erw";
            this.lblTitel_erw.Size = new System.Drawing.Size(30, 13);
            this.lblTitel_erw.TabIndex = 31;
            this.lblTitel_erw.Text = "Titel:";
            // 
            // lblAutor_erw
            // 
            this.lblAutor_erw.AutoSize = true;
            this.lblAutor_erw.Location = new System.Drawing.Point(29, 472);
            this.lblAutor_erw.Name = "lblAutor_erw";
            this.lblAutor_erw.Size = new System.Drawing.Size(35, 13);
            this.lblAutor_erw.TabIndex = 29;
            this.lblAutor_erw.Text = "Autor:";
            // 
            // lblSuche
            // 
            this.lblSuche.AutoSize = true;
            this.lblSuche.Location = new System.Drawing.Point(23, 61);
            this.lblSuche.Name = "lblSuche";
            this.lblSuche.Size = new System.Drawing.Size(41, 13);
            this.lblSuche.TabIndex = 28;
            this.lblSuche.Text = "Suche:";
            // 
            // lblBenutzer_erw
            // 
            this.lblBenutzer_erw.AutoSize = true;
            this.lblBenutzer_erw.Location = new System.Drawing.Point(23, 25);
            this.lblBenutzer_erw.Name = "lblBenutzer_erw";
            this.lblBenutzer_erw.Size = new System.Drawing.Size(78, 13);
            this.lblBenutzer_erw.TabIndex = 26;
            this.lblBenutzer_erw.Text = "Benutzername:";
            // 
            // txbAutor_erw
            // 
            this.txbAutor_erw.Location = new System.Drawing.Point(70, 469);
            this.txbAutor_erw.Name = "txbAutor_erw";
            this.txbAutor_erw.Size = new System.Drawing.Size(139, 20);
            this.txbAutor_erw.TabIndex = 52;
            // 
            // txbTitel_erw
            // 
            this.txbTitel_erw.Location = new System.Drawing.Point(274, 469);
            this.txbTitel_erw.Name = "txbTitel_erw";
            this.txbTitel_erw.Size = new System.Drawing.Size(139, 20);
            this.txbTitel_erw.TabIndex = 53;
            // 
            // txbVerlag_erw
            // 
            this.txbVerlag_erw.Location = new System.Drawing.Point(475, 469);
            this.txbVerlag_erw.Name = "txbVerlag_erw";
            this.txbVerlag_erw.Size = new System.Drawing.Size(139, 20);
            this.txbVerlag_erw.TabIndex = 54;
            // 
            // txbJahr_erw
            // 
            this.txbJahr_erw.Location = new System.Drawing.Point(70, 519);
            this.txbJahr_erw.Name = "txbJahr_erw";
            this.txbJahr_erw.Size = new System.Drawing.Size(139, 20);
            this.txbJahr_erw.TabIndex = 55;
            // 
            // txbGenre_erw
            // 
            this.txbGenre_erw.Location = new System.Drawing.Point(274, 519);
            this.txbGenre_erw.Name = "txbGenre_erw";
            this.txbGenre_erw.Size = new System.Drawing.Size(139, 20);
            this.txbGenre_erw.TabIndex = 56;
            // 
            // txbISBN_erw
            // 
            this.txbISBN_erw.Location = new System.Drawing.Point(475, 519);
            this.txbISBN_erw.Name = "txbISBN_erw";
            this.txbISBN_erw.Size = new System.Drawing.Size(139, 20);
            this.txbISBN_erw.TabIndex = 57;
            // 
            // btnReservierung_loeschen_erw
            // 
            this.btnReservierung_loeschen_erw.Location = new System.Drawing.Point(714, 569);
            this.btnReservierung_loeschen_erw.Name = "btnReservierung_loeschen_erw";
            this.btnReservierung_loeschen_erw.Size = new System.Drawing.Size(134, 23);
            this.btnReservierung_loeschen_erw.TabIndex = 58;
            this.btnReservierung_loeschen_erw.Text = "Reservierung löschen";
            this.btnReservierung_loeschen_erw.UseVisualStyleBackColor = true;
            // 
            // lblBenutzer_eingeloggt_erw
            // 
            this.lblBenutzer_eingeloggt_erw.AutoSize = true;
            this.lblBenutzer_eingeloggt_erw.Location = new System.Drawing.Point(107, 25);
            this.lblBenutzer_eingeloggt_erw.Name = "lblBenutzer_eingeloggt_erw";
            this.lblBenutzer_eingeloggt_erw.Size = new System.Drawing.Size(123, 13);
            this.lblBenutzer_eingeloggt_erw.TabIndex = 59;
            this.lblBenutzer_eingeloggt_erw.Text = "Benutzername_Ausgabe";
            // 
            // lblAusgeliehen_Ausgabe_erw
            // 
            this.lblAusgeliehen_Ausgabe_erw.AutoSize = true;
            this.lblAusgeliehen_Ausgabe_erw.Location = new System.Drawing.Point(717, 472);
            this.lblAusgeliehen_Ausgabe_erw.Name = "lblAusgeliehen_Ausgabe_erw";
            this.lblAusgeliehen_Ausgabe_erw.Size = new System.Drawing.Size(98, 13);
            this.lblAusgeliehen_Ausgabe_erw.TabIndex = 60;
            this.lblAusgeliehen_Ausgabe_erw.Text = "lblAusgeliehen_erw";
            // 
            // lblReserviert_Ausgabe_erw
            // 
            this.lblReserviert_Ausgabe_erw.AutoSize = true;
            this.lblReserviert_Ausgabe_erw.Location = new System.Drawing.Point(717, 522);
            this.lblReserviert_Ausgabe_erw.Name = "lblReserviert_Ausgabe_erw";
            this.lblReserviert_Ausgabe_erw.Size = new System.Drawing.Size(126, 13);
            this.lblReserviert_Ausgabe_erw.TabIndex = 61;
            this.lblReserviert_Ausgabe_erw.Text = "Reserviert_Ausgabe_erw";
            // 
            // btnAendern_erw
            // 
            this.btnAendern_erw.Location = new System.Drawing.Point(26, 569);
            this.btnAendern_erw.Name = "btnAendern_erw";
            this.btnAendern_erw.Size = new System.Drawing.Size(75, 23);
            this.btnAendern_erw.TabIndex = 62;
            this.btnAendern_erw.Text = "Ändern";
            this.btnAendern_erw.UseVisualStyleBackColor = true;
            this.btnAendern_erw.Click += new System.EventHandler(this.btnAendern_erw_Click);
            // 
            // btnLoeschen_erw
            // 
            this.btnLoeschen_erw.Location = new System.Drawing.Point(188, 569);
            this.btnLoeschen_erw.Name = "btnLoeschen_erw";
            this.btnLoeschen_erw.Size = new System.Drawing.Size(75, 23);
            this.btnLoeschen_erw.TabIndex = 63;
            this.btnLoeschen_erw.Text = "Löschen";
            this.btnLoeschen_erw.UseVisualStyleBackColor = true;
            // 
            // btnNeu_erw
            // 
            this.btnNeu_erw.Location = new System.Drawing.Point(269, 569);
            this.btnNeu_erw.Name = "btnNeu_erw";
            this.btnNeu_erw.Size = new System.Drawing.Size(75, 23);
            this.btnNeu_erw.TabIndex = 64;
            this.btnNeu_erw.Text = "Neu";
            this.btnNeu_erw.UseVisualStyleBackColor = true;
            // 
            // btnAusleihen_erw
            // 
            this.btnAusleihen_erw.Location = new System.Drawing.Point(403, 569);
            this.btnAusleihen_erw.Name = "btnAusleihen_erw";
            this.btnAusleihen_erw.Size = new System.Drawing.Size(75, 23);
            this.btnAusleihen_erw.TabIndex = 65;
            this.btnAusleihen_erw.Text = "Ausleihen";
            this.btnAusleihen_erw.UseVisualStyleBackColor = true;
            // 
            // btnZurueck_erw
            // 
            this.btnZurueck_erw.Location = new System.Drawing.Point(484, 569);
            this.btnZurueck_erw.Name = "btnZurueck_erw";
            this.btnZurueck_erw.Size = new System.Drawing.Size(85, 23);
            this.btnZurueck_erw.TabIndex = 66;
            this.btnZurueck_erw.Text = "Zurückgeben";
            this.btnZurueck_erw.UseVisualStyleBackColor = true;
            // 
            // btnSpeichern_erw
            // 
            this.btnSpeichern_erw.Location = new System.Drawing.Point(107, 569);
            this.btnSpeichern_erw.Name = "btnSpeichern_erw";
            this.btnSpeichern_erw.Size = new System.Drawing.Size(75, 23);
            this.btnSpeichern_erw.TabIndex = 67;
            this.btnSpeichern_erw.Text = "Speichern";
            this.btnSpeichern_erw.UseVisualStyleBackColor = true;
            this.btnSpeichern_erw.Click += new System.EventHandler(this.btnSpeichern_erw_Click);
            // 
            // cbAuswahlSuchen_erw
            // 
            this.cbAuswahlSuchen_erw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuswahlSuchen_erw.FormattingEnabled = true;
            this.cbAuswahlSuchen_erw.Location = new System.Drawing.Point(422, 58);
            this.cbAuswahlSuchen_erw.Name = "cbAuswahlSuchen_erw";
            this.cbAuswahlSuchen_erw.Size = new System.Drawing.Size(75, 21);
            this.cbAuswahlSuchen_erw.TabIndex = 69;
            // 
            // lvErgebnis_erw
            // 
            this.lvErgebnis_erw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ISBN,
            this.columnHeader_Titel,
            this.columnHeader_Autor,
            this.columnHeader_Genre,
            this.columnHeader_Verlag});
            this.lvErgebnis_erw.Location = new System.Drawing.Point(11, 86);
            this.lvErgebnis_erw.Name = "lvErgebnis_erw";
            this.lvErgebnis_erw.Size = new System.Drawing.Size(861, 358);
            this.lvErgebnis_erw.TabIndex = 70;
            this.lvErgebnis_erw.UseCompatibleStateImageBehavior = false;
            this.lvErgebnis_erw.View = System.Windows.Forms.View.Details;
            this.lvErgebnis_erw.SelectedIndexChanged += new System.EventHandler(this.lvErgebnis_erw_SelectedIndexChanged);
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
            // FrmHauptfenster_Erweitert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 620);
            this.Controls.Add(this.lvErgebnis_erw);
            this.Controls.Add(this.cbAuswahlSuchen_erw);
            this.Controls.Add(this.btnSpeichern_erw);
            this.Controls.Add(this.btnZurueck_erw);
            this.Controls.Add(this.btnAusleihen_erw);
            this.Controls.Add(this.btnNeu_erw);
            this.Controls.Add(this.btnLoeschen_erw);
            this.Controls.Add(this.btnAendern_erw);
            this.Controls.Add(this.lblReserviert_Ausgabe_erw);
            this.Controls.Add(this.lblAusgeliehen_Ausgabe_erw);
            this.Controls.Add(this.lblBenutzer_eingeloggt_erw);
            this.Controls.Add(this.btnReservierung_loeschen_erw);
            this.Controls.Add(this.txbISBN_erw);
            this.Controls.Add(this.txbGenre_erw);
            this.Controls.Add(this.txbJahr_erw);
            this.Controls.Add(this.txbVerlag_erw);
            this.Controls.Add(this.txbTitel_erw);
            this.Controls.Add(this.txbAutor_erw);
            this.Controls.Add(this.btnReservieren_erw);
            this.Controls.Add(this.lblReserviert_erw);
            this.Controls.Add(this.lblAusgeliehen_erw);
            this.Controls.Add(this.lblisbn_erw);
            this.Controls.Add(this.lblGenre_erw);
            this.Controls.Add(this.btnSuchen_erw);
            this.Controls.Add(this.btnAusloggen_erw);
            this.Controls.Add(this.txbSuche_erw);
            this.Controls.Add(this.lblJahr_erw);
            this.Controls.Add(this.lblVerlag_erw);
            this.Controls.Add(this.lblTitel_erw);
            this.Controls.Add(this.lblAutor_erw);
            this.Controls.Add(this.lblSuche);
            this.Controls.Add(this.lblBenutzer_erw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmHauptfenster_Erweitert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buecherei Laufen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHauptfenster_Erweitert_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReservieren_erw;
        private System.Windows.Forms.Label lblReserviert_erw;
        private System.Windows.Forms.Label lblAusgeliehen_erw;
        private System.Windows.Forms.Label lblisbn_erw;
        private System.Windows.Forms.Label lblGenre_erw;
        private System.Windows.Forms.Button btnSuchen_erw;
        private System.Windows.Forms.Button btnAusloggen_erw;
        private System.Windows.Forms.TextBox txbSuche_erw;
        private System.Windows.Forms.Label lblJahr_erw;
        private System.Windows.Forms.Label lblVerlag_erw;
        private System.Windows.Forms.Label lblTitel_erw;
        private System.Windows.Forms.Label lblAutor_erw;
        private System.Windows.Forms.Label lblSuche;
        private System.Windows.Forms.Label lblBenutzer_erw;
        private System.Windows.Forms.TextBox txbAutor_erw;
        private System.Windows.Forms.TextBox txbTitel_erw;
        private System.Windows.Forms.TextBox txbVerlag_erw;
        private System.Windows.Forms.TextBox txbJahr_erw;
        private System.Windows.Forms.TextBox txbGenre_erw;
        private System.Windows.Forms.TextBox txbISBN_erw;
        private System.Windows.Forms.Button btnReservierung_loeschen_erw;
        private System.Windows.Forms.Label lblBenutzer_eingeloggt_erw;
        private System.Windows.Forms.Label lblAusgeliehen_Ausgabe_erw;
        private System.Windows.Forms.Label lblReserviert_Ausgabe_erw;
        private System.Windows.Forms.Button btnAendern_erw;
        private System.Windows.Forms.Button btnLoeschen_erw;
        private System.Windows.Forms.Button btnNeu_erw;
        private System.Windows.Forms.Button btnAusleihen_erw;
        private System.Windows.Forms.Button btnZurueck_erw;
        private System.Windows.Forms.Button btnSpeichern_erw;
        private System.Windows.Forms.ComboBox cbAuswahlSuchen_erw;
        private System.Windows.Forms.ListView lvErgebnis_erw;
        private System.Windows.Forms.ColumnHeader columnHeader_ISBN;
        private System.Windows.Forms.ColumnHeader columnHeader_Titel;
        private System.Windows.Forms.ColumnHeader columnHeader_Autor;
        private System.Windows.Forms.ColumnHeader columnHeader_Genre;
        private System.Windows.Forms.ColumnHeader columnHeader_Verlag;
    }
}