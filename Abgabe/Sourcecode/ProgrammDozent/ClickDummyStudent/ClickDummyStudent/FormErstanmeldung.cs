using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Typen;
using DB_Services;

namespace StudentBelegverwaltungUI
{
    public partial class FormErstanmeldung : Form
    {
        public string Belegkennung;

        // Konstruktor
        public FormErstanmeldung( string belegKennung)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            Text = "Bitte tragen Sie den Leiter der Gruppe ein";
            Belegkennung = belegKennung;
        }

        // Bestätigen geklickt
        private void button1_Click(object sender, EventArgs e)
        {
            // auf leere Felder überprüfen
            if(!(string.IsNullOrEmpty(sNummerTextField.Text) ||
                string.IsNullOrEmpty(nachnameTextField.Text) || 
                string.IsNullOrEmpty(vornameTextField.Text) ||
                string.IsNullOrEmpty(mailTextField.Text)))
            {
                // S-Nummer und Mail-Adresse überprüfen
                if (!checkSNummer(sNummerTextField.Text))
                {
                    MessageBox.Show("S-Nummer ist fehlerhaft oder schon in der Datenbank vorhanden.");
                    return;
                }
                if (!checkMail(mailTextField.Text))
                {
                    MessageBox.Show("Dies ist keine gültige E-Mail-Adresse.");
                    return;
                }
                if(mailTextField.Text.Length > 50)
                {
                    MessageBox.Show("Die eingegebene Mail-Adresse ist zu lang. (Maximal 50 Zeichen)");
                    return;
                }
                if (nachnameTextField.Text.Length > 15)
                {
                    MessageBox.Show("Der eingegebene Nachname ist zu lang. (Maximal 15 zeichen)");
                    return;
                }
                if (vornameTextField.Text.Length > 15)
                {
                    MessageBox.Show("Der eingegebene Vorname ist zu lang. (Maximal 15 zeichen)");
                    return;
                }
                
                // Student wird erst in nächster Form mit den restlichen gespeichert, hier noch nichts in Datenbank
                Student leiter = new Student(nachnameTextField.Text, vornameTextField.Text, sNummerTextField.Text, mailTextField.Text, "Leitung");
                FormMitgliederNeuEingeben form2 = new FormMitgliederNeuEingeben(leiter, this.Belegkennung);
                form2.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Bitte alle Felder ausfüllen!");
            }
        }

        // Anmeldung abbrechen
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        // S-Nummer auf Länge und Inhalt überprüfen
        private bool checkSNummer(string sNummer)
        {
            Database db = new Database();
            if (sNummer == "") return false;
            if (sNummer.Length != 6) return false;
            if (!sNummer.StartsWith("s")) return false;
            string nummer = sNummer.Substring(1);
            int n;
            bool isNummer = int.TryParse(nummer, out n);
            if (!isNummer) return false;

            List<string[]> output = db.ExecuteQuery("select * from Student");
            foreach (string[] info in output)
            {
                if (info[0] == sNummer) return false;
            }

            return true;
        }

        // Mail-Adresse überprüfen
        private bool checkMail(string mail)
        {
            Regex regExp = new Regex("\\b[!#$%&'*+./0-9=?_`a-z{|}~^-]+@[.0-9a-z-]+\\.[a-z]{2,6}\\b");
            Match match = regExp.Match(mail.ToLower());
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        // Closing-Eventhandler überschreiben, damit Prozess beendet wird beim Abbrechen und nicht nur Fenster geschlossen wird
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.Exit();
        }
    }
}
