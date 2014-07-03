namespace DozentBelegverwaltungUI
{
    partial class kontaktForm
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
            this.comboBoxBeleg = new System.Windows.Forms.ComboBox();
            this.comboBoxBelegthema = new System.Windows.Forms.ComboBox();
            this.comboBoxGruppe = new System.Windows.Forms.ComboBox();
            this.comboBoxRolle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.labelHint = new System.Windows.Forms.Label();
            this.txtBoxStudents = new System.Windows.Forms.TextBox();
            this.txtBoxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxBeleg
            // 
            this.comboBoxBeleg.FormattingEnabled = true;
            this.comboBoxBeleg.Location = new System.Drawing.Point(126, 38);
            this.comboBoxBeleg.Name = "comboBoxBeleg";
            this.comboBoxBeleg.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBeleg.TabIndex = 0;
            this.comboBoxBeleg.SelectedIndexChanged += new System.EventHandler(this.comboBoxBeleg_SelectedIndexChanged);
            // 
            // comboBoxBelegthema
            // 
            this.comboBoxBelegthema.FormattingEnabled = true;
            this.comboBoxBelegthema.Location = new System.Drawing.Point(126, 78);
            this.comboBoxBelegthema.Name = "comboBoxBelegthema";
            this.comboBoxBelegthema.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBelegthema.TabIndex = 1;
            this.comboBoxBelegthema.SelectedIndexChanged += new System.EventHandler(this.comboBoxBelegthema_SelectedIndexChanged);
            // 
            // comboBoxGruppe
            // 
            this.comboBoxGruppe.FormattingEnabled = true;
            this.comboBoxGruppe.Location = new System.Drawing.Point(126, 122);
            this.comboBoxGruppe.Name = "comboBoxGruppe";
            this.comboBoxGruppe.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGruppe.TabIndex = 2;
            this.comboBoxGruppe.SelectedIndexChanged += new System.EventHandler(this.comboBoxGruppe_SelectedIndexChanged);
            // 
            // comboBoxRolle
            // 
            this.comboBoxRolle.FormattingEnabled = true;
            this.comboBoxRolle.Location = new System.Drawing.Point(126, 165);
            this.comboBoxRolle.Name = "comboBoxRolle";
            this.comboBoxRolle.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRolle.TabIndex = 3;
            this.comboBoxRolle.SelectedIndexChanged += new System.EventHandler(this.comboBoxRolle_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Beleg*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Belegthema*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Gruppe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rolle";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(155, 340);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(92, 23);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "E-Mail senden";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.Location = new System.Drawing.Point(12, 371);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(69, 13);
            this.labelHint.TabIndex = 10;
            this.labelHint.Text = "* Pflichtfelder";
            // 
            // txtBoxStudents
            // 
            this.txtBoxStudents.Location = new System.Drawing.Point(126, 216);
            this.txtBoxStudents.Multiline = true;
            this.txtBoxStudents.Name = "txtBoxStudents";
            this.txtBoxStudents.ReadOnly = true;
            this.txtBoxStudents.Size = new System.Drawing.Size(121, 106);
            this.txtBoxStudents.TabIndex = 11;
            // 
            // txtBoxLabel
            // 
            this.txtBoxLabel.AutoSize = true;
            this.txtBoxLabel.Location = new System.Drawing.Point(25, 216);
            this.txtBoxLabel.Name = "txtBoxLabel";
            this.txtBoxLabel.Size = new System.Drawing.Size(41, 13);
            this.txtBoxLabel.TabIndex = 12;
            this.txtBoxLabel.Text = "E-Mails";
            // 
            // kontaktForm
            // 
            this.AcceptButton = this.btnFilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 393);
            this.Controls.Add(this.txtBoxLabel);
            this.Controls.Add(this.txtBoxStudents);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxRolle);
            this.Controls.Add(this.comboBoxGruppe);
            this.Controls.Add(this.comboBoxBelegthema);
            this.Controls.Add(this.comboBoxBeleg);
            this.MaximumSize = new System.Drawing.Size(303, 432);
            this.MinimumSize = new System.Drawing.Size(303, 432);
            this.Name = "kontaktForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxBeleg;
        private System.Windows.Forms.ComboBox comboBoxBelegthema;
        private System.Windows.Forms.ComboBox comboBoxGruppe;
        private System.Windows.Forms.ComboBox comboBoxRolle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.TextBox txtBoxStudents;
        private System.Windows.Forms.Label txtBoxLabel;
    }
}