namespace ClickDummy
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
            this.studentenDataGridView = new System.Windows.Forms.DataGridView();
            this.gruppeAnlegenButton = new System.Windows.Forms.Button();
            this.mitgliedAnlegen = new System.Windows.Forms.Button();
            this.dataGridViewFreigebenButton = new System.Windows.Forms.Button();
            this.saveDataGridViewButton = new System.Windows.Forms.Button();
            this.cancelDataGridViewButton = new System.Windows.Forms.Button();
            this.themenVerwaltenButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.studentenDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // belegListBox
            // 
            this.belegListBox.FormattingEnabled = true;
            this.belegListBox.Location = new System.Drawing.Point(21, 38);
            this.belegListBox.Name = "belegListBox";
            this.belegListBox.Size = new System.Drawing.Size(180, 199);
            this.belegListBox.TabIndex = 0;
            this.belegListBox.SelectedIndexChanged += new System.EventHandler(this.belegListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aktuell laufende Belege";
            // 
            // belegAnlegenButton
            // 
            this.belegAnlegenButton.Location = new System.Drawing.Point(21, 243);
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
            this.gruppenListBox.Location = new System.Drawing.Point(207, 38);
            this.gruppenListBox.Name = "gruppenListBox";
            this.gruppenListBox.Size = new System.Drawing.Size(180, 199);
            this.gruppenListBox.TabIndex = 4;
            this.gruppenListBox.SelectedIndexChanged += new System.EventHandler(this.gruppenListBox_SelectedIndexChanged);
            // 
            // studentenDataGridView
            // 
            this.studentenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentenDataGridView.Enabled = false;
            this.studentenDataGridView.Location = new System.Drawing.Point(393, 38);
            this.studentenDataGridView.Name = "studentenDataGridView";
            this.studentenDataGridView.Size = new System.Drawing.Size(552, 199);
            this.studentenDataGridView.TabIndex = 6;
            // 
            // gruppeAnlegenButton
            // 
            this.gruppeAnlegenButton.Location = new System.Drawing.Point(207, 243);
            this.gruppeAnlegenButton.Name = "gruppeAnlegenButton";
            this.gruppeAnlegenButton.Size = new System.Drawing.Size(180, 23);
            this.gruppeAnlegenButton.TabIndex = 7;
            this.gruppeAnlegenButton.Text = "Gruppe anlegen";
            this.gruppeAnlegenButton.UseVisualStyleBackColor = true;
            this.gruppeAnlegenButton.Click += new System.EventHandler(this.gruppeAnlegenButton_Click);
            // 
            // mitgliedAnlegen
            // 
            this.mitgliedAnlegen.Location = new System.Drawing.Point(393, 243);
            this.mitgliedAnlegen.Name = "mitgliedAnlegen";
            this.mitgliedAnlegen.Size = new System.Drawing.Size(180, 23);
            this.mitgliedAnlegen.TabIndex = 8;
            this.mitgliedAnlegen.Text = "Mitglied anlegen";
            this.mitgliedAnlegen.UseVisualStyleBackColor = true;
            this.mitgliedAnlegen.Click += new System.EventHandler(this.mitgliedAnlegen_Click);
            // 
            // dataGridViewFreigebenButton
            // 
            this.dataGridViewFreigebenButton.Location = new System.Drawing.Point(579, 243);
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
            this.saveDataGridViewButton.Location = new System.Drawing.Point(765, 243);
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
            this.cancelDataGridViewButton.Location = new System.Drawing.Point(858, 243);
            this.cancelDataGridViewButton.Name = "cancelDataGridViewButton";
            this.cancelDataGridViewButton.Size = new System.Drawing.Size(87, 23);
            this.cancelDataGridViewButton.TabIndex = 11;
            this.cancelDataGridViewButton.Text = "Abbrechen";
            this.cancelDataGridViewButton.UseVisualStyleBackColor = true;
            this.cancelDataGridViewButton.Click += new System.EventHandler(this.cancelDataGridViewButton_Click);
            // 
            // themenVerwaltenButton
            // 
            this.themenVerwaltenButton.Location = new System.Drawing.Point(21, 273);
            this.themenVerwaltenButton.Name = "themenVerwaltenButton";
            this.themenVerwaltenButton.Size = new System.Drawing.Size(180, 23);
            this.themenVerwaltenButton.TabIndex = 12;
            this.themenVerwaltenButton.Text = "Themen verwalten";
            this.themenVerwaltenButton.UseVisualStyleBackColor = true;
            this.themenVerwaltenButton.Click += new System.EventHandler(this.themenVerwaltenButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 310);
            this.Controls.Add(this.themenVerwaltenButton);
            this.Controls.Add(this.cancelDataGridViewButton);
            this.Controls.Add(this.saveDataGridViewButton);
            this.Controls.Add(this.dataGridViewFreigebenButton);
            this.Controls.Add(this.mitgliedAnlegen);
            this.Controls.Add(this.gruppeAnlegenButton);
            this.Controls.Add(this.studentenDataGridView);
            this.Controls.Add(this.gruppenListBox);
            this.Controls.Add(this.belegAnlegenButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.belegListBox);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentenDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox belegListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button belegAnlegenButton;
        private System.Windows.Forms.ListBox gruppenListBox;
        private System.Windows.Forms.DataGridView studentenDataGridView;
        private System.Windows.Forms.Button gruppeAnlegenButton;
        private System.Windows.Forms.Button mitgliedAnlegen;
        private System.Windows.Forms.Button dataGridViewFreigebenButton;
        private System.Windows.Forms.Button saveDataGridViewButton;
        private System.Windows.Forms.Button cancelDataGridViewButton;
        private System.Windows.Forms.Button themenVerwaltenButton;


    }
}