namespace DozentBelegverwaltungUI
{
    partial class gruppeBearbeiten
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.speichernbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.themenComboBox = new System.Windows.Forms.ComboBox();
            this.passwortTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kennungComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(260, 86);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 41;
            this.cancelButton.Text = "Abbrechen";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // speichernbutton
            // 
            this.speichernbutton.Location = new System.Drawing.Point(15, 86);
            this.speichernbutton.Name = "speichernbutton";
            this.speichernbutton.Size = new System.Drawing.Size(75, 23);
            this.speichernbutton.TabIndex = 40;
            this.speichernbutton.Text = "Speichern";
            this.speichernbutton.UseVisualStyleBackColor = true;
            this.speichernbutton.Click += new System.EventHandler(this.speichernbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Kennung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Belegthema";
            // 
            // themenComboBox
            // 
            this.themenComboBox.FormattingEnabled = true;
            this.themenComboBox.Location = new System.Drawing.Point(134, 33);
            this.themenComboBox.Name = "themenComboBox";
            this.themenComboBox.Size = new System.Drawing.Size(200, 21);
            this.themenComboBox.TabIndex = 45;
            // 
            // passwortTextBox
            // 
            this.passwortTextBox.Location = new System.Drawing.Point(134, 60);
            this.passwortTextBox.Name = "passwortTextBox";
            this.passwortTextBox.Size = new System.Drawing.Size(200, 20);
            this.passwortTextBox.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Passwort";
            // 
            // kennungComboBox
            // 
            this.kennungComboBox.Enabled = false;
            this.kennungComboBox.FormattingEnabled = true;
            this.kennungComboBox.Location = new System.Drawing.Point(134, 6);
            this.kennungComboBox.Name = "kennungComboBox";
            this.kennungComboBox.Size = new System.Drawing.Size(200, 21);
            this.kennungComboBox.TabIndex = 48;
            // 
            // gruppeBearbeiten
            // 
            this.AcceptButton = this.speichernbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(346, 125);
            this.Controls.Add(this.kennungComboBox);
            this.Controls.Add(this.passwortTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.themenComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.speichernbutton);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(362, 164);
            this.MinimumSize = new System.Drawing.Size(362, 164);
            this.Name = "gruppeBearbeiten";
            this.Text = "gruppeBearbeiten";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button speichernbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox themenComboBox;
        private System.Windows.Forms.TextBox passwortTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox kennungComboBox;
    }
}