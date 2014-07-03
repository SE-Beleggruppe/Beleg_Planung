namespace DozentBelegverwaltungUI
{
    partial class MainForm
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
            this.belegListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.belegAnlegenButton = new System.Windows.Forms.Button();
            this.gruppenListBox = new System.Windows.Forms.ListBox();
            this.mitgliederDataGridView = new System.Windows.Forms.DataGridView();
            this.nachname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNummer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gruppeAnlegenButton = new System.Windows.Forms.Button();
            this.dataGridViewFreigebenButton = new System.Windows.Forms.Button();
            this.saveDataGridViewButton = new System.Windows.Forms.Button();
            this.cancelDataGridViewButton = new System.Windows.Forms.Button();
            this.themenVerwaltenButton = new System.Windows.Forms.Button();
            this.rolleTextBox = new System.Windows.Forms.Button();
            this.buttonArchivieren = new System.Windows.Forms.Button();
            this.btnKontaktiern = new System.Windows.Forms.Button();
            this.gruppeLoeschenButton = new System.Windows.Forms.Button();
            this.belegLoeschenButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mitgliederDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // belegListBox
            // 
            this.belegListBox.FormattingEnabled = true;
            this.belegListBox.Location = new System.Drawing.Point(12, 38);
            this.belegListBox.Name = "belegListBox";
            this.belegListBox.Size = new System.Drawing.Size(180, 199);
            this.belegListBox.TabIndex = 0;
            this.belegListBox.SelectedIndexChanged += new System.EventHandler(this.belegListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aktuell laufende Belege";
            // 
            // belegAnlegenButton
            // 
            this.belegAnlegenButton.Location = new System.Drawing.Point(12, 243);
            this.belegAnlegenButton.Name = "belegAnlegenButton";
            this.belegAnlegenButton.Size = new System.Drawing.Size(180, 23);
            this.belegAnlegenButton.TabIndex = 2;
            this.belegAnlegenButton.Text = "Beleg anlegen";
            this.belegAnlegenButton.UseVisualStyleBackColor = true;
            this.belegAnlegenButton.Click += new System.EventHandler(this.belegAnlegenButton_Click);
            // 
            // gruppenListBox
            // 
            this.gruppenListBox.FormattingEnabled = true;
            this.gruppenListBox.Location = new System.Drawing.Point(198, 38);
            this.gruppenListBox.Name = "gruppenListBox";
            this.gruppenListBox.Size = new System.Drawing.Size(180, 199);
            this.gruppenListBox.TabIndex = 4;
            this.gruppenListBox.SelectedIndexChanged += new System.EventHandler(this.gruppenListBox_SelectedIndexChanged);
            // 
            // mitgliederDataGridView
            // 
            this.mitgliederDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mitgliederDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nachname,
            this.vorname,
            this.sNummer,
            this.mail,
            this.rolle});
            this.mitgliederDataGridView.Enabled = false;
            this.mitgliederDataGridView.Location = new System.Drawing.Point(384, 38);
            this.mitgliederDataGridView.Name = "mitgliederDataGridView";
            this.mitgliederDataGridView.Size = new System.Drawing.Size(743, 199);
            this.mitgliederDataGridView.TabIndex = 6;
            this.mitgliederDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.studentenDataGridView_CellContentClick);
            // 
            // nachname
            // 
            this.nachname.HeaderText = "Nachname";
            this.nachname.Name = "nachname";
            // 
            // vorname
            // 
            this.vorname.HeaderText = "Vorname";
            this.vorname.Name = "vorname";
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
            // rolle
            // 
            this.rolle.HeaderText = "Rolle";
            this.rolle.Name = "rolle";
            // 
            // gruppeAnlegenButton
            // 
            this.gruppeAnlegenButton.Location = new System.Drawing.Point(198, 243);
            this.gruppeAnlegenButton.Name = "gruppeAnlegenButton";
            this.gruppeAnlegenButton.Size = new System.Drawing.Size(180, 23);
            this.gruppeAnlegenButton.TabIndex = 7;
            this.gruppeAnlegenButton.Text = "Gruppe anlegen";
            this.gruppeAnlegenButton.UseVisualStyleBackColor = true;
            this.gruppeAnlegenButton.Click += new System.EventHandler(this.gruppeAnlegenButton_Click);
            // 
            // dataGridViewFreigebenButton
            // 
            this.dataGridViewFreigebenButton.Location = new System.Drawing.Point(570, 243);
            this.dataGridViewFreigebenButton.Name = "dataGridViewFreigebenButton";
            this.dataGridViewFreigebenButton.Size = new System.Drawing.Size(180, 23);
            this.dataGridViewFreigebenButton.TabIndex = 9;
            this.dataGridViewFreigebenButton.Text = "Tabelle bearbeiten";
            this.dataGridViewFreigebenButton.UseVisualStyleBackColor = true;
            this.dataGridViewFreigebenButton.Click += new System.EventHandler(this.dataGridViewFreigebenButton_Click);
            // 
            // saveDataGridViewButton
            // 
            this.saveDataGridViewButton.Enabled = false;
            this.saveDataGridViewButton.Location = new System.Drawing.Point(756, 243);
            this.saveDataGridViewButton.Name = "saveDataGridViewButton";
            this.saveDataGridViewButton.Size = new System.Drawing.Size(87, 23);
            this.saveDataGridViewButton.TabIndex = 10;
            this.saveDataGridViewButton.Text = "Speichern";
            this.saveDataGridViewButton.UseVisualStyleBackColor = true;
            this.saveDataGridViewButton.Click += new System.EventHandler(this.saveDataGridViewButton_Click);
            // 
            // cancelDataGridViewButton
            // 
            this.cancelDataGridViewButton.Enabled = false;
            this.cancelDataGridViewButton.Location = new System.Drawing.Point(849, 243);
            this.cancelDataGridViewButton.Name = "cancelDataGridViewButton";
            this.cancelDataGridViewButton.Size = new System.Drawing.Size(87, 23);
            this.cancelDataGridViewButton.TabIndex = 11;
            this.cancelDataGridViewButton.Text = "Abbrechen";
            this.cancelDataGridViewButton.UseVisualStyleBackColor = true;
            this.cancelDataGridViewButton.Click += new System.EventHandler(this.cancelDataGridViewButton_Click);
            // 
            // themenVerwaltenButton
            // 
            this.themenVerwaltenButton.Location = new System.Drawing.Point(384, 273);
            this.themenVerwaltenButton.Name = "themenVerwaltenButton";
            this.themenVerwaltenButton.Size = new System.Drawing.Size(180, 23);
            this.themenVerwaltenButton.TabIndex = 12;
            this.themenVerwaltenButton.Text = "Themen verwalten";
            this.themenVerwaltenButton.UseVisualStyleBackColor = true;
            this.themenVerwaltenButton.Click += new System.EventHandler(this.themenVerwaltenButton_Click);
            // 
            // rolleTextBox
            // 
            this.rolleTextBox.Location = new System.Drawing.Point(570, 272);
            this.rolleTextBox.Name = "rolleTextBox";
            this.rolleTextBox.Size = new System.Drawing.Size(180, 23);
            this.rolleTextBox.TabIndex = 13;
            this.rolleTextBox.Text = "Rollen verwalten";
            this.rolleTextBox.UseVisualStyleBackColor = true;
            this.rolleTextBox.Click += new System.EventHandler(this.rolleTextBox_Click);
            // 
            // buttonArchivieren
            // 
            this.buttonArchivieren.Location = new System.Drawing.Point(1003, 245);
            this.buttonArchivieren.Name = "buttonArchivieren";
            this.buttonArchivieren.Size = new System.Drawing.Size(124, 22);
            this.buttonArchivieren.TabIndex = 14;
            this.buttonArchivieren.Text = "Beleg archivieren";
            this.buttonArchivieren.UseVisualStyleBackColor = true;
            this.buttonArchivieren.Click += new System.EventHandler(this.buttonArchivieren_Click);
            // 
            // btnKontaktiern
            // 
            this.btnKontaktiern.Location = new System.Drawing.Point(384, 244);
            this.btnKontaktiern.Name = "btnKontaktiern";
            this.btnKontaktiern.Size = new System.Drawing.Size(179, 23);
            this.btnKontaktiern.TabIndex = 15;
            this.btnKontaktiern.Text = "Kontaktieren";
            this.btnKontaktiern.UseVisualStyleBackColor = true;
            this.btnKontaktiern.Click += new System.EventHandler(this.button1_Click);
            // 
            // gruppeLoeschenButton
            // 
            this.gruppeLoeschenButton.Location = new System.Drawing.Point(198, 272);
            this.gruppeLoeschenButton.Name = "gruppeLoeschenButton";
            this.gruppeLoeschenButton.Size = new System.Drawing.Size(180, 23);
            this.gruppeLoeschenButton.TabIndex = 17;
            this.gruppeLoeschenButton.Text = "Gruppe löschen";
            this.gruppeLoeschenButton.UseVisualStyleBackColor = true;
            this.gruppeLoeschenButton.Click += new System.EventHandler(this.gruppeLoeschenButton_Click);
            // 
            // belegLoeschenButton
            // 
            this.belegLoeschenButton.Location = new System.Drawing.Point(12, 272);
            this.belegLoeschenButton.Name = "belegLoeschenButton";
            this.belegLoeschenButton.Size = new System.Drawing.Size(180, 23);
            this.belegLoeschenButton.TabIndex = 16;
            this.belegLoeschenButton.Text = "Beleg löschen";
            this.belegLoeschenButton.UseVisualStyleBackColor = true;
            this.belegLoeschenButton.Click += new System.EventHandler(this.belegLoeschenButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.belegAnlegenButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 310);
            this.Controls.Add(this.gruppeLoeschenButton);
            this.Controls.Add(this.belegLoeschenButton);
            this.Controls.Add(this.btnKontaktiern);
            this.Controls.Add(this.buttonArchivieren);
            this.Controls.Add(this.rolleTextBox);
            this.Controls.Add(this.themenVerwaltenButton);
            this.Controls.Add(this.cancelDataGridViewButton);
            this.Controls.Add(this.saveDataGridViewButton);
            this.Controls.Add(this.dataGridViewFreigebenButton);
            this.Controls.Add(this.gruppeAnlegenButton);
            this.Controls.Add(this.mitgliederDataGridView);
            this.Controls.Add(this.gruppenListBox);
            this.Controls.Add(this.belegAnlegenButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.belegListBox);
            this.MaximumSize = new System.Drawing.Size(1155, 349);
            this.MinimumSize = new System.Drawing.Size(1155, 349);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mitgliederDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox belegListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button belegAnlegenButton;
        private System.Windows.Forms.ListBox gruppenListBox;
        private System.Windows.Forms.DataGridView mitgliederDataGridView;
        private System.Windows.Forms.Button gruppeAnlegenButton;
        private System.Windows.Forms.Button dataGridViewFreigebenButton;
        private System.Windows.Forms.Button saveDataGridViewButton;
        private System.Windows.Forms.Button cancelDataGridViewButton;
        private System.Windows.Forms.Button themenVerwaltenButton;
        private System.Windows.Forms.Button rolleTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn nachname;
        private System.Windows.Forms.DataGridViewTextBoxColumn vorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewComboBoxColumn rolle;
        private System.Windows.Forms.Button buttonArchivieren;
        private System.Windows.Forms.Button btnKontaktiern;
        private System.Windows.Forms.Button gruppeLoeschenButton;
        private System.Windows.Forms.Button belegLoeschenButton;


    }
}