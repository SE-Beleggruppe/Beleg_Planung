namespace ClickDummyStudent
{
    partial class FormErstanmeldung1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tboSNummer = new System.Windows.Forms.TextBox();
            this.tboNachname = new System.Windows.Forms.TextBox();
            this.tboVorname = new System.Windows.Forms.TextBox();
            this.tboMail = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Willkommen! Bitte füllen Sie alle Felder aus, bevor Sie mit der Anmeldung fortfah" +
    "ren. ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "sNummer:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nachname:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Vorname:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "E-Mail:";
            // 
            // tboSNummer
            // 
            this.tboSNummer.Location = new System.Drawing.Point(121, 29);
            this.tboSNummer.Name = "tboSNummer";
            this.tboSNummer.Size = new System.Drawing.Size(294, 20);
            this.tboSNummer.TabIndex = 7;
            // 
            // tboNachname
            // 
            this.tboNachname.Location = new System.Drawing.Point(121, 55);
            this.tboNachname.Name = "tboNachname";
            this.tboNachname.Size = new System.Drawing.Size(294, 20);
            this.tboNachname.TabIndex = 9;
            // 
            // tboVorname
            // 
            this.tboVorname.Location = new System.Drawing.Point(121, 81);
            this.tboVorname.Name = "tboVorname";
            this.tboVorname.Size = new System.Drawing.Size(294, 20);
            this.tboVorname.TabIndex = 10;
            // 
            // tboMail
            // 
            this.tboMail.Location = new System.Drawing.Point(121, 107);
            this.tboMail.Name = "tboMail";
            this.tboMail.Size = new System.Drawing.Size(294, 20);
            this.tboMail.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Fortfahren";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(340, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Abbrechen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormErstanmeldung1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 165);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tboMail);
            this.Controls.Add(this.tboVorname);
            this.Controls.Add(this.tboNachname);
            this.Controls.Add(this.tboSNummer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormErstanmeldung1";
            this.Text = "FormErstanmeldung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tboSNummer;
        private System.Windows.Forms.TextBox tboNachname;
        private System.Windows.Forms.TextBox tboVorname;
        private System.Windows.Forms.TextBox tboMail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}