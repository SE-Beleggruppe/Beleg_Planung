using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Typen;
using DB_Services;

namespace StudentBelegverwaltungUI
{
    public partial class MainForm : Form
    {
        // Gruppe, die angezeigt werden soll
        Gruppe _gruppe;
        // Liste der Rollen für ComboBox
        List<string> rollen = new List<string>();
        // Min- und Max-Anzahl, die durch Beleg gegeben sind
        int minAnzahl;
        int maxAnzahl;

        // Konstruktor
        public MainForm(string gruppenKennung, string belegkennung)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            comboBoxThemen.DropDownStyle = ComboBoxStyle.DropDownList;

            getZeitraum(belegkennung);

            // Anmeldezeitraum checken -> wenn überschritten, Felder sperren
            if (!isInBelegZeitraum(belegkennung))
            {
                mitgliederDataGridView.ReadOnly = true;
                comboBoxThemen.Enabled = false;
                saveButton.Enabled = false;
                zeitraumLabel.ForeColor = Color.Red;
            }

            

            minAnzahl = getMinAnzahlMitglieder(belegkennung);
            maxAnzahl = getMaxAnzahlMitglieder(belegkennung);

            this._gruppe = GetGruppeFromKennungS(gruppenKennung, belegkennung);

            this.Text = gruppenKennung;

            mitgliederDataGridView.AllowUserToAddRows = false;
            mitgliederDataGridView.UserDeletingRow += mitgliederDataGridView_UserDeletingRow;


            UpdateRollen();
            updateMitgliederData(null);
            UpdateThemen();
        }

        // Eventhandler, wenn Student gelöscht werden soll
        void mitgliederDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow rowToDelete = e.Row;
            string sNummerToDelete = (string)rowToDelete.Cells[2].Value;
            if (sNummerToDelete == "na") e.Cancel = true;

