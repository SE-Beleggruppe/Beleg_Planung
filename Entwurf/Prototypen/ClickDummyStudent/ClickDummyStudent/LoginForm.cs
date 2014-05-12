using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickDummyStudent
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (ErstAnmeldungCheckBox.Checked == true)
            {
                 if (tboLogin.Text == "")
                    {
                        if (tboPasswort.Text == "")
                        {
                            FormErstanmeldung1 FormErstanmeldung1 = new FormErstanmeldung1();
                            FormErstanmeldung1.Show();
                            Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kombination aus Login/Passwort nicht korrekt.");
                    }
            }

            else
            {
                if (tboLogin.Text == "")
                {
                    if (tboPasswort.Text == "")
                    {
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                        Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Kombination aus Login/Passwort nicht korrekt.");
                }
            }       
        }
    }
}
