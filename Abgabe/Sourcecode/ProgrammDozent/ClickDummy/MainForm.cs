using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Typen;
using DB_Services;

namespace DozentBelegverwaltungUI
{
    public partial class MainForm : Form
    {
        List<Beleg> _belege = new List<Beleg>();
        List<Gruppe> _gruppen = new List<Gruppe>();
        List<string> _rollen = new List<string>();
        List<Student> _tempStudent;
        Database _database = new Database();

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Übersicht";
            this.StartPosition = FormStartPosition.CenterScreen;
            
            UpdateBelege(null);

            mitgliederDataGridView.AllowUserToAddRows = false;
            mitgliederDataGridView.UserDeletingRow += mitgliederDataGridView_UserDeletingRow;

            belegListBox.DoubleClick += belegListBox_DoubleClicked;
            gruppenListBox.DoubleClick += gruppenListBox_DoubleClicked;
        }

        // Eventhandler, bevor Student gelöscht werden soll
        void mitgliederDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow rowToDelete = e.Row;
            string sNummerToDelete = (string)rowToDelete.Cells[2].Value;

            // Kein Student, sondern Platzhalter
            if (sNummerToDelete == "na") e.Cancel = true;

            DialogResult dialogResult = MessageBox.Show("Wollen Sie den Studenten " + sNummerToDelete + " wirklich löschen?", "Achtung", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Student wird gelöscht
                Database db = new Database();
                db.ExecuteQuery("delete from Student where sNummer=\"" + sNummerToDelete + "\"");
                db.ExecuteQuery("delete from Zuordnung_GruppeStudent where sNummer=\"" + sNummerToDelete + "\"");
            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // Belege aus Datenbank ziehen
        private void UpdateBelege(object sender)
        {
            // Datasource für belegListBox
            _belege = new List<Beleg>();
            foreach (var array in _database.ExecuteQuery("select * from Beleg"))
            {
                var beleg = new Beleg(array[0], array[1], Convert.ToDateTime(array[2]), Convert.ToDateTime(array[3]), Convert.ToInt32(array[4]), Convert.ToInt32(array[5]), array[6]);
                _belege.Add(beleg);
            }

            gruppeAnlegenButton.Enabled = !(_belege.Count == 0);
            gruppeLoeschenButton.Enabled = !(_belege.Count == 0);
            belegLoeschenButton.Enabled = !(_belege.Count == 0);

            // Listbox mit allen Belegen
            belegListBox.DataSource = _belege;
            belegListBox.DisplayMember = "Belegkennung";
            belegListBox_SelectedIndexChanged(null,null);
        }

         
        // neuer Beleg ausgewählt -> Gruppen und Studenten anpassen
        private void belegListBox_SelectedIndexChanged(object sender, EventArgs e){
            // belegListBox leer?!
            if (belegListBox.SelectedItem == null)
            {
                gruppenListBox.DataSource = null;
                gruppenListBox_SelectedIndexChanged(null,null);
                return;
            }
            mitgliederDataGridView.Rows.Clear();
            var selected = (Beleg)belegListBox.SelectedItem;
            UpdateRollen(selected);

            // Datasource für gruppenListBox
            _gruppen = new List<Gruppe>();
            foreach (var info in _database.ExecuteQuery("select * from Gruppe where Gruppenkennung in (select Gruppenkennung from Zuordnung_GruppeBeleg where Belegkennung=\"" + selected.BelegKennung + "\")"))
            {
                var temp = new Gruppe(info[0], Convert.ToInt32(info[1]), info[2]) {Belegkennung = selected.BelegKennung};
                _gruppen.Add(temp);
            }
            gruppenListBox.DataSource = null;
            gruppenListBox.DataSource = _gruppen;
            gruppenListBox.DisplayMember = "gruppenKennung";
            gruppeLoeschenButton.Enabled = !(_gruppen.Count == 0);
        }

        // Rollen aus Datenkbank ziehen
        private void UpdateRollen(Beleg beleg)
        {
            _rollen = new List<string>();
            var db = new Database();
            var output = db.ExecuteQuery("Select Rolle from Rolle where Rolle in (select Rolle from Zuordnung_BelegRolle where Belegkennung=\"" + beleg.BelegKennung + "\")");
            foreach (var info in output)
            {
                _rollen.Add(info[0]);
            }
            _rollen.Add("na");
        }

        // Beleg bearbeiten-Dialog öffnene
        private void belegListBox_DoubleClicked(object sender, EventArgs e)
        {
            var belegB = new BelegBearbeiten(((Beleg) belegListBox.SelectedItem).BelegKennung, false)
            {Saved = UpdateBelege};
            belegB.Show();
        }

        // Gruppe bearbeiten-Dialog öffnen
        private void gruppenListBox_DoubleClicked(object sender, EventArgs e)
        {
            var gruppeB = new gruppeBearbeiten((Gruppe)gruppenListBox.SelectedItem, false);
            gruppeB.Show();
        }

        // neue Gruppe ausgewählt
        private void gruppenListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // gruppenListBox leer?!
            if (gruppenListBox.SelectedItem == null)
            {
                mitgliederDataGridView.Rows.Clear();
                return;
            }
            Gruppe selected = (Gruppe)gruppenListBox.SelectedItem;

            // Studenten neu aus der Datenbank laden
            selected.Studenten = null;
            foreach (var info2 in _database.ExecuteQuery("select * from Student where sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung=\"" + selected.GruppenKennung + "\")"))
            {
                selected.addStudent(new Student(info2[2], info2[1], info2[0], info2[3], info2[4]));
            }
            int studentenCount = 0;
            if (selected.Studenten != null) studentenCount = selected.Studenten.Count;

            // Studenten DataGridView mit Platzhaltern auffüllen (Anzahl der angegebenen maximalen Anzahl (-> nach Beleg der Gruppe)
            if (studentenCount < ((Beleg)belegListBox.SelectedItem).MaxMitglieder)
            {
                for (int i = 0; i < ((Beleg)belegListBox.SelectedItem).MaxMitglieder - studentenCount; i++)
                    selected.addStudent(new Student("na", "na", "na", "na", "na"));
            }

            // Studenten dieser Gruppe im DataGridView darstellen
            mitgliederDataGridView.Rows.Clear();
            ((DataGridViewComboBoxColumn) mitgliederDataGridView.Columns[4]).DataSource = _rollen;
            mitgliederDataGridView.Columns[4].MinimumWidth = 150;
            mitgliederDataGridView.Columns[3].MinimumWidth = 250;
            if (selected.Studenten != null)
                foreach (var info in selected.Studenten)
                {
                    var number = mitgliederDataGridView.Rows.Add();
                    mitgliederDataGridView.Rows[number].Cells[0].Value = info.Name;
                    mitgliederDataGridView.Rows[number].Cells[1].Value = info.Vorname;
                    mitgliederDataGridView.Rows[number].Cells[2].Value = info.SNummer;
                    if (info.SNummer != "na") mitgliederDataGridView.Rows[number].Cells[2].ReadOnly = true;
                    mitgliederDataGridView.Rows[number].Cells[3].Value = info.Mail;
                    mitgliederDataGridView.Rows[number].Cells[4].Value = info.Rolle;

                    // Noch nicht ausgefüllte Mitglieder unter Mindestanzahl nach Beleg werden gelb markiert -> müssen noch vor Ende ausgefüllt werden
                    if (info.SNummer == "na" && number < ((Beleg)belegListBox.SelectedItem).MinMitglieder)
                        mitgliederDataGridView.Rows[number].DefaultCellStyle.BackColor = Color.Yellow;
                }
        }

