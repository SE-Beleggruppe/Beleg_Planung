using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Typen;
using DB_Services;

namespace DozentBelegverwaltungUI
{
    public partial class kontaktForm : Form
    {

        // member
        List<Beleg> Belege = new List<Beleg>();
        List<Gruppe> Gruppen = new List<Gruppe>();
        List<Thema> Themen = new List<Thema>();
        List<Rolle> Rollen = new List<Rolle>();
        Database database = new Database();

        // member for filter funct
        List<Gruppe> filterGroups = new List<Gruppe>();
        List<Student> filterStudents = new List<Student>();

        Beleg selBeleg;
        Gruppe selGruppe;
        Thema selThema;
        Rolle selRolle;

        public kontaktForm()
        {
            InitializeComponent();
            this.Text = "Kontaktieren";
            this.StartPosition = FormStartPosition.CenterScreen;

            updateBelegData();

            updateThemenData();

            updateGroupData();

            updateRollenData();

            updateFilterBtn();
        }

        private void updateBelegData()
        {
            /*
             * fill Beleg combo box
             * first item is '*'
             */
            Beleg dummyBeleg = new Beleg("*", "", DateTime.Today, DateTime.Today, 0, 0, "");
            Belege.Add(dummyBeleg);

            //comboBoxBeleg.Items.Add()
            foreach (string[] array in database.ExecuteQuery("select * from Beleg"))
            {
                Beleg beleg = new Beleg(array[0], array[1], Convert.ToDateTime(array[2]), Convert.ToDateTime(array[3]), Convert.ToInt32(array[4]), Convert.ToInt32(array[5]), array[6]);
                Belege.Add(beleg);
            }
            comboBoxBeleg.DataSource = Belege;
            comboBoxBeleg.DisplayMember = "BelegKennung";
        }

        private void updateThemenData()
        {
            /*
            * fill 'Thema' combo box
            * first item is '*'
            */
            comboBoxBelegthema.DataSource = null;
            comboBoxBelegthema.Items.Clear();
            Themen.Clear();

            if (comboBoxBeleg.SelectedItem == null || comboBoxBeleg.SelectedIndex == 0)
            {
                comboBoxBelegthema.Enabled = false;
                return;
            }
            comboBoxBelegthema.Enabled = true;


            Thema dummyThema = new Thema(9999, "*");
            Themen.Add(dummyThema);

            Beleg selectedBeleg = (Beleg)comboBoxBeleg.SelectedItem;
            selBeleg = selectedBeleg;


            foreach (string[] array in database.ExecuteQuery("select * from Thema where Themennummer in (select Themennummer from Zuordnung_BelegThema where Belegkennung=\"" + selectedBeleg.BelegKennung + "\")"))
            {
                Thema thema = new Thema(Convert.ToInt32(array[0]), array[1]);
                Themen.Add(thema);
            }

            comboBoxBelegthema.DataSource = Themen;
            comboBoxBelegthema.DisplayMember = "aufgabenName";
            comboBoxBelegthema.SelectedIndex = 0;
        }

        private void updateGroupData()
        {
            /*
             * fill 'Gruppen' combo box
             * first item is '*'
             */
            comboBoxGruppe.DataSource = null;
            comboBoxGruppe.Items.Clear();
            Gruppen.Clear();

            if (comboBoxBelegthema.SelectedItem == null || comboBoxBelegthema.SelectedIndex == 0)
            {                
                comboBoxGruppe.Enabled = false;
                return;
            }
            comboBoxGruppe.Enabled = true;
            Beleg selected = (Beleg)comboBoxBeleg.SelectedItem;


            Gruppe dummyGruppe = new Gruppe("*", 919199, "");
            Gruppen.Add(dummyGruppe);
            foreach (string[] info in database.ExecuteQuery("select * from Gruppe where Themennummer= " 
                + selThema.ThemenNummer +" and Gruppenkennung in (select Gruppenkennung from Zuordnung_GruppeBeleg where Belegkennung=\"" + selected.BelegKennung + "\")"))
            {
                Gruppe temp = new Gruppe(info[0], Convert.ToInt32(info[1]), info[2]);
                temp.Belegkennung = selected.BelegKennung;
                Gruppen.Add(temp);
            }
       
            comboBoxGruppe.DataSource = Gruppen;
            comboBoxGruppe.DisplayMember = "gruppenKennung";
        }

        private void updateRollenData()
        {
            if ((comboBoxBeleg.SelectedItem == null || comboBoxBeleg.SelectedIndex == 0) ||
            (comboBoxBelegthema.SelectedItem == null || comboBoxBelegthema.SelectedIndex == 0))
            {
                comboBoxRolle.Enabled = false;
                return;
            }
            comboBoxRolle.Enabled = true;

            Rolle dummyRolle = new Rolle("*");
            Rollen.Add(dummyRolle);

           
                foreach (string[] array in database.ExecuteQuery("select * from Rolle"))
                {
                    Rolle rolle = new Rolle(array[0]);
                    Rollen.Add(rolle);
                }
           
            comboBoxRolle.DataSource = Rollen;
            comboBoxRolle.DisplayMember = "rolle";
        }

        

