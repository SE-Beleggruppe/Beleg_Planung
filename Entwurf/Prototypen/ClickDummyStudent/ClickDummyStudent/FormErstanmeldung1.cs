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
    public partial class FormErstanmeldung1 : Form
    {
        public FormErstanmeldung1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student leiter = new Student(tboNachname.Text, tboVorname.Text, tboSNummer.Text, tboMail.Text, "Leiter");
            FormErstanmeldung2 FormErstanmeldung2 = new FormErstanmeldung2(leiter);
            FormErstanmeldung2.Show();
            Hide();
        }
    }
}
