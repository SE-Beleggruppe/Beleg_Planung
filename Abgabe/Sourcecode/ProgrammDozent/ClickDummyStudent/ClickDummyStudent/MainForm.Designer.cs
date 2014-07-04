namespace StudentBelegverwaltungUI
{
    partial class MainForm
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
            this.mitgliederDataGridView = new System.Windows.Forms.DataGridView();
            this.Nachname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rolle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.saveButton = new System.Windows.Forms.Button();
            this.comboBoxThemen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.zeitraumLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mitgliederDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mitgliederDataGridView
            // 
            this.mitgliederDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mitgliederDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nachname,
            this.Vorname,
            this.sNummer,
            this.mail,
            this.Rolle});
            this.mitgliederDataGridView.Location = new System.Drawing.Point(12, 12);
            this.mitgliederDataGridView.Name = "mitgliederDataGridView";
            this.mitgliederDataGridView.Size = new System.Drawing.Size(743, 309);
            this.mitgliederDataGridView.TabIndex = 0;
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
            // mail
            // 
            this.mail.HeaderText = "Mail";
            this.mail.Name = "mail";
            // 
            // Rolle
            // 
            this.Rolle.HeaderText = "Rolle";
            this.Rolle.Name = "Rolle";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(309, 327);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(71, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Speichern";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // comboBoxThemen
            // 
            this.comboBoxThemen.FormattingEnabled = true;
            this.comboBoxThemen.Location = new System.Drawing.Point(61, 327);
            this.comboBoxThemen.Name = "comboBoxThemen";
            this.comboBoxThemen.Size = new System.Drawing.Size(242, 21);
            this.comboBoxThemen.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thema:";
            // 
            // zeitraumLabel
            // 
            this.zeitraumLabel.AutoSize = true;
            this.zeitraumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zeitraumLabel.Location = new System.Drawing.Point(386, 330);
            this.zeitraumLabel.Name = "zeitraumLabel";
            this.zeitraumLabel.Size = new System.Drawing.Size(68, 15);
            this.zeitraumLabel.TabIndex = 6;
            this.zeitraumLabel.Text = "ZEITRAUM";
            // 
            // MainForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 366);
            this.Controls.Add(this.zeitraumLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxThemen);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.mitgliederDataGridView);
            this.MaximumSize = new System.Drawing.Size(784, 405);
            this.MinimumSize = new System.Drawing.Size(784, 405);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.mitgliederDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mitgliederDataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox comboBoxThemen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nachname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewComboBoxColumn Rolle;
        private System.Windows.Forms.Label zeitraumLabel;
    }
}