        private void updateFilterBtn() {
            if ((comboBoxBeleg.SelectedItem == null || comboBoxBeleg.SelectedIndex == 0) ||
                (comboBoxBelegthema.SelectedItem == null || comboBoxBelegthema.SelectedIndex == 0))
            {
                btnFilter.Enabled = false;
                return;
            }   
            
            /*
             * information we have: 
             *  - Beleg
             *  - Belegthema
             *  
             * information we __need__:
             *  - Gruppen[] which match Beleg and Belegthema
             *  - Rollen[] which match Beleg and Belegthema
             */

            // reset
            filterGroups.Clear();
            filterStudents.Clear();

            // lets query all groups...
            foreach (var groupData in database.ExecuteQuery("select * from Gruppe where Themennummer=" + selThema.ThemenNummer + " and Gruppenkennung in (select Gruppenkennung from Zuordnung_GruppeBeleg where Belegkennung=\"" + selBeleg.BelegKennung + "\")"))
            {
                Gruppe temp = new Gruppe(groupData[0], Convert.ToInt32(groupData[1]), groupData[2]);
                temp.Belegkennung = selBeleg.BelegKennung;
                filterGroups.Add(temp);
            }

            // selection state: 
            //  Beleg: x
            //  Belegthema: x
            //  Gruppe/Rolle: -
            if ((comboBoxGruppe.SelectedItem == null || comboBoxGruppe.SelectedIndex == 0) &&
               (comboBoxRolle.SelectedItem == null || comboBoxRolle.SelectedIndex == 0))
            {
                
                foreach (var group1 in filterGroups)
                {
                    string sqlQuery;
                    
                    sqlQuery = "select * from Student where sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung=\"" + group1.GruppenKennung + "\")";

                    foreach (var info2 in database.ExecuteQuery(sqlQuery))
                    {
                        Student tmpStud = new Student(info2[2], info2[1], info2[0], info2[3], info2[4]);
                        filterStudents.Add(tmpStud);
                    }
                }

            }

            // selection state: 
            //  Beleg: x
            //  Belegthema: x
            //  Gruppe: -
            //  Rolle: x
            else if (comboBoxRolle.SelectedItem != null && (comboBoxGruppe.SelectedItem == null || comboBoxGruppe.SelectedIndex == 0))
            {
                
                foreach (var group in filterGroups)
                {
                    string sqlQuery;
                    if (!selRolle.rolle.Equals("*"))
                        sqlQuery = "select * from Student where Rolle=\"" + selRolle.rolle + "\" and sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung=\"" + group.GruppenKennung + "\")";

                    else
                        sqlQuery = "select * from Student where sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung=\"" + group.GruppenKennung + "\")";

                    foreach (var info2 in database.ExecuteQuery(sqlQuery))
                    {
                        Student tmpStud = new Student(info2[2], info2[1], info2[0], info2[3], info2[4]);
                        filterStudents.Add(tmpStud);
                    }
                }
            }

            // selection state: 
            //  Beleg: x
            //  Belegthema: x
            //  Gruppe: x
            //  Rolle: -
            else if (comboBoxRolle.SelectedItem == null && comboBoxGruppe.SelectedItem != null)
            {

                foreach (var group in filterGroups)
                {
                    string sqlQuery;
                    if (!selGruppe.GruppenKennung.Equals("*"))
                        sqlQuery = "select * from Student where sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung=\"" + selGruppe.GruppenKennung + "\")";

                    else
                        sqlQuery = "select * from Student where sNummer in (select sNummer from Zuordnung_GruppeStudent)";

                    foreach (var info2 in database.ExecuteQuery(sqlQuery))
                    {
                        Student tmpStud = new Student(info2[2], info2[1], info2[0], info2[3], info2[4]);
                        filterStudents.Add(tmpStud);
                    }
                }
            }
            // selection state: 
            //  Beleg: x
            //  Belegthema: x
            //  Gruppe: x
            //  Rolle: x
            else
            {

                string sqlString = "";
                if (selRolle.rolle.Equals("*"))
                    sqlString = "select * from Student where sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung=\"" + selGruppe.GruppenKennung + "\")";
                else
                    sqlString = "select * from Student where Rolle=\"" + selRolle.rolle +"\" and sNummer in (select sNummer from Zuordnung_GruppeStudent where Gruppenkennung=\"" + selGruppe.GruppenKennung + "\")";

                foreach (var info2 in database.ExecuteQuery(sqlString))
                {
                    Student tmpStud = new Student(info2[2], info2[1], info2[0], info2[3], info2[4]);
                    filterStudents.Add(tmpStud);
                }

            }


            if (filterStudents.Count() == 0)
            {
                labelHint.Text = "*Plichtfelder, keine Resultate";
                btnFilter.Enabled = false;
            }

            else
                labelHint.Text = "*Plichtfelder"; btnFilter.Enabled = true;

            // update txtbox with email information
            String mailString = "";

            foreach (var studi in filterStudents)
            {                
                mailString = String.Concat(mailString, studi.Mail, ',');
            }
            txtBoxStudents.Clear();
            txtBoxStudents.Text = txtBoxStudents.Text.Insert(0, mailString);
            
        }

        private void comboBoxBeleg_SelectedIndexChanged(object sender, EventArgs e)
        {           

            // refresh 'themen' information
            updateThemenData();
        }

        private void comboBoxBelegthema_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thema tmpTema = (Thema)comboBoxBelegthema.SelectedItem;
            selThema = tmpTema;

            // enable Group ComboBox
            updateGroupData();

            // enable Rollen ComboBox
            updateRollenData();

            // enable filter btn
            updateFilterBtn();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            String mailString = "";
 
            foreach(var studi in filterStudents) {
                
                mailString = String.Concat(mailString,studi.Mail,',');
            }
          
            Process.Start("mailto: " + mailString + "?subject="+selBeleg.BelegKennung);
        }

        private void comboBoxRolle_SelectedIndexChanged(object sender, EventArgs e)
        {
            selRolle = (Rolle)comboBoxRolle.SelectedItem;

            // enable filter btn
            updateFilterBtn();
        }

        private void comboBoxGruppe_SelectedIndexChanged(object sender, EventArgs e)
        {
            selGruppe = (Gruppe)comboBoxGruppe.SelectedItem;

            updateFilterBtn();
        }


    }
}