        // Da MainForm nur präsentiert werden kann, muss ClosingEvent überschrieben werden, damit Prozess und nicht nur Fenster geschlossen wird
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        // Neuer Beleg soll hinzugefügt werden
        private void belegAnlegenButton_Click(object sender, EventArgs e)
        {
            // belegBearbeiten-Dialog mit isNeuerBeleg-Bool als true
            // Delegate zum refreshen nach hinzufügen setzen.
            BelegBearbeiten dest = new BelegBearbeiten("na", true)
            {
                Saved = UpdateBelege
            };
            dest.Show();
        }

        // neue Gruppe soll hinzugefügt werden
        private void gruppeAnlegenButton_Click(object sender, EventArgs e)
        {
            // Platzhalter-Gruppe für Anlegen-Dialog
            Gruppe temp = new Gruppe("na", 0, "na");
            temp.Belegkennung = ((Beleg) belegListBox.SelectedItem).BelegKennung;

            // Prüfen ob es noch freie Casekennungen gibt für diesen Beleg
            if (getFreieCases(temp) == null)
            {
                MessageBox.Show("Für diesen Beleg können keine weiteren Gruppen hinzugefügt werden.");
                return;
            }

            // Gruppe bearbeiten-Dialog mit Delegate erstellen und anzeigen lassen
            gruppeBearbeiten dest = new gruppeBearbeiten(temp, true);
            dest.SavedG = belegListBox_SelectedIndexChanged;
            dest.Show();
        }