            DialogResult dialogResult = MessageBox.Show("Wollen Sie den Studenten " + sNummerToDelete + " wirklich löschen?", "Achtung", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Soll gelöscht werden (nach Nachfrage-MessageBox)
                Database db = new Database();
                db.ExecuteQuery("delete from Student where sNummer=\"" + sNummerToDelete + "\"");
                db.ExecuteQuery("delete from Zuordnung_GruppeStudent where sNummer=\"" + sNummerToDelete + "\"");
            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }

            
        }


        // Gruppe aus Datenbank holen
        private Gruppe GetGruppeFromKennungS(string kennung, string belegkennung)
        {
            Database db = new Database();
            foreach (string[] info in db.ExecuteQuery("select * from Gruppe where Gruppenkennung=\"" + kennung + "\""))
            {
                Gruppe neu = new Gruppe(info[0], Convert.ToInt32(info[1]), info[2]);
                neu.Belegkennung = belegkennung;
                neu.Studenten = null;
                neu.Studenten = new List<Student>();
                // Studenten dieser Gruppe aus Datenbank holen
                foreach (string[] info2 in db.ExecuteQuery("select * from Student where sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung=\"" + kennung + "\")"))
                {
                    neu.addStudent(new Student(info2[2], info2[1], info2[0], info2[3], info2[4]));
                }
                if (neu.Studenten != null)
                {
                    int studentenCount = neu.Studenten.Count;
                    if(neu.Studenten.Count < maxAnzahl)
                    {
                        for (int i = 0; i < maxAnzahl - studentenCount; i++)
                            neu.addStudent(new Student("na", "na", "na", "na", "na"));
                    }
                }
                return neu;
            }
            return null;
        }

        // Zeitraum aus Datenbank holen und checken, ob aktuelles Datum drin liegt
        private bool isInBelegZeitraum(string belegkennung)
        {
            Database db = new Database();
            DateTime anfang = Convert.ToDateTime(db.ExecuteQuery("select StartDatum from Beleg where Belegkennung=\"" + belegkennung + "\"").First()[0]);
            DateTime ende = Convert.ToDateTime(db.ExecuteQuery("select EndDatum from Beleg where Belegkennung=\"" + belegkennung + "\"").First()[0]);
            if (DateTime.Today < anfang || DateTime.Today > ende) return false;
            return true;
        }

        // Mitglieder-Anzeige refreshen
        private void updateMitgliederData(List<Student> errorStudenten)
        {
            mitgliederDataGridView.Rows.Clear();
            (mitgliederDataGridView.Columns[4] as DataGridViewComboBoxColumn).DataSource = rollen;
            (mitgliederDataGridView.Columns[4] as DataGridViewComboBoxColumn).MinimumWidth = 150;
            (mitgliederDataGridView.Columns[3] as DataGridViewTextBoxColumn).MinimumWidth = 250;

            if (_gruppe.Studenten != null)
            {
                foreach (Student info in _gruppe.Studenten)
                {
                    int number = mitgliederDataGridView.Rows.Add();
                    mitgliederDataGridView.Rows[number].Cells[0].Value = info.Name;
                    mitgliederDataGridView.Rows[number].Cells[1].Value = info.Vorname;
                    mitgliederDataGridView.Rows[number].Cells[2].Value = info.SNummer;
                    if (info.SNummer != "na") mitgliederDataGridView.Rows[number].Cells[2].ReadOnly = true;
                    mitgliederDataGridView.Rows[number].Cells[3].Value = info.Mail;
                    mitgliederDataGridView.Rows[number].Cells[4].Value = info.Rolle;

                    // Gelb, wenn Mitglied noch ausgefüllt werden muss (mindest-Anzahl)
                    if (info.SNummer == "na" && number < minAnzahl)
                        mitgliederDataGridView.Rows[number].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            
            if (errorStudenten != null)
            {
                foreach (Student info in errorStudenten)
                {
                    int number = mitgliederDataGridView.Rows.Add();
                    mitgliederDataGridView.Rows[number].Cells[0].Value = info.Name;
                    mitgliederDataGridView.Rows[number].Cells[1].Value = info.Vorname;
                    mitgliederDataGridView.Rows[number].Cells[2].Value = info.SNummer;
                    mitgliederDataGridView.Rows[number].Cells[3].Value = info.Mail;
                    mitgliederDataGridView.Rows[number].Cells[4].Value = info.Rolle;

                    // Rot, wenn beim speichern dieses Studenten Fehler aufgetreten sind
                    mitgliederDataGridView.Rows[number].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        // verfügbare Themen aus DB ziehen
        private void UpdateThemen()
        {
            Database db = new Database();
            List<Thema> erg = new List<Thema>();
            List<string[]> output = db.ExecuteQuery("select * from Thema where Themennummer in (select Themennummer from Zuordnung_BelegThema where Belegkennung=\"" + _gruppe.Belegkennung + "\")");
            foreach (string[] info in output)
            {
                erg.Add(new Thema(Convert.ToInt32(info[0]), info[1]));
            }
            comboBoxThemen.DataSource = erg;
            comboBoxThemen.DisplayMember = "AufgabenName";
            string[] thisThema = db.ExecuteQuery("select * from Thema where Themennummer in (select Themennummer from Gruppe where Gruppenkennung=\"" + _gruppe.GruppenKennung + "\")").First();
            int index = 0;
            foreach (Thema tempThema in erg)
            {
                if (tempThema.ThemenNummer == Convert.ToInt32(thisThema[0]))
                    comboBoxThemen.SelectedIndex = index;

                index++;
            }
        }

        // Rollen aus Datenbank ziehen
        private void UpdateRollen()
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

        // vorgegebene Mindestanzahl aus DB 
        private int getMinAnzahlMitglieder(string beKennung)
        {
            Database db = new Database();
            List<string[]> output = db.ExecuteQuery("select MinAnzMitglieder from Beleg where Belegkennung=\"" + beKennung + "\"");
            return Convert.ToInt32(output.First()[0]);
        }

        // vorgegebene Maximalanzahl Studenten aus DB holen
        private int getMaxAnzahlMitglieder(string beKennung)
        {
            Database db = new Database();
            List<string[]> output = db.ExecuteQuery("select MaxAnzMitglieder from Beleg where Belegkennung=\"" + beKennung + "\"");
            return Convert.ToInt32(output.First()[0]);
        }

        // Closing-Event überschrieben
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.Exit();
        }

        // Azhal der eingetragenen Leiter überprüfen (darf nur ein Leiter und auch mindestens einer)
        private int getAnzahlLeiter()
        {
            int anzahlLeiter = 0;
            for (int i = 0; i < mitgliederDataGridView.Rows.Count; i++)
            {
                string name = (string)mitgliederDataGridView.Rows[i].Cells[0].Value;
                string vorname = (string)mitgliederDataGridView.Rows[i].Cells[1].Value;
                string sNummer = (string)mitgliederDataGridView.Rows[i].Cells[2].Value;
                string mail = (string)mitgliederDataGridView.Rows[i].Cells[3].Value;
                var formattedValue = mitgliederDataGridView.Rows[i].Cells[4].FormattedValue;
                if (formattedValue != null)
                {
                    string rolle = (string)formattedValue.ToString();

                    if (rolle == "Leitung" && sNummer != "na" && (mitgliederDataGridView.Rows[i].Cells[2].ReadOnly || checkSNummer(sNummer)) && (mitgliederDataGridView.Rows[i].Cells[2].ReadOnly || checkMail(mail)))
                    {
                        anzahlLeiter++;
                    }
                }
            }
            return anzahlLeiter;
        }

        // Speichern-Button wurde geklickt
        private void saveButton_Click(object sender, EventArgs e)
        {
            int anzahlLeiter = getAnzahlLeiter();
            if(anzahlLeiter == 0)
            {
                MessageBox.Show("Es muss ein Gruppenmitglied der Leiter sein. (Falsche S-Nummern oder ungültige Mail-Adressen sind nicht erlaubt)", "Fehler");
                return;
            }
            else if (anzahlLeiter > 1)
            {
                MessageBox.Show("Es darf nur ein Gruppenmitglied der Leiter sein. (Falsche S-Nummern oder ungültige Mail-Adressen sind nicht erlaubt)", "Fehler");
                return;
            }

            // Wenn Fehler bei Studenten auftreten, werden sie dieser Liste hinzugefügt und rot markiert ausgegeben
            List<Student> error = new List<Student>();

            for (int i = 0; i < mitgliederDataGridView.Rows.Count; i++)
            {
                string mail = (string) mitgliederDataGridView.Rows[i].Cells[3].Value;
                if(mitgliederDataGridView.Rows[i].Cells[2].ReadOnly && !checkMail(mail))
                {
                    MessageBox.Show(mail + " ist keine gültige Mail-Adresse. Die Daten wurden nicht gespeichert.",
                        "Fehler");
                    return;
                }
            }

            for (int i = 0; i < mitgliederDataGridView.Rows.Count; i++)
            {
                string name = (string)mitgliederDataGridView.Rows[i].Cells[0].Value;
                string vorname = (string)mitgliederDataGridView.Rows[i].Cells[1].Value;
                string sNummer = (string)mitgliederDataGridView.Rows[i].Cells[2].Value;
                string mail = (string) mitgliederDataGridView.Rows[i].Cells[3].Value;
                string rolle = (string)mitgliederDataGridView.Rows[i].Cells[4].FormattedValue.ToString();

                if (sNummer != "na" && !string.IsNullOrEmpty(sNummer))
                {
                    Student student = new Student(name, vorname, sNummer, mail, rolle);
                    if (mitgliederDataGridView.Rows[i].Cells[2].ReadOnly || checkSNummer(sNummer))
                    {
                        if (mitgliederDataGridView.Rows[i].Cells[2].ReadOnly || checkMail(mail))
                        {
                            if (mitgliederDataGridView.Rows[i].Cells[2].ReadOnly) updateStudent(student);
                            else insertStudent(student, _gruppe);
                        }
                        else
                        {
                            // MAIL IST NICHT RICHTIG
                            error.Add(student);
                        }
                    }
                    else
                    {
                        // S-Nummer ist falsch
                        error.Add(student);
                    }
                    
                }
            }
            // Thema der Gruppe in der DB zuordnen
            int themennummer = ((Thema) comboBoxThemen.SelectedItem).ThemenNummer;
            Database db = new Database();
            db.ExecuteQuery("update Gruppe set Themennummer=" + themennummer + " where Gruppenkennung=\"" + _gruppe.GruppenKennung + "\"");


            this._gruppe = GetGruppeFromKennungS(_gruppe.GruppenKennung, _gruppe.Belegkennung);
            this._gruppe.Belegkennung = _gruppe.Belegkennung;
            UpdateRollen();
            updateMitgliederData(error);
            UpdateThemen();

            if (error.Count == 0) MessageBox.Show("Änderungen erfolgreich gespeichert!", "Super!");
            else
                MessageBox.Show(
                    "Änderungen wurden, bis auf die rot markierten Studenten, gespeichert. Bei diesen bitte S-Nummer oder Mail-Adresse anpassen.",
                    "Bestätigung");
        }

        // Student ist schon in DB -> update
        private void updateStudent(Student student)
        {
            Database db = new Database();
            string query = "update Student set Nachname=\"" + student.Name + "\", Vorname=\"" + student.Vorname + "\", Mail=\"" + student.Mail + "\", Rolle=\"" + student.Rolle + "\" where sNummer=\"" + student.SNummer + "\"";
            db.ExecuteQuery(query);
        }

        // ist ein neuer Student -> insert
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
            if (mail.Length > 50) return false;
            Regex regExp = new Regex("\\b[!#$%&'*+./0-9=?_`a-z{|}~^-]+@[.0-9a-z-]+\\.[a-z]{2,6}\\b");
            Match match = regExp.Match(mail.ToLower());
            if (match.Success)
            {
                return true;
            }
            else return false;
        }

        private void getZeitraum (string belegkennung) {

            Database db = new Database();
            DateTime anfang = Convert.ToDateTime(db.ExecuteQuery("select StartDatum from Beleg where Belegkennung=\"" + belegkennung + "\"").First()[0]);
            DateTime ende = Convert.ToDateTime(db.ExecuteQuery("select EndDatum from Beleg where Belegkennung=\"" + belegkennung + "\"").First()[0]);

            zeitraumLabel.Text = "Änderungsmöglichkeiten zwischen " + anfang.ToString("dd.MM.yyyy") + " und " + ende.ToString("dd.MM.yyyy");
        }
        
    }
}
