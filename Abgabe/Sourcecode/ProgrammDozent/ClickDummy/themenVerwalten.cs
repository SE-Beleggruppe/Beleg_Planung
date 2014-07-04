using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Typen;
using DB_Services;

namespace DozentBelegverwaltungUI
{
    public partial class ThemenVerwalten : Form
    {
        private List<Thema> _themen;
        readonly Database _database = new Database();

        public ThemenVerwalten()
        {
            InitializeComponent();
            this.Text = "Themen";
            this.StartPosition = FormStartPosition.CenterScreen;

            RefreshThemen();
        }

        private void deleteThemaButton_Click(object sender, EventArgs e)
        {
            // Überprüfen, ob Thema in Benutzung ist
            var thema = (Thema)themenListBox.SelectedItem;
            if (
                _database.ExecuteQuery(
                    "select * from Thema where Themennummer in(select Themennummer from Zuordnung_BelegThema) and Themennummer=" +
                    thema.ThemenNummer).Count != 0)
            {
                MessageBox.Show("Das Thema " + thema.AufgabenName +
                                " ist noch in Verwendung und kann nicht gelöscht werden.");
                return;
            }

            //Thema löschen und Listbox aktualisieren
            _database.ExecuteQuery("delete from Thema where Themennummer =" + thema.ThemenNummer + "");
            RefreshThemen();
        }

        /// <summary>
        /// aktualisiert Listbox mit Themen
        /// </summary>
        private void RefreshThemen()
        {
            _themen = new List<Thema>();
            foreach (var array in _database.ExecuteQuery("select * from Thema"))
            {
                var thema = new Thema(Convert.ToInt32(array[0]), array[1]);
                _themen.Add(thema);
            }
            themenListBox.DataSource = _themen;
            themenListBox.DisplayMember = "aufgabenName";
            if (_themen.Count == 0) deleteThemaButton.Enabled = false;
            else deleteThemaButton.Enabled = true;
        }

        //Verwendet Eingabedialog aus Klasse Eingabe
        private void addThemaButton_Click_1(object sender, EventArgs e)
        {
            var eingabe = new Eingabe {textEingabe = EingabeF};
            eingabe.Show();
        }


        //wertet Eingabe aus und überprüft diese auf mögliche Fehleingaben
        //falls Eingabe korrekt, füge Thema hinzu
        public void EingabeF(object sender)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text) || ((TextBox)sender).Text.Length > 80)
            {
                MessageBox.Show("Die Aufgabe " + ((TextBox) sender).Text + " ist leer oder länger als 80 Zeichen. Die Daten konnten nicht gespeichert werden.");
                return;
            }
            _database.ExecuteQuery("insert into Thema values(\"" + ((TextBox)sender).Text + "\")");
            RefreshThemen();
        }
    }
}
