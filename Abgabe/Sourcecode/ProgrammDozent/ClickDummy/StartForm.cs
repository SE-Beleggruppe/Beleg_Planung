using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB_Services;

namespace DozentBelegverwaltungUI
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            this.Text = "Starte Programm..";
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = "Verbindung zur Datenbank wird aufgebaut...";
        }

        private void StartForm_Load(object sender, EventArgs e) {}

        private void StartForm_Shown(object sender, EventArgs e)
        {
            Database db = new Database();
            var temp = db.ExecuteQuery("select * from Beleg");

            MainForm mf = new MainForm();
            mf.Show();
            Hide();
        }
    }
}
