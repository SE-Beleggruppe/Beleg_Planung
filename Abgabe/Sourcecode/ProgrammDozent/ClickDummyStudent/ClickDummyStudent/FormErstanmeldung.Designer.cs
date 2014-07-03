namespace StudentBelegverwaltungUI
{
    partial class FormErstanmeldung
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
            this.sNummerTextField = new System.Windows.Forms.TextBox();
            this.nachnameTextField = new System.Windows.Forms.TextBox();
            this.vornameTextField = new System.Windows.Forms.TextBox();
            this.mailTextField = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
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
            // sNummerTextField
            // 
            this.sNummerTextField.Location = new System.Drawing.Point(121, 29);
            this.sNummerTextField.Name = "sNummerTextField";
            this.sNummerTextField.Size = new System.Drawing.Size(294, 20);
            this.sNummerTextField.TabIndex = 7;
            // 
            // nachnameTextField
            // 
            this.nachnameTextField.Location = new System.Drawing.Point(121, 55);
            this.nachnameTextField.Name = "nachnameTextField";
            this.nachnameTextField.Size = new System.Drawing.Size(294, 20);
            this.nachnameTextField.TabIndex = 9;
            // 
            // vornameTextField
            // 
            this.vornameTextField.Location = new System.Drawing.Point(121, 81);
            this.vornameTextField.Name = "vornameTextField";
            this.vornameTextField.Size = new System.Drawing.Size(294, 20);
            this.vornameTextField.TabIndex = 10;
            // 
            // mailTextField
            // 
            this.mailTextField.Location = new System.Drawing.Point(121, 107);
            this.mailTextField.Name = "mailTextField";
            this.mailTextField.Size = new System.Drawing.Size(294, 20);
            this.mailTextField.TabIndex = 11;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(259, 133);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 12;
            this.goButton.Text = "Fortfahren";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(340, 133);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Abbrechen";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormErstanmeldung
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 165);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.mailTextField);
            this.Controls.Add(this.vornameTextField);
            this.Controls.Add(this.nachnameTextField);
            this.Controls.Add(this.sNummerTextField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(440, 204);
            this.MinimumSize = new System.Drawing.Size(440, 204);
            this.Name = "FormErstanmeldung";
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
        private System.Windows.Forms.TextBox sNummerTextField;
        private System.Windows.Forms.TextBox nachnameTextField;
        private System.Windows.Forms.TextBox vornameTextField;
        private System.Windows.Forms.TextBox mailTextField;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button cancelButton;
    }
}