namespace DozentBelegverwaltungUI
{
    partial class BelegBearbeiten
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
            this.kennungTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.semesterTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.verThemen = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.allThemen = new System.Windows.Forms.ListBox();
            this.addButtonThema = new System.Windows.Forms.Button();
            this.remButtonThema = new System.Windows.Forms.Button();
            this.speichernbutton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.minGR = new System.Windows.Forms.NumericUpDown();
            this.maxGR = new System.Windows.Forms.NumericUpDown();
            this.remButtonRolle = new System.Windows.Forms.Button();
            this.addButtonRolle = new System.Windows.Forms.Button();
            this.allRollen = new System.Windows.Forms.ListBox();
            this.verRollen = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.passwortTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.remButtonCase = new System.Windows.Forms.Button();
            this.addButtonCase = new System.Windows.Forms.Button();
            this.allCases = new System.Windows.Forms.ListBox();
            this.verCases = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.minGR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxGR)).BeginInit();
            this.SuspendLayout();
            // 
            // kennungTextBox
            // 
            this.kennungTextBox.Enabled = false;
            this.kennungTextBox.Location = new System.Drawing.Point(198, 15);
            this.kennungTextBox.Name = "kennungTextBox";
            this.kennungTextBox.Size = new System.Drawing.Size(200, 20);
            this.kennungTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kennung";
            // 
            // semesterTextBox
            // 
            this.semesterTextBox.Location = new System.Drawing.Point(198, 41);
            this.semesterTextBox.Name = "semesterTextBox";
            this.semesterTextBox.Size = new System.Drawing.Size(200, 20);
            this.semesterTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Semester";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start-Datum";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(198, 93);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.startDateTimePicker.TabIndex = 4;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.startDateTimePicker_ValueChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(198, 119);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.endDateTimePicker.TabIndex = 5;
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.endDateTimePicker_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "End-Datum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mindest-Gruppengröße";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Maximale Gruppengröße";
            // 
            // verThemen
            // 
            this.verThemen.FormattingEnabled = true;
            this.verThemen.Location = new System.Drawing.Point(16, 215);
            this.verThemen.Name = "verThemen";
            this.verThemen.Size = new System.Drawing.Size(154, 108);
            this.verThemen.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Verfügbare Themen";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Alle Themen";
            // 
            // allThemen
            // 
            this.allThemen.FormattingEnabled = true;
            this.allThemen.Location = new System.Drawing.Point(249, 218);
            this.allThemen.Name = "allThemen";
            this.allThemen.Size = new System.Drawing.Size(149, 108);
            this.allThemen.TabIndex = 101;
            // 
            // addButtonThema
            // 
            this.addButtonThema.Location = new System.Drawing.Point(176, 242);
            this.addButtonThema.Name = "addButtonThema";
            this.addButtonThema.Size = new System.Drawing.Size(67, 23);
            this.addButtonThema.TabIndex = 8;
            this.addButtonThema.Text = "<<";
            this.addButtonThema.UseVisualStyleBackColor = true;
            this.addButtonThema.Click += new System.EventHandler(this.addButtonThema_Click);
            // 
            // remButtonThema
            // 
            this.remButtonThema.Location = new System.Drawing.Point(176, 271);
            this.remButtonThema.Name = "remButtonThema";
            this.remButtonThema.Size = new System.Drawing.Size(67, 23);
            this.remButtonThema.TabIndex = 9;
            this.remButtonThema.Text = ">>";
            this.remButtonThema.UseVisualStyleBackColor = true;
            this.remButtonThema.Click += new System.EventHandler(this.remButtonThema_Click);
            // 
            // speichernbutton
            // 
            this.speichernbutton.Location = new System.Drawing.Point(15, 601);
            this.speichernbutton.Name = "speichernbutton";
            this.speichernbutton.Size = new System.Drawing.Size(75, 23);
            this.speichernbutton.TabIndex = 14;
            this.speichernbutton.Text = "Speichern";
            this.speichernbutton.UseVisualStyleBackColor = true;
            this.speichernbutton.Click += new System.EventHandler(this.speichernbutton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(323, 604);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Abbrechen";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // minGR
            // 
            this.minGR.Location = new System.Drawing.Point(198, 145);
            this.minGR.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.minGR.Name = "minGR";
            this.minGR.Size = new System.Drawing.Size(120, 20);
            this.minGR.TabIndex = 6;
            this.minGR.ValueChanged += new System.EventHandler(this.minGR_ValueChanged);
            // 
            // maxGR
            // 
            this.maxGR.Location = new System.Drawing.Point(198, 171);
            this.maxGR.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.maxGR.Name = "maxGR";
            this.maxGR.Size = new System.Drawing.Size(120, 20);
            this.maxGR.TabIndex = 7;
            this.maxGR.ValueChanged += new System.EventHandler(this.maxGR_ValueChanged);
            // 
            // remButtonRolle
            // 
            this.remButtonRolle.Location = new System.Drawing.Point(177, 402);
            this.remButtonRolle.Name = "remButtonRolle";
            this.remButtonRolle.Size = new System.Drawing.Size(67, 23);
            this.remButtonRolle.TabIndex = 11;
            this.remButtonRolle.Text = ">>";
            this.remButtonRolle.UseVisualStyleBackColor = true;
            this.remButtonRolle.Click += new System.EventHandler(this.remButtonRolle_Click);
            // 
            // addButtonRolle
            // 
            this.addButtonRolle.Location = new System.Drawing.Point(177, 373);
            this.addButtonRolle.Name = "addButtonRolle";
            this.addButtonRolle.Size = new System.Drawing.Size(67, 23);
            this.addButtonRolle.TabIndex = 10;
            this.addButtonRolle.Text = "<<";
            this.addButtonRolle.UseVisualStyleBackColor = true;
            this.addButtonRolle.Click += new System.EventHandler(this.addButtonRolle_Click);
            // 
            // allRollen
            // 
            this.allRollen.FormattingEnabled = true;
            this.allRollen.Location = new System.Drawing.Point(250, 349);
            this.allRollen.Name = "allRollen";
            this.allRollen.Size = new System.Drawing.Size(149, 108);
            this.allRollen.TabIndex = 103;
            // 
            // verRollen
            // 
            this.verRollen.FormattingEnabled = true;
            this.verRollen.Location = new System.Drawing.Point(17, 346);
            this.verRollen.Name = "verRollen";
            this.verRollen.Size = new System.Drawing.Size(154, 108);
            this.verRollen.TabIndex = 102;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 471);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Verfügbare Cases";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(249, 474);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Alle freien Cases";
            // 
            // passwortTextBox
            // 
            this.passwortTextBox.Location = new System.Drawing.Point(198, 67);
            this.passwortTextBox.Name = "passwortTextBox";
            this.passwortTextBox.Size = new System.Drawing.Size(200, 20);
            this.passwortTextBox.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Start-Kennwort";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(249, 333);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Alle Rollen";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 330);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 13);
            this.label16.TabIndex = 40;
            this.label16.Text = "Verfügbare Rollen";
            // 
            // remButtonCase
            // 
            this.remButtonCase.Location = new System.Drawing.Point(176, 543);
            this.remButtonCase.Name = "remButtonCase";
            this.remButtonCase.Size = new System.Drawing.Size(67, 23);
            this.remButtonCase.TabIndex = 13;
            this.remButtonCase.Text = ">>";
            this.remButtonCase.UseVisualStyleBackColor = true;
            this.remButtonCase.Click += new System.EventHandler(this.remButtonCase_Click);
            // 
            // addButtonCase
            // 
            this.addButtonCase.Location = new System.Drawing.Point(176, 514);
            this.addButtonCase.Name = "addButtonCase";
            this.addButtonCase.Size = new System.Drawing.Size(67, 23);
            this.addButtonCase.TabIndex = 12;
            this.addButtonCase.Text = "<<";
            this.addButtonCase.UseVisualStyleBackColor = true;
            this.addButtonCase.Click += new System.EventHandler(this.addButtonCase_Click);
            // 
            // allCases
            // 
            this.allCases.FormattingEnabled = true;
            this.allCases.Location = new System.Drawing.Point(249, 490);
            this.allCases.Name = "allCases";
            this.allCases.Size = new System.Drawing.Size(149, 108);
            this.allCases.TabIndex = 105;
            // 
            // verCases
            // 
            this.verCases.FormattingEnabled = true;
            this.verCases.Location = new System.Drawing.Point(16, 487);
            this.verCases.Name = "verCases";
            this.verCases.Size = new System.Drawing.Size(154, 108);
            this.verCases.TabIndex = 104;
            // 
            // BelegBearbeiten
            // 
            this.AcceptButton = this.speichernbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(410, 633);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.remButtonCase);
            this.Controls.Add(this.addButtonCase);
            this.Controls.Add(this.allCases);
            this.Controls.Add(this.verCases);
            this.Controls.Add(this.passwortTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.remButtonRolle);
            this.Controls.Add(this.addButtonRolle);
            this.Controls.Add(this.allRollen);
            this.Controls.Add(this.verRollen);
            this.Controls.Add(this.maxGR);
            this.Controls.Add(this.minGR);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.speichernbutton);
            this.Controls.Add(this.remButtonThema);
            this.Controls.Add(this.addButtonThema);
            this.Controls.Add(this.allThemen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.verThemen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.semesterTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kennungTextBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(426, 672);
            this.MinimumSize = new System.Drawing.Size(426, 672);
            this.Name = "BelegBearbeiten";
            this.Text = "belegBearbeiten";
            ((System.ComponentModel.ISupportInitialize)(this.minGR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxGR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox kennungTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox semesterTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox verThemen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox allThemen;
        private System.Windows.Forms.Button addButtonThema;
        private System.Windows.Forms.Button remButtonThema;
        private System.Windows.Forms.Button speichernbutton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown minGR;
        private System.Windows.Forms.NumericUpDown maxGR;
        private System.Windows.Forms.Button remButtonRolle;
        private System.Windows.Forms.Button addButtonRolle;
        private System.Windows.Forms.ListBox allRollen;
        private System.Windows.Forms.ListBox verRollen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox passwortTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button remButtonCase;
        private System.Windows.Forms.Button addButtonCase;
        private System.Windows.Forms.ListBox allCases;
        private System.Windows.Forms.ListBox verCases;
    }
}