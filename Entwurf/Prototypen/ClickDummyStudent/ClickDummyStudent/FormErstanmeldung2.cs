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
    public partial class FormErstanmeldung2 : Form
    {
        Gruppe gruppe;
        public FormErstanmeldung2(Student leiter)
        {
            InitializeComponent();
            List<Student> studenten = new List<Student>();
            Student student = new Student("na", "na", "na", "na", "na");
            studenten.Add(leiter);
            studenten.Add(student);
            studenten.Add(student);
            studenten.Add(student);
            studenten.Add(student);
            studenten.Add(student);
            gruppe = new Gruppe("case11", leiter, studenten, "na", "passwort");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anmeldung abgeschlossen! \nIhre Gruppenkennung lautet: case11");
        }

        private void FormErstanmeldung2_Load(object sender, EventArgs e)
        {
            RefreshDatagrid(this.gruppe);
            dataGridViewGruppe.Rows[0].ReadOnly = true;
        }

        private void RefreshDatagrid(Gruppe gruppe)
        {
            dataGridViewGruppe.DataSource = null;
            dataGridViewGruppe.DataSource = gruppe.studenten;
        }
    }
}
