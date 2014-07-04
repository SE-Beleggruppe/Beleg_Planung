using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Typen;
using DB_Services;

namespace DozentBelegverwaltungUI
{
    public partial class RolleVerwalten : Form
    {

        private List<Rolle> _rollen;
        readonly Database _database = new Database();

        //Konstruktor
        public RolleVerwalten()
        {
            InitializeComponent();
            this.Text = "Rollen";
            this.StartPosition = FormStartPosition.CenterScreen;

            RefreshRollen();
        }


        private void deleteRolleButton_Click(object sender, EventArgs e)
        {
            var rolle = (Rolle)rollenListBox.SelectedItem;

            //Falls Rolle noch bei einem Beleg zugeordnet ist
            if (
                _database.ExecuteQuery(
                    "select * from Rolle where Rolle in(select Rolle from Zuordnung_BelegRolle) and Rolle=\"" +
                    rolle.rolle + "\"").Count != 0)
            {
                MessageBox.Show("Die Rolle " + rolle.rolle +
                                " ist noch in Verwendung und kann nicht gelöscht werden.");
                return;
            }

            //Rolle löschen und Listbox aktualisieren
            _database.ExecuteQuery("delete from Rolle where Rolle =\""+rolle.rolle+"\"");
            RefreshRollen();
        }

        /// <summary>
        /// aktualisiert Listbox mit Rollen
        /// </summary>
        private void RefreshRollen()
        {
            _rollen = new List<Rolle>();
            foreach (var array in _database.ExecuteQuery("select * from Rolle"))
            {
                var rolle = new Rolle(array[0]);
                _rollen.Add(rolle);
            }
            rollenListBox.DataSource = _rollen;
            rollenListBox.DisplayMember = "rolle";
            if (_rollen.Count == 0) deleteRolleButton.Enabled = false;
            else deleteRolleButton.Enabled = true;

            rollenListBox_SelectedIndexChanged(null, null);
        }

        //Verwendet Eingabedialog aus Klasse Eingabe
        private void newRolleButton_Click(object sender, EventArgs e)
        {
            var eingabe = new Eingabe {textEingabe = new Eingabe.textEingabeHandler(EingabeF)};
            eingabe.Show();
        }

        //wertet Eingabe aus und überprüft diese auf mögliche Fehleingaben
        //falls Eingabe korrekt, füge Rolle hinzu
        public void EingabeF(object sender)
        {
            foreach(Rolle temp in _rollen)
            {
                if(temp.rolle == ((TextBox)sender).Text)
                {
                    MessageBox.Show("Die Rolle " + ((TextBox)sender).Text + " ist schon in der Liste vorhanden.");
                    return;
                }
            }

            if (string.IsNullOrEmpty(((TextBox)sender).Text) || ((TextBox)sender).Text.Length > 25)
            {
                MessageBox.Show("Die Rolle " + ((TextBox)sender).Text + " ist leer oder länger als 25 Zeichen. Die Daten konnten nicht gespeichert werden.");
                return;
            }
            _database.ExecuteQuery("insert into Rolle values(\""+((TextBox)sender).Text +"\")");
            RefreshRollen();
        }

        private void rollenListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rolle = (Rolle)rollenListBox.SelectedItem;
            if (rolle.rolle == "Leitung") deleteRolleButton.Enabled = false;
            else deleteRolleButton.Enabled = true;
        }
    }
}
