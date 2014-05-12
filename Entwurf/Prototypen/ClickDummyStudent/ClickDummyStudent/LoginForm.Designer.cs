namespace ClickDummyStudent
{
    partial class LoginForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.tboLogin = new System.Windows.Forms.TextBox();
            this.tboPasswort = new System.Windows.Forms.TextBox();
            this.ErstAnmeldungCheckBox = new System.Windows.Forms.CheckBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Passwort:";
            // 
            // tboLogin
            // 
            this.tboLogin.Location = new System.Drawing.Point(124, 10);
            this.tboLogin.Name = "tboLogin";
            this.tboLogin.Size = new System.Drawing.Size(156, 20);
            this.tboLogin.TabIndex = 2;
            // 
            // tboPasswort
            // 
            this.tboPasswort.Location = new System.Drawing.Point(124, 39);
            this.tboPasswort.Name = "tboPasswort";
            this.tboPasswort.Size = new System.Drawing.Size(156, 20);
            this.tboPasswort.TabIndex = 3;
            // 
            // ErstAnmeldungCheckBox
            // 
            this.ErstAnmeldungCheckBox.AutoSize = true;
            this.ErstAnmeldungCheckBox.Location = new System.Drawing.Point(15, 67);
            this.ErstAnmeldungCheckBox.Name = "ErstAnmeldungCheckBox";
            this.ErstAnmeldungCheckBox.Size = new System.Drawing.Size(96, 17);
            this.ErstAnmeldungCheckBox.TabIndex = 4;
            this.ErstAnmeldungCheckBox.Text = "Erstanmeldung";
            this.ErstAnmeldungCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(124, 65);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(205, 64);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Abbrechen";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 96);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.ErstAnmeldungCheckBox);
            this.Controls.Add(this.tboPasswort);
            this.Controls.Add(this.tboLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboLogin;
        private System.Windows.Forms.TextBox tboPasswort;
        private System.Windows.Forms.CheckBox ErstAnmeldungCheckBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button CloseButton;
    }
}