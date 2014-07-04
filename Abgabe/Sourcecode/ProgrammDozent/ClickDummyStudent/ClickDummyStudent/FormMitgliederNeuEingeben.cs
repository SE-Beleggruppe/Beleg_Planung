using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Typen;
using DB_Services;

namespace StudentBelegverwaltungUI
{
    public partial class FormMitgliederNeuEingeben : Form
    {
        // angzeigte Gruppe
        Gruppe _gruppe;
        public string Belegkennung;

        // mögliche Rollen, die ausgewählt werden können
        List<string> rollen;

        // Konstruktor 
        public FormMitgliederNeuEingeben(Student leiter, string belegKennung)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Text = "Neue Gruppe in Beleg " + belegKennung;
            this.Belegkennung = belegKennung;
            _gruppe = new Gruppe("p", Belegkennung);
            string newGruppenkennung = getGruppenKennung();

            // Wenn getGruppenkennung -1 zurückliefert, dann sind keine freien Gruppen mehr verfügbar!!!! :)
            if (newGruppenkennung != "-1") _gruppe.GruppenKennung = newGruppenkennung;
            else
            {
                MessageBox.Show("Keine freien Gruppen für diesen Beleg verfügbar, bitte bei dem Dozenten melden", "Fehler");
                Application.Exit();
            }

            // Da neue Gruppe, ist noch kein Thema festgelegt, es wird das erstbeste genommen
            _gruppe.ThemenNummer = getThemenNummer();
            _gruppe.addStudent(leiter);
            for (int i = 0; i < getMaxAnzahlMitglieder(belegKennung) - 1; i++)
            {
                // Platzhalter-Studenten einfügen
                _gruppe.addStudent(new Student("na","na","na","na","na"));
            }
            updateRollen();
            RefreshDatagrid(this._gruppe);
            alleMitgliederDataGridView.Rows[0].ReadOnly = true;
        }

        // Bestätigen-Button wurde geklickt-Eventhandler
        private void commitButton_Click(object sender, EventArgs e)
        {
            // neues Passwort auf Vollständigkeit überprüfen
            if (string.IsNullOrEmpty(newPasswortTextBox.Text) || newPasswortTextBox.Text.Length > 25)
            {
                MessageBox.Show("Bitte geben Sie ein Passwort ein (maximal 25 Zeichen lang) mit dem Sie später auf die Gruppe zugreifen können.", "Fehler");
                return;
            }
            _gruppe.Password = newPasswortTextBox.Text;
            saveGruppeInDatabase();
        }

        // Rollen aus der Datenbank ziehen
        private void updateRollen()
        {
            rollen = new List<string>();
            Database db = new Database();
            List<string[]> output = db.ExecuteQuery("Select Rolle from Rolle where Rolle in (select Rolle from Zuordnung_BelegRolle where Belegkennung=\"" + _gruppe.Belegkennung + "\")");
            foreach (string[] info in output)
            {
                rollen.Add(info[0]);
            }
            rollen.Add("na");
        }

        // Studenten-DatagridView refreshen
        private void RefreshDatagrid(Gruppe gruppe)
        {
            alleMitgliederDataGridView.Rows.Clear();
            (alleMitgliederDataGridView.Columns[4] as DataGridViewComboBoxColumn).DataSource = rollen;
            (alleMitgliederDataGridView.Columns[3] as DataGridViewTextBoxColumn).MinimumWidth = 250;
            foreach (Student info in gruppe.Studenten)
            {
                int number = alleMitgliederDataGridView.Rows.Add();
                alleMitgliederDataGridView.Rows[number].Cells[0].Value = info.Name;
                alleMitgliederDataGridView.Rows[number].Cells[1].Value = info.Vorname;
                alleMitgliederDataGridView.Rows[number].Cells[2].Value = info.SNummer;
                if (info.SNummer != "na") alleMitgliederDataGridView.Rows[number].Cells[2].ReadOnly = true;
                alleMitgliederDataGridView.Rows[number].Cells[3].Value = info.Mail;
                alleMitgliederDataGridView.Rows[number].Cells[4].Value = info.Rolle;
            }
        }

        // Anmeldung abbrechen
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // neue, freie Gruppenkennung aus der Datenbank holen
        private string getGruppenKennung()
        {
            Database db = new Database();
            List<string[]> output1 = db.ExecuteQuery("select Casekennung from Zuordnung_BelegCases where Belegkennung=\"" + _gruppe.Belegkennung + "\" and Casekennung not in (select Gruppenkennung from Zuordnung_GruppeBeleg)");
            foreach (string[] info in output1)
            {
                return info[0];
            }
            return "-1";
        }

        // gültige Themennummer aus der Datenbank holen
        private int getThemenNummer()
        {
            Database db = new Database();
            string query = "select Themennummer from Zuordnung_BelegThema where Belegkennung=\"" + Belegkennung + "\"";
            List<string[]> output = db.ExecuteQuery(query);
            int nr = 0;
            if(output.Count > 0) int.TryParse(output.First()[0], out nr);
            return nr;
        }

        // maximal zulässige Mitgliederanzahl aus der Datenbank holen (Beleg abhängig)
        private int getMaxAnzahlMitglieder(string beKennung)
        {
            Database db = new Database();
            List<string[]> output = db.ExecuteQuery("select MaxAnzMitglieder from Beleg where Belegkennung=\"" + beKennung + "\"");
            return Convert.ToInt32(output.First()[0]);
        }

