using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Typen;
using DB_Services;


namespace StudentBelegverwaltungUI
{
    public partial class LoginForm : Form
    {
        // Konstruktor
        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Bitte loggen Sie sich ein";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Login-Button wurde geklaickt -- Eventhandler
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Gruppen oder Beleglogin?!?!?!
               if (checkGruppeLogin(loginTextField.Text,passwordTextField.Text))
               {
                   // Gruppenlogin
                    MainForm mainForm = new MainForm(loginTextField.Text, getBelegKennungFromGruppenKennung(loginTextField.Text));
                    mainForm.Show();
                    Hide();
                }
                else
                {
                   //Beleglogin
                    if (checkBelegLogin(loginTextField.Text, passwordTextField.Text))
                    {
                        // freie Case-Kennungen checken
                        if (freieGruppen(loginTextField.Text))
                        {
                            // Anmeldezeitraum prüfen
                            if (!isInBelegZeitraum(loginTextField.Text))
                            {
                                MessageBox.Show("Der Anmeldezeitraum für diesen Beleg ist leider abgelaufen. Bitte melden Sie sich beim Dozenten.","Fehler");
                                return;
                            }
                            FormErstanmeldung leiterEingeben = new FormErstanmeldung(loginTextField.Text);
                            leiterEingeben.Show();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Für diesen Beleg gibt es keine freien Gruppen mehr. Bitte melden Sie sich beim Dozenten.", "Fehler");
                            Application.Exit();
                        }
                    }
                        // komplett falscher Login
                    else MessageBox.Show("Kombination Login/Passwort ist falsch.", "Fehler");
                }   
        }

        // Beleg-Login überprüfen
        private bool checkBelegLogin(string login, string password)
        {
            Database db = new Database();
            List<string[]> output = db.ExecuteQuery("select * from Beleg where Belegkennung = \"" + login + "\" and Passwort=\"" + password + "\"");
            if (output.Count != 0) return true;
            return false;
        }

        // GruppenKennung checken
        private bool checkGruppeLogin(string login, string password)
        {
            Database db = new Database();
            List<string[]> output = db.ExecuteQuery("select * from Gruppe where Gruppenkennung=\"" + login + "\" and Passwort=internal_encrypt(\"" + password + "\")");
            if (output.Count != 0) return true;
            return false;
        }

        // Freie Casekennungen zu diesem Beleg checken
        private bool freieGruppen(string BelegKennung)
        {
            Database db = new Database();
            List<string[]> output1 = db.ExecuteQuery("select Casekennung from Zuordnung_BelegCases where Belegkennung=\"" + BelegKennung + "\" and Casekennung not in (select Gruppenkennung from Zuordnung_GruppeBeleg)");
            if (output1.Count != 0) return true;
            return false;
        }

        // Belegkennung durch Gruppenkennung aus Datenbank ziehen
        private string getBelegKennungFromGruppenKennung(string kennung)
        {
            Database db = new Database();
            string query = "select Belegkennung from Zuordnung_GruppeBeleg where Gruppenkennung=\"" + kennung + "\"";
            List<string[]> output = db.ExecuteQuery(query);
            foreach (string[] info in output)
                return info[0];
            return null;
        }

        // Zeitraum zum Anmelden aus der Datenbankziehen und mit aktuellem Datum vergleichen
        private bool isInBelegZeitraum(string belegkennung)
        {
            Database db = new Database();
            DateTime anfang = Convert.ToDateTime(db.ExecuteQuery("select StartDatum from Beleg where Belegkennung=\"" + belegkennung + "\"").First()[0]);
            DateTime ende = Convert.ToDateTime(db.ExecuteQuery("select EndDatum from Beleg where Belegkennung=\"" + belegkennung + "\"").First()[0]);
            return DateTime.Today >= anfang && DateTime.Today <= ende;
        }

        // Login abbrechen
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