        // Übergibt eine Liste aller noch freien Cases
        List<string> getFreieCases(Gruppe gruppe)
        {
            Database database = new Database();
            List<string[]> ergDB = database.ExecuteQuery(
                "select Casekennung from Zuordnung_BelegCases where Casekennung not in(select Gruppenkennung from Zuordnung_GruppeBeleg where Belegkennung=\"" +
                gruppe.Belegkennung + "\") and Belegkennung=\"" + gruppe.Belegkennung + "\"");
            if (ergDB.Count == 0) return null;
            List<string> erg = new List<string>();
            foreach (string[] strings in ergDB)
            {
                erg.Add(strings[0]);
            }
            return erg;
        }

        // Studenten-DataGridView in bearbeitbaren Modus setzen
        private void dataGridViewFreigebenButton_Click(object sender, EventArgs e)
        {
            _tempStudent = (List<Student>)mitgliederDataGridView.DataSource;
            mitgliederDataGridView.DataSource = null;
            mitgliederDataGridView.DataSource = _tempStudent;

            mitgliederDataGridView.Enabled = true;
            saveDataGridViewButton.Enabled = true;
            cancelDataGridViewButton.Enabled = true;
            dataGridViewFreigebenButton.Enabled = false;
        }

        // Änderungen in StudentenDataGridView speichern
        private void saveDataGridViewButton_Click(object sender, EventArgs e)
        {
            if (SaveMitglieder())
            {
                mitgliederDataGridView.Enabled = false;
                saveDataGridViewButton.Enabled = false;
                cancelDataGridViewButton.Enabled = false;
                dataGridViewFreigebenButton.Enabled = true;

                gruppenListBox_SelectedIndexChanged(this, null);
            }
        }

        // Studenten einer Gruppe speichern
        private bool SaveMitglieder()
        {
            // aktuelle Gruppe auslesen
            var gruppe = (Gruppe)gruppenListBox.SelectedItem;

            // For-Schleife über alle Studenten dieser Gruppe (im DataGridView)
            for (var i = 0; i < mitgliederDataGridView.Rows.Count; i++)
            {
                // Daten rausziehen
                var name = (String)mitgliederDataGridView.Rows[i].Cells[0].Value;
                var vorname = (String)mitgliederDataGridView.Rows[i].Cells[1].Value;
                var sNummer = (String)mitgliederDataGridView.Rows[i].Cells[2].Value;
                var mail = (String) mitgliederDataGridView.Rows[i].Cells[3].Value;

                // Wenn eine Mail-Adresse falsch ist und dieser Student kein Platzhalter ist
                if (sNummer != "na" && mail != "na" && !checkMail(mail))
                {
                    MessageBox.Show(mail + " ist keine gültige Mail-Adresse. Die Daten wurden nicht gespeichert.",
                        "Fehler");
                    return false;
                }

                // Wenn eine S-Nummer falsch ist und der Student kein Platzhalter ist
                if (!mitgliederDataGridView.Rows[i].Cells[2].ReadOnly && sNummer != "na" && !checkSNummer(sNummer))
                {
                    MessageBox.Show(
                        sNummer +
                        " ist keine gültige S-Nummer oder der betreffende Student steht schon in der Datenbank. Die Daten wurden nicht gespeichert.",
                        "Fehler");
                    return false;
                }

                // Vorname zu lang oder leer (Länge ist als Festwert in der DB)
                if (sNummer != "na" && (string.IsNullOrEmpty(vorname) || vorname.Length > 15))
                {
                    MessageBox.Show("Der Vorname " + vorname +
                                    " ist länger als 15 Zeichen oder leer. Die Daten wurden nicht gespeichert.");
                    return false;
                }

                //Nachname zu lang oder leer (Länge ist als Festwert in der DB)
                if (sNummer != "na" && ( string.IsNullOrEmpty(name) || name.Length > 15))
                {
                    MessageBox.Show("Der Nachname " + name +
                                    " ist länger als 15 Zeichen oder leer. Die Daten wurden nicht gespeichert.");
                    return false;
                }
            }

            // Nach Überprüfung kann gespeichert werden, For-Schleife über alle Studenten dieser Gruppe
            for (var i = 0; i < mitgliederDataGridView.Rows.Count; i++)
            {
                var name = (String)mitgliederDataGridView.Rows[i].Cells[0].Value;
                var vorname = (String)mitgliederDataGridView.Rows[i].Cells[1].Value;
                var sNummer = (String)mitgliederDataGridView.Rows[i].Cells[2].Value;
                var mail = (String)mitgliederDataGridView.Rows[i].Cells[3].Value;
                var rolle = (String)mitgliederDataGridView.Rows[i].Cells[4].FormattedValue.ToString();

                if (sNummer != "na" && !string.IsNullOrEmpty(sNummer))
                {
                    // Überprüfen, ob es sich um einen neuen Studenten (insert) oder einen geänderten Studenten (update) handelt
                    if (mitgliederDataGridView.Rows[i].Cells[2].ReadOnly) updateStudent(new Student(name, vorname, sNummer, mail, rolle));
                    else insertStudent(new Student(name, vorname, sNummer, mail, rolle), gruppe);
                }
            }
            return true;
        }

