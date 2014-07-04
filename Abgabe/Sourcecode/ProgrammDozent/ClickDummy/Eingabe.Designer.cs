namespace DozentBelegverwaltungUI
{
    partial class Eingabe
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
            this.eingabeButton = new System.Windows.Forms.Button();
            this.tboEingabe = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bezeichnung:";
            // 
            // eingabeButton
            // 
            this.eingabeButton.Location = new System.Drawing.Point(271, 4);
            this.eingabeButton.Name = "eingabeButton";
            this.eingabeButton.Size = new System.Drawing.Size(75, 23);
            this.eingabeButton.TabIndex = 1;
            this.eingabeButton.Text = "OK";
            this.eingabeButton.UseVisualStyleBackColor = true;
            this.eingabeButton.Click += new System.EventHandler(this.eingabeButton_Click);
            // 
            // tboEingabe
            // 
            this.tboEingabe.Location = new System.Drawing.Point(88, 6);
            this.tboEingabe.Name = "tboEingabe";
            this.tboEingabe.Size = new System.Drawing.Size(177, 20);
            this.tboEingabe.TabIndex = 1;
            // 
            // Eingabe
            // 
            this.AcceptButton = this.eingabeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 36);
            this.Controls.Add(this.tboEingabe);
            this.Controls.Add(this.eingabeButton);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(365, 75);
            this.MinimumSize = new System.Drawing.Size(365, 75);
            this.Name = "Eingabe";
            this.Text = "Eingabe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button eingabeButton;
        private System.Windows.Forms.TextBox tboEingabe;
    }
}