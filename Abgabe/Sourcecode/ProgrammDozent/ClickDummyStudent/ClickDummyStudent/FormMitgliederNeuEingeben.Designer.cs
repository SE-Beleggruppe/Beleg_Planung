namespace StudentBelegverwaltungUI
{
    partial class FormMitgliederNeuEingeben
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
            this.alleMitgliederDataGridView = new System.Windows.Forms.DataGridView();
            this.Nachname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rolle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.newPasswortTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.CommitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.alleMitgliederDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sie können nun weitere Gruppenmitglieder eintragen, oder dies im Nachhinein erled" +
    "igen.";
            // 
            // alleMitgliederDataGridView
            // 
            this.alleMitgliederDataGridView.AllowUserToAddRows = false;
            this.alleMitgliederDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.alleMitgliederDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nachname,
            this.Vorname,
            this.sNummer,
            this.Mail,
            this.Rolle});
            this.alleMitgliederDataGridView.Location = new System.Drawing.Point(15, 36);
            this.alleMitgliederDataGridView.Name = "alleMitgliederDataGridView";
            this.alleMitgliederDataGridView.Size = new System.Drawing.Size(829, 150);
            this.alleMitgliederDataGridView.TabIndex = 1;
            // 
            // Nachname
            // 
            this.Nachname.HeaderText = "Nachname";
            this.Nachname.Name = "Nachname";
            // 
            // Vorname
            // 
            this.Vorname.HeaderText = "Vorname";
            this.Vorname.Name = "Vorname";
            // 
            // sNummer
            // 
            this.sNummer.HeaderText = "S-Nummer";
            this.sNummer.Name = "sNummer";
            // 
            // Mail
            // 
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            // 
            // Rolle
            // 
            this.Rolle.HeaderText = "Rolle";
            this.Rolle.Name = "Rolle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Legen Sie abschließend noch ein Gruppenkennwort fest:";
            // 
            // newPasswortTextBox
            // 
            this.newPasswortTextBox.Location = new System.Drawing.Point(297, 193);
            this.newPasswortTextBox.Name = "newPasswortTextBox";
            this.newPasswortTextBox.Size = new System.Drawing.Size(325, 20);
            this.newPasswortTextBox.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(769, 191);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Abbrechen";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CommitButton
            // 
            this.CommitButton.Location = new System.Drawing.Point(628, 192);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(135, 23);
            this.CommitButton.TabIndex = 5;
            this.CommitButton.Text = "Anmeldung abschließen";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // FormMitgliederNeuEingeben
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(856, 226);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.newPasswortTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.alleMitgliederDataGridView);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(872, 265);
            this.MinimumSize = new System.Drawing.Size(872, 265);
            this.Name = "FormMitgliederNeuEingeben";
            this.Text = "FormErstanmeldung2";
            ((System.ComponentModel.ISupportInitialize)(this.alleMitgliederDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView alleMitgliederDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newPasswortTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nachname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewComboBoxColumn Rolle;
    }
}