        // Gruppe wurde überprüft und kann gepspeichert werden :)
        private void saveGruppeInDatabase()
        {
            string fehlermeldung = "";
            for (int i = 0; i < alleMitgliederDataGridView.Rows.Count; i++)
            {
                string name = (string)alleMitgliederDataGridView.Rows[i].Cells[0].Value;
                string vorname = (string)alleMitgliederDataGridView.Rows[i].Cells[1].Value;
                string sNummer = (string)alleMitgliederDataGridView.Rows[i].Cells[2].Value;
                string mail = (string)alleMitgliederDataGridView.Rows[i].Cells[3].Value;
                string rolle = (string)alleMitgliederDataGridView.Rows[i].Cells[4].FormattedValue.ToString();

                if (sNummer != "na" && !string.IsNullOrEmpty(sNummer))
                {
                    // S-Nummer überprüfen
                    if (!checkSNummer(sNummer))
                    {
                       fehlermeldung += "Student " + name + " " + vorname + " hat weder 'na' noch eine gültige S-Nummer eingetragen und konnte nicht hinzugefügt werden. (" + sNummer + ")\n";
                    }
                    // Mail überprüfen
                    if (!checkMail(mail) || mail.Length > 50)
                    {
                        fehlermeldung += "Student " + name + " " + vorname +
                                         "hat weder 'na' noch eine gültige Mail-Adresse eingetragen und konnte nicht hinzugefügt werden oder die eingegebene Mail-Adresse ist zu lang (>50 Zeichen). (" +
                                         sNummer + ")\n";
                    }
                    // Name überprüfen
                    if (string.IsNullOrEmpty(name) || name.Length > 15)
                    {
                        fehlermeldung += "Student " + name + " " + vorname + " hat einen leeren oder zu langen (>15 Zeichen) Nachnamen und konnte nicht hinzugefügt werden. (" + sNummer + ")\n";
                    }
                    // Vorname überprüfen
                    if ( string.IsNullOrEmpty(vorname) || vorname.Length > 15)
                    {
                        fehlermeldung += "Student " + name + " " + vorname + " hat einen leeren oder zu langen (>15 Zeichen) Vornamen und konnte nicht hinzugefügt werden. (" + sNummer + ")\n";
                    }
                }
            }
            // Wenn fehlerhafte Studenten in DatagridView, dann Fehlermeldung ausgeben und abbrechen
            if (fehlermeldung != "")
            {
                MessageBox.Show(fehlermeldung, "Fehler");
                return;
            }
            // Alles in Ordnung? Los gehts! :)
            for (int i = 0; i < alleMitgliederDataGridView.Rows.Count; i++)
            {
                string name = (string)alleMitgliederDataGridView.Rows[i].Cells[0].Value;
                string vorname = (string)alleMitgliederDataGridView.Rows[i].Cells[1].Value;
                string sNummer = (string)alleMitgliederDataGridView.Rows[i].Cells[2].Value;
                string mail = (string)alleMitgliederDataGridView.Rows[i].Cells[3].Value;
                string rolle = (string)alleMitgliederDataGridView.Rows[i].Cells[4].FormattedValue.ToString();

                if (sNummer != "na" && !string.IsNullOrEmpty(sNummer))
                {
                    insertStudent(new Student(name,vorname,sNummer,mail,rolle), _gruppe );
                }
            }
            Database db = new Database();
            string query = "insert into Gruppe values(\"" + _gruppe.GruppenKennung + "\"," + _gruppe.ThemenNummer + ",internal_encrypt(\"" + _gruppe.Password + "\"))";
            db.ExecuteQuery(query);
            query = "insert into Zuordnung_GruppeBeleg values(\"" + _gruppe.GruppenKennung + "\",\"" + _gruppe.Belegkennung + "\")";
            db.ExecuteQuery(query);

            // Anmeldung in Datenbank abgeschlossen -> Warnung mit Case-Kennung (damit sie nicht sofort weggeklickt wird
            MessageBox.Show("Anmeldung abgeschlossen! \nIhre Gruppenkennung lautet: " + _gruppe.GruppenKennung + "\n(Wichtig für das spätere Anmelden!)", "ACHTUNG!!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            MainForm form = new MainForm(_gruppe.GruppenKennung, _gruppe.Belegkennung);
            form.Show();
            this.Hide();
        }

        // Student neu einfügen in Datenbank
        private void insertStudent(Student student, Gruppe gruppe)
        {
            Database db = new Database();
            string query = "insert into Student values(\"" + student.SNummer + "\",\"" + student.Vorname + "\",\"" + student.Name + "\",\"" + student.Mail + "\",\"" + student.Rolle + "\")";
            db.ExecuteQuery(query);
            query = "insert into Zuordnung_GruppeStudent values(\"" + gruppe.GruppenKennung + "\",\"" + student.SNummer + "\")";
            db.ExecuteQuery(query);
        }

        // S-Nummer überprüfen
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

            List<string[]> output = db.ExecuteQuery("select sNummer from Student");
            foreach (string[] info in output)
            {
                if (info[0] == sNummer) return false;
            }

            return true;
        }

        // Mail überprüfen
        private bool checkMail(string mail)
        {
            if (mail == "na") return true;
            Regex regExp = new Regex("\\b[!#$%&'*+./0-9=?_`a-z{|}~^-]+@[.0-9a-z-]+\\.[a-z]{2,6}\\b");
            Match match = regExp.Match(mail.ToLower());
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        // Close-Event überschreiben
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.Exit();
        }
    }
}
