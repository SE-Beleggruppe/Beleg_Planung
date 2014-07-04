namespace DozentBelegverwaltungUI
{
    partial class PdfArchivierung
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
            this.buttonArchivieren = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.abbrechenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonArchivieren
            // 
            this.buttonArchivieren.Location = new System.Drawing.Point(12, 226);
            this.buttonArchivieren.Name = "buttonArchivieren";
            this.buttonArchivieren.Size = new System.Drawing.Size(186, 23);
            this.buttonArchivieren.TabIndex = 0;
            this.buttonArchivieren.Text = "Belege unwiderruflich archivieren";
            this.buttonArchivieren.UseVisualStyleBackColor = true;
            this.buttonArchivieren.Click += new System.EventHandler(this.buttonArchivieren_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Möchten Sie sämtliche Belege dieses Semesters archivieren?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hinweis: Dabei werden sämtliche Daten in ein PDF Dokument gepackt. ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(332, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Danach werden sämtliche Beleg-Daten aus der Datenbank gelöscht!";
            // 
            // abbrechenButton
            // 
            this.abbrechenButton.Location = new System.Drawing.Point(208, 226);
            this.abbrechenButton.Name = "abbrechenButton";
            this.abbrechenButton.Size = new System.Drawing.Size(186, 23);
            this.abbrechenButton.TabIndex = 4;
            this.abbrechenButton.Text = "Abbrechen";
            this.abbrechenButton.UseVisualStyleBackColor = true;
            this.abbrechenButton.Click += new System.EventHandler(this.abbrechenButton_Click);
            // 
            // PdfArchivierung
            // 
            this.AcceptButton = this.buttonArchivieren;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 261);
            this.Controls.Add(this.abbrechenButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonArchivieren);
            this.MaximumSize = new System.Drawing.Size(419, 300);
            this.MinimumSize = new System.Drawing.Size(419, 300);
            this.Name = "PdfArchivierung";
            this.Text = "PdfArchivierung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonArchivieren;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button abbrechenButton;
    }
}