using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DozentBelegverwaltungUI
{
    public partial class Eingabe : Form
    {
        /// <summary>
        /// Fenster erscheint bei sämtlichen Eingaben (neues Thema, neue Rolle,...)
        /// </summary>

        public delegate void textEingabeHandler(object sender);
        public textEingabeHandler textEingabe;

        public Eingabe()
        {
            InitializeComponent();
            this.Text = "Bitte geben Sie etwas ein";
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void eingabeButton_Click(object sender, EventArgs e)
        {
            if (textEingabe != null)
            {
                textEingabe(tboEingabe);
            }
            this.Close();
        }
    }
}
