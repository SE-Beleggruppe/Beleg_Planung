namespace DozentBelegverwaltungUI
{
    partial class RolleVerwalten
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
            this.rollenListBox = new System.Windows.Forms.ListBox();
            this.newRolleButton = new System.Windows.Forms.Button();
            this.deleteRolleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rollenListBox
            // 
            this.rollenListBox.FormattingEnabled = true;
            this.rollenListBox.Location = new System.Drawing.Point(13, 13);
            this.rollenListBox.Name = "rollenListBox";
            this.rollenListBox.Size = new System.Drawing.Size(443, 199);
            this.rollenListBox.TabIndex = 0;
            this.rollenListBox.SelectedIndexChanged += new System.EventHandler(this.rollenListBox_SelectedIndexChanged);
            // 
            // newRolleButton
            // 
            this.newRolleButton.Location = new System.Drawing.Point(462, 13);
            this.newRolleButton.Name = "newRolleButton";
            this.newRolleButton.Size = new System.Drawing.Size(164, 23);
            this.newRolleButton.TabIndex = 1;
            this.newRolleButton.Text = "Neue Rolle";
            this.newRolleButton.UseVisualStyleBackColor = true;
            this.newRolleButton.Click += new System.EventHandler(this.newRolleButton_Click);
            // 
            // deleteRolleButton
            // 
            this.deleteRolleButton.Location = new System.Drawing.Point(462, 42);
            this.deleteRolleButton.Name = "deleteRolleButton";
            this.deleteRolleButton.Size = new System.Drawing.Size(164, 23);
            this.deleteRolleButton.TabIndex = 2;
            this.deleteRolleButton.Text = "Ausgewählte Rolle löschen";
            this.deleteRolleButton.UseVisualStyleBackColor = true;
            this.deleteRolleButton.Click += new System.EventHandler(this.deleteRolleButton_Click);
            // 
            // RolleVerwalten
            // 
            this.AcceptButton = this.newRolleButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 221);
            this.Controls.Add(this.deleteRolleButton);
            this.Controls.Add(this.newRolleButton);
            this.Controls.Add(this.rollenListBox);
            this.MaximumSize = new System.Drawing.Size(650, 260);
            this.MinimumSize = new System.Drawing.Size(650, 260);
            this.Name = "RolleVerwalten";
            this.Text = "themenVerwalten";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox rollenListBox;
        private System.Windows.Forms.Button newRolleButton;
        private System.Windows.Forms.Button deleteRolleButton;
    }
}