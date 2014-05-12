using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickDummy
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "")
            {
                if (passwordTextBox.Text == "")
                {
                    Logger("login erfolgreich");
                    MainForm main = new MainForm();
                    main.Show();
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("Kombination aus Login/Passwort nicht korrekt.");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Logger(String lines)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Benjamin\\Documents\\test.txt", true);
            file.WriteLine(lines);
            file.Close();
        }

    }

    
}

