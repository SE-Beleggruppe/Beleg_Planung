namespace ClickDummy
{
    partial class themenVerwalten
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
            this.themenListBox = new System.Windows.Forms.ListBox();
            this.newThemaButton = new System.Windows.Forms.Button();
            this.deleteThemaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // themenListBox
            // 
            this.themenListBox.FormattingEnabled = true;
            this.themenListBox.Location = new System.Drawing.Point(13, 13);
            this.themenListBox.Name = "themenListBox";
            this.themenListBox.Size = new System.Drawing.Size(149, 199);
            this.themenListBox.TabIndex = 0;
            // 
            // newThemaButton
            // 
            this.newThemaButton.Location = new System.Drawing.Point(168, 13);
            this.newThemaButton.Name = "newThemaButton";
            this.newThemaButton.Size = new System.Drawing.Size(164, 23);
            this.newThemaButton.TabIndex = 1;
            this.newThemaButton.Text = "Neues Thema";
            this.newThemaButton.UseVisualStyleBackColor = true;
            this.newThemaButton.Click += new System.EventHandler(this.newThemaButton_Click);
            // 
            // deleteThemaButton
            // 
            this.deleteThemaButton.Location = new System.Drawing.Point(168, 42);
            this.deleteThemaButton.Name = "deleteThemaButton";
            this.deleteThemaButton.Size = new System.Drawing.Size(164, 23);
            this.deleteThemaButton.TabIndex = 2;
            this.deleteThemaButton.Text = "Ausgewähltes Thema löschen";
            this.deleteThemaButton.UseVisualStyleBackColor = true;
            this.deleteThemaButton.Click += new System.EventHandler(this.deleteThemaButton_Click);
            // 
            // themenVerwalten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 225);
            this.Controls.Add(this.deleteThemaButton);
            this.Controls.Add(this.newThemaButton);
            this.Controls.Add(this.themenListBox);
            this.Name = "themenVerwalten";
            this.Text = "themenVerwalten";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox themenListBox;
        private System.Windows.Forms.Button newThemaButton;
        private System.Windows.Forms.Button deleteThemaButton;
    }
}