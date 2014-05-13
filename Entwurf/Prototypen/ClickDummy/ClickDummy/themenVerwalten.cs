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
    public partial class themenVerwalten : Form
    {
        private List<Thema> themen;
        
        public themenVerwalten()
        {
            InitializeComponent();
            themen = new List<Thema>();
            for (int i = 0; i < 10; i++)
            { 
                themen.Add(new Thema("Eine schöne Aufgabe " + i));
            }
            themenListBox.DataSource = themen;
            themenListBox.DisplayMember = "aufgabenName";
        }

        private void newThemaButton_Click(object sender, EventArgs e)
        {
            themen.Add(new Thema("eine neue Aufgabe"));
            themenListBox.DataSource = null;
            themenListBox.DataSource = themen;
            themenListBox.DisplayMember = "aufgabenName";
        }

        private void deleteThemaButton_Click(object sender, EventArgs e)
        {
            Thema selT = (Thema)themenListBox.SelectedItem;
            themen.Remove(selT);
            themenListBox.DataSource = null;
            themenListBox.DataSource = themen;
            themenListBox.DisplayMember = "aufgabenName";
        }
    }
}