        // Mail-Adresse anhand von regular Expression überprüfen
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

            // Wenn S-Nummer schon vorhanden -> Fehlermeldung
            List<string[]> output = db.ExecuteQuery("select * from Student");
            foreach (string[] info in output)
            {
                if (info[0] == sNummer) return false;
            }

            return true;
        }

        // Vorhandenen Student in der Datenbank aktualisieren
        private void updateStudent(Student student)
        {
            var db = new Database();
            var query = "update Student set Nachname=\"" + student.Name + "\", Vorname=\"" + student.Vorname + "\", Mail=\"" + student.Mail + "\", Rolle=\"" + student.Rolle + "\" where sNummer=\"" + student.SNummer + "\"";
            db.ExecuteQuery(query);
        }

        // Neuen Student in die DB einfügen
        private void insertStudent(Student student, Gruppe gruppe)
        {
            var db = new Database();
            var query = "insert into Student values(\"" + student.SNummer + "\",\"" + student.Vorname + "\",\"" + student.Name + "\",\"" + student.Mail + "\",\"" + student.Rolle + "\")";
            db.ExecuteQuery(query);
            query = "insert into Zuordnung_GruppeStudent values(\"" + gruppe.GruppenKennung + "\",\"" + student.SNummer + "\")";
            db.ExecuteQuery(query);
        }

        // Änderungen in der Studenten-DataGridView verwerfen
        private void cancelDataGridViewButton_Click(object sender, EventArgs e)
        {
            mitgliederDataGridView.Enabled = false;
            saveDataGridViewButton.Enabled = false;
            cancelDataGridViewButton.Enabled = false;
            dataGridViewFreigebenButton.Enabled = true;

            // Studenten einfach neu aus der DB laden
            gruppenListBox_SelectedIndexChanged(this, null);
        }

        private void themenVerwaltenButton_Click(object sender, EventArgs e)
        {
            var themenV =  new ThemenVerwalten();
            themenV.Show();
        }

        // Rollen verwalten
        private void rolleTextBox_Click(object sender, EventArgs e)
        {
            var rolleV = new RolleVerwalten();
            rolleV.Show();
        }

        private void studentenDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void buttonArchivieren_Click(object sender, EventArgs e)
        {
            var archivierung = new PdfArchivierung(_database)
            {
                SavedG = UpdateBelege
            };
            archivierung.Show();
        }

        // Gruppen kontaktieren geklickt
        private void button1_Click(object sender, EventArgs e)
        {
            kontaktForm kForm = new kontaktForm();
            kForm.Show();
        }

        // ausgewählten Beleg löschen 
        private void belegLoeschenButton_Click(object sender, EventArgs e)
        {
            // aktuellen Beleg ziehen
            Beleg temp = (Beleg)belegListBox.SelectedItem;
            if (temp != null)
            {
                // Erstes Nachfragen
                DialogResult dialogResult = MessageBox.Show("Wollen Sie den Beleg " + temp.BelegKennung + " wirklich löschen?", "Achtung", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Database db = new Database();
                    if (db.ExecuteQuery("select * from Zuordnung_GruppeBeleg where Belegkennung=\"" + temp.BelegKennung + "\"").Count != 0)
                    {
                        // Wenn dieser Beleg noch aktive Gruppen hat -> zweite Meldung zum Nachfragen
                        DialogResult result = MessageBox.Show("Dieser Beleg hat noch aktive Gruppen, sollen diese ebenfalls gelöscht werden? (Das betrifft auch die Mitglieder der Gruppen)", "Achtung", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            // Alle Belege + Gruppen + Mitglieder löschen
                            List<string[]> gruppenliste =
                                db.ExecuteQuery(
                                    "select Gruppenkennung from Zuordnung_GruppeBeleg where Belegkennung=\"" +
                                    temp.BelegKennung + "\"");
                            for (int i = 0; i < gruppenliste.Count; i++)
                            {
                                db.ExecuteQuery(
                                "delete from Student where sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung=\"" +
                                gruppenliste[i][0] + "\")");
                                db.ExecuteQuery("delete from Gruppe where Gruppenkennung=\"" + gruppenliste[i][0] + "\"");
                                db.ExecuteQuery("delete from Zuordnung_GruppeStudent where Gruppenkennung=\"" + gruppenliste[i][0] + "\"");
                                db.ExecuteQuery("delete from Zuordnung_GruppeBeleg where Gruppenkennung=\"" + gruppenliste[i][0] + "\"");
                            }
                        }
                        else 
                            return;
                    }

                    // Beleg ohne Gruppen löschen
                    db.ExecuteQuery("delete from Beleg where Belegkennung=\"" + temp.BelegKennung + "\"");
                    db.ExecuteQuery("delete from Zuordnung_BelegCases where Belegkennung=\"" + temp.BelegKennung + "\"");
                    db.ExecuteQuery("delete from Zuordnung_BelegThema where Belegkennung=\"" + temp.BelegKennung + "\"");
                    db.ExecuteQuery("delete from Zuordnung_BelegRolle where Belegkennung=\"" + temp.BelegKennung + "\"");
                    db.ExecuteQuery("delete from Zuordnung_GruppeBeleg where Belegkennung=\"" + temp.BelegKennung + "\"");
                    UpdateBelege(null);
                    if (_belege.Count == 0)
                    {
                        gruppenListBox.DataSource = null;
                        mitgliederDataGridView.Rows.Clear();
                    }
                    else belegListBox.SelectedIndex = 0;
                    
                }
            }
        }

        // Gruppe löschen
        private void gruppeLoeschenButton_Click(object sender, EventArgs e)
        {
            Gruppe temp = (Gruppe) gruppenListBox.SelectedItem;
            if (temp != null)
            {
                // Erstes Nachfragen
                DialogResult dialogResult = MessageBox.Show("Wollen Sie die Gruppe " + temp.GruppenKennung + " wirklich löschen?", "Achtung", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Database db = new Database();
                    if (db.ExecuteQuery("select * from Zuordnung_GruppeStudent where Gruppenkennung=\"" + temp.GruppenKennung + "\"").Count != 0)
                    {
                        // Wenn Gruppe noch aktive Studenten -> Zweites nachfragen zum rekursiven Löschen
                        DialogResult result = MessageBox.Show("Dieser Beleg hat noch aktive Studenten, sollen diese auch gelöscht werden?", "Achtung", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            // Alle Studenten rekursiv löschen
                            db.ExecuteQuery(
                                "delete from Student where sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung=\"" +
                                temp.GruppenKennung + "\")");
                        }
                        else 
                            return;
                    }

                    // Gruppe ohne Studenten löschen
                    db.ExecuteQuery("delete from Gruppe where Gruppenkennung=\"" + temp.GruppenKennung + "\"");
                    db.ExecuteQuery("delete from Zuordnung_GruppeStudent where Gruppenkennung=\"" + temp.GruppenKennung + "\"");
                    db.ExecuteQuery("delete from Zuordnung_GruppeBeleg where Gruppenkennung=\"" + temp.GruppenKennung + "\"");

                    belegListBox_SelectedIndexChanged(this, null);
                }

                
            }
        }


        
    }
}
