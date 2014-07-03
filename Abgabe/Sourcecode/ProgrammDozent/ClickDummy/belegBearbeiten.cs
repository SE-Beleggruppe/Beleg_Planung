using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Typen;
using DB_Services;

namespace DozentBelegverwaltungUI
{
    public partial class BelegBearbeiten : Form
    {
        public delegate void IsSavedHandler(object sender);
        public IsSavedHandler Saved;


        //überprüft ob bereits vorhandener Beleg bearbeitet (false) 
        //oder neuer Beleg angelegt wird (true)
        private bool isNeuerBeleg;  

        public List<Thema> AlleThemen = new List<Thema>();
        public List<Thema> VerfThemen = new List<Thema>();
        public List<Rolle> AlleRollen = new List<Rolle>();
        public List<Rolle> VerfRollen = new List<Rolle>();
        public List<string> AlleCases = new List<string>();
        public List<string> VerfCases = new List<string>();


        public Beleg Beleg { get; set; }

        Database _database = new Database();

        public BelegBearbeiten(string belegKennung, bool neu)
        {
            InitializeComponent();
            this.Text = "Beleg";
            this.StartPosition = FormStartPosition.CenterScreen;

            isNeuerBeleg = neu;

            //falls kein neuer Beleg, lade ihn aus Datenbank
            if (!isNeuerBeleg) this.Beleg = GetBelegFromKennung(belegKennung);
            
            //neuer Beleg mit Default-Daten wird angelegt (Kennung, Semester, Startdatum, Enddatum, minAnz, maxAnz, Passwort)
            else
            {
                this.Beleg = new Beleg("na", "na", DateTime.Today, DateTime.Today.AddDays(1), 1, 1, "passwort");
                //Belegkennung darf eingegeben werden (beim bearbeiten nicht)
                kennungTextBox.Enabled = true;
            }

            kennungTextBox.Text = Beleg.BelegKennung;
            passwortTextBox.Text = Beleg.Passwort;
            semesterTextBox.Text = Beleg.Semester;
            semesterTextBox.ReadOnly = true;
            startDateTimePicker.Value = Beleg.StartDatum;
            endDateTimePicker.Value = Beleg.EndDatum;
            minGR.Value = Beleg.MinMitglieder;
            maxGR.Value = Beleg.MaxMitglieder;

            //Alle Themen füllen
            foreach (var array in _database.ExecuteQuery("select * from Thema where Themennummer not in (select Themennummer from Zuordnung_BelegThema where Belegkennung = \""+Beleg.BelegKennung+"\")"))
            {
                var thema = new Thema(Convert.ToInt32(array[0]),array[1]);
                AlleThemen.Add(thema);
            }

            //Themen mittels Lambda-Expression alphabetisch sortieren
            AlleThemen.Sort((t1, t2) => t1.AufgabenName.CompareTo(t2.AufgabenName));
            allThemen.DataSource = AlleThemen;
            allThemen.DisplayMember = "aufgabenName";

            //Alle Rollen füllen
            foreach (var array in _database.ExecuteQuery("select * from Rolle where Rolle not in(select Rolle from Zuordnung_BelegRolle where Belegkennung = \"" + Beleg.BelegKennung + "\")"))
            {
                var rolle = new Rolle(array[0]);
                if(rolle.rolle != "Leitung") AlleRollen.Add(rolle);
            }

            //Rollen mittels Lambda-Expression alphabetisch sortieren
            AlleRollen.Sort((t1, t2) => t1.rolle.CompareTo(t2.rolle));
            allRollen.DataSource = AlleRollen;
            allRollen.DisplayMember = "rolle";
            if (isNeuerBeleg)
            {
                VerfRollen.Add(new Rolle("Leitung"));
                verRollen.DataSource = VerfRollen;
                verRollen.DisplayMember = "rolle";
            }

            //Alle Cases füllen
            foreach (var array in _database.ExecuteQuery("select Cases.Casekennung from Cases where Cases.Casekennung not in (select Casekennung from Zuordnung_BelegCases)"))
            {
                var oneCase = array[0];
                AlleCases.Add(oneCase);
            }

            //Cases aufsteigend sortieren
            AlleCases.Sort();
            allCases.DataSource = AlleCases;

            if (!isNeuerBeleg)
            {
                //Verfügbare Themen füllen
                foreach (
                    var array in
                        _database.ExecuteQuery(
                            "select * from Thema where Themennummer in (select Themennummer from Zuordnung_BelegThema where Belegkennung = \"" +
                            Beleg.BelegKennung + "\")"))
                {
                    var thema = new Thema(Convert.ToInt32(array[0]), array[1]);
                    VerfThemen.Add(thema);
                }

                VerfThemen.Sort((t1, t2) => t1.AufgabenName.CompareTo(t2.AufgabenName));
                verThemen.DataSource = VerfThemen;
                verThemen.DisplayMember = "aufgabenName";

                //Verfügbare Rollen füllen
                foreach (
                    var array in
                        _database.ExecuteQuery(
                            "select * from Rolle where Rolle in(select Rolle from Zuordnung_BelegRolle where Belegkennung = \"" +
                            Beleg.BelegKennung + "\")"))
                {
                    var rolle = new Rolle(array[0]);
                    VerfRollen.Add(rolle);
                }

                VerfRollen.Sort((t1, t2) => t1.rolle.CompareTo(t2.rolle));
                verRollen.DataSource = VerfRollen;
                verRollen.DisplayMember = "rolle";



                //Verfügbare Cases füllen
                foreach (
                    var array in
                        _database.ExecuteQuery(
                            "select Cases.Casekennung from Cases where Cases.Casekennung in (select Casekennung from Zuordnung_BelegCases where Belegkennung = \"" +
                            Beleg.BelegKennung + "\")"))
                {
                    var oneCase = array[0];
                    VerfCases.Add(oneCase);
                }
                VerfCases.Sort();
                verCases.DataSource = VerfCases;
            }

            //Buttons ausgrauen falls alle Themen, Rollen oder Cases bereits vergeben sind
            addButtonThema.Enabled = allThemen.Items.Count != 0;
            remButtonThema.Enabled = verThemen.Items.Count != 0;

            addButtonRolle.Enabled = allRollen.Items.Count != 0;
            remButtonRolle.Enabled = verRollen.Items.Count != 0;

            addButtonCase.Enabled = allCases.Items.Count != 0;
            remButtonCase.Enabled = verCases.Items.Count != 0;
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void speichernbutton_Click(object sender, EventArgs e)
        {
            if (minGR.Text == "") minGR.Value = 1;
            if (maxGR.Text == "") minGR.Value = 1;
            
            if(String.IsNullOrEmpty(passwortTextBox.Text))
            {
                MessageBox.Show("Bitte geben Sie ein Passwort ein.");
                return;
            }

            if(passwortTextBox.Text.Length >= 10)
            {
                MessageBox.Show("Das Passwort darf maximal 10 Zeichen lang sein.");
                return;
            }

            //falls neuer Beleg
            if (isNeuerBeleg)
            {
                if(!checkTextFields()) return;

                Database database = new Database();

                //Belegkennung bereits vergeben?
                List<string[]> ergDB = database.ExecuteQuery(
                    "select * from Beleg where Belegkennung =\"" +
                    kennungTextBox.Text + "\"");

                //falls neue Belegkennung
                if (ergDB.Count == 0)
                {
                    //Datensätze in die Datenbank einfügen
                    InsertBeleg();
                    if (Saved != null) Saved(this);
                    Close();
                }

                else
                {
                    MessageBox.Show("Ungültige oder bereits vergebene Belegkennung!");
                }
                    
            }

            //falls bereits vorhandener Beleg bearbeitet wird
            else
            {
                UpdateBeleg();
                if (Saved != null) Saved(this);
                Close();
            }

        }

        /// <summary>
        /// //Pflichtfelder auf leere Eingaben oder Fehleingaben prüfen
        /// </summary>
        /// <returns>true, falls Pflichtfelder alle korrekt ausgefüllt sind</returns>
        bool checkTextFields()
        {
            if (kennungTextBox.Text == "")
            {
               MessageBox.Show("Bitte geben Sie eine Belegkennung ein.");
               return false;
            }
            if (kennungTextBox.Text.Length > 20)
            {
                MessageBox.Show("Die Belegkennung darf maximal 20 Zeichen lang sein.");
                return false;
            }
            return true;
        }

        void UpdateBeleg()
        {
            //Beleg updaten
            var startdatum = startDateTimePicker.Value.Year + "-" + startDateTimePicker.Value.Month + "-" + startDateTimePicker.Value.Day;
            var enddatum = endDateTimePicker.Value.Year + "-" + endDateTimePicker.Value.Month + "-" + endDateTimePicker.Value.Day;
            var query = "Update Beleg Set Semester = \"" + semesterTextBox.Text + "\", StartDatum = \"" + startdatum + "\",EndDatum = \"" + enddatum + "\",MinAnzMitglieder = " + minGR.Value + ",MaxAnzMitglieder = " + maxGR.Value + ",Passwort = \"" + passwortTextBox.Text + "\" where Belegkennung = \"" + Beleg.BelegKennung + "\"";
            

            if (_database != null)
            {
                _database.ExecuteQuery(query);

                //Zuordnung_BelegThema updaten
                //Alle zugehörigen Datensätze löschen
                _database.ExecuteQuery("delete from Zuordnung_BelegThema where Belegkennung = \"" + Beleg.BelegKennung + "\"");
                //Inhalt von verfthemen inserten
                foreach (var thema in VerfThemen)
                {
                    _database.ExecuteQuery("insert into Zuordnung_BelegThema values(\"" + Beleg.BelegKennung + "\", " + thema.ThemenNummer + ")");
                }

                //Zuordnung_BelegRolle
                //Alle zugehörigen Datensätze löschen
                _database.ExecuteQuery("delete from Zuordnung_BelegRolle where Belegkennung = \"" + Beleg.BelegKennung + "\"");
                //Inhalt von verfrollen inserten
                foreach (var rolle in VerfRollen)
                {
                    _database.ExecuteQuery("insert into Zuordnung_BelegRolle values(\"" + Beleg.BelegKennung + "\", \"" + rolle.rolle + "\")");
                }

                //Zuordnung_BelegCase
                //Alle zugehörigen Datensätze löschen
                _database.ExecuteQuery("delete from Zuordnung_BelegCases where Belegkennung = \"" + Beleg.BelegKennung + "\"");
                //Inhalt von verfcases inserten
                foreach (var onecase in VerfCases)
                {
                    _database.ExecuteQuery("insert into Zuordnung_BelegCases values(\"" + Beleg.BelegKennung + "\", \"" + onecase + "\")");
                }
            }
        }

        void InsertBeleg()
        {
            //Beleg einfügen
            var startdatum = startDateTimePicker.Value.Year + "-" + startDateTimePicker.Value.Month + "-" + startDateTimePicker.Value.Day;
            var enddatum = endDateTimePicker.Value.Year + "-" + endDateTimePicker.Value.Month + "-" + endDateTimePicker.Value.Day;
            var query = "insert into Beleg values(\"" + kennungTextBox.Text + "\",\"" + semesterTextBox.Text + "\",\"" + startdatum + "\",\"" + enddatum + "\"," + minGR.Value + "," + maxGR.Value + ",\"" + passwortTextBox.Text + "\")";
            
            
            if (_database != null)
            {
                _database.ExecuteQuery(query);
                //Inhalt von verfthemen inserten
                foreach (var thema in VerfThemen)
                {
                    _database.ExecuteQuery("insert into Zuordnung_BelegThema values(\"" + kennungTextBox.Text + "\", " + thema.ThemenNummer + ")");
                }

                //Inhalt von verfrollen inserten
                foreach (var rolle in VerfRollen)
                {
                    _database.ExecuteQuery("insert into Zuordnung_BelegRolle values(\"" + kennungTextBox.Text + "\", \"" + rolle.rolle + "\")");
                }

                //Inhalt von verfcases inserten
                foreach (var onecase in VerfCases)
                {
                    _database.ExecuteQuery("insert into Zuordnung_BelegCases values(\"" + kennungTextBox.Text + "\", \"" + onecase + "\")");
                }
            }
        }

        /// <summary>
        /// verfügbares Thema dem zu bearbeitenden Beleg hinzufügen
        /// </summary>
        private void addButtonThema_Click(object sender, EventArgs e)
        {
            var thema = (Thema)allThemen.SelectedItem;
            AlleThemen.Remove(thema);
            allThemen.DataSource = null;
            allThemen.DataSource = AlleThemen;
            allThemen.DisplayMember = "aufgabenName";

            VerfThemen.Add(thema);
            VerfThemen.Sort((t1, t2) => t1.AufgabenName.CompareTo(t2.AufgabenName));
            verThemen.DataSource = null;
            verThemen.DataSource = VerfThemen;
            verThemen.DisplayMember = "aufgabenName";

            if (allThemen.Items.Count != 0)
            {
                allThemen.SelectedIndex = 0;
            }

            if (verThemen.Items.Count != 0)
            {
                verThemen.SelectedIndex = 0;
            }

            addButtonThema.Enabled = allThemen.Items.Count != 0;
            remButtonThema.Enabled = verThemen.Items.Count != 0;
        }

        /// <summary>
        /// dem Beleg zugeordnetes Thema wieder freigeben
        /// </summary>
        private void remButtonThema_Click(object sender, EventArgs e)
        {
            var thema = (Thema)verThemen.SelectedItem;

            if (_database.ExecuteQuery("select * from Gruppe where Themennummer = " + thema.ThemenNummer).Count != 0)
            {
                MessageBox.Show("Das Thema " + thema.AufgabenName + " ist noch einer Grupper zugeordnet und kann nicht entfernt werden.");
                return;
            }

            VerfThemen.Remove(thema);
            verThemen.DataSource = null;
            verThemen.DataSource = VerfThemen;
            verThemen.DisplayMember = "aufgabenName";

            AlleThemen.Add(thema);
            AlleThemen.Sort((t1, t2) => t1.AufgabenName.CompareTo(t2.AufgabenName));
            allThemen.DataSource = null;
            allThemen.DataSource = AlleThemen;
            allThemen.DisplayMember = "aufgabenName";

            if (allThemen.Items.Count != 0)
            {
                allThemen.SelectedIndex = 0;
            }

            if (verThemen.Items.Count != 0)
            {
                verThemen.SelectedIndex = 0;
            }

            addButtonThema.Enabled = allThemen.Items.Count != 0;
            remButtonThema.Enabled = verThemen.Items.Count != 0;
        }

        /// <summary>
        /// verfügbare Rolle dem zu bearbeitenden Beleg hinzufügen
        /// </summary>
        private void addButtonRolle_Click(object sender, EventArgs e)
        {
            var rolle = (Rolle)allRollen.SelectedItem;
            AlleRollen.Remove(rolle);
            allRollen.DataSource = null;
            allRollen.DataSource = AlleRollen;
            allRollen.DisplayMember = "rolle";

            VerfRollen.Add(rolle);
            VerfRollen.Sort((t1, t2) => t1.rolle.CompareTo(t2.rolle));
            verRollen.DataSource = null;
            verRollen.DataSource = VerfRollen;
            verRollen.DisplayMember = "rolle";

            addButtonRolle.Enabled = allRollen.Items.Count != 0;
            remButtonRolle.Enabled = verRollen.Items.Count != 0;

            if (allRollen.Items.Count != 0)
            {
                allRollen.SelectedIndex = 0;
            }

            if (verRollen.Items.Count != 0)
            {
                verRollen.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// dem Beleg zugeordnete Rolle wieder freigeben
        /// </summary>
        private void remButtonRolle_Click(object sender, EventArgs e)
        {
            var rolle = (Rolle)verRollen.SelectedItem;

            if (rolle.rolle == "Leitung") return;

            //Falls Rolle noch bei einem Beleg zugeordnet ist
            if (
                _database.ExecuteQuery(
                    "select * from Rolle where Rolle in (select Rolle from Student where sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung in (select Gruppenkennung from Zuordnung_GruppeBeleg where Belegkennung = \"" + Beleg.BelegKennung + "\"))) and Rolle = \"" + rolle.rolle + "\"").Count != 0)
            {
                MessageBox.Show("Die Rolle " + rolle.rolle +
                                " ist noch in Verwendung und kann nicht entfernt werden.");
                return;
            }


            VerfRollen.Remove(rolle);
            verRollen.DataSource = null;
            verRollen.DataSource = VerfRollen;
            verRollen.DisplayMember = "rolle";

            AlleRollen.Add(rolle);
            AlleRollen.Sort((t1, t2) => t1.rolle.CompareTo(t2.rolle));
            allRollen.DataSource = null;
            allRollen.DataSource = AlleRollen;
            allRollen.DisplayMember = "rolle";
            
            if (allRollen.Items.Count != 0)
            {
               allRollen.SelectedIndex = 0; 
            }

            if (verRollen.Items.Count != 0)
            {
                verRollen.SelectedIndex = 0;
            }

            addButtonRolle.Enabled = allRollen.Items.Count != 0;
            remButtonRolle.Enabled = verRollen.Items.Count != 0;
        }


        /// <summary>
        /// verfügbare Case-Gruppe dem zu bearbeitenden Beleg hinzufügen
        /// </summary>
        private void addButtonCase_Click(object sender, EventArgs e)
        {
            var onecase = (string)allCases.SelectedItem;
            AlleCases.Remove(onecase);
            allCases.DataSource = null;
            allCases.DataSource = AlleCases;

            VerfCases.Add(onecase);
            VerfCases.Sort();
            verCases.DataSource = null;
            verCases.DataSource = VerfCases;

            if (allCases.Items.Count != 0)
            {
                allCases.SelectedIndex = 0;
            }

            if (verCases.Items.Count != 0)
            {
                verCases.SelectedIndex = 0;
            }

            addButtonCase.Enabled = allCases.Items.Count != 0;
            remButtonCase.Enabled = verCases.Items.Count != 0;
        }

        /// <summary>
        /// dem Beleg zugeordnete Case-Gruppe wieder freigeben
        /// </summary>
        private void remButtonCase_Click(object sender, EventArgs e)
        {

            if (_database.ExecuteQuery("select * from Gruppe where Gruppenkennung = \"" + verCases.SelectedItem + "\"").Count != 0)
            {
                MessageBox.Show(verCases.SelectedItem + " ist noch Gruppe zugeordnet!");
                return;
            }

            var onecase = (string)verCases.SelectedItem;
            VerfCases.Remove(onecase);
            verCases.DataSource = null;
            verCases.DataSource = VerfCases;

            AlleCases.Add(onecase);
            AlleCases.Sort();
            allCases.DataSource = null;
            allCases.DataSource = AlleCases;

            if (allCases.Items.Count != 0)
            {
                allCases.SelectedIndex = 0;
            }

            if (verCases.Items.Count != 0)
            {
                verCases.SelectedIndex = 0;
            }

            addButtonCase.Enabled = allCases.Items.Count != 0;
            remButtonCase.Enabled = verCases.Items.Count != 0;
        }


        /// <summary>
        /// sucht Beleg aus Datenbank
        /// </summary>
        /// <param name="belegKennung">gesuchte Belegkennung</param>
        /// <returns>gesuchter Beleg</returns>
        private Beleg GetBelegFromKennung(string belegKennung)
        {
            var ergebnis = _database.ExecuteQuery("select * from Beleg where Belegkennung = \""+belegKennung+"\"");
            var array = ergebnis.First();
            return new Beleg(array[0], array[1], Convert.ToDateTime(array[2]), Convert.ToDateTime(array[3]), Convert.ToInt32(array[4]), Convert.ToInt32(array[5]), array[6]);

        }

        /// <summary>
        /// gewährleistet, dass Enddatum mindestens ein Tag später als Startdatum ist und erkennt ob Semester WS oder SS ist
        /// </summary>
        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (startDateTimePicker.Value >= endDateTimePicker.Value)
            {
                endDateTimePicker.Value = startDateTimePicker.Value.AddDays(1);
            }
            DateTime startTime = startDateTimePicker.Value;
            if (startTime.Month >= 3 && startTime.Month <= 9) semesterTextBox.Text = "SS " + (startTime.Year-2000);
            else semesterTextBox.Text = "WS " + (startTime.Year - 2000) + "/" + (startTime.Year - 2000 + 1);
        }

        /// <summary>
        /// gewährleistet, dass Enddatum mindestens ein Tag später als Startdatum ist
        /// </summary>
        private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (startDateTimePicker.Value >= endDateTimePicker.Value)
            {
                endDateTimePicker.Value = startDateTimePicker.Value.AddDays(1);
            }
        }

        /// <summary>
        /// gewährleistet dass minAnz immer kleiner ist als maxAnz
        /// </summary>
        private void minGR_ValueChanged(object sender, EventArgs e)
        {
            if (minGR.Text == "") minGR.Value = 1;
            if (minGR.Value > maxGR.Value)
            {
                maxGR.Value = minGR.Value;
            }
        }

        /// <summary>
        /// gewährleistet dass minAnz immer kleiner ist als maxAnz
        /// </summary>
        private void maxGR_ValueChanged(object sender, EventArgs e)
        {
            if (minGR.Text == "") minGR.Value = 1;
            if (maxGR.Text == "") minGR.Value = 1;
            if (minGR.Value > maxGR.Value)
            {
                maxGR.Value = minGR.Value;
            }
        }
    }
}
