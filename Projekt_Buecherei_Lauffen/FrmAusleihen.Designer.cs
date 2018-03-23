namespace Projekt_Buecherei_Lauffen
{
    partial class FrmAusleihen
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
            this.lblBuch_ausleihe = new System.Windows.Forms.Label();
            this.lblAusgabeBuch_ausleihe = new System.Windows.Forms.Label();
            this.btnAusleihen_ausleihe = new System.Windows.Forms.Button();
            this.btnAbbruch_ausleihe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBuch_ausleihe
            // 
            this.lblBuch_ausleihe.AutoSize = true;
            this.lblBuch_ausleihe.Location = new System.Drawing.Point(13, 33);
            this.lblBuch_ausleihe.Name = "lblBuch_ausleihe";
            this.lblBuch_ausleihe.Size = new System.Drawing.Size(38, 13);
            this.lblBuch_ausleihe.TabIndex = 0;
            this.lblBuch_ausleihe.Text = "Buch: ";
            // 
            // lblAusgabeBuch_ausleihe
            // 
            this.lblAusgabeBuch_ausleihe.AutoSize = true;
            this.lblAusgabeBuch_ausleihe.Location = new System.Drawing.Point(72, 33);
            this.lblAusgabeBuch_ausleihe.Name = "lblAusgabeBuch_ausleihe";
            this.lblAusgabeBuch_ausleihe.Size = new System.Drawing.Size(0, 13);
            this.lblAusgabeBuch_ausleihe.TabIndex = 1;
            // 
            // btnAusleihen_ausleihe
            // 
            this.btnAusleihen_ausleihe.Location = new System.Drawing.Point(16, 75);
            this.btnAusleihen_ausleihe.Name = "btnAusleihen_ausleihe";
            this.btnAusleihen_ausleihe.Size = new System.Drawing.Size(124, 23);
            this.btnAusleihen_ausleihe.TabIndex = 2;
            this.btnAusleihen_ausleihe.Text = "Ausleihen abschließen";
            this.btnAusleihen_ausleihe.UseVisualStyleBackColor = true;
            this.btnAusleihen_ausleihe.Click += new System.EventHandler(this.btnAusleihen_ausleihe_Click);
            // 
            // btnAbbruch_ausleihe
            // 
            this.btnAbbruch_ausleihe.Location = new System.Drawing.Point(146, 75);
            this.btnAbbruch_ausleihe.Name = "btnAbbruch_ausleihe";
            this.btnAbbruch_ausleihe.Size = new System.Drawing.Size(124, 23);
            this.btnAbbruch_ausleihe.TabIndex = 3;
            this.btnAbbruch_ausleihe.Text = "Ausleihen abbrechen";
            this.btnAbbruch_ausleihe.UseVisualStyleBackColor = true;
            this.btnAbbruch_ausleihe.Click += new System.EventHandler(this.btnAbbruch_ausleihe_Click);
            // 
            // FrmAusleihen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 112);
            this.Controls.Add(this.btnAbbruch_ausleihe);
            this.Controls.Add(this.btnAusleihen_ausleihe);
            this.Controls.Add(this.lblAusgabeBuch_ausleihe);
            this.Controls.Add(this.lblBuch_ausleihe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmAusleihen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ausleihen";
            this.Load += new System.EventHandler(this.Ausleihen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBuch_ausleihe;
        private System.Windows.Forms.Label lblAusgabeBuch_ausleihe;
        private System.Windows.Forms.Button btnAusleihen_ausleihe;
        private System.Windows.Forms.Button btnAbbruch_ausleihe;
    }
}