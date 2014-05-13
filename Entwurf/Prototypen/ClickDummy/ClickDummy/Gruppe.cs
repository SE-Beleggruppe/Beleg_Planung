using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickDummy
{
    public class Gruppe
    {
        public string gruppenKennung { get; set; }
        public Student leiter { get; set; }
        public List<Student> studenten { get; set; }
        public Thema thema { get; set; }
        public string gruppenPasswort { get; set; }

        public Gruppe() {
            this.gruppenKennung = "ICH BIN EINE NEUE GRUPPE";
        }

        public Gruppe(string gruppenKennung, Student leiter, List<Student> mitglieder, Thema thema, string passwort)
        {
            this.gruppenKennung = gruppenKennung;
            this.leiter = leiter;
            this.studenten = mitglieder;
            this.thema = thema;
            this.gruppenPasswort = passwort;
        }

        public void addMitglied(Student neu)
        {
            if (this.studenten == null) this.studenten = new List<Student>();
            this.studenten.Add(neu);
        }
    }
}
